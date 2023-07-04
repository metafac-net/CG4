namespace MetaFac.CG4.ModelBuilding
{
    public interface IMemberBuilder : IEntityBuilder
    {
        IMemberBuilder SetProxyTypes(string externalName, string concreteName);
    }
}