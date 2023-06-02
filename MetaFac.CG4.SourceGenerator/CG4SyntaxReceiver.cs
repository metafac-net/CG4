using MetaFac.CG4.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace MetaFac.CG4.SourceGenerator
{
    internal static class SyntaxHelpers
    {
        public static bool IsIdentifierForAttributeName(this IdentifierNameSyntax ins, string attributeName)
        {
            var prefix = ins.Identifier.Text.AsSpan();
            var suffix = nameof(Attribute).AsSpan();
            var candidate = attributeName.AsSpan();
            return candidate.Length == (prefix.Length + suffix.Length)
                && candidate.StartsWith(prefix)
                && candidate.EndsWith(suffix);
        }
    }

    internal abstract class BaseCommand
    {
        public readonly GeneratorId GeneratorId;
        public readonly string TargetNamespace;

        protected BaseCommand(GeneratorId generatorId, string targetNamespace)
        {
            GeneratorId = generatorId;
            TargetNamespace = targetNamespace;
        }
    }
    internal sealed class GenerateCommand : BaseCommand
    {
        public readonly string JsonMetadataFilename;
        public GenerateCommand(GeneratorId generatorId, string targetNamespace, string jsonMetadataFilename)
            : base(generatorId, targetNamespace)
        {
            JsonMetadataFilename = jsonMetadataFilename;
        }
    }
    internal sealed class SyntaxVisitError : BaseCommand
    {
        public readonly Location Location;
        public readonly string Message;
        public SyntaxVisitError(GeneratorId generatorId, string targetNamespace, Location location, string message)
            : base(generatorId, targetNamespace)
        {
            Location = location;
            Message = message;
        }
    }

    internal static class SyntaxReceiverHelpers
    {
        public static bool HasOneAttributeNamed(this ClassDeclarationSyntax cds, string attributeName)
        {
            var allAttributes = cds.AttributeLists.SelectMany(al => al.Attributes).ToArray();
            if (allAttributes.Length != 1) return false;

            return allAttributes[0].Name is IdentifierNameSyntax ins && ins.IsIdentifierForAttributeName(attributeName);
        }
    }

    internal class CG4SyntaxReceiver : ISyntaxContextReceiver
    {
        private ImmutableQueue<BaseCommand> _modelsToGenerate = ImmutableQueue<BaseCommand>.Empty;
        public ImmutableQueue<BaseCommand> ModelsToGenerate => _modelsToGenerate;

        private static T GetValue<T>(object? input, T defaultValue) => input is T value ? value : defaultValue;
        private static T GetValue<T>(object? input) => input is T value ? value : throw new ArgumentNullException(nameof(input));

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (context.Node is not ClassDeclarationSyntax cds) return;
            if (cds.AttributeLists.Count == 0) return;
            if (cds.Parent is not NamespaceDeclarationSyntax nds) return;

            if (cds.Modifiers.Any(SyntaxKind.PartialKeyword)
                && cds.Modifiers.Any(SyntaxKind.InternalKeyword)
                && cds.Modifiers.Any(SyntaxKind.StaticKeyword)
                && cds.HasOneAttributeNamed("CG4GenerateAttribute"))
            {
                Location location = Location.Create(cds.SyntaxTree, cds.Span);
                string targetNamespace = nds.Name.ToString();
                GeneratorId generatorId = GeneratorId.None;
                try
                {
                    if (context.SemanticModel.GetDeclaredSymbol(cds) is INamedTypeSymbol classSymbol)
                    {
                        var attributes = classSymbol.GetAttributes();
                        var attribute = attributes[0];

                        var attributeArguments = attribute.ConstructorArguments;
                        if (attributeArguments.Length == 2)
                        {
                            generatorId = (GeneratorId)GetValue<int>(attributeArguments[0].Value);
                            string jsonMetadaFilename = GetValue<string>(attributeArguments[1].Value);
                            ImmutableInterlocked.Enqueue(ref _modelsToGenerate, new GenerateCommand(generatorId, targetNamespace, jsonMetadaFilename));
                        }
                        else
                        {
                            ImmutableInterlocked.Enqueue(ref _modelsToGenerate, 
                                new SyntaxVisitError(generatorId, targetNamespace, location,
                                $"Expected CG4Generate attribute to have 2 arguments, but it has {attributeArguments.Length}"));
                        }
                    }
                    else
                    {
                        ImmutableInterlocked.Enqueue(ref _modelsToGenerate, 
                            new SyntaxVisitError(generatorId, targetNamespace, location,
                            $"Cannot get class symbol from semantic model for: {cds.Identifier}"));
                    }
                }
                catch (Exception ex)
                {
                    ImmutableInterlocked.Enqueue(ref _modelsToGenerate, 
                        new SyntaxVisitError(generatorId, targetNamespace, location,
                        $"Exception: {ex.GetType().Name}: {ex.Message}"));
                }
            }
        }
    }
}