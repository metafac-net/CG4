using MetaFac.CG4.Models;

namespace MetaFac.CG4.ModelBuilding
{
    internal sealed class EnumItemBuilder : IEnumItemBuilder
    {
        private readonly EnumTypeBuilder _outer;
        private readonly string _name;
        private readonly int _code;
        private readonly string? _summary;
        private readonly ItemState _itemState;
        private readonly string? _reason;

        public EnumItemBuilder(EnumTypeBuilder outer, string name, int code, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
        {
            _outer = outer;
            _name = name;
            _code = code;
            _summary = summary;
            _itemState = itemState;
            _reason = reason;
        }

        public ModelEnumItemDef GetEnumItemDef()
        {
            return new ModelEnumItemDef(_name, _summary, _code, ModelItemState.Create(_itemState, _reason));
        }

        public IEntityBuilder AddEntity(string entityName, int? entityTag, string? baseName = null, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEntity(entityName, entityTag, baseName, summary, itemState, reason);
        public IEnumTypeBuilder AddEnumType(string enumTypeName, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEnumType(enumTypeName, summary, itemState, reason);
        public IEnumItemBuilder AddEnumItem(string itemName, int code, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEnumItem(itemName, code, summary, itemState, reason);
        public IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag) => _outer.AddModelDef(modelName, modelTag);
        public ModelContainer Build() => _outer.Build();
        public IModelContainerBuilder AddOuterToken(string name, string value) => _outer.AddOuterToken(name, value);
        public IModelDefinitionBuilder AddModelToken(string name, string value) => _outer.AddModelToken(name, value);
    }
}