using System;

namespace MetaFac.CG4.Attributes
{

    /// <summary>
    /// Marks a type in the model as a proxy for an external type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct)]
    public class ProxyAttribute : Attribute
    {
        public readonly string ExternalName;
        public readonly string ConcreteName;

        public ProxyAttribute(string externalName, string concreteName)
        {
            ExternalName = externalName;
            ConcreteName = concreteName;
        }
    }
}
