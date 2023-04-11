namespace MetaFac.CG3.ModelReader
{
    internal class ProxyTypeInfo
    {
        public readonly string ExternalName;
        public readonly string ConcreteName;

        public ProxyTypeInfo(string externalName, string concreteName)
        {
            ExternalName = externalName;
            ConcreteName = concreteName;
        }
    }
}