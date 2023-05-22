﻿using MetaFac.CG4.Attributes;
using MetaFac.CG4.Generators;
using MetaFac.CG4.ModelReader;
using MetaFac.CG4.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace MetaFac.CG4.SourceGenerator
{
    public class CG4SourceGenerator : ISourceGenerator
    {
        private static ModelContainer ReadMetadataFromJsonFile(string jsonFilename)
        {
            if (!File.Exists(jsonFilename)) throw new FileNotFoundException($"Metadata file (JSON) not found", jsonFilename);
            using StreamReader mr = new StreamReader(jsonFilename);
            return ModelContainer.FromJson(mr.ReadToEnd());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not CG4SyntaxReceiver syntaxReceiver) return;

            var jsonFiles = context.AdditionalFiles.Where(at => at.Path.EndsWith(".json")).ToArray();

            var commands = syntaxReceiver.ModelsToGenerate;
            while (ImmutableInterlocked.TryDequeue(ref commands, out var command))
            {
                string hintName = $"{command.TargetNamespace}.{command.GeneratorId}.g.cs";
                var builder = new StringBuilder();
                string stepName = "";
                try
                {
                    if (command is GenerateCommand generateCmd)
                    {
                        stepName = "GetGenerator";
                        var generator = GeneratorHelper.CreateBasicGenerator(command.GeneratorId);
                        string generatorVersion = FileVersionInfo.GetVersionInfo(generator.GetType().Assembly.Location).FileVersion ?? "unknown";
                        stepName = "ReadMetadata";
                        var metadata = ReadMetadataFromJsonFile(generateCmd.JsonMetadataFilename);
                        metadata = metadata
                            .SetToken("Namespace", generateCmd.TargetNamespace)
                            .SetToken("GeneratorId", $"{nameof(BasicGeneratorId)}.{command.GeneratorId}")
                            .SetToken("GeneratorVersion", $"(version {generatorVersion})");
                        stepName = "CheckMetadata";
                        // validate metadata
                        var validationResult = new ModelValidator().Validate(metadata);
                        if (validationResult.HasErrors)
                        {
                            builder.AppendLine("// <auto-generated>");
                            builder.AppendLine("// Schema validation errors:");
                            foreach (var ve in validationResult.Errors)
                            {
                                builder.AppendLine($"// {ve.ErrorCode}: {ve.Message}");
                            }
                            builder.AppendLine("// </auto-generated>");
                        }
                        else
                        {
                            stepName = "GenerateCode";
                            var source = generator.Generate(metadata);
                            foreach (var line in source)
                            {
                                builder.AppendLine(line);
                            }
                        }
                    }
                    else
                    {
                        throw new NotSupportedException($"Unsupported command: {command.GetType().Name}");
                    }
                }
                catch (Exception ex)
                {
                    builder.AppendLine("// <auto-generated>");
                    builder.AppendLine("// An unexpected error occurred during generation:");
                    builder.AppendLine($"// After: {stepName}");
                    builder.AppendLine($"// Error: {ex.GetType().Name}: {ex.Message}");
                    builder.AppendLine("// </auto-generated>");
                }
                context.AddSource(hintName, builder.ToString());
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new CG4SyntaxReceiver());
        }
    }
}