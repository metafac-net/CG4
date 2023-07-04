using MetaFac.CG4.Models;

namespace MetaFac.CG4.ModelBuilding
{
    public interface IModelDefinitionBuilder : IModelContainerBuilder
    {
        IEntityBuilder AddEntity(string entityName, int? entityTag, string? baseName = null, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null);
        IModelEnumTypeDefBuilder AddEnumTypeDef(string enumName);
    }
}