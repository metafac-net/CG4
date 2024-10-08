﻿using MetaFac.CG4.Generators;
using MetaFac.CG4.ModelReader;
using MetaFac.CG4.Models;
using MetaFac.TinyCLI;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
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

        public Commands() : base("MFCG4", "MetaFac Code Generator 4 (CG4)")
        {
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

            AddCommand("a2c", "Generates source code using the named generator and supplied metadata.",
                new Arg<string>("am", "assm-metadata", "The metadata file (DLL) to process.", s => s),
                new Arg<string>("an", "assm-namespace", "The namespace within the assembly to search.", s => s),
                new Arg<string>("g", "generator", $"The id of the generator: {string.Join(", ", GetGeneratorIds())}", s => s),
                new Arg<string>("o", "output-filename", "The implementation file to create.", s => s),
                new Arg<string>("on", "output-namespace", "The target namespace for the output.", s => s),
                new Arg<bool>("ie", "ignore-errors", "Ignore metadata validation errors.", bool.Parse, false),
                a2cHandler);

            AddCommand("a2j", "Generates metadata (JSON) from an assembly.",
                new Arg<string>("am", "assm-metadata", "The metadata file (DLL) to process.", s => s),
                new Arg<string>("an", "assm-namespace", "The namespace within the assembly to search.", s => s, ""),
                new Arg<string>("oj", "output-json", "The metadata (JSON) filename to write.", s => s),
                a2jHandler);

            AddCommand("j2c", "Generates source code from JSON metadata.",
                new Arg<string>("jm", "json-metadata", "The metadata file (JSON) to process.", s => s),
                new Arg<string>("g", "generator", $"The id of the generator: {string.Join(", ", GetGeneratorIds())}", s => s),
                new Arg<string>("o", "output-filename", "The implementation file to create.", s => s),
                new Arg<string>("on", "output-namespace", "The target namespace for the output.", s => s),
                new Arg<bool>("ie", "ignore-errors", "Ignore metadata validation errors.", bool.Parse, false),
                j2cHandler);

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

        internal async ValueTask<int> a2jHandler(
            string assmFilename,
            string assmNamespace,
            string outputFilename)
        {
            if (string.IsNullOrEmpty(assmFilename)) throw new ArgumentException($"assm-metadata not specified.");
            if (string.IsNullOrEmpty(assmNamespace)) throw new ArgumentException($"assm-namespace not specified.");
            if (string.IsNullOrEmpty(outputFilename)) throw new ArgumentException($"output-json not specified.");

            if (!File.Exists(assmFilename)) throw new FileNotFoundException($"Metadata file (DLL) not found", assmFilename);

            var sourceAssembly = Assembly.LoadFrom(assmFilename);
            ModelContainer metadata = ModelParser.ParseAssembly(sourceAssembly, assmNamespace);

            Logger.LogInformation($"  Source: {assmFilename}");
            Logger.LogInformation($"  Output: {outputFilename}");

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

            // generate!
            Logger.LogInformation($"  Generating...");

            using var jsw = new StreamWriter(outputFilename);
            jsw.WriteLine(metadata.ToJson(true));

            Logger.LogInformation($"  Complete.");

            await Task.Delay(0);
            return 0;
        }

        private static ModelContainer ReadMetadataFromJsonFile(string jsonFilename)
        {
            if (!File.Exists(jsonFilename)) throw new FileNotFoundException($"Metadata file (JSON) not found", jsonFilename);
            using StreamReader mr = new StreamReader(jsonFilename);
            return ModelContainer.FromJson(mr.ReadToEnd());
        }

        private bool CheckMetadata(ModelContainer metadata, bool ignoreValidationErrors)
        {
            var validationResult = new ModelValidator().Validate(metadata, ValidationErrorHandling.Default);
            if (validationResult.HasErrors)
            {
                Logger.LogError($"  Metadata errors:");
                foreach (var ve in validationResult.Errors)
                {
                    Logger.LogError($"    {ve.ErrorCode}: {ve.Message}");
                }
            }
            if (validationResult.HasWarnings)
            {
                Logger.LogWarning($"  Metadata warnings:");
                foreach (var ve in validationResult.Warnings)
                {
                    Logger.LogWarning($"    {ve.ErrorCode}: {ve.Message}");
                }
            }
            return ignoreValidationErrors ? true : !validationResult.HasErrors;
        }

        internal async ValueTask<int> j2cHandler(
            string jsonFilename,
            string generatorName,
            string outputFilename,
            string outputNamespace,
            bool ignoreErrors)
        {
            if (string.IsNullOrEmpty(jsonFilename)) throw new ArgumentException($"json-metadata not specified.");

            ModelContainer metadata = ReadMetadataFromJsonFile(jsonFilename)
                .SetToken("Namespace", outputNamespace);

            var generator = generatorName.ParseGeneratorId().GetGenerator();

            Logger.LogInformation($"  Source: {jsonFilename}");
            Logger.LogInformation($"  Output: {outputFilename}");

            // validate metadata before generation
            if (!CheckMetadata(metadata, ignoreErrors)) { return 1; }

            // generate!
            Logger.LogInformation($"  Generating...");
            var outputText = generator.Generate(metadata);
            using var csw = new StreamWriter(outputFilename);
            foreach (var line in outputText)
            {
                csw.WriteLine(line);
            }

            Logger.LogInformation($"  Complete.");

            await Task.Delay(0);
            return 0;
        }

        internal async ValueTask<int> a2cHandler(
            string assmFilename,
            string assmNamespace,
            string generatorName,
            string outputCodeFilename,
            string outputNamespace,
            bool ignoreErrors)
        {
            if (string.IsNullOrEmpty(assmFilename)) throw new ArgumentException($"assm-metadata not specified.");
            if (string.IsNullOrEmpty(assmNamespace)) throw new ArgumentException($"assm-namespace not specified.");
            if (!File.Exists(assmFilename)) throw new FileNotFoundException($"Metadata file (DLL) not found", assmFilename);

            var sourceAssembly = Assembly.LoadFrom(assmFilename);
            ModelContainer metadata = ModelParser.ParseAssembly(sourceAssembly, assmNamespace)
                .SetToken("Namespace", outputNamespace);

            string sourceNamespace = assmNamespace;

            var generator = generatorName.ParseGeneratorId().GetGenerator();

            Logger.LogInformation($"  Source: {assmFilename} ({sourceNamespace ?? "*"})");
            Logger.LogInformation($"  Output: {outputCodeFilename}");

            // validate metadata before generation
            if (!CheckMetadata(metadata, ignoreErrors)) { return 1; }


            // generate!
            Logger.LogInformation($"  Generating...");
            var outputText = generator.Generate(metadata);
            using var csw = new StreamWriter(outputCodeFilename);
            foreach (var line in outputText)
            {
                csw.WriteLine(line);
            }

            Logger.LogInformation($"  Complete.");

            await Task.Delay(0);
            return 0;
        }
    }
}