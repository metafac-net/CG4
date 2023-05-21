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
        public readonly string GeneratorName;
        public readonly string TargetNamespace;

        protected BaseCommand(string generatorName, string targetNamespace)
        {
            GeneratorName = generatorName;
            TargetNamespace = targetNamespace;
        }
    }
    internal sealed class GenerateCommand : BaseCommand
    {
        public readonly Type SchemaAnchorType;
        public readonly string SchemaNamespace;
        public GenerateCommand(string generatorName, string targetNamespace, Type schemaAnchorType, string schemaNamespace)
            : base(generatorName, targetNamespace)
        {
            SchemaAnchorType = schemaAnchorType;
            SchemaNamespace = schemaNamespace;
        }
    }
    internal sealed class DebugCommand : BaseCommand
    {
        public readonly string Message;
        public DebugCommand(string generatorName, string targetNamespace, string message)
            : base(generatorName, targetNamespace)
        {
            Message = message;
        }
    }

    internal class CG4SyntaxReceiver : ISyntaxContextReceiver
    {
        private ImmutableQueue<BaseCommand> _modelsToGenerate = ImmutableQueue<BaseCommand>.Empty;
        public ImmutableQueue<BaseCommand> ModelsToGenerate => _modelsToGenerate;

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (context.Node is not ClassDeclarationSyntax cds) return;
            if (cds.AttributeLists.Count == 0) return;
            if (cds.Parent is not NamespaceDeclarationSyntax nds) return;
            if (nds.Name is not NameSyntax sns) return;

            if (cds.Modifiers.Any(SyntaxKind.PartialKeyword)
                && cds.Modifiers.Any(SyntaxKind.InternalKeyword)
                && cds.Modifiers.Any(SyntaxKind.StaticKeyword))
            {
                foreach (AttributeSyntax attributeSyntax in cds.AttributeLists.SelectMany(al => al.Attributes))
                {
                    if (attributeSyntax.Name is IdentifierNameSyntax ins && ins.IsIdentifierForAttributeName(nameof(CG4GenerateAttribute)))
                    {
                        string targetNamespace = sns.ToString();
                        // todo how to get the attribute object?
                        var symbol = context.SemanticModel.GetSymbolInfo(attributeSyntax.Name);

                        //CG4GenerateAttribute attr = todo;
                        //ImmutableInterlocked.Enqueue(ref _modelsToGenerate, 
                        //    new ModelGenerationInfo(attr.SchemaAnchorType, attr.SchemaNamespace, attr.GeneratorName, targetNamespace));
                        ImmutableInterlocked.Enqueue(ref _modelsToGenerate, 
                            new DebugCommand("Contracts", "Generated", $"TargetNamespace: {targetNamespace}"));
                        break;
                    }
                }
            }
        }
    }
}