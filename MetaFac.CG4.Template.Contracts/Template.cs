//------------------------------------------------------------------------------
//   Warning: This code was automatically generated.
//   Changes to this file may cause incorrect behavior
//   and will be lost when this file is regenerated.
//------------------------------------------------------------------------------
//
// |metacode:version=0.1|
// |metacode:template_begin|
//>>DefineCSharpTypes();
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
// Generator: T_Generator_
// Metadata : T_Metadata_
// </information>
#endregion
#nullable enable
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8019 // Unnecessary using directive
using MetaFac.CG4.Runtime;
using MetaFac.Memory;
using MetaFac.Mutability;
using System;
using System.Collections.Generic;

namespace T_Namespace_.Contracts
{
    //>>using (Ignored())
    //>>{
    using T_ExternalOtherType_ = System.Int64;
    using T_ExternalMaybeType_ = System.DayOfWeek;
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
        //>>                var memberInfo = new MemberInfo(fd, _engine.Current);
        //>>                switch (memberInfo.Kind)
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
        T_ExternalMaybeType_? T_UnaryMaybeFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.ArrayMaybe:
        IReadOnlyList<T_ExternalMaybeType_?>? T_ArrayMaybeFieldName_ { get; }
        //>>                        break;
        //>>                    case FieldKind.IndexMaybe:
        IReadOnlyDictionary<T_IndexType_, T_ExternalMaybeType_?>? T_IndexMaybeFieldName_ { get; }
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
