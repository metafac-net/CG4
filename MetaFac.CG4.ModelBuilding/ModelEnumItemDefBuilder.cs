using MetaFac.CG4.Models;

namespace MetaFac.CG4.ModelBuilding
{
    internal sealed class ModelEnumItemDefBuilder : IModelEnumItemDefBuilder
    {
        private readonly ModelEnumTypeDefBuilder _outer;
        private readonly string _name;

        public ModelEnumItemDefBuilder(ModelEnumTypeDefBuilder outer, string name)
        {
            _outer = outer;
            _name = name;
        }

        public ModelEnumItemDef GetEnumItemDef()
        {
            return new ModelEnumItemDef(_name, null, 0, ModelItemState.Create(false, false, null));
        }

        public IEntityBuilder AddEntity(string entityName, int? entityTag, string? baseName = null, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEntity(entityName, entityTag, baseName, summary, itemState, reason);
        public IModelEnumItemDefBuilder AddEnumItemDef(string itemName) => _outer.AddEnumItemDef(itemName);
        public IModelEnumTypeDefBuilder AddEnumTypeDef(string enumTypeName) => _outer.AddEnumTypeDef(enumTypeName);
        public IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag) => _outer.AddModelDef(modelName, modelTag);
        public ModelContainer Build() => _outer.Build();
    }
}