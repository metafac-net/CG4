using MetaFac.CG4.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.ModelBuilding
{
    internal sealed class EntityBuilder : IEntityBuilder
    {
        private readonly ModelDefinitionBuilder _outer;
        private readonly Dictionary<string, string> _tokens = new Dictionary<string, string>();
        private readonly string _name;
        private readonly int? _tag;
        private readonly string? _baseName;
        private readonly string? _summary;
        private readonly ItemState _itemState;
        private readonly string? _reason;

        private readonly Dictionary<string, MemberBuilder> _memberBuilders = new Dictionary<string, MemberBuilder>();

        public EntityBuilder(ModelDefinitionBuilder outer, string name, int? tag, string? baseName = null, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
        {
            _outer = outer;
            _name = name;
            _tag = tag;
            _baseName = baseName;
            _summary = summary;
            _itemState = itemState;
            _reason = reason;
        }

        public IEntityBuilder AddEntityToken(string name, string value)
        {
            _tokens[name] = value;
            return this;
        }

        public IMemberBuilder AddMember(string memberName, int? memberTag, string innerType, bool nullable, int arrayRank, string? indexType, bool isModelType, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
        {
            var memberDefBuilder = new MemberBuilder(this, memberName, memberTag, innerType, nullable, arrayRank, indexType, isModelType, summary, itemState, reason);
            _memberBuilders.Add(memberName, memberDefBuilder);
            return memberDefBuilder;
        }

        public ModelEntityDef GetModelEntityDef()
        {
            var memberDefs = _memberBuilders.Values.Select(mdb => mdb.GetModelMemberDef()).OrderBy(x => x.Name).ToList();
            return new ModelEntityDef(_name, _tag, _summary, _baseName, memberDefs, ModelItemState.Create(_itemState, _reason), _tokens);
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