namespace MetaFac.CG4.ModelBuilding
{
    public interface IModelEnumTypeDefBuilder : IModelDefinitionBuilder
    {
        IModelEnumItemDefBuilder AddEnumItemDef(string itemName);
    }
}