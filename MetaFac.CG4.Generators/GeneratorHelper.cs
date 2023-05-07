using MetaFac.CG4.ModelReader;
using MetaFac.CG4.Models;
using MetaFac.Platform;
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
        /// A helper method to aid generating multiple outputs from a single model source.
        /// </summary>
        /// <param name="logger">The event logger.</param>
        /// <param name="modelAnchorType">An anchor type in the model used to find all other model types.</param>
        /// <param name="outputNamespace">The output namespace for the generated source files.</param>
        /// <param name="filenamePrefix">The filename prefix for the generated source files.</param>
        /// <param name="copyrightInfo">The users' copyright information to be included in the generated source files.</param>
        /// <param name="usersOptions">The optional users' options.</param>
        /// <param name="generators">The generators to be run in the order given.</param>
        public static void GenerateOutputs(
            ILogger logger,
            ITimeOfDayClock clock,
            Type modelAnchorType,
            string outputNamespace,
            string filenamePrefix,
            string copyrightInfo,
            GeneratorOptions? usersOptions,
            params GeneratorBase[] generators)
        {
            var options = new GeneratorOptions(usersOptions);
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

            var outerScope = metadata.GetScopeFromMetadata()
                .SetToken("Namespace", outputNamespace)
                .SetToken("CopyrightInfo", copyrightInfo)
                .SetToken("MetadataSource", metadataSource)
                .SetToken("MetadataVersion", metadataVersion);
            foreach (var generator in generators)
            {
                string outputFilename = $"{filenamePrefix}.{generator.ShortName}.g.cs";
                logger.LogInformation("Output filename  : {filename}", outputFilename);
                string generatorVersion = FileVersionInfo.GetVersionInfo(generator.GetType().Assembly.Location).FileVersion ?? "unknown";
                var innerScope = outerScope
                    .SetToken("GeneratorId", generator.GetType().FullName ?? "Unknown_Generator")
                    .SetToken("GeneratorVersion", $"(version {generatorVersion})");
                var output = generator.Generate(logger, clock, innerScope, options).ToList();
                WriteLines(output, outputFilename);
            }
        }

        /// <summary>
        /// A helper method to aid generating multiple outputs from a single model source.
        /// </summary>
        /// <param name="logger">The event logger.</param>
        /// <param name="modelAnchorType">An anchor type in the model used to find all other model types.</param>
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
        /// A helper method to generate a single source file.
        /// </summary>
        /// <param name="logger">The event logger.</param>
        /// <param name="metadata">The model(s).</param>
        /// <param name="outputNamespace">The output namespace for the generated source files.</param>
        /// <param name="usersOptions">The optional users' options.</param>
        /// <param name="generators">The generators to be run in the order given.</param>
        public static IEnumerable<string> GenerateSource(
            ILogger logger,
            ITimeOfDayClock clock,
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

            var outerScope = metadata.GetScopeFromMetadata()
                .SetToken("Namespace", outputNamespace)
                //.SetToken("MetadataSource", metadataSource)
                //.SetToken("MetadataVersion", metadataVersion)
                ;
            if (options.CopyrightInfo is not null)
            {
                outerScope = outerScope.SetToken("CopyrightInfo", options.CopyrightInfo);
            }
            string generatorVersion = FileVersionInfo.GetVersionInfo(generator.GetType().Assembly.Location).FileVersion ?? "unknown";
            var innerScope = outerScope
                .SetToken("GeneratorId", generator.GetType().FullName ?? "Unknown_Generator")
                .SetToken("GeneratorVersion", $"(version {generatorVersion})");
            var source = generator.Generate(logger, clock, innerScope, options).ToList();
            return source;
        }

        /// <summary>
        /// A helper method to aid generating multiple outputs from a single model.
        /// </summary>
        /// <param name="logger">The event logger.</param>
        /// <param name="modelAnchorType">An anchor type in the model used to find all other model types.</param>
        /// <param name="outputNamespace">The output namespace for the generated source files.</param>
        /// <param name="filenamePrefix">The filename prefix for the generated source files.</param>
        /// <param name="usersOptions">The optional users' options.</param>
        /// <param name="generators">The generators to be run in the order given.</param>
        public static void GenerateSourceFiles(
            ILogger logger,
            ITimeOfDayClock clock,
            ModelContainer metadata,
            string outputNamespace,
            string outputFilenamePrefix,
            GeneratorOptions? usersOptions,
            params GeneratorBase[] generators)
        {
            if (string.IsNullOrWhiteSpace(outputNamespace))
            {
                throw new ArgumentException($"'{nameof(outputNamespace)}' cannot be null or whitespace.", nameof(outputNamespace));
            }

            if (string.IsNullOrWhiteSpace(outputFilenamePrefix))
            {
                throw new ArgumentException($"'{nameof(outputFilenamePrefix)}' cannot be null or whitespace.", nameof(outputFilenamePrefix));
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

            var outerScope = metadata.GetScopeFromMetadata()
                .SetToken("Namespace", outputNamespace)
                //.SetToken("MetadataSource", metadataSource)
                //.SetToken("MetadataVersion", metadataVersion)
                ;
            if (options.CopyrightInfo is not null)
            {
                outerScope = outerScope.SetToken("CopyrightInfo", options.CopyrightInfo);
            }
            foreach (var generator in generators)
            {
                string outputFilename = $"{outputFilenamePrefix}.{generator.ShortName}.g.cs";
                logger.LogInformation("Output filename  : {filename}", outputFilename);
                string generatorVersion = FileVersionInfo.GetVersionInfo(generator.GetType().Assembly.Location).FileVersion ?? "unknown";
                var innerScope = outerScope
                    .SetToken("GeneratorId", generator.GetType().FullName ?? "Unknown_Generator")
                    .SetToken("GeneratorVersion", $"(version {generatorVersion})");
                var source = generator.Generate(logger, clock, innerScope, options).ToList();
                WriteLines(source, outputFilename);
            }
            if (options.EmitModelAsJson)
            {
                string outputFilename = $"{outputFilenamePrefix}.models.json";
                var output = metadata.ToJson(true);
                using var sw = new StreamWriter(outputFilename);
                sw.WriteLine(output);
            }
        }
    }
}