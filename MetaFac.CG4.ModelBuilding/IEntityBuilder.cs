using MetaFac.CG4.Models;

namespace MetaFac.CG4.ModelBuilding
{
    public interface IEntityBuilder : IModelDefinitionBuilder
    {
        IEntityBuilder AddEntityToken(string name, string value);
        IMemberBuilder AddMember(string memberName, int? memberTag, string innerType, bool nullable, int arrayRank, string? indexType, bool isModelType, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null);
    }
}