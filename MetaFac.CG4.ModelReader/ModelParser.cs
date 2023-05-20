using MetaFac.Memory;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using MetaFac.CG4.Models;
using MetaFac.CG4.Schemas;

namespace MetaFac.CG4.ModelReader
{
    public static class ModelParser
    {
        internal static List<ModelEntityDef> ParseEntities(string modelName, Assembly sourceAssembly, string sourceNamespace)
        {
            var entityDefsByName = new Dictionary<string, ModelEntityDef>();
            var entityDefsByTag = new Dictionary<int, ModelEntityDef>();
            Queue<EntityDefInfo> toBeProcessed = new Queue<EntityDefInfo>();
            Dictionary<string, EntityDefInfo> allModelTypes = new Dictionary<string, EntityDefInfo>();
            var proxyTypes = new ProxyTypeInfoCollection();

            foreach (TypeInfo typeInfo in sourceAssembly.DefinedTypes.Where(t => t.Namespace == sourceNamespace))
            {
                bool obsolete = false;
                ProxyAttribute? proxyAttr = null;
                int? entityTag = null;
                foreach (Attribute attr in typeInfo.GetCustomAttributes(false))
                {
                    if (attr is EntityAttribute tagAttribute)
                    {
                        entityTag = tagAttribute.Tag;
                    }
                    else if (attr is ProxyAttribute pa)
                    {
                        proxyAttr = pa;
                    }
                    else if (attr is ObsoleteAttribute oa && oa.IsError)
                    {
                        obsolete = true;
                    }
                }
                if (!obsolete)
                {
                    if (proxyAttr is not null)
                    {
                        string typeName = typeInfo.Name;
                        proxyTypes.Add(typeName, new ProxyTypeInfo(proxyAttr.ExternalName, proxyAttr.ConcreteName));
                    }
                    else if (typeInfo.IsInterface && typeInfo.Name.StartsWith("I") && entityTag.HasValue)
                    {
                        var entityInfo = new EntityDefInfo(typeInfo, entityTag);
                        toBeProcessed.Enqueue(entityInfo);
                        allModelTypes.Add(entityInfo.EntityName, entityInfo);
                    }
                }
            }

            while (toBeProcessed.Count > 0)
            {
                EntityDefInfo entityDefInfo = toBeProcessed.Dequeue();
                //Type entityType = entityDefInfo.Type;
                var entityName = entityDefInfo.EntityName;
                bool isAbstract = entityDefInfo.IsAbstract;
                int? entityTag = entityDefInfo.Tag;
                var entityTagName = new TagName(entityTag, entityName);
                bool obsolete = false;
                foreach (Attribute attr in entityDefInfo.CustomAttributes)
                {
                    if (attr is EntityAttribute tagAttribute)
                    {
                        if (entityTag.HasValue && tagAttribute.Tag != entityTag.Value)
                            throw new ValidationException(
                                new ValidationError(ValidationErrorCode.RedefinedEntityTag, modelName,
                                entityTagName, null, new TagName(tagAttribute.Tag, entityName), null));
                        entityTag = tagAttribute.Tag;
                    }

                    if (attr is ObsoleteAttribute oa && oa.IsError)
                    {
                        obsolete = true;
                    }
                }

                List<ModelFieldDef> fieldList = ParseFields(entityDefInfo, sourceNamespace, modelName, entityTagName, proxyTypes, allModelTypes);

                if (!obsolete && entityTag.HasValue)
                {
                    // ensure parent has been processed first
                    //Type? baseType = entityDefInfo.BaseType;
                    //string? parentName = !(baseType is null) && baseType != typeof(object)
                    //    ? baseType.Name
                    //    : null;
                    string? parentName = entityDefInfo.ParentName;
                    //if (baseType != null && baseType != typeof(Object))
                    //{
                    //    throw new ValidationException(new ValidationError(ValidationErrorCode.ParentNotSupported,
                    //        modelName, new ModelEntityDef(entityTag, entityName, null), null,
                    //        new ModelEntityDef(null, baseType.Name, null), null));
                    //}

                    var entityDef = new ModelEntityDef(entityName, entityTag.Value, isAbstract, parentName, fieldList);
                    entityDefsByName.Add(entityName, entityDef);
                    entityDefsByTag.Add(entityTag.Value, entityDef);
                }

            } // while

            // check for unbound entities
            if (toBeProcessed.Count > 0)
            {
                var entityTypeInfo = toBeProcessed.Dequeue();
                var entityName = entityTypeInfo.EntityName;

                throw new ValidationException(new ValidationError(ValidationErrorCode.UnknownParent, modelName, new TagName(null, entityName), null, null, null));
            }

            return entityDefsByName.Values.ToList();

        }

