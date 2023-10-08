using MetaFac.CG4.Models;
using System;
using System.Collections.Generic;

namespace MetaFac.CG4.Generators
{
    public abstract class GeneratorBase
    {
        protected readonly TemplateEngine _engine = new TemplateEngine();
        private readonly List<string> _output = new List<string>();

        private readonly string _shortName;
        public string ShortName => _shortName;

        private readonly string _fullName;
        public string FullName => _fullName;

        protected GeneratorBase(string generatorId)
        {
            Version av = new Version(ThisAssembly.AssemblyFileVersion);
            _shortName = $"{generatorId}.{av.Major}.{av.Minor}";
            _fullName = $"{ThisAssembly.AssemblyName}.{generatorId}.{av.Major}.{av.Minor}.{av.Revision}.{av.Build}";
        }

        protected void Emit(string encodedOutput)
        {
            if (!_engine.Current.Ignored)
            {
                string templateLine = encodedOutput;
                string? replacedLine = _engine.Current.ReplaceTokens(templateLine);
                _output.Add(replacedLine ?? "");
            }
        }

        protected void Define(string name, string value)
        {
            _engine.Current.SetToken(name, value);
        }

        protected void DefineCSharpTypes()
        {
            var tokens = new Dictionary<string, string>()
            {
                // Boolean
                ["BooleanFieldType"] = "Boolean",
                ["ConcreteBoolean"] = "T_BooleanFieldType_",
                ["ExternalBoolean"] = "T_BooleanFieldType_",
                // SByte
                ["SByteFieldType"] = "SByte",
                ["ConcreteSByte"] = "T_SByteFieldType_",
                ["ExternalSByte"] = "T_SByteFieldType_",
                // Byte
                ["ByteFieldType"] = "Byte",
                ["ConcreteByte"] = "T_ByteFieldType_",
                ["ExternalByte"] = "T_ByteFieldType_",
                // Int16
                ["Int16FieldType"] = "Int16",
                ["ConcreteInt16"] = "T_Int16FieldType_",
                ["ExternalInt16"] = "T_Int16FieldType_",
                // UInt16
                ["UInt16FieldType"] = "UInt16",
                ["ConcreteUInt16"] = "T_UInt16FieldType_",
                ["ExternalUInt16"] = "T_UInt16FieldType_",
                // Char
                ["CharFieldType"] = "Char",
                ["ConcreteChar"] = "T_CharFieldType_",
                ["ExternalChar"] = "T_CharFieldType_",
                // Int32
                ["Int32FieldType"] = "Int32",
                ["ConcreteInt32"] = "T_Int32FieldType_",
                ["ExternalInt32"] = "T_Int32FieldType_",
                // UInt32
                ["UInt32FieldType"] = "UInt32",
                ["ConcreteUInt32"] = "T_UInt32FieldType_",
                ["ExternalUInt32"] = "T_UInt32FieldType_",
                // Single
                ["SingleFieldType"] = "Single",
                ["ConcreteSingle"] = "T_SingleFieldType_",
                ["ExternalSingle"] = "T_SingleFieldType_",
                // Int64
                ["Int64FieldType"] = "Int64",
                ["ConcreteInt64"] = "T_Int64FieldType_",
                ["ExternalInt64"] = "T_Int64FieldType_",
                // UInt64
                ["UInt64FieldType"] = "UInt64",
                ["ConcreteUInt64"] = "T_UInt64FieldType_",
                ["ExternalUInt64"] = "T_UInt64FieldType_",
                // Double
                ["DoubleFieldType"] = "Double",
                ["ConcreteDouble"] = "T_DoubleFieldType_",
                ["ExternalDouble"] = "T_DoubleFieldType_",
                // DateTime
                ["DateTimeFieldType"] = "DateTime",
                ["ConcreteDateTime"] = "T_DateTimeFieldType_",
                ["ExternalDateTime"] = "T_DateTimeFieldType_",
                // TimeSpan
                ["TimeSpanFieldType"] = "TimeSpan",
                ["ConcreteTimeSpan"] = "T_TimeSpanFieldType_",
                ["ExternalTimeSpan"] = "T_TimeSpanFieldType_",
                // Guid
                ["GuidFieldType"] = "Guid",
                ["ConcreteGuid"] = "T_GuidFieldType_",
                ["ExternalGuid"] = "T_GuidFieldType_",
                // Decimal
                ["DecimalFieldType"] = "Decimal",
                ["ConcreteDecimal"] = "T_DecimalFieldType_",
                ["ExternalDecimal"] = "T_DecimalFieldType_",
                // DateTimeOffset
                ["DateTimeOffsetFieldType"] = "DateTimeOffset",
                ["ConcreteDateTimeOffset"] = "T_DateTimeOffsetFieldType_",
                ["ExternalDateTimeOffset"] = "T_DateTimeOffsetFieldType_",
                // String
                ["StringFieldType"] = "String",
                ["ConcreteString"] = "T_StringFieldType_",
                ["ExternalString"] = "T_StringFieldType_",
                // Binary
                ["BinaryFieldType"] = "Octets",
                ["ConcreteBinary"] = "T_BinaryFieldType_",
                ["ExternalBinary"] = "T_BinaryFieldType_",
                // Half
                ["HalfFieldType"] = "Half",
                ["ConcreteHalf"] = "T_HalfFieldType_",
                ["ExternalHalf"] = "T_HalfFieldType_",
            };
            _engine.Current.SetTokens(tokens);
        }

