using MetaFac.CG4.Models;
using MetaFac.CG4.TextProcessing;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Xml.Linq;

namespace MetaFac.CG4.Generators
{
    public abstract class GeneratorBase
    {
        protected readonly TemplateEngine _engine = new TemplateEngine();
        private readonly List<string> _output = new List<string>();

        private readonly string _shortName;
        public string ShortName => _shortName;

        protected GeneratorBase(string shortName)
        {
            _shortName = shortName;
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

        protected bool IsDefined(string name)
        {
            return _engine.Current.Scope.Tokens.ContainsKey(name);
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
                "datetimezone" => "T_DateTimeZoneFieldType_",
                "decimal" => "T_DecimalFieldType_",
                "guid" => "T_GuidFieldType_",
                _ => innerType,
            };
        }

        protected IDisposable NewScope(ModelMemberDef memberDef)
        {
            string innerType = GetFieldTypeToken(memberDef.InnerType);
            var tokens = new Dictionary<string, string>
            {
                ["FieldName"] = memberDef.Name,
                ["InnerType"] = innerType,
        };
            if (memberDef.Tag.HasValue)
                tokens["FieldTag"] = memberDef.Tag.Value.ToString();
            if (memberDef.IsModelType)
                tokens["ModelType"] = innerType;
            if (memberDef.IndexType != null)
                tokens["IndexType"] = memberDef.IndexType;
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
            if (enumItemDef.IsObsolete(out string reason, out bool isError))
            {
                tokens["ObsoleteReason"] = reason;
                // todo isError
            }
            return _engine.NewScope(tokens);
        }

        protected abstract void OnGenerate(ModelDefinition outerScope);

        /// <summary>
        /// Generates output using the supplied metadata and options.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// metadata
        /// or
        /// options
        /// </exception>
        public IEnumerable<string> Generate(ModelContainer metadata)
        {
            if (metadata is null) throw new ArgumentNullException(nameof(metadata));
            if (metadata.ModelDefs.Count != 1)
                throw new NotSupportedException("Metadata with multiple models!");
            var modelDef = metadata.ModelDefs[0];

            using (NewScope(metadata))
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