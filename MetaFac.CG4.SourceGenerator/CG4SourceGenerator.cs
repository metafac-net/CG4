using MetaFac.CG4.Generators;
using MetaFac.CG4.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace MetaFac.CG4.SourceGenerator
{
    [Generator]
    public class CG4SourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not CG4SyntaxReceiver syntaxReceiver) return;

            var jsonFiles = context.AdditionalFiles.Where(at => at.Path.EndsWith(".json")).ToArray();

            var commands = syntaxReceiver.ModelsToGenerate;
            while (ImmutableInterlocked.TryDequeue(ref commands, out var command))
            {
                string hintName = $"{command.TargetNamespace}.{command.GeneratorId}.g.cs";
                var builder = new StringBuilder();
                try
                {
                    if (command is GenerateCommand generateCmd)
                    {
                        AdditionalText jsonModelFile = jsonFiles.FirstOrDefault() ?? throw new FileNotFoundException("No JSON model file supplied");
                        SourceText? jsonSourceText = jsonModelFile.GetText();
                        string jsonModel = jsonSourceText is not null ? jsonSourceText.ToString() : throw new FileNotFoundException("File is empty", jsonModelFile.Path);

                        var generator = GeneratorHelper.CreateBasicGenerator(command.GeneratorId);
                        string generatorVersion = FileVersionInfo.GetVersionInfo(generator.GetType().Assembly.Location).FileVersion ?? "unknown";
                        var metadata = ModelContainer.FromJson(jsonModel);
                        metadata = metadata
                            .SetToken("Namespace", generateCmd.TargetNamespace)
                            .SetToken("Generator", $"{generator.ShortName}.{generatorVersion}")
                            ;

                        // validate metadata and emit diagnostics
                        var validationResult = new ModelValidator().Validate(metadata);
                        foreach (var ve in validationResult.Errors)
                        {
                            // todo convert validation error codes to strings
                            context.ReportDiagnostic(
                                Diagnostic.Create(
                                    new DiagnosticDescriptor("CG4MV999", "DiagnosticTitle",
                                    $"{ve.ErrorCode}: {ve.Message}",
                                    "DiagnosticCategory",
                                    DiagnosticSeverity.Error, true),
                                null)); // todo? location
                        }
                        foreach (var ve in validationResult.Warnings)
                        {
                            context.ReportDiagnostic(
                                Diagnostic.Create(
                                    new DiagnosticDescriptor("CG4MV998", "DiagnosticTitle",
                                    $"{ve.ErrorCode}: {ve.Message}",
                                    "DiagnosticCategory",
                                    DiagnosticSeverity.Warning, true),
                                null)); // todo? location
                        }

                        // generate source
                        var source = generator.Generate(metadata);
                        foreach (var line in source)
                        {
                            builder.AppendLine(line);
                        }
                    }
                    else if (command is SyntaxVisitError syntaxError)
                    {
                        // report diagnostic
                        context.ReportDiagnostic(
                            Diagnostic.Create(
                                new DiagnosticDescriptor("CG4SG001", "DiagnosticTitle", 
                                syntaxError.Message, 
                                "DiagnosticCategory", 
                                DiagnosticSeverity.Error, true), 
                            syntaxError.Location));
                    }
                    else
                    {
                        throw new NotSupportedException($"Unsupported command: {command.GetType().Name}");
                    }
                }
                catch (Exception ex)
                {
                    // report diagnostic
                    context.ReportDiagnostic(
                        Diagnostic.Create(
                            new DiagnosticDescriptor("CG4SG999", "DiagnosticTitle",
                            ex.Message,
                            "DiagnosticCategory",
                            DiagnosticSeverity.Error, true),
                        null));
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