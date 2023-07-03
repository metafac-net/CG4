using MetaFac.CG4.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.ModelBuilding
{
    public interface IModelContainerBuilder
    {
        ModelContainer Build();
        IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag);
    }
    public interface IModelDefinitionBuilder : IModelContainerBuilder
    {
        IModelEntityDefBuilder AddEntityDef(string entityName, int? entityTag);
    }
    public interface IModelEntityDefBuilder : IModelDefinitionBuilder
    {
    }
    public static class ModelBuilder
    {
        public static IModelContainerBuilder Create() => new ModelContainerBuilder();
    }
    internal class ModelContainerBuilder : IModelContainerBuilder
    {
        private readonly Dictionary<string, string> _tokens = new Dictionary<string, string>();
        private readonly Dictionary<string, ModelDefinitionBuilder> _modelDefBuilders = new Dictionary<string, ModelDefinitionBuilder>();
        public IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag)
        {
            var modelDefBuilder = new ModelDefinitionBuilder(this, modelName, modelTag);
            _modelDefBuilders.Add(modelName, modelDefBuilder);
            return modelDefBuilder;
        }
        public ModelContainer Build()
        {
            List<ModelDefinition> modelDefs = _modelDefBuilders.Values.Select(mdb => mdb.GetModelDefinition()).ToList();
            return new ModelContainer(modelDefs, _tokens);
        }
    }
    internal sealed class ModelDefinitionBuilder : IModelDefinitionBuilder
    {
        private readonly ModelContainerBuilder _parent;
        private readonly string _modelName;
        private readonly int? _modelTag;
        private readonly Dictionary<string, ModelEntityDefBuilder> _entityDefBuilders = new Dictionary<string, ModelEntityDefBuilder>();

        public ModelDefinitionBuilder(ModelContainerBuilder container, string modelName, int? modelTag)
        {
            _parent = container;
            _modelName = modelName;
            _modelTag = modelTag;
        }

        public IModelEntityDefBuilder AddEntityDef(string entityName, int? entityTag)
        {
            var entityDefBuilder = new ModelEntityDefBuilder(this, entityName, entityTag);
            _entityDefBuilders.Add(entityName, entityDefBuilder);
            return entityDefBuilder;
        }

        public ModelDefinition GetModelDefinition()
        {
            List<ModelEntityDef> entityDefs = _entityDefBuilders.Values.Select(edb => edb.GetModelEntityDef()).ToList();
            return new ModelDefinition(_modelName, _modelTag, entityDefs);
        }

        public IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag) => _parent.AddModelDef(modelName, modelTag);
        public ModelContainer Build() => _parent.Build();
    }
    internal sealed class ModelEntityDefBuilder : IModelEntityDefBuilder
    {
        private readonly ModelDefinitionBuilder _parent;
        private readonly string _entityName;
        private readonly int? _entityTag;

        public ModelEntityDefBuilder(ModelDefinitionBuilder parent, string entityName, int? entityTag)
        {
            _parent = parent;
            _entityName = entityName;
            _entityTag = entityTag;
        }

        public ModelEntityDef GetModelEntityDef()
        {
            var memberDefs = new List<ModelMemberDef>();
            return new ModelEntityDef(_entityName, _entityTag, null, false, null, memberDefs, null); // todo
        }

        public IModelEntityDefBuilder AddEntityDef(string entityName, int? entityTag) => _parent.AddEntityDef(entityName, entityTag);
        public IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag) => _parent.AddModelDef(modelName, modelTag);
        public ModelContainer Build() => _parent.Build();
    }
}