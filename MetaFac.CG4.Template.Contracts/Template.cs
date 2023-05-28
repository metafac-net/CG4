//------------------------------------------------------------------------------
//   Warning: This code was automatically generated.
//   Changes to this file may cause incorrect behavior
//   and will be lost when this file is regenerated.
//------------------------------------------------------------------------------
//
// |metacode:version=0.1|
// |metacode:template_begin|
//>>Define("BooleanFieldType", "Boolean");
//>>Define("SByteFieldType", "SByte");
//>>Define("ByteFieldType", "Byte");
//>>Define("Int16FieldType", "Int16");
//>>Define("UInt16FieldType", "UInt16");
//>>Define("CharFieldType", "Char");
//>>Define("Int32FieldType", "Int32");
//>>Define("UInt32FieldType", "UInt32");
//>>Define("SingleFieldType", "Single");
//>>Define("Int64FieldType", "Int64");
//>>Define("UInt64FieldType", "UInt64");
//>>Define("DoubleFieldType", "Double");
//>>Define("DateTimeFieldType", "DateTime");
//>>Define("TimeSpanFieldType", "TimeSpan");
//>>Define("DateTimeZoneFieldType", "DateTimeOffset");
//>>Define("DecimalFieldType", "Decimal");
//>>Define("GuidFieldType", "Guid");
//>>Define("ConcreteBoolean", "T_BooleanFieldType_");
//>>Define("ConcreteSByte", "T_SByteFieldType_");
//>>Define("ConcreteByte", "T_ByteFieldType_");
//>>Define("ConcreteInt16", "T_Int16FieldType_");
//>>Define("ConcreteUInt16", "T_UInt16FieldType_");
//>>Define("ConcreteChar", "T_CharFieldType_");
//>>Define("ConcreteInt32", "T_Int32FieldType_");
//>>Define("ConcreteUInt32", "T_UInt32FieldType_");
//>>Define("ConcreteSingle", "T_SingleFieldType_");
//>>Define("ConcreteInt64", "T_Int64FieldType_");
//>>Define("ConcreteUInt64", "T_UInt64FieldType_");
//>>Define("ConcreteDouble", "T_DoubleFieldType_");
//>>Define("ConcreteDateTime", "T_DateTimeFieldType_");
//>>Define("ConcreteTimeSpan", "T_TimeSpanFieldType_");
//>>Define("ConcreteDateTimeOffset", "T_DateTimeZoneFieldType_");
//>>Define("ConcreteDecimal", "T_DecimalFieldType_");
//>>Define("ConcreteGuid", "T_GuidFieldType_");
//>>Define("ExternalBoolean", "T_BooleanFieldType_");
//>>Define("ExternalSByte", "T_SByteFieldType_");
//>>Define("ExternalByte", "T_ByteFieldType_");
//>>Define("ExternalInt16", "T_Int16FieldType_");
//>>Define("ExternalUInt16", "T_UInt16FieldType_");
//>>Define("ExternalChar", "T_CharFieldType_");
//>>Define("ExternalInt32", "T_Int32FieldType_");
//>>Define("ExternalUInt32", "T_UInt32FieldType_");
//>>Define("ExternalSingle", "T_SingleFieldType_");
//>>Define("ExternalInt64", "T_Int64FieldType_");
//>>Define("ExternalUInt64", "T_UInt64FieldType_");
//>>Define("ExternalDouble", "T_DoubleFieldType_");
//>>Define("ExternalDateTime", "T_DateTimeFieldType_");
//>>Define("ExternalTimeSpan", "T_TimeSpanFieldType_");
//>>Define("ExternalDateTimeOffset", "T_DateTimeZoneFieldType_");
//>>Define("ExternalDecimal", "T_DecimalFieldType_");
//>>Define("ExternalGuid", "T_GuidFieldType_");
//>>Define("ParentName", "EntityBase");
#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
//>>if (IsDefined("CopyrightInfo"))
//>>{
// <copyright>
//     T_CopyrightInfo_
// </copyright>
//>>}
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: qqq
// Metadata : qqq
// </information>
#endregion
#nullable enable
#pragma warning disable CS8019 // Unnecessary using directive
using MetaFac.Memory;
using MetaFac.Mutability;
using MetaFac.CG4.Runtime;
using System;
using System.Collections.Generic;