        internal static string? ConvertBuiltinTypeName(Type? dataType)
        {
            if (dataType is null) return null;
            if (dataType.IsEnum) return dataType.FullName;
            var typeCode = Type.GetTypeCode(dataType);
            switch (typeCode)
            {
                case TypeCode.Boolean: return "bool";
                case TypeCode.SByte: return "int8";
                case TypeCode.Byte: return "uint8";
                case TypeCode.Int16: return "int16";
                case TypeCode.UInt16: return "uint16";
                case TypeCode.Char: return "char";
                case TypeCode.Int32: return "int32";
                case TypeCode.UInt32: return "uint32";
                case TypeCode.Single: return "single";
                case TypeCode.Int64: return "int64";
                case TypeCode.UInt64: return "uint64";
                case TypeCode.DateTime: return "datetime";
                case TypeCode.Double: return "double";
                case TypeCode.Decimal: return "decimal";
                case TypeCode.String: return "string";
            }
            if (dataType == typeof(TimeSpan)) return "timespan";
            if (dataType == typeof(DateTimeOffset)) return "datetimezone";
            if (dataType == typeof(Guid)) return "guid";
            if (dataType == typeof(Octets)) return "binary";
            return dataType.FullName;
        }

        private class FieldInfo
        {
            public bool nullable = false;
            public bool IsProxy = false;
            public int ArrayRank = 0;
            public bool isModelType = false;
            public bool isValueType = false;
            public bool isBufferType = false;
            public bool isStringType = false;
            public string? innerTypeName = null;
            public string? indexTypeName = null;
        }

        private static FieldInfo GetFieldInfo(
            string sourceNamespace,
            string modelName, TagName entityTagName, string fieldName, Type fieldType,
            ProxyTypeInfoCollection proxyTypes,
            Dictionary<string, EntityDefInfo> allModelTypes)
        {
            var result = new FieldInfo();
            // vector types
            Type? indexType = null;
            // collection types
            Type innerType = fieldType;
            if (innerType.IsArray)
            {
                if (innerType.GetArrayRank() == 1)
                {
                    result.ArrayRank = 1;
                    innerType = innerType.GetElementType() ?? typeof(Unknown);
                }
                else
                {
                    // erk!
                    throw new ValidationException(
                        new ValidationError(
                            ValidationErrorCode.InvalidArrayRank,
                            modelName, entityTagName, new TagName(null, fieldName, null), null, null));
                }
            }
            else if (innerType.IsConstructedGenericType
                && innerType.GenericTypeArguments.Length == 1
                && (innerType.GetGenericTypeDefinition() == typeof(ImmutableList<>) ||
                                                            innerType.GetGenericTypeDefinition() == typeof(List<>)))
            {
                result.ArrayRank = 1;
                innerType = innerType.GenericTypeArguments[0] ?? typeof(Unknown);
            }
            else if (innerType.IsConstructedGenericType
                && innerType.GenericTypeArguments.Length == 2
                && (innerType.GetGenericTypeDefinition() == typeof(ImmutableDictionary<,>) ||
                                                            innerType.GetGenericTypeDefinition() == typeof(Dictionary<,>)))
            {
                result.ArrayRank = 1;
                indexType = innerType.GenericTypeArguments[0];
                innerType = innerType.GenericTypeArguments[1];
            }
            // nullable types
            result.nullable = innerType.IsConstructedGenericType && innerType.GetGenericTypeDefinition() == typeof(Nullable<>);
            if (result.nullable)
                innerType = innerType.GenericTypeArguments[0] ?? typeof(Unknown);
            // unary types
            if (innerType.Namespace == sourceNamespace && innerType.IsInterface)
            {
                // must be a model type
                string fieldTypeName = innerType.Name.Substring(1);
                if(allModelTypes.TryGetValue(fieldTypeName, out var entityInfo))
                {
                    result.isModelType = true;
                    result.innerTypeName = entityInfo.EntityName;
                    result.indexTypeName = ConvertBuiltinTypeName(indexType);
                    return result;
                }
                else
                {
                    // erk!
                    throw new ValidationException(
                        new ValidationError(
                            ValidationErrorCode.UnknownFieldType,
                            modelName, entityTagName, new TagName(null, fieldName, fieldTypeName), null, null));
                }
            }
            if (innerType.IsValueType)
            {
                // value type
                result.isValueType = true;
                switch (Type.GetTypeCode(innerType))
                {
                    case TypeCode.Char:
                    case TypeCode.Byte:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        break;
                    case TypeCode.SByte:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                        break;
                    case TypeCode.Decimal:
                    case TypeCode.Double:
                    case TypeCode.Single:
                    case TypeCode.Boolean:
                    case TypeCode.DateTime:
                        break;
                    default:

                        if (innerType == typeof(DateTimeOffset)
                            || innerType == typeof(TimeSpan)
                            || innerType == typeof(Guid))
                        {
                            // supported value type
                            break;
                        }
                        else if (proxyTypes.TryGetValue(innerType.Name, out var _))
                        {
                            // external type
                            result.innerTypeName = innerType.Name;
                            result.IsProxy = true;
                            break;
                        }
                        else
                            // unsupported value type!
                            throw new ValidationException(
                                new ValidationError(
                                    ValidationErrorCode.UnknownFieldType,
                                    modelName, entityTagName, new TagName(null, fieldName, fieldType.FullName), null, null));
                }

            }
            else if (proxyTypes.TryGetValue(innerType.Name, out var _))
            {
                // external type
                result.innerTypeName = innerType.Name;
                result.IsProxy = true;
            }
            else if (innerType == typeof(string))
            {
                // string type
                result.isStringType = true;
                innerType = typeof(string);
            }
            else if (innerType == typeof(Octets)
                    || innerType == typeof(ArraySegment<byte>)
                    || innerType == typeof(Memory<byte>)
                    || innerType == typeof(ReadOnlyMemory<byte>)
                    || innerType == typeof(ReadOnlySequence<byte>)
                    )
            {
                // buffer type
                result.isBufferType = true;
                innerType = typeof(Octets);
            }
            else
            {
                // unsupported type!
                throw new ValidationException(
                    new ValidationError(
                        ValidationErrorCode.UnknownFieldType,
                        modelName, entityTagName, new TagName(null, fieldName, fieldType.FullName), null, null));
            }

            // convert built-in type names
            if (result.innerTypeName is null)
            {
                result.innerTypeName = result.isModelType
                    ? innerType.Name
                    : ConvertBuiltinTypeName(innerType);
            }
            result.indexTypeName = ConvertBuiltinTypeName(indexType);
            return result;
        }

