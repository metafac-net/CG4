using MetaFac.CG4.Models;

namespace MetaFac.CG4.ModelBuilding
{
    public interface IModelDefinitionBuilder : IModelContainerBuilder
    {
        IModelDefinitionBuilder AddModelToken(string name, string value);
        IEntityBuilder AddEntity(string entityName, int? entityTag = null, string? baseName = null, bool isAbstract = false, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null);
        IEnumTypeBuilder AddEnumType(string enumTypeName, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null);
    }
}