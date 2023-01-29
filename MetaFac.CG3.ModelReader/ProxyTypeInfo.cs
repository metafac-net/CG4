using System;

namespace MetaCode.ModelReader
{
    internal class ProxyTypeInfo
    {
        public readonly bool HasNames;
        public readonly string? ExternalName;
        public readonly string? ConcreteName;

        public ProxyTypeInfo(bool hasNames, string? externalName, string? concreteName)
        {
            HasNames = hasNames;
            ExternalName = externalName;
            ConcreteName = concreteName;
        }
    }
}