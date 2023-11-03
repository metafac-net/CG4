using MetaFac.CG4.Models;
using System.Collections.Generic;

namespace MetaFac.CG4.ModelBuilding
{
    internal sealed class EnumItemBuilder : IEnumItemBuilder
    {
        private readonly EnumTypeBuilder _outer;
        private readonly Dictionary<string, string> _tokens = new Dictionary<string, string>();
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
            return new ModelEnumItemDef(_name, _code, _summary, ModelItemState.Create(_itemState, _reason), _tokens);
        }

        public IEntityBuilder AddEntity(string entityName, int? entityTag, string? baseName = null, bool isAbstract = false, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEntity(entityName, entityTag, baseName, isAbstract, summary, itemState, reason);
        public IEnumTypeBuilder AddEnumType(string enumTypeName, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEnumType(enumTypeName, summary, itemState, reason);
        public IEnumItemBuilder AddEnumItem(string name, int value, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEnumItem(name, value, summary, itemState, reason);
        public IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag) => _outer.AddModelDef(modelName, modelTag);
        public ModelContainer Build() => _outer.Build();
        public IModelContainerBuilder AddOuterToken(string name, string value) => _outer.AddOuterToken(name, value);
        public IModelDefinitionBuilder AddModelToken(string name, string value) => _outer.AddModelToken(name, value);
    }
}