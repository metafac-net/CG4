namespace MetaFac.CG3.Generators
{
    public class ProxyDef
    {
        public readonly string ProxyTypeName;
        public readonly string ExternalTypeName;
        public readonly string ConcreteTypeName;

        public ProxyDef(string proxyTypeName, string externalTypeName, string concreteTypeName)
        {
            ProxyTypeName = proxyTypeName;
            ExternalTypeName = externalTypeName;
            ConcreteTypeName = concreteTypeName;
        }
        public ProxyDef(string proxyTypeName, string externalTypeName)
        {
            ProxyTypeName = proxyTypeName;
            ExternalTypeName = externalTypeName;
            ConcreteTypeName = externalTypeName;
        }
    }
}