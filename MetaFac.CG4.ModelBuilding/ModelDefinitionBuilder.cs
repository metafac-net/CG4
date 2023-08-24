using MetaFac.CG4.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.ModelBuilding
{
    internal sealed class ModelDefinitionBuilder : IModelDefinitionBuilder
    {
        private readonly ModelContainerBuilder _outer;
        private readonly Dictionary<string, string> _tokens = new Dictionary<string, string>();
        private readonly string _nameqqq;
        private readonly int? _tag;
        private readonly Dictionary<string, EntityBuilder> _entityDefBuilders = new Dictionary<string, EntityBuilder>();
        private readonly Dictionary<string, EnumTypeBuilder> _enumTypeDefBuilders = new Dictionary<string, EnumTypeBuilder>();

        public ModelDefinitionBuilder(ModelContainerBuilder outer, string name, int? tag)
        {
            _outer = outer;
            _nameqqq = name;
            _tag = tag;
        }

        public IModelDefinitionBuilder AddModelToken(string name, string value)
        {
            _tokens[name] = value;
            return this;
        }

        public IEntityBuilder AddEntity(string entityName, int? entityTag, string? baseName, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
        {
            var entityDefBuilder = new EntityBuilder(this, entityName, entityTag, baseName, summary, itemState, reason);
            _entityDefBuilders.Add(entityName, entityDefBuilder);
            return entityDefBuilder;
        }

        public IEnumTypeBuilder AddEnumType(string enumTypeName, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
        {
            var enumTypeDefBuilder = new EnumTypeBuilder(this, enumTypeName, summary, itemState, reason);
            _enumTypeDefBuilders.Add(enumTypeName, enumTypeDefBuilder);
            return enumTypeDefBuilder;
        }

        public ModelDefinition GetModelDefinition()
        {
            List<ModelEntityDef> entityDefs = _entityDefBuilders.Values.Select(edb => edb.GetModelEntityDef()).OrderBy(x => x.Name).ToList();
            List<ModelEnumTypeDef> enumTypeDefs = _enumTypeDefBuilders.Values.Select(etdb => etdb.GetModelEnumTypeDef()).OrderBy(x => x.Name).ToList();
            return new ModelDefinition(_nameqqq, _tag, entityDefs, enumTypeDefs, _tokens);
        }

        public IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag) => _outer.AddModelDef(modelName, modelTag);
        public ModelContainer Build() => _outer.Build();
        public IModelContainerBuilder AddOuterToken(string name, string value) => _outer.AddOuterToken(name, value);
    }
}