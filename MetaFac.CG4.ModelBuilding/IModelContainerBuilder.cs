using MetaFac.CG4.Models;

namespace MetaFac.CG4.ModelBuilding
{
    public interface IModelContainerBuilder
    {
        ModelContainer Build();
        IModelContainerBuilder AddOuterToken(string name, string value);
        IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag = null);
    }
}