using MetaFac.CG4.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.ModelBuilding
{
    internal sealed class ModelDefinitionBuilder : IModelDefinitionBuilder
    {
        private readonly ModelContainerBuilder _outer;
        private readonly string _name;
        private readonly int? _tag;
        private readonly Dictionary<string, EntityBuilder> _entityDefBuilders = new Dictionary<string, EntityBuilder>();
        private readonly Dictionary<string, ModelEnumTypeDefBuilder> _enumTypeDefBuilders = new Dictionary<string, ModelEnumTypeDefBuilder>();

        public ModelDefinitionBuilder(ModelContainerBuilder outer, string name, int? tag)
        {
            _outer = outer;
            _name = name;
            _tag = tag;
        }

        public IEntityBuilder AddEntity(string entityName, int? entityTag, string? baseName, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
        {
            var entityDefBuilder = new EntityBuilder(this, entityName, entityTag, baseName, summary, itemState, reason);
            _entityDefBuilders.Add(entityName, entityDefBuilder);
            return entityDefBuilder;
        }

        public IModelEnumTypeDefBuilder AddEnumTypeDef(string enumTypeName)
        {
            var enumTypeDefBuilder = new ModelEnumTypeDefBuilder(this, enumTypeName);
            _enumTypeDefBuilders.Add(enumTypeName, enumTypeDefBuilder);
            return enumTypeDefBuilder;
        }

        public ModelDefinition GetModelDefinition()
        {
            List<ModelEntityDef> entityDefs = _entityDefBuilders.Values.Select(edb => edb.GetModelEntityDef()).OrderBy(x => x.Name).ToList();
            List<ModelEnumTypeDef> enumTypeDefs = _enumTypeDefBuilders.Values.Select(etdb => etdb.GetModelEnumTypeDef()).OrderBy(x => x.Name).ToList();
            return new ModelDefinition(_name, _tag, entityDefs, enumTypeDefs);
        }

        public IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag) => _outer.AddModelDef(modelName, modelTag);
        public ModelContainer Build() => _outer.Build();
    }
}