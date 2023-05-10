using MetaFac.CG4.Models;
using MetaFac.CG4.TextProcessing;
using MetaFac.Platform;
using Microsoft.Extensions.Logging;
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
            var tokens = new Dictionary<string, string>();
            tokens["ModelName"] = modelDef.Name;
            return _engine.NewScope(ImmutableDictionary<string, string>.Empty.AddRange(tokens));
        }

        protected IDisposable NewScope(ModelEntityDef entityDef)
        {
            var tokens = new Dictionary<string, string>();
            tokens["EntityName"] = entityDef.Name;
            tokens["EntityName2"] = entityDef.Name;
            if (entityDef.Tag.HasValue)
                tokens["EntityTag"] = entityDef.Tag.Value.ToString();
            if (entityDef.ParentName is not null)
                tokens["ParentName"] = entityDef.ParentName;
            return _engine.NewScope(ImmutableDictionary<string, string>.Empty.AddRange(tokens));
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
                "string" => "T_StringFieldType_",
                "binary" => "T_BinaryFieldType_",
                _ => innerType,
            };
        }

        protected IDisposable NewScope(ModelFieldDef fieldDef)
        {
            var tokens = new Dictionary<string, string>();
            tokens["FieldName"] = fieldDef.Name;
            if (fieldDef.Tag.HasValue)
                tokens["FieldTag"] = fieldDef.Tag.Value.ToString();
            string innerType = GetFieldTypeToken(fieldDef.InnerType);
            tokens["InnerType"] = innerType;
            if (fieldDef.IsModelType)
                tokens["ModelType"] = innerType;
            if (fieldDef.IndexType != null)
                tokens["IndexType"] = fieldDef.IndexType;
            if (fieldDef.IsBufferType)
                tokens["BufferType"] = true.ToString();
            if (fieldDef.IsStringType)
                tokens["StringType"] = true.ToString();
            if (fieldDef.ProxyDef is not null)
            {
                tokens[$"External{fieldDef.InnerType}"] = fieldDef.ProxyDef.ExternalName ?? "Unknown_Proxy_ExternalName";
                tokens[$"Concrete{fieldDef.InnerType}"] = fieldDef.ProxyDef.ConcreteName ?? "Unknown_Proxy_ConcreteName";
            }
            return _engine.NewScope(ImmutableDictionary<string, string>.Empty.AddRange(tokens));
        }

        protected void DumpTokens()
        {
            _output.Add("//dump: ---------- begin ----------");
            foreach (var kvp in _engine.Current.Scope.Tokens)
            {
                _output.Add($"//dump: {kvp.Key}='{kvp.Value}'");
            }
            _output.Add("//dump: ----------- end -----------");
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