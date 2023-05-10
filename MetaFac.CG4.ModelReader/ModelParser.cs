﻿using MetaFac.Memory;
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
        internal static List<ModelClassDef> ParseClasses(string modelName, Assembly sourceAssembly, string sourceNamespace)
        {
            var classDefsByName = new Dictionary<string, ModelClassDef>();
            var classDefsByTag = new Dictionary<int, ModelClassDef>();
            Queue<ClassDefInfo> toBeProcessed = new Queue<ClassDefInfo>();
            var proxyTypes = new ProxyTypeInfoCollection();

            foreach (
                TypeInfo typeInfo in
                sourceAssembly.DefinedTypes.Where(t => t.Namespace == sourceNamespace))
            {
                bool exclude = false;
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
                    else if (attr is ExcludeAttribute excludeAttribute)
                    {
                        exclude = true;
                    }
                }
                if (!exclude)
                {
                    if (proxyAttr is not null)
                    {
                        string typeName = typeInfo.Name;
                        proxyTypes.Add(typeName, new ProxyTypeInfo(proxyAttr.ExternalName, proxyAttr.ConcreteName));
                    }
                    else if (typeInfo.IsClass && entityTag.HasValue)
                    {
                        toBeProcessed.Enqueue(new ClassDefInfo(typeInfo.AsType(), entityTag));
                    }
                }
            }

            while (toBeProcessed.Count > 0)
            {
                ClassDefInfo classDefInfo = toBeProcessed.Dequeue();
                Type classType = classDefInfo.ClassType;
                var className = classType.Name;
                bool isAbstract = classType.IsAbstract;
                int? classTag = classDefInfo.ClassTag;
                var classTagName = new TagName(classTag, className);
                //var classTokens = classDefInfo.ClassTokens;
                bool exclude = false;
                foreach (Attribute attr in classType.GetTypeInfo().GetCustomAttributes(false))
                {
                    if (attr is EntityAttribute tagAttribute)
                    {
                        if (classTag.HasValue && tagAttribute.Tag != classTag.Value)
                            throw new ValidationException(
                                new ValidationError(ValidationErrorCode.RedefinedClassTag, modelName,
                                classTagName, null, new TagName(tagAttribute.Tag, className), null));
                        classTag = tagAttribute.Tag;
                    }

                    if (attr is ExcludeAttribute excludeAttribute)
                    {
                        exclude = true;
                    }
                }

                List<ModelFieldDef> fieldList = ParseFields(classDefInfo, sourceNamespace, modelName, classTagName, proxyTypes);

                if (!exclude && classTag.HasValue)
                {
                    // ensure base class has been processed first
                    Type? baseType = classType.GetTypeInfo().BaseType;
                    string? baseClassName = !(baseType is null) && baseType != typeof(object)
                        ? baseType.Name
                        : null;

                    //if (baseType != null && baseType != typeof(Object))
                    //{
                    //    throw new ValidationException(new ValidationError(ValidationErrorCode.BaseClassNotSupported,
                    //        modelName, new ModelClassDef(classTag, className, null), null,
                    //        new ModelClassDef(null, baseType.Name, null), null));
                    //}

                    var classDef = new ModelClassDef(className, classTag.Value, isAbstract, baseClassName, fieldList);
                    classDefsByName.Add(className, classDef);
                    classDefsByTag.Add(classTag.Value, classDef);
                }

            } // while

            // check for unbound classes
            if (toBeProcessed.Count > 0)
            {
                var classTypeInfo = toBeProcessed.Dequeue();
                var className = classTypeInfo.ClassType.Name;

                throw new ValidationException(new ValidationError(ValidationErrorCode.UnknownBaseClass, modelName, new TagName(null, className), null, null, null));
            }

            return classDefsByName.Values.ToList();

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
            string modelName, TagName classTagName, string fieldName, Type fieldType,
            ProxyTypeInfoCollection proxyTypes)
        {
            var result = new FieldInfo();
            // vector types
            Type? indexType = null;
            // collection types
            Type innerType = fieldType;
            if (innerType.IsArray && innerType.GetArrayRank() == 1)
            {
                result.ArrayRank = 1;
                innerType = innerType.GetElementType() ?? typeof(Unknown);
            }
            else if (innerType.IsConstructedGenericType && (innerType.GetGenericTypeDefinition() == typeof(ImmutableList<>) ||
                                                            innerType.GetGenericTypeDefinition() == typeof(List<>)))
            {
                result.ArrayRank = 1;
                innerType = innerType.GenericTypeArguments[0] ?? typeof(Unknown);
            }
            else if (innerType.IsConstructedGenericType && (innerType.GetGenericTypeDefinition() == typeof(ImmutableDictionary<,>) ||
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
                                    modelName, classTagName, new TagName(null, fieldName, fieldType.FullName), null, null));
                }

            }
            else if (proxyTypes.TryGetValue(innerType.Name, out var _))
            {
                // external type
                result.innerTypeName = innerType.Name;
                result.IsProxy = true;
            }
            else if (innerType.Namespace == sourceNamespace)
            {
                // model type
                result.isModelType = true;
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
                        modelName, classTagName, new TagName(null, fieldName, fieldType.FullName), null, null));
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
            ClassDefInfo classDefInfo, string sourceNamespace, string modelName, TagName classTagName,
            ProxyTypeInfoCollection proxyTypes)
        {
            var classType = classDefInfo.ClassType;
            var fieldDefsByName = new Dictionary<string, ModelFieldDef>();
            // process fields
            // todo include inherited fields?
            foreach (var propInfo in classType.GetRuntimeProperties().Where(p => p.DeclaringType == classType))
            {
                int fieldTag = 0;
                string fieldName = propInfo.Name;
                Type fieldType = propInfo.PropertyType;
                var fieldInfo = GetFieldInfo(sourceNamespace, modelName, classTagName, fieldName, fieldType, proxyTypes);
                string innerTypeName = fieldInfo.innerTypeName ?? nameof(Unknown);
                // emit field tokens
                // todo? emit these tokens later
                //var fieldTokens = new Dictionary<string, string>();
                //if (fieldInfo.isValueType)
                //    fieldTokens.Add("ValueType", innerTypeName);
                //if (fieldInfo.isBufferType)
                //    fieldTokens.Add("BufferType", true.ToString());
                //if (fieldInfo.isStringType)
                //    fieldTokens.Add("StringType", true.ToString());

                bool exclude = false;
                //bool bigEndian = false;
                //int fieldSize = 0;
                //int arraySize = 0;
                foreach (Attribute attr in propInfo.GetCustomAttributes())
                {
                    switch (attr)
                    {
                        case MemberAttribute tagAttribute:
                            fieldTag = tagAttribute.Tag;
                            break;
                        case ExcludeAttribute excludeAttribute:
                            exclude = true;
                            break;
                        //case EndianAttribute endianAttr:
                        //    bigEndian = endianAttr.BigEndian;
                        //    break;
                        //case FieldSizeAttribute fieldSizeAttr:
                        //    fieldSize = fieldSizeAttr.FieldSize;
                        //    break;
                        //case ArraySizeAttribute arraySizeAttr:
                        //    arraySize = arraySizeAttr.ArraySize;
                        //    break;
                        default:
                            break;
                    }

                }

                if (!exclude)
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
            List<ModelClassDef> classList = ParseClasses(modelName, sourceAssembly, sourceNamespace);
            var modelDefinition = new ModelDefinition(modelName, modelTag, classList, modelTokens);

            // derive class hierarchy
            List<ModelClassDef> updatedClassList = new List<ModelClassDef>();
            foreach (var classDef in classList)
            {
                var allDescendents = modelDefinition.AllDescendentsOf(classDef.Name);
                var updatedClassDef = classDef.SetAllDerivedClasses(allDescendents);
                updatedClassList.Add(updatedClassDef);
            }

            modelDefinition = new ModelDefinition(modelName, modelTag, updatedClassList, modelTokens);
            modelDefinitions.Add(modelDefinition);
            return new ModelContainer(modelDefinitions);
        }
    }
}