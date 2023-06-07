using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelValidator
    {
        public ModelContainer MergeMetadata(ModelContainer oldMetadata, ModelContainer newMetadata,
            bool updateModelName = false,
            bool createEntities = false,
            bool ignoreNewEntityTags = false,
            bool updateEntities = false,
            bool deleteEntities = false)
        {
            if (oldMetadata is null) throw new ArgumentNullException(nameof(oldMetadata));
            if (newMetadata is null) throw new ArgumentNullException(nameof(newMetadata));

            var x = Validate(oldMetadata);
            if (x.HasErrors)
                throw new ArgumentException("Metadata is not valid", nameof(oldMetadata));
            if (oldMetadata.ModelDefs.Count > 1)
                throw new NotSupportedException("Metadata cannot have multiple models!");
            if (newMetadata.ModelDefs.Count > 1)
                throw new NotSupportedException("Metadata cannot have multiple models!");
            string modelName = oldMetadata.ModelDefs[0].Name;
            if (updateModelName && !string.IsNullOrWhiteSpace(newMetadata.ModelDefs[0].Name))
                modelName = newMetadata.ModelDefs[0].Name;

            int? modelTag = oldMetadata.ModelDefs[0].Tag;
            if (newMetadata.ModelDefs[0].Tag.HasValue)
                modelTag = newMetadata.ModelDefs[0].Tag;

            Dictionary<string, ModelEntityDef> newEntityDefs = new Dictionary<string, ModelEntityDef>();
            foreach (var ncd in newMetadata.ModelDefs[0].AllEntityDefs)
            {
                newEntityDefs.Add(ncd.Name, ncd);
            }

            Dictionary<int, ModelEntityDef> oldEntityDefsByTag = new Dictionary<int, ModelEntityDef>();
            Dictionary<string, int> oldEntityNameToTagMap = new Dictionary<string, int>();
            foreach (var ocd in oldMetadata.ModelDefs[0].AllEntityDefs)
            {
                if (ocd.Tag.HasValue)
                {
                    oldEntityDefsByTag.Add(ocd.Tag.Value, ocd);
                    oldEntityNameToTagMap.Add(ocd.Name, ocd.Tag.Value);
                }
                else
                    throw new ArgumentException("Metadata is not valid", nameof(oldMetadata));
            }

            Dictionary<int, ModelEntityDef> mergedEntityDefsByTag = new Dictionary<int, ModelEntityDef>();
            Dictionary<string, int> mergedEntityNameToTagMap = new Dictionary<string, int>();

            int maxEntityTag = 0;
            if (oldEntityNameToTagMap.Any())
                maxEntityTag = oldEntityNameToTagMap.Values.Max();

            if (createEntities)
            {
                var newEntityNames = newEntityDefs.Keys.ToList();
                foreach (var newEntityName in newEntityNames)
                {
                    var ncd = newEntityDefs[newEntityName];
                    int newEntityTag = ignoreNewEntityTags ? 0 : ncd.Tag ?? 0;
                    if (oldEntityDefsByTag.ContainsKey(newEntityTag))
                        continue;
                    if (oldEntityNameToTagMap.ContainsKey(ncd.Name))
                        continue;

                    // add new class
                    if (newEntityTag == 0)
                        newEntityTag = ++maxEntityTag;
                    mergedEntityDefsByTag.Add(newEntityTag,
                        new ModelEntityDef(ncd.Name, newEntityTag, ncd.Summary, ncd.IsAbstract, ncd.ParentName, ncd.AllMemberDefs, ncd.State));
                    mergedEntityNameToTagMap.Add(ncd.Name, newEntityTag);
                    newEntityDefs.Remove(newEntityName);
                }
            }

            if (updateEntities)
            {
                var newEntityNames = newEntityDefs.Keys.ToList();
                foreach (var newEntityName in newEntityNames)
                {
                    var ncd = newEntityDefs[newEntityName];
                    int oldEntityTag;
                    ModelEntityDef? oldEntityDef = null;
                    if (ncd.Tag.HasValue && !ignoreNewEntityTags)
                    {
                        oldEntityTag = ncd.Tag.Value;
                        oldEntityDefsByTag.TryGetValue(oldEntityTag, out oldEntityDef);
                    }
                    else
                    {
                        if (oldEntityNameToTagMap.TryGetValue(ncd.Name, out oldEntityTag))
                            oldEntityDefsByTag.TryGetValue(oldEntityTag, out oldEntityDef);
                    }
                    if (oldEntityDef != null)
                    {
                        // update class
                        mergedEntityDefsByTag.Add(oldEntityTag,
                            new ModelEntityDef(ncd.Name, oldEntityTag, ncd.Summary, ncd.IsAbstract, ncd.ParentName, ncd.AllMemberDefs, ncd.State));
                        mergedEntityNameToTagMap.Add(ncd.Name, oldEntityTag);
                        newEntityDefs.Remove(newEntityName);
                        oldEntityNameToTagMap.Remove(oldEntityDef.Name);
                        oldEntityDefsByTag.Remove(oldEntityTag);
                    }
                }
            }

            // delete or retain remaining old entities
            foreach (var ocd in oldEntityDefsByTag.Values.ToList())
            {
                if (!deleteEntities || newEntityDefs.ContainsKey(ocd.Name))
                {
                    mergedEntityDefsByTag.Add(ocd.Tag ?? 0, ocd);
                    mergedEntityNameToTagMap.Add(ocd.Name, ocd.Tag ?? 0);
                }
            }

            return new ModelContainer(new ModelDefinition(modelName, modelTag, mergedEntityDefsByTag.Values.OrderBy(c => c.Tag ?? 0)));
        }

        public ValidationResult Validate(ModelContainer metadata,
            ValidationErrorHandling errorHandling = ValidationErrorHandling.Default)
        {
            if (metadata is null) throw new ArgumentNullException(nameof(metadata));
            if (metadata.ModelDefs.Count != 1)
                throw new NotSupportedException("Metadata with multiple models!");
            var model = metadata.ModelDefs[0];

            // validation rules
            // 1. all entity tags must be: unique, positive
            // 2. all data types are native or defined
            // 3. all field tags must be: unique, positive
            ValidationResult result = ValidationResult.Init(errorHandling);

            ImmutableDictionary<int, ModelEntityDef> entityTagMap = ImmutableDictionary<int, ModelEntityDef>.Empty;
            ImmutableDictionary<string, ModelEntityDef> entityNameMap = ImmutableDictionary<string, ModelEntityDef>.Empty;

            foreach (var entityDef in model.AllEntityDefs)
            {
                //---------- check entity tag not missing
                if (!entityDef.Tag.HasValue)
                    result = result.AddError(
                        new ValidationError(
                            ValidationErrorCode.MissingEntityTag,
                            model.Name, entityDef.ToTagName(), null, null, null));

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;

                if (entityDef.Tag.HasValue && entityDef.Tag.Value <= 0)
                    result = result.AddError(
                        new ValidationError(
                            ValidationErrorCode.InvalidEntityTag,
                            model.Name, entityDef.ToTagName(), null, null, null));

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;

                ModelEntityDef? tempEntityDef;

                //---------- check entity tag is unique
                if (entityDef.Tag.HasValue)
                {
                    var entityTag = entityDef.Tag.Value;
                    if (entityTagMap.TryGetValue(entityTag, out tempEntityDef))
                        result = result.AddError(
                            new ValidationError(
                                ValidationErrorCode.DuplicateEntityTag,
                                model.Name, entityDef.ToTagName(), null, tempEntityDef.ToTagName(), null));
                    else
                    {
                        entityTagMap = entityTagMap.Add(entityTag, entityDef);
                    }
                }

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;

                //---------- check class name is unique
                var entityName = entityDef.Name;
                if (entityNameMap.TryGetValue(entityName, out tempEntityDef))
                {
                    result = result.AddError(new ValidationError(
                        ValidationErrorCode.DuplicateEntityName,
                        model.Name, entityDef.ToTagName(), null, tempEntityDef.ToTagName(), null));
                }
                else
                {
                    entityNameMap = entityNameMap.Add(entityName, entityDef);
                }

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;

                Dictionary<int, ModelMemberDef> fieldTagMap = new Dictionary<int, ModelMemberDef>();
                Dictionary<string, ModelMemberDef> fieldNameMap = new Dictionary<string, ModelMemberDef>();

                foreach (var memberDef in entityDef.AllMemberDefs)
                {
                    //---------- check field tag is not missing
                    if (!memberDef.Tag.HasValue)
                        result = result.AddError(
                            new ValidationError(
                                ValidationErrorCode.MissingFieldTag,
                                model.Name, entityDef.ToTagName(), memberDef.ToTagName(), null, null));

                    if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                        return result;

                    //---------- check field tag is unique
                    if (memberDef.Tag.HasValue)
                    {
                        var fieldTag = memberDef.Tag.Value;
                        if (fieldTagMap.TryGetValue(fieldTag, out var other1))
                            result = result.AddError(
                                new ValidationError(ValidationErrorCode.DuplicateFieldTag,
                                    model.Name, entityDef.ToTagName(), memberDef.ToTagName(), null, other1.ToTagName()));
                        else
                        {
                            fieldTagMap[fieldTag] = memberDef;
                        }
                    }

                    if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                        return result;

                    //---------- check field name is unique
                    var memberName = memberDef.Name;
                    if (fieldNameMap.TryGetValue(memberName, out var other2))
                    {
                        result = result.AddError(new ValidationError(
                            ValidationErrorCode.DuplicateFieldName,
                            model.Name, entityDef.ToTagName(), memberDef.ToTagName(), null, other2.ToTagName()));
                    }
                    else
                    {
                        fieldNameMap[memberName] = memberDef;
                    }

                    if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                        return result;
                }
            }

            // ---------- check missing parents
            foreach (var entityDef in model.AllEntityDefs)
            {
                if (entityDef.ParentName != null)
                {
                    if (entityNameMap.TryGetValue(entityDef.ParentName, out var parent))
                    {
                        // known parent - check is abstract
                        if (!parent.IsAbstract)
                        {
                            result = result.AddWarning(new ValidationError(
                                ValidationErrorCode.NonAbstractParent,
                                model.Name, entityDef.ToTagName(), null, parent.ToTagName(), null));
                        }
                    }
                    else
                    {
                        // unknown parent
                        parent = new ModelEntityDef(entityDef.ParentName, null, null, false, null, new List<ModelMemberDef>(), null);
                        result = result.AddError(new ValidationError(
                            ValidationErrorCode.UnknownParent,
                            model.Name, entityDef.ToTagName(), null, parent.ToTagName(), null));
                    }
                }

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;
            }

            // ---------- check circular refs
            foreach (var entityDef in model.AllEntityDefs)
            {
                ImmutableDictionary<string, ModelEntityDef> visitedEntityDefs =
                    ImmutableDictionary<string, ModelEntityDef>.Empty.Add(entityDef.Name, entityDef);
                result = CheckFieldRecursion(result, errorHandling, metadata, entityDef, entityNameMap, visitedEntityDefs);

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;
            }

            // throw aggregate exception if requested
            if (errorHandling == ValidationErrorHandling.ThrowAggregate && result.HasErrors)
            {
                throw new AggregateException(result.Errors.Select(e => new ValidationException(e)));
            }
            return result;
        }

        private ValidationResult CheckFieldRecursion(
            ValidationResult result,
            ValidationErrorHandling errorHandling,
            ModelContainer metadata,
            ModelEntityDef entityDef,
            ImmutableDictionary<string, ModelEntityDef> allEntities,
            ImmutableDictionary<string, ModelEntityDef> visitedEntities
        )
        {
            if (metadata.ModelDefs.Count != 1)
                throw new NotSupportedException("Metadata with multiple models!");
            var model = metadata.ModelDefs[0];

            foreach (var memberDef in entityDef.AllMemberDefs)
            {
                if (memberDef.ProxyDef is not null)
                    continue;

                if (IsNativeDataType(memberDef.InnerType))
                    continue;

                ModelEntityDef? otherEntity;
                if (allEntities.TryGetValue(memberDef.InnerType, out otherEntity))
                {
                    // known type - check recursion
                    if (visitedEntities.ContainsKey(memberDef.InnerType))
                    {
                        // circular ref!
                        result = result.AddWarning(new ValidationError(
                            ValidationErrorCode.CircularReference,
                            model.Name, entityDef.ToTagName(), memberDef.ToTagName(), otherEntity.ToTagName(), null));
                    }
                    else
                    {
                        // recurse
                        result = CheckFieldRecursion(result, errorHandling, metadata,
                            otherEntity, allEntities, visitedEntities.Add(otherEntity.Name, otherEntity));
                    }
                }
                else
                {
                    // unknown field type
                    result = result.AddError(new ValidationError(
                        ValidationErrorCode.UnknownFieldType,
                        model.Name, entityDef.ToTagName(), memberDef.ToTagName(), null, null));
                }

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;
            }
            return result;
        }

        private bool IsNativeDataType(string datatype)
        {
            switch (datatype)
            {
                case "bool":
                case "int8":
                case "uint8":
                case "char":
                case "int16":
                case "uint16":
                case "int32":
                case "uint32":
                case "single":
                case "int64":
                case "uint64":
                case "double":
                case "datetime":
                case "timespan":
                case "decimal":
                case "guid":
                case "datetimezone":
                case "string":
                case "binary":
                    return true;
                default:
                    return false;
            }
        }
    }
}