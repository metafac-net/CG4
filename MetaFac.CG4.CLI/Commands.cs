using MetaFac.CG4.Generators;
using MetaFac.CG4.ModelReader;
using MetaFac.CG4.Models;
using MetaFac.CG4.TextProcessing;
using MetaFac.Platform;
using MetaFac.TinyCLI;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MetaFac.CG4.CLI
{
    internal class Commands : CommandsBase
    {
        private static IEnumerable<string> GetGeneratorIds()
        {
            foreach (GeneratorId id in Enum.GetValues(typeof(GeneratorId)))
            {
                yield return id.ToString();
            }
        }

        private static GeneratorId ParseGeneratorId(string generatorName)
        {
            string trimmedName = generatorName?.Trim() ?? throw new ArgumentNullException(nameof(generatorName));
            foreach (GeneratorId generatorId in Enum.GetValues(typeof(GeneratorId)))
            {
                if (string.Equals(generatorId.ToString(), trimmedName, StringComparison.OrdinalIgnoreCase))
                    return generatorId;
            }
            throw new ArgumentOutOfRangeException(nameof(generatorName), generatorName, null);
        }

        private static GeneratorBase GetGenerator(GeneratorId generatorId)
        {
            GeneratorBase generator = generatorId switch
            {
                GeneratorId.Contracts => new MetaFac.CG4.Generator.Contracts.Generator(),
                GeneratorId.RecordsV2 => new MetaFac.CG4.Generator.RecordsV2.Generator(),
                GeneratorId.MessagePack => new MetaFac.CG4.Generator.MessagePack.Generator(),
                GeneratorId.ClassesV2 => new MetaFac.CG4.Generator.ClassesV2.Generator(),
                _ => throw new NotSupportedException($"GeneratorId: {generatorId}"),
            };
            return generator;
        }

        private readonly ITimeOfDayClock clock;

        public Commands(ITimeOfDayClock clock) : base("MFCG4", "MetaFac Code Generator 4 (CG4)")
        {
            this.clock = clock;

            AddCommand("t2g", "Converts a template to a code generator",
                new Arg<string>("tf", "template", "The template file to process", s => s),
                new Arg<string>("gf", "output", "The name of the generated file", s => s),
                new Arg<string>("gn", "namespace", "The namespace for the generated code", s => s),
                new Arg<string>("gs", "shortname", "The short name (or id) of the generator", s => s),
                ConvertTemplateToGenerator);

            AddCommand("g2t", "Converts a generator to template",
                new Arg<string>("gf", "source", "The generator source file", s => s),
                new Arg<string>("tf", "target", "The template file to produce", s => s),
                ConvertGeneratorToTemplate);

            AddCommand("g2c", "Generates source code using the named generator and supplied metadata.",
                new Arg<string>("jm", "json-metadata", "The metadata file (JSON) to process.", s => s, ""),
                new Arg<string>("am", "assm-metadata", "The metadata file (DLL) to process.", s => s, ""),
                new Arg<string>("an", "assm-namespace", "The namespace within the assembly to search.", s => s, ""),
                new Arg<string>("g", "generator", $"The id of the generator: {string.Join(", ", GetGeneratorIds())}", s => s),
                new Arg<string>("o", "output-filename", "The implementation file to create.", s => s),
                new Arg<string>("on", "output-namespace", "The target namespace for the output.", s => s),
                new Arg<string>("oj", "output-json", "The metadata file (JSON) to emit.", s => s, ""),
                g2cHandler);
        }

        private static IEnumerable<string> ReadLines(string filename)
        {
            using var sr = new StreamReader(filename);
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                yield return line;
            }
        }

        private static void WriteLinesToFile(IEnumerable<string?>? content, string filename)
        {
            if (content is null) return;
            using var sw = new StreamWriter(filename);
            foreach (var line in content)
            {
                sw.WriteLine(line);
            }
        }

        internal async ValueTask<int> ConvertTemplateToGenerator(
            string templateFilename,
            string generatorFilename,
            string generatorNamespace,
            string generatorShortname)
        {
            // get relative paths
            string currentPath = Directory.GetCurrentDirectory();
            string templateRelPath = Path.GetRelativePath(currentPath, templateFilename);
            string generatorRelPath = Path.GetRelativePath(currentPath, generatorFilename);

            Logger.LogInformation("  Current path: {value}", currentPath);
            Logger.LogInformation(" Template file: {value}", templateRelPath);
            Logger.LogInformation("Generator file: {value}", generatorRelPath);

            var sourceLines = ReadLines(templateRelPath);
            var outputLines = TextProcessor.ConvertTemplateToGenerator(
                sourceLines, generatorNamespace, generatorShortname);
            WriteLinesToFile(outputLines, generatorRelPath);
            await Task.Delay(0);
            return 0;
        }

        internal async ValueTask<int> ConvertGeneratorToTemplate(string generatorFilename, string templateFilename)
        {
            // get relative paths
            string currentPath = Directory.GetCurrentDirectory();
            string generatorRelPath = Path.GetRelativePath(currentPath, generatorFilename);
            string templateRelPath = Path.GetRelativePath(currentPath, templateFilename);

            Logger.LogInformation("  Current path: {value}", currentPath);
            Logger.LogInformation("Generator file: {value}", generatorRelPath);
            Logger.LogInformation(" Template file: {value}", templateRelPath);

            var sourceLines = ReadLines(generatorRelPath);
            var outputLines = TextProcessor.ConvertGeneratorToTemplate(sourceLines);
            WriteLinesToFile(outputLines, templateRelPath);
            await Task.Delay(0);
            return 0;
        }

        internal async ValueTask<int> g2cHandler(
            string jsonFilename, string assmFilename, string assmNamespace,
            string generatorName, string outputCodeFilename, string outputNamespace,
            string outputJsonFilename)
        {
            string metadataSource;
            string metadataVersion;
            string? sourceNamespace = null;
            ModelContainer metadata;
            if (!string.IsNullOrEmpty(jsonFilename))
            {
                if (!File.Exists(jsonFilename))
                    throw new FileNotFoundException($"Metadata file (JSON) not found", jsonFilename);
                using (StreamReader mr = new StreamReader(jsonFilename))
                {
                    metadata = ModelContainer.FromJson(mr.ReadToEnd());
                }
                metadataSource = Path.GetFileName(jsonFilename);
                metadataVersion = $"(updated {new FileInfo(jsonFilename).LastWriteTimeUtc:O})";
            }
            else if (!string.IsNullOrEmpty(assmFilename))
            {
                if (!File.Exists(assmFilename))
                    throw new FileNotFoundException($"Metadata file (DLL) not found", assmFilename);
                if (string.IsNullOrEmpty(assmNamespace))
                    throw new ArgumentException($"assembly-namespace not specified.");
                var assembly = Assembly.LoadFrom(assmFilename);
                metadata = ModelParser.ParseAssembly(assembly, assmNamespace);
                sourceNamespace = assmNamespace;
                metadataSource = Path.GetFileName(assmFilename);
                metadataVersion = $"(version {FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion})";
            }
            else
            {
                throw new ArgumentException($"metadata-filename not specified.");
            }

            var generator = GetGenerator(ParseGeneratorId(generatorName));

            string fileVersion = ThisAssembly.AssemblyFileVersion;
            Logger.LogInformation($"  Source: {metadataSource} ({sourceNamespace ?? "*"})");
            Logger.LogInformation($"  Output: {outputCodeFilename}");

            // validate metadata before generation
            var validationResult = new ModelValidator().Validate(metadata, ValidationErrorHandling.Default);
            if (validationResult.HasErrors)
            {
                Logger.LogError($"  Metadata errors:");
                foreach (var ve in validationResult.Errors)
                {
                    Logger.LogError($"    {ve.ErrorCode}: {ve.Message}");
                }
                return 1;
            }
            if (validationResult.HasWarnings)
            {
                Logger.LogWarning($"  Metadata warnings:");
                foreach (var ve in validationResult.Warnings)
                {
                    Logger.LogWarning($"    {ve.ErrorCode}: {ve.Message}");
                }
            }

            metadata = metadata
                .SetToken("Namespace", outputNamespace)
                .SetToken("GeneratorId", generator.ShortName)
                .SetToken("GeneratorVersion", $"(version {fileVersion})")
                .SetToken("MetadataSource", metadataSource)
                .SetToken("MetadataVersion", metadataVersion)
                ;

            // generate!
            Logger.LogInformation($"  Generating...");
            var outputText = generator.Generate(metadata);
            using var csw = new StreamWriter(outputCodeFilename);
            foreach (var line in outputText)
            {
                csw.WriteLine(line);
            }
            if (!string.IsNullOrEmpty(outputJsonFilename))
            {
                using var jsw = new StreamWriter(outputJsonFilename);
                jsw.WriteLine(metadata.ToJson(true));
            }

            Logger.LogInformation($"  Complete.");

            await Task.Delay(0);
            return 0;
        }
    }
}