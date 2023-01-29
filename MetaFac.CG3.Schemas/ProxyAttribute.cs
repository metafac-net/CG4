using System;

namespace MetaFac.CG3.Schemas
{
    /// <summary>
    /// Marks a type in the model as a proxy for an external type.
    /// </summary>
    public class ProxyAttribute : Attribute
    {
        public readonly bool HasNames;
        public readonly string? ExternalName;
        public readonly string? ConcreteName;

        [Obsolete("External and concrete type names are now required.")]
        public ProxyAttribute()
        {
            HasNames = false;
        }

        public ProxyAttribute(string externalName, string concreteName)
        {
            HasNames = true;
            ExternalName = externalName;
            ConcreteName = concreteName;
        }
    }

}
