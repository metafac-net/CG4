using MetaFac.CG4.Models;

namespace MetaFac.CG4.ModelBuilding
{
    public interface IEnumTypeBuilder : IModelDefinitionBuilder
    {
        IEnumItemBuilder AddEnumItem(string itemName, int code, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null);
    }
}