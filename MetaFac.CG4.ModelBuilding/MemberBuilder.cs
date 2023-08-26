using MetaFac.CG4.Models;

namespace MetaFac.CG4.ModelBuilding
{
    internal sealed class MemberBuilder : IMemberBuilder
    {
        private readonly EntityBuilder _outer;
        private readonly string _name;
        private readonly int? _tag;
        private readonly string _innerType;
        private readonly bool _nullable;
        private readonly int _arrayRank;
        private readonly string? _indexType;
        private readonly bool _isModelType;
        private readonly string? _summary;
        private readonly ItemState _itemState;
        private readonly string? _reason;

        private string? _proxyExternalType = null;
        private string? _proxyConcreteType = null;

        public MemberBuilder(EntityBuilder outer, string name, int? tag, string innerType, bool nullable, int arrayRank, string? indexType, bool isModelType,
            string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
        {
            _outer = outer;
            _name = name;
            _tag = tag;
            _innerType = innerType;
            _nullable = nullable;
            _arrayRank = arrayRank;
            _indexType = indexType;
            _isModelType = isModelType;
            _summary = summary;
            _itemState = itemState;
            _reason = reason;
        }

        public IMemberBuilder SetProxyTypes(string externalName, string concreteName)
        {
            _proxyExternalType = externalName;
            _proxyConcreteType = concreteName;
            return this;
        }

        public ModelMemberDef GetModelMemberDef()
        {
            ModelProxyDef? proxyDef = (_proxyExternalType is not null && _proxyConcreteType is not null)
                ? new ModelProxyDef(_proxyExternalType, _proxyConcreteType)
                : null;
            return new ModelMemberDef(_name, _tag, _summary, _innerType, _nullable, proxyDef, _arrayRank, _indexType, _isModelType, ModelItemState.Create(_itemState, _reason));
        }

        public IEntityBuilder AddEntity(string entityName, int? entityTag, string? baseName = null, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEntity(entityName, entityTag, baseName, summary, itemState, reason);
        public IMemberBuilder AddMember(string memberName, int? memberTag, string innerType, bool nullable, int arrayRank, string? indexType, bool isModelType, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddMember(memberName, memberTag, innerType, nullable, arrayRank, indexType, isModelType, summary, itemState, reason);
        public IEnumTypeBuilder AddEnumType(string enumTypeName, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEnumType(enumTypeName, summary, itemState, reason);
        public IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag) => _outer.AddModelDef(modelName, modelTag);
        public ModelContainer Build() => _outer.Build();
        public IModelContainerBuilder AddOuterToken(string name, string value) => _outer.AddOuterToken(name, value);
        public IModelDefinitionBuilder AddModelToken(string name, string value) => _outer.AddModelToken(name, value);
        public IEntityBuilder AddEntityToken(string name, string value) => _outer.AddEntityToken(name, value);
    }
}