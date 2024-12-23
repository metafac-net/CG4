using MetaFac.CG4.Models;
using MetaFac.CG4.Schemas;
using MetaFac.Memory;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace MetaFac.CG4.ModelReader
{
    public static class ModelParser
    {
        internal static ModelDefinition ParseEntities(Assembly sourceAssembly, string sourceNamespace)
        {
            string modelName = "Model1";
            int modelTag = 1;
            var entityDefsByName = new Dictionary<string, ModelEntityDef>();
            var entityDefsByTag = new Dictionary<int, ModelEntityDef>();
            var toBeProcessed = new Queue<EntityDefInfo>();
            var allModelTypes = new Dictionary<string, EntityDefInfo>();
            var proxyTypes = new ProxyTypeInfoCollection();
            var enumTypeDefs = new List<ModelEnumTypeDef>();

            foreach (TypeInfo typeInfo in sourceAssembly.DefinedTypes.Where(t => t.Namespace == sourceNamespace))
            {
                ProxyAttribute? proxyAttr = null;
                int? entityTag = null;
                foreach (Attribute attr in typeInfo.GetCustomAttributes(false))
                {
                    if (attr is EntityAttribute ea)
                    {
                        entityTag = ea.Tag;
                    }
                    else if (attr is ProxyAttribute pa)
                    {
                        proxyAttr = pa;
                    }
                }
                if (proxyAttr is not null)
                {
                    string typeName = typeInfo.Name;
                    proxyTypes.Add(typeName, new ProxyTypeInfo(proxyAttr.ExternalName, proxyAttr.ConcreteName));
                }
                else if (typeInfo.IsClass && entityTag.HasValue)
                {
                    var entityInfo = new EntityDefInfo(typeInfo, entityTag);
                    toBeProcessed.Enqueue(entityInfo);
                    allModelTypes.Add(entityInfo.EntityName, entityInfo);
                }
                else if (typeInfo.IsEnum)
                {
                    List<ModelEnumItemDef> enumItemsDefs = new List<ModelEnumItemDef>();
                    foreach (var fieldInfo in typeInfo.DeclaredFields.Where(fi => fi.IsLiteral))
                    {
                        object? enumItemValue = fieldInfo.GetValue(fieldInfo);
                        if (enumItemValue is not null)
                        {
                            int enumItemAsInt = (int)enumItemValue;
                            enumItemsDefs.Add(new ModelEnumItemDef(fieldInfo.Name, enumItemAsInt));
                        }
                    }
                    enumTypeDefs.Add(new ModelEnumTypeDef(typeInfo.Name, enumItemsDefs));
                }
            }

            while (toBeProcessed.Count > 0)
            {
                EntityDefInfo entityDefInfo = toBeProcessed.Dequeue();
                var entityName = entityDefInfo.EntityName;
                int? entityTag = entityDefInfo.Tag;
                string? entityDesc = null;
                ModelItemState? entityState = null;
                var entityTokens = new Dictionary<string, string>();
                var entityTagName = new TagName(entityTag, entityName);
                foreach (Attribute attr in entityDefInfo.CustomAttributes)
                {
                    if (attr is EntityAttribute ea)
                    {
                        if (entityTag.HasValue && ea.Tag != entityTag.Value)
                            throw new ValidationException(
                                new ValidationError(ValidationErrorCode.RedefinedEntityTag, modelName,
                                entityTagName, null, new TagName(ea.Tag, entityName)));
                        entityTag = ea.Tag;
                        entityState = ModelItemState.Create(ea.Deprecated, ea.IsRedacted, ea.Reason);
                    }
                    else if (attr is TokenAttribute ta)
                    {
                        entityTokens[ta.Name] = ta.Value;
                    }
                }

                List<ModelMemberDef> fieldList = ParseFields(entityDefInfo, sourceNamespace, modelName, entityTagName, proxyTypes, allModelTypes);

                if (entityTag.HasValue)
                {
                    bool isAbstract = entityDefInfo.IsAbstract;
                    string? parentName = entityDefInfo.ParentName;
                    var entityDef = new ModelEntityDef(entityName, isAbstract, entityTag.Value, entityDesc, parentName, fieldList, entityState, entityTokens);
                    entityDefsByName.Add(entityName, entityDef);
                    entityDefsByTag.Add(entityTag.Value, entityDef);
                }

            } // while

            // check for unbound entities
            if (toBeProcessed.Count > 0)
            {
                var entityTypeInfo = toBeProcessed.Dequeue();
                var entityName = entityTypeInfo.EntityName;

                throw new ValidationException(new ValidationError(ValidationErrorCode.UnknownParent, modelName, new TagName(null, entityName), null));
            }

            return new ModelDefinition(modelName, modelTag, entityDefsByName.Values, enumTypeDefs);

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
#if NET6_0_OR_GREATER
            if (dataType == typeof(Half)) return "half";
            if (dataType == typeof(DateOnly)) return "date";
            if (dataType == typeof(TimeOnly)) return "time";
#endif
            if (dataType == typeof(BigInteger)) return "bigint";
            if (dataType == typeof(Complex)) return "complex";
            if (dataType == typeof(Version)) return "version";
            return dataType.FullName;
        }

        private class MemberInfo
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

        private static MemberInfo GetFieldInfo(
            string sourceNamespace,
            string modelName, TagName entityTagName, string memberName, Type fieldType,
            ProxyTypeInfoCollection proxyTypes,
            Dictionary<string, EntityDefInfo> allEntityDefs)
        {
            var result = new MemberInfo();
            // vector types
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
                            modelName, entityTagName, new TagName(null, memberName)));
                }
            }
            else if (innerType.IsConstructedGenericType
                && innerType.GenericTypeArguments.Length == 1
                && (innerType.GetGenericTypeDefinition() == typeof(ImmutableList<>)
                    || innerType.GetGenericTypeDefinition() == typeof(List<>)))
            {
                result.ArrayRank = 1;
                innerType = innerType.GenericTypeArguments[0] ?? typeof(Unknown);
            }
            else if (innerType.IsConstructedGenericType
                && innerType.GenericTypeArguments.Length == 2
                && (innerType.GetGenericTypeDefinition() == typeof(ImmutableDictionary<,>)
                    || innerType.GetGenericTypeDefinition() == typeof(Dictionary<,>)))
            {
                result.ArrayRank = 1;
                var indexType = innerType.GenericTypeArguments[0];
                if (indexType.Namespace == sourceNamespace && indexType.IsEnum)
                {
                    // index type must be a model enum
                    result.indexTypeName = indexType.Name;
                }
                else
                {
                    result.indexTypeName = ConvertBuiltinTypeName(indexType);
                }
                innerType = innerType.GenericTypeArguments[1];
            }
            // nullable types
            result.nullable = innerType.IsConstructedGenericType && innerType.GetGenericTypeDefinition() == typeof(Nullable<>);
            if (result.nullable)
                innerType = innerType.GenericTypeArguments[0] ?? typeof(Unknown);
            // unary types
            if (innerType.Namespace == sourceNamespace && innerType.IsClass)
            {
                // must be a model type
                string fieldTypeName = innerType.Name;
                if (allEntityDefs.TryGetValue(fieldTypeName, out var entityInfo))
                {
                    result.isModelType = true;
                    result.innerTypeName = entityInfo.EntityName;
                    return result;
                }
                else
                {
                    // erk!
                    throw new ValidationException(
                        new ValidationError(
                            ValidationErrorCode.UnknownFieldType,
                            modelName, entityTagName, new TagName(null, memberName, fieldTypeName)));
                }
            }
            if (innerType.Namespace == sourceNamespace && innerType.IsEnum)
            {
                // must be a model enum
                result.isValueType = true;
                result.innerTypeName = innerType.Name;
                return result;
            }
            else if (proxyTypes.TryGetValue(innerType.Name, out var _))
            {
                // external type
                result.innerTypeName = innerType.Name;
                result.IsProxy = true;
            }
            else if (innerType.IsValueType)
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

                        if (innerType == typeof(TimeSpan)
                            || innerType == typeof(Guid)
#if NET6_0_OR_GREATER
                            || innerType == typeof(Half)
                            || innerType == typeof(DateOnly)
                            || innerType == typeof(TimeOnly)
#endif
                            || innerType == typeof(BigInteger)
                            || innerType == typeof(Complex)
                            || innerType == typeof(DateTimeOffset))
                        {
                            // supported value type
                            break;
                        }
                        else
                            // unsupported value type!
                            throw new ValidationException(
                                new ValidationError(
                                    ValidationErrorCode.UnknownFieldType,
                                    modelName, entityTagName, new TagName(null, memberName, fieldType.FullName)));
                }

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
            else if(innerType == typeof(Version))
            {
                // version
                innerType = typeof(Version);
                result.nullable = true;
            }
            else
            {
                // unsupported type!
                throw new ValidationException(
                    new ValidationError(
                        ValidationErrorCode.UnknownFieldType,
                        modelName, entityTagName, new TagName(null, memberName, fieldType.FullName)));
            }

            // convert built-in type names
            if (result.innerTypeName is null)
            {
                result.innerTypeName = result.isModelType
                    ? innerType.Name
                    : ConvertBuiltinTypeName(innerType);
            }
            return result;
        }

        internal static List<ModelMemberDef> ParseFields(
            EntityDefInfo entityDefInfo, string sourceNamespace, string modelName, TagName entityTagName,
            ProxyTypeInfoCollection proxyTypes,
            Dictionary<string, EntityDefInfo> allEntityDefs)
        {
            var memberDefsByName = new Dictionary<string, ModelMemberDef>();
            // process fields
            foreach (var propInfo in entityDefInfo.RuntimeProperties)
            {
                string memberName = propInfo.Name;
                int fieldTag = 0;
                string? fieldDesc = null;
                ModelItemState? fieldState = null;
                Type fieldType = propInfo.PropertyType;
                var memberInfo = GetFieldInfo(sourceNamespace, modelName, entityTagName, memberName, fieldType, proxyTypes, allEntityDefs);
                string innerTypeName = memberInfo.innerTypeName ?? nameof(Unknown);

                foreach (Attribute attr in propInfo.GetCustomAttributes())
                {
                    if (attr is MemberAttribute ma)
                    {
                        fieldTag = ma.Tag;
                        //isEmitted = ma.IsEmitted();
                        fieldState = ModelItemState.Create(ma.Deprecated, ma.IsRedacted, ma.Reason);
                    }
                }

                bool isVector = memberInfo.ArrayRank == 1;
                string typeDesc = $"{innerTypeName}{(memberInfo.nullable ? "?" : "")}{(isVector ? "[" : "")}{memberInfo.indexTypeName}{(isVector ? "]" : "")}";
                ModelProxyDef? proxyDef = null;
                if (memberInfo.IsProxy
                    && proxyTypes.TryGetValue(innerTypeName, out var pd)
                    && pd is not null)
                {
                    proxyDef = new ModelProxyDef(pd.ExternalName, pd.ConcreteName);
                }
                var memberDef = new ModelMemberDef(
                    memberName, fieldTag, fieldDesc,
                    innerTypeName,
                    memberInfo.nullable,
                    proxyDef,
                    memberInfo.ArrayRank,
                    memberInfo.indexTypeName,
                    memberInfo.isModelType,
                    fieldState);
                memberDefsByName.Add(memberName, memberDef);
            } // foreach field
            return memberDefsByName.Values.OrderBy(x => x.Tag).ToList();
        }

        private static string GetMetadataSourceDisplayString(Assembly sourceAssembly, string? sourceNamespace)
        {
            string assemblyName = sourceAssembly.GetName().Name ?? "Unknown";
            if (sourceNamespace is null
                || string.IsNullOrWhiteSpace(sourceNamespace)
                || string.Equals(sourceNamespace, assemblyName))
                return assemblyName;

            return sourceNamespace.StartsWith(assemblyName)
                ? $"{assemblyName}({sourceNamespace.Substring(assemblyName.Length)})"
                : $"{assemblyName}({sourceNamespace})";
        }

        /// <summary>
        /// Scans the assembly namespace containing the source type for CG4 models.
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="sourceNamespace"></param>
        /// <returns></returns>
        public static ModelContainer ParseAssembly(Type sourceType, string? sourceNamespace = null)
        {
            return ParseAssembly(sourceType.Assembly, sourceNamespace ?? sourceType.Namespace!);
        }

        /// <summary>
        /// Scans the assembly namespace for CG4 models.
        /// </summary>
        /// <param name="sourceAssembly"></param>
        /// <param name="sourceNamespace"></param>
        /// <returns></returns>
        public static ModelContainer ParseAssembly(Assembly sourceAssembly, string sourceNamespace)
        {
            var model = ParseEntities(sourceAssembly, sourceNamespace);
            var tokens = new Dictionary<string, string>();
            tokens["Metadata"] = GetMetadataSourceDisplayString(sourceAssembly, sourceNamespace);
            return new ModelContainer(new ModelDefinition[] { model }, tokens);
        }
    }
}