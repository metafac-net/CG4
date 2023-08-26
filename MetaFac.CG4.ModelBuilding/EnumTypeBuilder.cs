using MetaFac.CG4.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.ModelBuilding
{
    internal sealed class EnumTypeBuilder : IEnumTypeBuilder
    {
        private readonly ModelDefinitionBuilder _outer;
        private readonly Dictionary<string, string> _tokens = new Dictionary<string, string>();
        private readonly string _name;
        private readonly string? _summary;
        private readonly ItemState _itemState;
        private readonly string? _reason;

        private readonly Dictionary<string, EnumItemBuilder> _enumItemBuilders = new Dictionary<string, EnumItemBuilder>();

        public EnumTypeBuilder(ModelDefinitionBuilder outer, string name, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
        {
            _outer = outer;
            _name = name;
            _summary = summary;
            _itemState = itemState;
            _reason = reason;
        }

        public IEnumItemBuilder AddEnumItem(string itemName, int code, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
        {
            var enumItemBuilder = new EnumItemBuilder(this, itemName, code, summary, itemState, reason);
            _enumItemBuilders.Add(itemName, enumItemBuilder);
            return enumItemBuilder;
        }

        public ModelEnumTypeDef GetModelEnumTypeDef()
        {
            List<ModelEnumItemDef> enumItemDefs = _enumItemBuilders.Values.Select(eidb => eidb.GetEnumItemDef()).OrderBy(x => x.Name).ToList();
            return new ModelEnumTypeDef(_name, enumItemDefs, _summary, ModelItemState.Create(_itemState, _reason), _tokens);
        }

        public IEntityBuilder AddEntity(string entityName, int? entityTag, string? baseName = null, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEntity(entityName, entityTag, baseName, summary, itemState, reason);
        public IEnumTypeBuilder AddEnumType(string enumTypeName, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEnumType(enumTypeName, summary, itemState, reason);
        public IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag) => _outer.AddModelDef(modelName, modelTag);
        public ModelContainer Build() => _outer.Build();
        public IModelContainerBuilder AddOuterToken(string name, string value) => _outer.AddOuterToken(name, value);
        public IModelDefinitionBuilder AddModelToken(string name, string value) => _outer.AddModelToken(name, value);
    }
}