using MetaFac.CG4.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.ModelBuilding
{
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

        public IModelContainerBuilder AddOuterToken(string name, string value)
        {
            _tokens[name] = value;
            return this;
        }

        public ModelContainer Build()
        {
            List<ModelDefinition> modelDefs = _modelDefBuilders.Values.Select(mdb => mdb.GetModelDefinition()).OrderBy(x => x.Name).ToList();
            return new ModelContainer(modelDefs, _tokens);
        }
    }
}