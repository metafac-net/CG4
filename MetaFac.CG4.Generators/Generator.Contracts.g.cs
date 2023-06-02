//------------------------------------------------------------------------------
//   Warning: This code was automatically generated.
//   Changes to this file may cause incorrect behavior
//   and will be lost when this file is regenerated.
//------------------------------------------------------------------------------
//
// |metacode:version=0.1|
// |metacode:generator_header|
using System;
using System.Linq;
using MetaFac.CG4.Generators;
using MetaFac.CG4.Models;
namespace MetaFac.CG4.Generator.Contracts
{
    public partial class Generator : GeneratorBase
    {
        public Generator() : base("Contracts") { }
        protected override void OnGenerate(ModelDefinition outerScope)
        {
// |metacode:generator_body|
Define("BooleanFieldType", "Boolean");
Define("SByteFieldType", "SByte");
Define("ByteFieldType", "Byte");
Define("Int16FieldType", "Int16");
Define("UInt16FieldType", "UInt16");
Define("CharFieldType", "Char");
Define("Int32FieldType", "Int32");
Define("UInt32FieldType", "UInt32");
Define("SingleFieldType", "Single");
Define("Int64FieldType", "Int64");
Define("UInt64FieldType", "UInt64");
Define("DoubleFieldType", "Double");
Define("DateTimeFieldType", "DateTime");
Define("TimeSpanFieldType", "TimeSpan");
Define("DateTimeZoneFieldType", "DateTimeOffset");
Define("DecimalFieldType", "Decimal");
Define("GuidFieldType", "Guid");
Define("ConcreteBoolean", "T_BooleanFieldType_");
Define("ConcreteSByte", "T_SByteFieldType_");
Define("ConcreteByte", "T_ByteFieldType_");
Define("ConcreteInt16", "T_Int16FieldType_");
Define("ConcreteUInt16", "T_UInt16FieldType_");
Define("ConcreteChar", "T_CharFieldType_");
Define("ConcreteInt32", "T_Int32FieldType_");
Define("ConcreteUInt32", "T_UInt32FieldType_");
Define("ConcreteSingle", "T_SingleFieldType_");
Define("ConcreteInt64", "T_Int64FieldType_");
Define("ConcreteUInt64", "T_UInt64FieldType_");
Define("ConcreteDouble", "T_DoubleFieldType_");
Define("ConcreteDateTime", "T_DateTimeFieldType_");
Define("ConcreteTimeSpan", "T_TimeSpanFieldType_");
Define("ConcreteDateTimeOffset", "T_DateTimeZoneFieldType_");
Define("ConcreteDecimal", "T_DecimalFieldType_");
Define("ConcreteGuid", "T_GuidFieldType_");
Define("ExternalBoolean", "T_BooleanFieldType_");
Define("ExternalSByte", "T_SByteFieldType_");
Define("ExternalByte", "T_ByteFieldType_");
Define("ExternalInt16", "T_Int16FieldType_");
Define("ExternalUInt16", "T_UInt16FieldType_");
Define("ExternalChar", "T_CharFieldType_");
Define("ExternalInt32", "T_Int32FieldType_");
Define("ExternalUInt32", "T_UInt32FieldType_");
Define("ExternalSingle", "T_SingleFieldType_");
Define("ExternalInt64", "T_Int64FieldType_");
Define("ExternalUInt64", "T_UInt64FieldType_");
Define("ExternalDouble", "T_DoubleFieldType_");
Define("ExternalDateTime", "T_DateTimeFieldType_");
Define("ExternalTimeSpan", "T_TimeSpanFieldType_");
Define("ExternalDateTimeOffset", "T_DateTimeZoneFieldType_");
Define("ExternalDecimal", "T_DecimalFieldType_");
Define("ExternalGuid", "T_GuidFieldType_");
Define("ParentName", "EntityBase");
Emit("#region Notices");
Emit("// <auto-generated>");
Emit("// Warning: This file was automatically generated. Changes to this file may");
Emit("// cause incorrect behavior and will be lost when this file is regenerated.");
Emit("// </auto-generated>");
if (IsDefined("CopyrightInfo"))
{
Emit("// <copyright>");
Emit("//     T_CopyrightInfo_");
Emit("// </copyright>");
}
Emit("// <information>");
Emit("// This file was generated using MetaFac.CG4 tools and user supplied metadata.");
Emit("// Generator: T_Generator_");
Emit("// Metadata : T_Metadata_");
Emit("// </information>");
Emit("#endregion");
Emit("#nullable enable");
Emit("#pragma warning disable CS8019 // Unnecessary using directive");
Emit("using MetaFac.Memory;");
Emit("using MetaFac.Mutability;");
Emit("using MetaFac.CG4.Runtime;");
Emit("using System;");
Emit("using System.Collections.Generic;");
Emit("");
Emit("namespace T_Namespace_.Contracts");
Emit("{");
    using (Ignored())
    {
Emit("    using T_ExternalOtherType_ = System.Int64;");
Emit("    using T_IndexType_ = System.String;");
    }
    foreach (var ed in outerScope.EnumTypeDefs)
    {
        using (NewScope(ed))
        {
Emit("    public enum T_EnumTypeName_");
Emit("    {");
        using (Ignored())
        {
Emit("        T_EnumItemValue_ = 0,");
        }
            foreach (var id in ed.EnumItemDefs)
            {
                using (NewScope(id))
                {
                    if (IsDefined("ItemSummary"))
                    {
Emit("        // <summary>");
Emit("        // T_ItemSummary_");
Emit("        // </summary>");
                    }
                    if (IsDefined("ObsoleteReason"))
                    {
Emit("        [Obsolete(\"T_ObsoleteReason_\")]");
                    }
Emit("        T_EnumItemName_ = T_EnumItemValue_,");
                }
            }
Emit("    }");
        }
    }
    using (Ignored())
    {
Emit("    public interface IT_ParentName_ : IFreezable, IEntityBase { }");
Emit("    public interface IT_ModelType_ : IFreezable, IEntityBase { int TestData { get; } }");
    }
    foreach (var cd in outerScope.EntityDefs)
    {
        using (NewScope(cd))
        {
Emit("    public partial interface IT_EntityName_ : IT_ParentName_");
Emit("    {");
                foreach (var fd in cd.MemberDefs)
                {
                    using (NewScope(fd))
                    {
                        var memberInfo = new MemberInfo(fd, _engine.Current);
                        switch (memberInfo.Kind)
                        {
                            case FieldKind.UnaryModel:
Emit("        IT_ModelType_? T_UnaryModelFieldName_ { get; }");
                                break;
                            case FieldKind.ArrayModel:
Emit("        IReadOnlyList<IT_ModelType_?>? T_ArrayModelFieldName_ { get; }");
                                break;
                            case FieldKind.IndexModel:
Emit("        IReadOnlyDictionary<T_IndexType_, IT_ModelType_?>? T_IndexModelFieldName_ { get; }");
                                break;
                            case FieldKind.UnaryMaybe:
Emit("        T_ExternalOtherType_? T_UnaryMaybeFieldName_ { get; }");
                                break;
                            case FieldKind.ArrayMaybe:
Emit("        IReadOnlyList<T_ExternalOtherType_?>? T_ArrayMaybeFieldName_ { get; }");
                                break;
                            case FieldKind.IndexMaybe:
Emit("        IReadOnlyDictionary<T_IndexType_, T_ExternalOtherType_?>? T_IndexMaybeFieldName_ { get; }");
                                break;
                            case FieldKind.UnaryOther:
Emit("        T_ExternalOtherType_ T_UnaryOtherFieldName_ { get; }");
                                break;
                            case FieldKind.ArrayOther:
Emit("        IReadOnlyList<T_ExternalOtherType_>? T_ArrayOtherFieldName_ { get; }");
                                break;
                            case FieldKind.IndexOther:
Emit("        IReadOnlyDictionary<T_IndexType_, T_ExternalOtherType_>? T_IndexOtherFieldName_ { get; }");
                                break;
                            case FieldKind.UnaryBuffer:
Emit("        Octets? T_UnaryBufferFieldName_ { get; }");
                                break;
                            case FieldKind.ArrayBuffer:
Emit("        IReadOnlyList<Octets?>? T_ArrayBufferFieldName_ { get; }");
                                break;
                            case FieldKind.IndexBuffer:
Emit("        IReadOnlyDictionary<T_IndexType_, Octets?>? T_IndexBufferFieldName_ { get; }");
                                break;
                            case FieldKind.UnaryString:
Emit("        String? T_UnaryStringFieldName_ { get; }");
                                break;
                            case FieldKind.ArrayString:
Emit("        IReadOnlyList<String?>? T_ArrayStringFieldName_ { get; }");
                                break;
                            case FieldKind.IndexString:
Emit("        IReadOnlyDictionary<T_IndexType_, String?>? T_IndexStringFieldName_ { get; }");
                                break;
                            default: break;
                        }
                    }
                }
Emit("    }");
        }
    }
    using (Ignored())
    {
Emit("    public interface IT_DerivedName_ : IT_EntityName_ { }");
    }
Emit("}");
// |metacode:generator_footer|
        }
    }
}
// |metacode:generator_end|
