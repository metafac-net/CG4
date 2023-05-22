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
        public readonly BasicGeneratorId GeneratorId;
        public readonly string TargetNamespace;

        protected BaseCommand(BasicGeneratorId generatorId, string targetNamespace)
        {
            GeneratorId = generatorId;
            TargetNamespace = targetNamespace;
        }
    }
    internal sealed class GenerateCommand : BaseCommand
    {
        public readonly string JsonMetadataFilename;
        public GenerateCommand(string jsonMetadataFilename, BasicGeneratorId generatorId, string targetNamespace)
            : base(generatorId, targetNamespace)
        {
            JsonMetadataFilename= jsonMetadataFilename;
        }
    }

    internal static class SyntaxReceiverHelpers
    {
        public static bool HasAttributeNamed(this ClassDeclarationSyntax cds, string attributeName)
        {
            foreach (AttributeSyntax attributeSyntax in cds.AttributeLists.SelectMany(al => al.Attributes))
            {
                if (attributeSyntax.Name is IdentifierNameSyntax ins
                    && ins.IsIdentifierForAttributeName(nameof(CG4GenerateAttribute)))
                {
                    return true;
                }
            }
            return false;
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
                && cds.HasAttributeNamed(nameof(CG4GenerateAttribute)))
            {
                if (context.SemanticModel.GetDeclaredSymbol(cds) is INamedTypeSymbol classSymbol)
                {
                    var attributes = classSymbol.GetAttributes();
                    var attribute = attributes[0];

                    BasicGeneratorId generatorId = (BasicGeneratorId)GetValue<int>(attribute.ConstructorArguments[0].Value, 0);
                    string jsonMetadaFilename = GetValue<string?>(attribute.ConstructorArguments[1].Value, null) ?? "MetaFac.CG4.Schema.json";
                    string targetNamespace = nds.Name.ToString();
                    ImmutableInterlocked.Enqueue(ref _modelsToGenerate, new GenerateCommand(jsonMetadaFilename, generatorId, targetNamespace));
                }
            }
        }
    }
}