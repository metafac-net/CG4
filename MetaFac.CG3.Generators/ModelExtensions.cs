using MetaFac.CG3.ModelReader;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MetaCode.Generators
{
    public static class ModelExtensions
    {
        private static string ToTargetType(this string typeName, IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue(typeName, out string? targetTypeName))
                return targetTypeName;
            else
                return typeName;
        }
        public static TemplateScope ToFieldIteration(this ModelFieldDef fieldDef, IReadOnlyDictionary<string, string> map)
        {
            var tokens = new Dictionary<string, string>(fieldDef.Tokens);
            tokens["FieldName"] = fieldDef.Name;
            if (fieldDef.Tag.HasValue)
                tokens["FieldTag"] = fieldDef.Tag.Value.ToString();
            tokens["InnerType"] = fieldDef.InnerType.ToTargetType(map);
            if (fieldDef.Nullable)
                tokens["Nullable"] = true.ToString();
            if (fieldDef.ArrayRank > 0)
                tokens["ArrayRank"] = fieldDef.ArrayRank.ToString();
            if (fieldDef.IndexType != null)
                tokens["IndexType"] = fieldDef.IndexType;
            if (fieldDef.IsBufferType)
                tokens["BufferType"] = true.ToString();
            if (fieldDef.IsStringType)
                tokens["StringType"] = true.ToString();
            if(fieldDef.ProxyDef is not null)
            {
                tokens[$"External{fieldDef.InnerType}"] = fieldDef.ProxyDef.ExternalName ?? "Unknown_Proxy_ExternalName";
                tokens[$"Concrete{fieldDef.InnerType}"] = fieldDef.ProxyDef.ConcreteName ?? "Unknown_Proxy_ConcreteName";
            }
            return new TemplateScope(tokens);
        }

        public static TemplateScope ToFullClassIteration(this ModelClassDef classDef, ModelDefinition modelDef, IReadOnlyDictionary<string, string> map)
        {
            var tokens = new Dictionary<string, string>(classDef.Tokens);
            tokens.Add("ClassName", classDef.Name);
            tokens.Add("ClassName2", classDef.Name);
            if (!string.IsNullOrWhiteSpace(classDef.BaseClassName))
            {
                tokens.Add("HasBaseClass", true.ToString());
                tokens.Add("BaseClassName", classDef.BaseClassName!);
            }
            if (classDef.IsAbstract)
                tokens.Add("IsAbstract", "true");
            if (classDef.Tag.HasValue)
                tokens.Add("ClassTag", classDef.Tag?.ToString() ?? "Unknown_Tag");
            var fields = classDef.FieldDefs.Select(fd => fd.ToFieldIteration(map));
            var descendents = modelDef.DescendentsOf(classDef.Name).Select(cd => cd.ToShortClassIteration());
            var allDescendents = modelDef.AllDescendentsOf(classDef.Name).Select(cd => cd.ToShortClassIteration());
            var iterators = ImmutableDictionary<string, TemplateIterator>
                .Empty
                .Add("Fields", new TemplateIterator("Fields", fields))
                .Add("DerivedClasses", new TemplateIterator("DerivedClasses", descendents))
                .Add("AllDerivedClasses", new TemplateIterator("AllDerivedClasses", allDescendents))
                ;
            return new TemplateScope(tokens, iterators);
        }
        public static TemplateScope ToShortClassIteration(this ModelClassDef classDef)
        {
            var tokens = new Dictionary<string, string>(classDef.Tokens);
            tokens.Add("ClassName", classDef.Name);
            tokens.Add("ClassName2", classDef.Name);
            if (classDef.IsAbstract)
                tokens.Add("IsAbstract", "true");
            if (classDef.Tag.HasValue)
                tokens.Add("ClassTag", classDef.Tag?.ToString() ?? "Unknown_Tag");
            var iterators = ImmutableDictionary<string, TemplateIterator>.Empty;
            return new TemplateScope(tokens, iterators);
        }

        public static TemplateScope GetScopeFromMetadata(this ModelContainer metadata)
        {
            var fieldTypeMap = ImmutableDictionary<string, string>.Empty.AddRange(new Dictionary<string, string>()
            {
                ["bool"] = "T_BooleanFieldType_",
                ["int8"] = "T_SByteFieldType_",
                ["uint8"] = "T_ByteFieldType_",
                ["int16"] = "T_Int16FieldType_",
                ["uint16"] = "T_UInt16FieldType_",
                ["char"] = "T_CharFieldType_",
                ["int32"] = "T_Int32FieldType_",
                ["uint32"] = "T_UInt32FieldType_",
                ["single"] = "T_SingleFieldType_",
                ["int64"] = "T_Int64FieldType_",
                ["uint64"] = "T_UInt64FieldType_",
                ["double"] = "T_DoubleFieldType_",
                ["datetime"] = "T_DateTimeFieldType_",
                ["timespan"] = "T_TimeSpanFieldType_",
                ["datetimezone"] = "T_DateTimeZoneFieldType_",
                ["decimal"] = "T_DecimalFieldType_",
                ["guid"] = "T_GuidFieldType_",
                ["string"] = "T_StringFieldType_",
                ["binary"] = "T_BinaryFieldType_",
            });

            var outerTokens = ImmutableDictionary<string, string>.Empty.AddRange(metadata.Tokens);
            var modelDef = metadata.ModelDefs.Single();
            var modelTokens = outerTokens.SetItems(modelDef.Tokens);
            var iterators = ImmutableDictionary<string, TemplateIterator>.Empty
                .Add("Classes", new TemplateIterator("Classes", modelDef.ClassDefs.Select(cd => cd.ToFullClassIteration(modelDef, fieldTypeMap))));
            TemplateScope scope = new TemplateScope(modelTokens, iterators);
            return scope;
        }
    }
}