namespace T_Namespace_.Contracts
{
    //>>using (Ignored())
    //>>{
    using T_ExternalOtherType_ = System.Int64;
    using T_IndexType_ = System.String;
    //>>}
    //>>foreach (var ed in outerScope.EnumTypeDefs)
    //>>{
    //>>    using (NewScope(ed))
    //>>    {
    public enum T_EnumTypeName_
    {
        //>>using (Ignored())
        //>>{
        T_EnumItemValue_ = 0,
        //>>}
        //>>    foreach (var id in ed.EnumItemDefs)
        //>>    {
        //>>        using (NewScope(id))
        //>>        {
        //>>            if (IsDefined("ItemSummary"))
        //>>            {
        // <summary>
        // T_ItemSummary_
        // </summary>
        //>>            }
        //>>            if (IsDefined("ObsoleteReason"))
        //>>            {
        [Obsolete("T_ObsoleteReason_")]
        //>>            }
        T_EnumItemName_ = T_EnumItemValue_,
        //>>        }
        //>>    }
    }
    //>>    }
    //>>}
    //>>using (Ignored())
    //>>{
    public interface IT_ParentName_ : IFreezable, IEntityBase { }
    public interface IT_ModelType_ : IFreezable, IEntityBase { int TestData { get; } }
    //>>}
    //>>foreach (var cd in outerScope.EntityDefs)
    //>>{
    //>>    using (NewScope(cd))
    //>>    {
    public partial interface IT_EntityName_ : IT_ParentName_
    {
        //>>        foreach (var fd in cd.MemberDefs)
        //>>        {
        //>>            using (NewScope(fd))
        //>>            {
        //>>                var fieldInfo = new FieldInfo(fd, _engine.Current);
        //>>                switch (fieldInfo.Kind)
        //>>                {
        //>>                    case FieldKind.UnaryModel:
        IT_ModelType_? T_UnaryModelFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.ArrayModel:
        IReadOnlyList<IT_ModelType_?>? T_ArrayModelFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.IndexModel:
        IReadOnlyDictionary<T_IndexType_, IT_ModelType_?>? T_IndexModelFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.UnaryMaybe:
        T_ExternalOtherType_? T_UnaryMaybeFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.ArrayMaybe:
        IReadOnlyList<T_ExternalOtherType_?>? T_ArrayMaybeFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.IndexMaybe:
        IReadOnlyDictionary<T_IndexType_, T_ExternalOtherType_?>? T_IndexMaybeFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.UnaryOther:
        T_ExternalOtherType_ T_UnaryOtherFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.ArrayOther:
        IReadOnlyList<T_ExternalOtherType_>? T_ArrayOtherFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.IndexOther:
        IReadOnlyDictionary<T_IndexType_, T_ExternalOtherType_>? T_IndexOtherFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.UnaryBuffer:
        Octets? T_UnaryBufferFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.ArrayBuffer:
        IReadOnlyList<Octets?>? T_ArrayBufferFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.IndexBuffer:
        IReadOnlyDictionary<T_IndexType_, Octets?>? T_IndexBufferFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.UnaryString:
        String? T_UnaryStringFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.ArrayString:
        IReadOnlyList<String?>? T_ArrayStringFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.IndexString:
        IReadOnlyDictionary<T_IndexType_, String?>? T_IndexStringFieldName_ { get; }
        //>>                        break;
        //>>                    default: break;
        //>>                }
        //>>            }
        //>>        }
    }
    //>>    }
    //>>}
    //>>using (Ignored())
    //>>{
    public interface IT_DerivedName_ : IT_EntityName_ { }
    //>>}
}
// |metacode:template_end|