        internal static List<ModelFieldDef> ParseFields(
            EntityDefInfo entityDefInfo, string sourceNamespace, string modelName, TagName entityTagName,
            ProxyTypeInfoCollection proxyTypes,
            Dictionary<string, EntityDefInfo> allModelTypes)
        {
            var fieldDefsByName = new Dictionary<string, ModelFieldDef>();
            // process fields
            foreach (var propInfo in entityDefInfo.RuntimeProperties)
            {
                int fieldTag = 0;
                string fieldName = propInfo.Name;
                Type fieldType = propInfo.PropertyType;
                var fieldInfo = GetFieldInfo(sourceNamespace, modelName, entityTagName, fieldName, fieldType, proxyTypes, allModelTypes);
                string innerTypeName = fieldInfo.innerTypeName ?? nameof(Unknown);

                bool obsolete = false;
                foreach (Attribute attr in propInfo.GetCustomAttributes())
                {
                    if (attr is MemberAttribute ma)
                    {
                        fieldTag = ma.Tag;
                    }
                    else if (attr is ObsoleteAttribute oa && oa.IsError)
                    {
                        obsolete = true;
                    }
                }

                if (!obsolete)
                {
                    bool isVector = fieldInfo.ArrayRank == 1;
                    string typeDesc = $"{innerTypeName}{(fieldInfo.nullable ? "?" : "")}{(isVector ? "[" : "")}{fieldInfo.indexTypeName}{(isVector ? "]" : "")}";
                    ModelProxyDef? proxyDef = null;
                    if (fieldInfo.IsProxy
                        && proxyTypes.TryGetValue(innerTypeName, out var pd)
                        && pd is not null)
                    {
                        proxyDef = new ModelProxyDef(pd.ExternalName, pd.ConcreteName);
                    }
                    var fieldDef = new ModelFieldDef(
                        fieldName, fieldTag, innerTypeName,
                        fieldInfo.nullable,
                        proxyDef,
                        fieldInfo.ArrayRank,
                        fieldInfo.indexTypeName,
                        fieldInfo.isModelType);
                    fieldDefsByName.Add(fieldName, fieldDef);
                }
            } // foreach field
            return fieldDefsByName.Values.OrderBy(x => x.Tag).ToList();
        }

        public static ModelContainer ParseAssembly(Assembly sourceAssembly, string sourceNamespace)
        {
            List<ModelDefinition> modelDefinitions = new List<ModelDefinition>();
            int modelTag = 1;
            string modelName = "Model1";
            var modelTokens = new Dictionary<string, string>();
            List<ModelEntityDef> entityListA = ParseEntities(modelName, sourceAssembly, sourceNamespace);
            var modelDefinition = new ModelDefinition(modelName, modelTag, entityListA, modelTokens);

            // derive class hierarchy
            var entityListB = new List<ModelEntityDef>();
            foreach (var entityDef in entityListA)
            {
                var allDescendents = modelDefinition.AllDescendentsOf(entityDef.Name);
                var updatedEntityDef = entityDef.SetDerivedEntities(allDescendents);
                entityListB.Add(updatedEntityDef);
            }

            modelDefinition = new ModelDefinition(modelName, modelTag, entityListB, modelTokens);
            modelDefinitions.Add(modelDefinition);
            return new ModelContainer(modelDefinitions);
        }
    }
}