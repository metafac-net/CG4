using MetaFac.CG4.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.ModelBuilding
{
    internal sealed class ModelEnumTypeDefBuilder : IModelEnumTypeDefBuilder
    {
        private readonly ModelDefinitionBuilder _outer;
        private readonly string _name;
        private readonly Dictionary<string, ModelEnumItemDefBuilder> _enumItemDefBuilders = new Dictionary<string, ModelEnumItemDefBuilder>();

        public ModelEnumTypeDefBuilder(ModelDefinitionBuilder outer, string name)
        {
            _outer = outer;
            _name = name;
        }

        public IModelEnumItemDefBuilder AddEnumItemDef(string memberName)
        {
            var memberDefBuilder = new ModelEnumItemDefBuilder(this, memberName);
            _enumItemDefBuilders.Add(memberName, memberDefBuilder);
            return memberDefBuilder;
        }

        public ModelEnumTypeDef GetModelEnumTypeDef()
        {
            List<ModelEnumItemDef> enumItemDefs = _enumItemDefBuilders.Values.Select(eidb => eidb.GetEnumItemDef()).OrderBy(x => x.Name).ToList();
            return new ModelEnumTypeDef(_name, null, ModelItemState.Create(false, false, null), enumItemDefs); // todo
        }

        public IEntityBuilder AddEntity(string entityName, int? entityTag, string? baseName = null, string? summary = null, ItemState itemState = ItemState.Active, string? reason = null)
            => _outer.AddEntity(entityName, entityTag, baseName, summary, itemState, reason);
        public IModelEnumTypeDefBuilder AddEnumTypeDef(string enumTypeName) => _outer.AddEnumTypeDef(enumTypeName);
        public IModelDefinitionBuilder AddModelDef(string modelName, int? modelTag) => _outer.AddModelDef(modelName, modelTag);
        public ModelContainer Build() => _outer.Build();
    }
}