        protected bool IsDefined(string name)
        {
            return _engine.Current.Scope.Tokens.TryGetValue(name, out string? value)
                ? !string.IsNullOrEmpty(value)
                : false;
        }

        protected IDisposable Ignored()
        {
            return _engine.Ignore();
        }

        protected IDisposable NewScope(ModelContainer container)
        {
            return _engine.NewScope(container.Tokens);
        }

        protected IDisposable NewScope(ModelDefinition modelDef)
        {
            var tokens = new Dictionary<string, string>
            {
                ["ModelName"] = modelDef.Name
            };
            return _engine.NewScope(tokens);
        }

        protected IDisposable NewScope(ModelEntityDef entityDef)
        {
            var tokens = new Dictionary<string, string>
            {
                ["EntityName"] = entityDef.Name,
                ["EntityName2"] = entityDef.Name
            };
            if (entityDef.Tag.HasValue)
                tokens["EntityTag"] = entityDef.Tag.Value.ToString();
            if (entityDef.ParentName is not null)
                tokens["ParentName"] = entityDef.ParentName;
            return _engine.NewScope(tokens);
        }

        private static string GetFieldTypeToken(string innerType)
        {
            return innerType switch
            {
                "bool" => "T_BooleanFieldType_",
                "int8" => "T_SByteFieldType_",
                "uint8" => "T_ByteFieldType_",
                "int16" => "T_Int16FieldType_",
                "uint16" => "T_UInt16FieldType_",
                "char" => "T_CharFieldType_",
                "int32" => "T_Int32FieldType_",
                "uint32" => "T_UInt32FieldType_",
                "single" => "T_SingleFieldType_",
                "int64" => "T_Int64FieldType_",
                "uint64" => "T_UInt64FieldType_",
                "double" => "T_DoubleFieldType_",
                "datetime" => "T_DateTimeFieldType_",
                "timespan" => "T_TimeSpanFieldType_",
                "datetimezone" => "T_DateTimeOffsetFieldType_",
                "decimal" => "T_DecimalFieldType_",
                "guid" => "T_GuidFieldType_",
                "string" => "T_StringFieldType_",
                "binary" => "T_BinaryFieldType_",
                "half" => "T_HalfFieldType_",
                _ => innerType,
            };
        }

        protected IDisposable NewScope(ModelMemberDef memberDef)
        {
            string innerType = GetFieldTypeToken(memberDef.InnerType);
            string? indexType = memberDef.IndexType is null ? null : GetFieldTypeToken(memberDef.IndexType);
            var tokens = new Dictionary<string, string>
            {
                ["FieldName"] = memberDef.Name,
                ["InnerType"] = innerType,
            };
            if (memberDef.Tag.HasValue)
                tokens["FieldTag"] = memberDef.Tag.Value.ToString();
            if (memberDef.IsModelType)
                tokens["ModelType"] = innerType;
            if (indexType is not null)
                tokens["IndexType"] = indexType;
#if NET6_0_OR_GREATER
            tokens.TryAdd($"External{memberDef.InnerType}", innerType);
            tokens.TryAdd($"Concrete{memberDef.InnerType}", innerType);
#else
            string externalInnerType = $"External{memberDef.InnerType}";
            if (!tokens.ContainsKey(externalInnerType)) tokens.Add(externalInnerType, innerType);
            string concreteInnerType = $"Concrete{memberDef.InnerType}";
            if (!tokens.ContainsKey(concreteInnerType)) tokens.Add(concreteInnerType, innerType);
#endif
            if (memberDef.ProxyDef is not null)
            {
                tokens[$"External{memberDef.InnerType}"] = memberDef.ProxyDef.ExternalName ?? "Unknown_Proxy_ExternalName";
                tokens[$"Concrete{memberDef.InnerType}"] = memberDef.ProxyDef.ConcreteName ?? "Unknown_Proxy_ConcreteName";
            }
            return _engine.NewScope(tokens);
        }

        protected IDisposable NewScope(ModelEnumTypeDef enumTypeDef)
        {
            var tokens = new Dictionary<string, string>
            {
                ["EnumTypeName"] = enumTypeDef.Name
            };
            return _engine.NewScope(tokens);
        }

        protected IDisposable NewScope(ModelEnumItemDef enumItemDef)
        {
            var tokens = new Dictionary<string, string>
            {
                ["EnumItemName"] = enumItemDef.Name,
                ["EnumItemValue"] = enumItemDef.Value.ToString()
            };
            if (enumItemDef.Summary is not null)
            {
                tokens["ItemSummary"] = enumItemDef.Summary;
            }
            if (enumItemDef.State is not null && enumItemDef.State.IsInactive)
            {
                tokens["ObsoleteReason"] = enumItemDef.State.Reason ?? "Deprecated";
            }
            return _engine.NewScope(tokens);
        }

        protected abstract void OnGenerate(ModelDefinition outerScope);

        /// <summary>
        /// Generates output using the supplied metadata and options.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">metadata</exception>
        public IEnumerable<string> Generate(ModelContainer metadata)
        {
            if (metadata is null) throw new ArgumentNullException(nameof(metadata));
            if (metadata.ModelDefs.Count != 1)
                throw new NotSupportedException("Metadata with multiple models!");

            var modelDef = metadata.ModelDefs[0];

            using (NewScope(metadata.SetToken("Generator", _shortName)))
            using (NewScope(modelDef))
            {
                OnGenerate(modelDef);
                foreach (var line in _output)
                {
                    yield return line;
                }
            }
        }

    }
}