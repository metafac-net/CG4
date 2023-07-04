using MetaFac.CG4.Models;

namespace MetaFac.CG4.ModelBuilding
{
    public interface IModelContainerBuilder
    {
        ModelContainer Build();
        IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag);
    }
}