using System;

namespace MetaFac.CG4.Attributes
{
    public enum BasicGeneratorId
    {
        None,
        Contracts,
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CG4GenerateAttribute : Attribute
    {
        public readonly string GeneratorName;
        public readonly string SchemaAnchorType;
        public readonly string SchemaNamespace;

        public CG4GenerateAttribute(BasicGeneratorId generatorId, Type schemaAnchorType, string? schemaNamespace = null)
        {
            GeneratorName = $"{nameof(BasicGeneratorId)}.{generatorId}";
            SchemaAnchorType = schemaAnchorType.FullName ?? throw new ArgumentNullException(nameof(schemaAnchorType));
            SchemaNamespace = schemaNamespace ?? schemaAnchorType.Namespace ?? throw new ArgumentNullException(nameof(SchemaNamespace));
        }
    }
}