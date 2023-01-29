using MetaFac.Platform;
using MetaCode.Generators;
using Microsoft.Extensions.Logging;
using MiniCLI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MetaFac.CG3.ModelReader;

namespace MetaCode.TS3.CLI
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
                GeneratorId.Interfaces => new Generator.Interfaces.Generator(),
                GeneratorId.Freezables => new Generator.Freezables.Generator(),
                GeneratorId.Immutables => new Generator.Immutables.Generator(),
                GeneratorId.JsonPoco => new Generator.JsonPoco.Generator(),
                GeneratorId.MsgPack => new Generator.MsgPack.Generator(),
                GeneratorId.ProtobufNet3 => new Generator.ProtobufNet3.Generator(),
                GeneratorId.Records => new Generator.Records.Generator(),
                GeneratorId.Contracts => new Generator.Contracts.Generator(),
                GeneratorId.RecordsV2 => new Generator.RecordsV2.Generator(),
                GeneratorId.MsgPackV2 => new Generator.MsgPackV2.Generator(),
                GeneratorId.MsgPackV3 => new Generator.MsgPackV3.Generator(),
                GeneratorId.ClassesV2 => new Generator.ClassesV2.Generator(),
                _ => throw new NotSupportedException($"GeneratorId: {generatorId}"),
            };
            return generator;
        }

        private readonly ILogger logger;
        private readonly ITimeOfDayClock clock;

        public Commands(ILogger logger, ITimeOfDayClock clock) : base("MCTS3", "MetaCode Template Suite 3 (TS3) Code Generator")
        {
            this.logger = logger;
            this.clock = clock;

            AddCommand("g2c", "Generates source code using the named generator and supplied metadata.",
                new Arg<string>("jm", "json-metadata", "The metadata file (JSON) to process.", s => s, ""),
                new Arg<string>("am", "assm-metadata", "The metadata file (DLL) to process.", s => s, ""),
                new Arg<string>("an", "assm-namespace", "The namespace within the assembly to search.", s => s, ""),
                new Arg<string>("g", "generator", $"The id of the generator: {string.Join(',', GetGeneratorIds())}", s => s),
                new Arg<string>("o", "output-filename", "The implementation file to create.", s => s),
                new Arg<string>("on", "output-namespace", "The target namespace for the output.", s => s),
                //new Arg<string>("xp", "secrets-path", "The path where secrets are stored.", s => s, "."),
                //new Arg<string>("s", "server", "The address (URL) of the metacode server.", s => s, Constants.ServerUrl.MetaCodeWebApiV1),
                //new Arg<string>("t", "token", "The MetaCode token for the account.", s => s, ""),
                g2cHandler);
        }

        internal async ValueTask<int> g2cHandler(
            string jsonFilename, string assmFilename, string assmNamespace,
            string generatorName, string outputFilename, string outputNamespace)
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

            // check proxy definitions
            // todo proxy definitions
            var proxyDefs = new List<ProxyDef>();
            //if (proxyDefinitions.HasValue())
            //{
            //    foreach (string value in proxyDefinitions.Values)
            //    {
            //        proxyDefs.Add(ParseProxyDef(value));
            //    }
            //}

            // good to go
            string fileVersion = ThisAssembly.AssemblyFileVersion;
            logger.LogInformation($"  Source: {metadataSource} ({sourceNamespace ?? "*"})");
            logger.LogInformation($"  Output: {outputFilename}");

            // validate metadata before generation
            var validationResult = new ModelValidator().Validate(metadata, ValidationErrorHandling.Default);
            if (validationResult.HasErrors)
            {
                logger.LogError($"  Metadata errors:");
                foreach (var ve in validationResult.Errors)
                {
                    logger.LogError($"    {ve.ErrorCode}: {ve.Message}");
                }
                return 1;
            }
            if (validationResult.HasWarnings)
            {
                logger.LogWarning($"  Metadata warnings:");
                foreach (var ve in validationResult.Warnings)
                {
                    logger.LogWarning($"    {ve.ErrorCode}: {ve.Message}");
                }
            }

            TemplateScope outerScope = metadata.GetScopeFromMetadata()
                .SetToken("Namespace", outputNamespace)
                .SetToken("GeneratorId", generator.ShortName)
                .SetToken("GeneratorVersion", $"(version {fileVersion})")
                .SetToken("MetadataSource", metadataSource)
                .SetToken("MetadataVersion", metadataVersion)
                ;
            if (proxyDefs.Count > 0)
            {
                logger.LogInformation($"  Proxy definitions:");
                foreach (var pd in proxyDefs)
                {
                    logger.LogInformation($"    {pd.ProxyTypeName}={pd.ExternalTypeName},{pd.ConcreteTypeName}");
                    outerScope = outerScope.SetProxyTypeTokens(pd);
                }
            }

            // generate!
            logger.LogInformation($"  Generating...");
            var outputText = generator.Generate(logger, clock, outerScope, null).ToArray();
            using var sw = new StreamWriter(outputFilename);
            foreach (var line in outputText)
            {
                sw.WriteLine(line);
            }

            logger.LogInformation($"  Complete.");

            await Task.Delay(0);
            return 0;
        }
    }
}