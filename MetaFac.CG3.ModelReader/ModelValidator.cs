using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MetaFac.CG3.ModelReader
{
    public class ModelValidator
    {
        public ModelContainer MergeMetadata(ModelContainer oldMetadata, ModelContainer newMetadata,
            bool updateModelName = false,
            bool createClasses = false,
            bool ignoreNewClassTags = false,
            bool updateClasses = false,
            bool deleteClasses = false)
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

            Dictionary<string, ModelClassDef> newClassDefs = new Dictionary<string, ModelClassDef>();
            foreach (var ncd in newMetadata.ModelDefs[0].ClassDefs)
            {
                newClassDefs.Add(ncd.Name, ncd);
            }

            Dictionary<int, ModelClassDef> oldClassDefsByTag = new Dictionary<int, ModelClassDef>();
            Dictionary<string, int> oldClassNameToTagMap = new Dictionary<string, int>();
            foreach (var ocd in oldMetadata.ModelDefs[0].ClassDefs)
            {
                if (ocd.Tag.HasValue)
                {
                    oldClassDefsByTag.Add(ocd.Tag.Value, ocd);
                    oldClassNameToTagMap.Add(ocd.Name, ocd.Tag.Value);
                }
                else
                    throw new ArgumentException("Metadata is not valid", nameof(oldMetadata));
            }

            Dictionary<int, ModelClassDef> mergedClassDefsByTag = new Dictionary<int, ModelClassDef>();
            Dictionary<string, int> mergedClassNameToTagMap = new Dictionary<string, int>();

            int maxClassTag = 0;
            if (oldClassNameToTagMap.Any())
                maxClassTag = oldClassNameToTagMap.Values.Max();

            if (createClasses)
            {
                var newClassNames = newClassDefs.Keys.ToList();
                foreach (var newClassName in newClassNames)
                {
                    var ncd = newClassDefs[newClassName];
                    int newClassTag = ignoreNewClassTags ? 0 : ncd.Tag ?? 0;
                    if (oldClassDefsByTag.ContainsKey(newClassTag))
                        continue;
                    if (oldClassNameToTagMap.ContainsKey(ncd.Name))
                        continue;

                    // add new class
                    if (newClassTag == 0)
                        newClassTag = ++maxClassTag;
                    mergedClassDefsByTag.Add(newClassTag,
                        new ModelClassDef(ncd.Name, newClassTag, ncd.IsAbstract, ncd.BaseClassName, ncd.FieldDefs, ncd.Tokens));
                    mergedClassNameToTagMap.Add(ncd.Name, newClassTag);
                    newClassDefs.Remove(newClassName);
                }
            }

            if (updateClasses)
            {
                var newClassNames = newClassDefs.Keys.ToList();
                foreach (var newClassName in newClassNames)
                {
                    var ncd = newClassDefs[newClassName];
                    int oldClassTag;
                    ModelClassDef? oldClassDef = null;
                    if (ncd.Tag.HasValue && !ignoreNewClassTags)
                    {
                        oldClassTag = ncd.Tag.Value;
                        oldClassDefsByTag.TryGetValue(oldClassTag, out oldClassDef);
                    }
                    else
                    {
                        if (oldClassNameToTagMap.TryGetValue(ncd.Name, out oldClassTag))
                            oldClassDefsByTag.TryGetValue(oldClassTag, out oldClassDef);
                    }
                    if (oldClassDef != null)
                    {
                        // update class
                        mergedClassDefsByTag.Add(oldClassTag,
                            new ModelClassDef(ncd.Name, oldClassTag, ncd.IsAbstract, ncd.BaseClassName, ncd.FieldDefs, ncd.Tokens));
                        mergedClassNameToTagMap.Add(ncd.Name, oldClassTag);
                        newClassDefs.Remove(newClassName);
                        oldClassNameToTagMap.Remove(oldClassDef.Name);
                        oldClassDefsByTag.Remove(oldClassTag);
                    }
                }
            }

            // delete or retain remaining old classes
            foreach (var ocd in oldClassDefsByTag.Values.ToList())
            {
                if (!deleteClasses || newClassDefs.ContainsKey(ocd.Name))
                {
                    mergedClassDefsByTag.Add(ocd.Tag ?? 0, ocd);
                    mergedClassNameToTagMap.Add(ocd.Name, ocd.Tag ?? 0);
                }
            }

            return new ModelContainer(new ModelDefinition(modelName, modelTag, mergedClassDefsByTag.Values.OrderBy(c => c.Tag ?? 0)));
        }

        public ValidationResult Validate(ModelContainer metadata,
            ValidationErrorHandling errorHandling = ValidationErrorHandling.Default)
        {
            if (metadata is null) throw new ArgumentNullException(nameof(metadata));
            if (metadata.ModelDefs.Count != 1)
                throw new NotSupportedException("Metadata with multiple models!");
            var model = metadata.ModelDefs[0];

            // validation rules
            // 1. all classes have unique, positive tags
            // 2. all data types are native or defined
            // 3. all fields have unique tags
            ValidationResult result = ValidationResult.Init(errorHandling);

            ImmutableDictionary<int, ModelClassDef> classTagMap = ImmutableDictionary<int, ModelClassDef>.Empty;
            ImmutableDictionary<string, ModelClassDef> classNameMap = ImmutableDictionary<string, ModelClassDef>.Empty;

            foreach (var classDef in model.ClassDefs)
            {
                //---------- check class tag not missing
                if (!classDef.Tag.HasValue)
                    result = result.AddError(
                        new ValidationError(
                            ValidationErrorCode.MissingClassTag,
                            model.Name, classDef.ToTagName(), null, null, null));

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;

                if (classDef.Tag.HasValue && classDef.Tag.Value <= 0)
                    result = result.AddError(
                        new ValidationError(
                            ValidationErrorCode.InvalidClassTag,
                            model.Name, classDef.ToTagName(), null, null, null));

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;

                ModelClassDef? tempClassDef;

                //---------- check class tag is unique
                if (classDef.Tag.HasValue)
                {
                    var classTag = classDef.Tag.Value;
                    if (classTagMap.TryGetValue(classTag, out tempClassDef))
                        result = result.AddError(
                            new ValidationError(
                                ValidationErrorCode.DuplicateClassTag,
                                model.Name, classDef.ToTagName(), null, tempClassDef.ToTagName(), null));
                    else
                    {
                        classTagMap = classTagMap.Add(classTag, classDef);
                    }
                }

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;

                //---------- check class name is unique
                var className = classDef.Name;
                if (classNameMap.TryGetValue(className, out tempClassDef))
                {
                    result = result.AddError(new ValidationError(
                        ValidationErrorCode.DuplicateClassName,
                        model.Name, classDef.ToTagName(), null, tempClassDef.ToTagName(), null));
                }
                else
                {
                    classNameMap = classNameMap.Add(className, classDef);
                }

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;

                Dictionary<int, ModelFieldDef> fieldTagMap = new Dictionary<int, ModelFieldDef>();
                Dictionary<string, ModelFieldDef> fieldNameMap = new Dictionary<string, ModelFieldDef>();

                foreach (var fieldDef in classDef.FieldDefs)
                {
                    //---------- check field tag is not missing
                    if (!fieldDef.Tag.HasValue)
                        result = result.AddError(
                            new ValidationError(
                                ValidationErrorCode.MissingFieldTag,
                                model.Name, classDef.ToTagName(), fieldDef.ToTagName(), null, null));

                    if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                        return result;

                    //---------- check field tag is unique
                    if (fieldDef.Tag.HasValue)
                    {
                        var fieldTag = fieldDef.Tag.Value;
                        if (fieldTagMap.TryGetValue(fieldTag, out var other1))
                            result = result.AddError(
                                new ValidationError(ValidationErrorCode.DuplicateFieldTag,
                                    model.Name, classDef.ToTagName(), fieldDef.ToTagName(), null, other1.ToTagName()));
                        else
                        {
                            fieldTagMap[fieldTag] = fieldDef;
                        }
                    }

                    if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                        return result;

                    //---------- check field name is unique
                    var fieldName = fieldDef.Name;
                    if (fieldNameMap.TryGetValue(fieldName, out var other2))
                    {
                        result = result.AddError(new ValidationError(
                            ValidationErrorCode.DuplicateFieldName,
                            model.Name, classDef.ToTagName(), fieldDef.ToTagName(), null, other2.ToTagName()));
                    }
                    else
                    {
                        fieldNameMap[fieldName] = fieldDef;
                    }

                    if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                        return result;
                }
            }

            // ---------- check missing base classes
            foreach (var classDef in model.ClassDefs)
            {
                if (classDef.BaseClassName != null)
                {
                    if (classNameMap.TryGetValue(classDef.BaseClassName, out var baseClass))
                    {
                        // known base class - check is abstract
                        if (!baseClass.IsAbstract)
                        {
                            result = result.AddWarning(new ValidationError(
                                ValidationErrorCode.NonAbstractBaseClass,
                                model.Name, classDef.ToTagName(), null, baseClass.ToTagName(), null));
                        }
                    }
                    else
                    {
                        // unknown base class
                        baseClass = new ModelClassDef(classDef.BaseClassName, null, false, null, new List<ModelFieldDef>());
                        result = result.AddError(new ValidationError(
                            ValidationErrorCode.UnknownBaseClass,
                            model.Name, classDef.ToTagName(), null, baseClass.ToTagName(), null));
                    }
                }

                if (errorHandling == ValidationErrorHandling.StopOnFirst && result.HasErrors)
                    return result;
            }

            // ---------- check field data types
            // todo

            // ---------- check circular refs
            foreach (var classDef in model.ClassDefs)
            {
                ImmutableDictionary<string, ModelClassDef> visitedClassDefs =
                    ImmutableDictionary<string, ModelClassDef>.Empty.Add(classDef.Name, classDef);
                result = CheckFieldRecursion(result, errorHandling, metadata, classDef, classNameMap, visitedClassDefs);

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
            ModelClassDef classDef,
            ImmutableDictionary<string, ModelClassDef> allClasses,
            ImmutableDictionary<string, ModelClassDef> visitedClasses
        )
        {
            if (metadata.ModelDefs.Count != 1)
                throw new NotSupportedException("Metadata with multiple models!");
            var model = metadata.ModelDefs[0];

            foreach (var fieldDef in classDef.FieldDefs)
            {
                if (fieldDef.ProxyDef is not null)
                    continue;

                if (IsNativeDataType(fieldDef.InnerType))
                    continue;

                ModelClassDef? otherClass;
                if (allClasses.TryGetValue(fieldDef.InnerType, out otherClass))
                {
                    // known type - check recursion
                    if (visitedClasses.ContainsKey(fieldDef.InnerType))
                    {
                        // circular ref!
                        result = result.AddWarning(new ValidationError(
                            ValidationErrorCode.CircularReference,
                            model.Name, classDef.ToTagName(), fieldDef.ToTagName(), otherClass.ToTagName(), null));
                    }
                    else
                    {
                        // recurse
                        result = CheckFieldRecursion(result, errorHandling, metadata,
                            otherClass, allClasses, visitedClasses.Add(otherClass.Name, otherClass));
                    }
                }
                else
                {
                    // unknown field type
                    result = result.AddError(new ValidationError(
                        ValidationErrorCode.UnknownFieldType,
                        model.Name, classDef.ToTagName(), fieldDef.ToTagName(), null, null));
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
