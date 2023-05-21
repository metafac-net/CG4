using System;

namespace MetaFac.CG4.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CG4GenerateAttribute : Attribute
    {
        public readonly string GeneratorName;
        public readonly Type SchemaAnchorType;
        public readonly string SchemaNamespace;

        public CG4GenerateAttribute(string generatorName, Type schemaAnchorType, string? schemaNamespace = null)
        {
            GeneratorName = generatorName;
            SchemaAnchorType = schemaAnchorType;
            SchemaNamespace = schemaNamespace ?? schemaAnchorType.Namespace ?? throw new ArgumentNullException(nameof(SchemaNamespace));
        }
    }
}