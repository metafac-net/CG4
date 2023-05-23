using MetaFac.CG4.Attributes;
using MetaFac.CG4.ModelReader;
using MetaFac.CG4.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MetaFac.CG4.Generators
{
    public static class GeneratorHelper
    {
        public static BasicGeneratorId GetGeneratorId(string generatorId)
        {
            if (generatorId is null) throw new ArgumentNullException(nameof(generatorId));
            string prefix = $"{nameof(BasicGeneratorId)}.";
            if (generatorId.StartsWith(prefix))
            {
                string suffix = generatorId.Substring(prefix.Length);
                if (Enum.TryParse<BasicGeneratorId>(suffix, out var parsedGeneratorId))
                {
                    return parsedGeneratorId;
                }
            }
            throw new ArgumentOutOfRangeException(nameof(generatorId), generatorId, null);
        }

        public static GeneratorBase CreateBasicGenerator(BasicGeneratorId generatorId)
        {
            switch (generatorId)
            {
                case BasicGeneratorId.Contracts:
                    return new MetaFac.CG4.Generator.Contracts.Generator();
                case BasicGeneratorId.MessagePack:
                    return new MetaFac.CG4.Generator.MessagePack.Generator();
                default:
                    throw new ArgumentOutOfRangeException(nameof(generatorId), generatorId, null);
            }
        }

        public static GeneratorBase GetGeneratorByName(string name, GeneratorBase[] generators)
        {
            if (generators is null || generators.Length == 0)
                throw new ArgumentException($"No generators specified.", nameof(generators));
            var candidates = generators.Where(g => g.GetType().Name.Contains(name)).ToArray();
            if (candidates.Length == 0)
                throw new ArgumentException($"Name does not match any of the generators", nameof(name));
            if (candidates.Length > 1)
                throw new ArgumentException($"Name matches multiple generators", nameof(name));
            GeneratorBase generator = candidates[0];
            return generator;
        }

        private static void WriteLines(IEnumerable<string> content, string filename)
        {
            using var sw = new StreamWriter(filename);
            foreach (var line in content)
            {
                sw.WriteLine(line);
            }
        }

        /// <summary>
        /// Generates metadata from attributed code in an assembly.
        /// </summary>
        /// <param name="logger">The event logger.</param>
        /// <param name="modelAnchorType">An anchor type in the assembly used to find all other model types.</param>
        public static ModelContainer GenerateMetadata(
            ILogger logger,
            Type modelAnchorType)
        {
            string fileVersion = FileVersionInfo.GetVersionInfo(typeof(GeneratorHelper).Assembly.Location).FileVersion ?? "unknown";
            using var scope1 = logger.BeginScope(nameof(GeneratorHelper));

            Assembly modelAssembly = modelAnchorType.Assembly;
            string modelNamespace = modelAnchorType.Namespace ?? "Unknown_Namespace";
            logger.LogInformation("Generator version: {version}", fileVersion);
            logger.LogInformation("Model source     : {modelAssembly} ({modelNamespace})", modelAssembly.GetName().Name, modelNamespace);
            var metadata = ModelParser.ParseAssembly(modelAssembly, modelNamespace);
            string metadataSource = Path.GetFileName(modelAssembly.Location);
            string metadataVersion = $"(version {FileVersionInfo.GetVersionInfo(modelAssembly.Location).FileVersion})";

            // validate metadata
            var validationResult = new ModelValidator().Validate(metadata, ValidationErrorHandling.ThrowOnFirst);
            if (validationResult.HasWarnings)
            {
                using (var scope2 = logger.BeginScope("Metadata warnings"))
                {
                    foreach (var ve in validationResult.Warnings)
                    {
                        logger.LogWarning("{errorCode} {errorMessage}", ve.ErrorCode, ve.Message);
                    }
                }
            }
            return metadata;
        }

        /// <summary>
        /// A helper method to generate source file.
        /// </summary>
        /// <param name="logger">The event logger.</param>
        /// <param name="metadata">The model(s).</param>
        /// <param name="outputNamespace">The output namespace for the generated source files.</param>
        /// <param name="usersOptions">The optional users' options.</param>
        /// <param name="generators">The generators to be run in the order given.</param>
        public static IEnumerable<string> GenerateSource(
            ILogger logger,
            ModelContainer metadata,
            string outputNamespace,
            GeneratorOptions? usersOptions,
            GeneratorBase generator)
        {
            if (string.IsNullOrWhiteSpace(outputNamespace))
            {
                throw new ArgumentException($"'{nameof(outputNamespace)}' cannot be null or whitespace.", nameof(outputNamespace));
            }

            var options = new GeneratorOptions(usersOptions);
            string fileVersion = FileVersionInfo.GetVersionInfo(typeof(GeneratorHelper).Assembly.Location).FileVersion ?? "unknown";
            using var scope1 = logger.BeginScope(nameof(GeneratorHelper));

            logger.LogInformation("Generator version: {version}", fileVersion);
            logger.LogInformation("Model source     : Metadata");

            // validate metadata
            var validationResult = new ModelValidator().Validate(metadata, ValidationErrorHandling.ThrowOnFirst);
            if (validationResult.HasWarnings)
            {
                using (var scope2 = logger.BeginScope("Metadata warnings"))
                {
                    foreach (var ve in validationResult.Warnings)
                    {
                        logger.LogWarning("{errorCode} {errorMessage}", ve.ErrorCode, ve.Message);
                    }
                }
            }

            string generatorVersion = FileVersionInfo.GetVersionInfo(generator.GetType().Assembly.Location).FileVersion ?? "unknown";

            metadata = metadata
                .SetToken("Namespace", outputNamespace)
                .SetToken("GeneratorId", generator.GetType().FullName ?? "Unknown_Generator")
                .SetToken("GeneratorVersion", $"(version {generatorVersion})");
            if (options.CopyrightInfo is not null)
            {
                metadata = metadata.SetToken("CopyrightInfo", options.CopyrightInfo);
            }
            var source = generator.Generate(metadata).ToList();
            return source;
        }

    }
}