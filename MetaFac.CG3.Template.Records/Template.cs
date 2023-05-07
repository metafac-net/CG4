﻿//------------------------------------------------------------------------------
//   Warning: This code was automatically generated.
//   Changes to this file may cause incorrect behavior
//   and will be lost when this file is regenerated.
//------------------------------------------------------------------------------
//
// |metacode:version=0.1|
// |metacode:template_begin|
//>>Define("BooleanFieldType","Boolean");
//>>Define("SByteFieldType","SByte");
//>>Define("ByteFieldType","Byte");
//>>Define("Int16FieldType","Int16");
//>>Define("UInt16FieldType","UInt16");
//>>Define("CharFieldType","Char");
//>>Define("Int32FieldType","Int32");
//>>Define("UInt32FieldType","UInt32");
//>>Define("SingleFieldType","Single");
//>>Define("Int64FieldType","Int64");
//>>Define("UInt64FieldType","UInt64");
//>>Define("DoubleFieldType","Double");
//>>Define("DateTimeFieldType","DateTime");
//>>Define("TimeSpanFieldType","TimeSpan");
//>>Define("DateTimeZoneFieldType","DateTimeOffset");
//>>Define("DecimalFieldType","Decimal");
//>>Define("GuidFieldType","Guid");
//>>Define("StringFieldType","String");
//>>Define("BinaryFieldType","byte[]");
//>>Define("ExternalBoolean","T_BooleanFieldType_");
//>>Define("ExternalSByte","T_SByteFieldType_");
//>>Define("ExternalByte","T_ByteFieldType_");
//>>Define("ExternalInt16","T_Int16FieldType_");
//>>Define("ExternalUInt16","T_UInt16FieldType_");
//>>Define("ExternalChar","T_CharFieldType_");
//>>Define("ExternalInt32","T_Int32FieldType_");
//>>Define("ExternalUInt32","T_UInt32FieldType_");
//>>Define("ExternalSingle","T_SingleFieldType_");
//>>Define("ExternalInt64","T_Int64FieldType_");
//>>Define("ExternalUInt64","T_UInt64FieldType_");
//>>Define("ExternalDouble","T_DoubleFieldType_");
//>>Define("ExternalDateTime","T_DateTimeFieldType_");
//>>Define("ExternalTimeSpan","T_TimeSpanFieldType_");
//>>Define("ExternalDateTimeOffset","T_DateTimeZoneFieldType_");
//>>Define("ExternalDecimal","T_DecimalFieldType_");
//>>Define("ExternalGuid","T_GuidFieldType_");
//>>Define("ExternalString","T_StringFieldType_");
//>>Define("ExternalBinaryFieldType","T_BinaryFieldType_");
//>>Define("BinaryFieldType","Octets");
//>>Define("BaseClassName","object");
// <auto-generated />
#region Auto-generated
//--------------------------------------------------------------------------------
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
//
// This file was generated using MetaFac.CG3 tools and user supplied metadata.
//
// To download and install the tool, the .NET CLI command is:
// dotnet tool install --global MetaFac.CG3.CLI
//
// For more information about using this tool, the help command is:
// mfcg3 g2c --help
//--------------------------------------------------------------------------------
#endregion
#nullable enable
using MetaFac.Memory;
using MetaFac.CG3.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using T_Namespace_.Interfaces;

namespace T_Namespace_.Records
{
    //>>using (Ignored()) {
    using T_ExternalOtherType_ = System.Int64;
    using T_IndexType_ = System.String;
    //>>}

    //>>using (Ignored()) {
    public record T_ModelType_ : IT_ModelType_
    {
        public static T_ModelType_? CreateFrom(IT_ModelType_? source)
        {
            if (source is null) return null;
            if (source is T_ModelType_ concrete) return concrete;
            return new T_ModelType_(source);
        }

        public int TestData { get; init; }

        public T_ModelType_() { }
        public T_ModelType_(int testData)
        {
            TestData = testData;
        }
        public T_ModelType_(IT_ModelType_ source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            TestData = source.TestData;
        }
    }
    //>>}

    //>>foreach (var cs in outerScope.Iterators["Classes"].Iterations) {
    //>>using (NewScope(cs)) {
    public partial record T_ClassName_ : IT_ClassName_
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T_ClassName_? CreateFrom(IT_ClassName_? source)
        {
            if (source is null) return null;
            if (source is T_ClassName_ thisClass) return thisClass;
            return new T_ClassName_(source);
        }

        private static readonly T_ClassName_ _empty = new T_ClassName_();
        public static T_ClassName_ Empty => _empty;

        //>>using (Ignored()) {
        private const int T_ClassTag_ = 99;
        //>>}
        private const int ClassTag = T_ClassTag_;

        //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
        //>>  using (NewScope(fs)) {
        //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
        //>>switch (fieldInfo.Kind)
        //>>{
        //>>    case FieldKind.UnaryModel:
        public T_ModelType_? T_UnaryModelFieldName_ { get; init; }
        IT_ModelType_? IT_ClassName_.T_UnaryModelFieldName_ => T_UnaryModelFieldName_;
        //>>    break; case FieldKind.ArrayModel:
        public ImmutableList<T_ModelType_?>? T_ArrayModelFieldName_ { get; init; }
        IEnumerable<IT_ModelType_?>? IT_ClassName_.T_ArrayModelFieldName_ => T_ArrayModelFieldName_;
        //>>    break; case FieldKind.IndexModel:
        public ImmutableDictionary<T_IndexType_, T_ModelType_?>? T_IndexModelFieldName_ { get; init; }
        IEnumerable<KeyValuePair<T_IndexType_, IT_ModelType_?>>? IT_ClassName_.T_IndexModelFieldName_ => T_IndexModelFieldName_?
            .Select(kvp => new KeyValuePair<T_IndexType_, IT_ModelType_?>(kvp.Key, kvp.Value));
        //>>    break; case FieldKind.UnaryMaybe:
        public T_ExternalOtherType_? T_UnaryMaybeFieldName_ { get; init; }
        T_ExternalOtherType_? IT_ClassName_.T_UnaryMaybeFieldName_ => T_UnaryMaybeFieldName_;
        //>>    break; case FieldKind.ArrayMaybe:
        public ImmutableList<T_ExternalOtherType_?>? T_ArrayMaybeFieldName_ { get; init; }
        IEnumerable<T_ExternalOtherType_?>? IT_ClassName_.T_ArrayMaybeFieldName_ => T_ArrayMaybeFieldName_;
        //>>    break; case FieldKind.IndexMaybe:
        public ImmutableDictionary<T_IndexType_, T_ExternalOtherType_?>? T_IndexMaybeFieldName_ { get; init; }
        IEnumerable<KeyValuePair<T_IndexType_, T_ExternalOtherType_?>>? IT_ClassName_.T_IndexMaybeFieldName_ => T_IndexMaybeFieldName_;
        //>>    break; case FieldKind.UnaryOther:
        public T_ExternalOtherType_ T_UnaryOtherFieldName_ { get; init; }
        T_ExternalOtherType_ IT_ClassName_.T_UnaryOtherFieldName_ => T_UnaryOtherFieldName_;
        //>>    break; case FieldKind.ArrayOther:
        public ImmutableList<T_ExternalOtherType_>? T_ArrayOtherFieldName_ { get; init; }
        IEnumerable<T_ExternalOtherType_>? IT_ClassName_.T_ArrayOtherFieldName_ => T_ArrayOtherFieldName_;
        //>>    break; case FieldKind.IndexOther:
        public ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>? T_IndexOtherFieldName_ { get; init; }
        IEnumerable<KeyValuePair<T_IndexType_, T_ExternalOtherType_>>? IT_ClassName_.T_IndexOtherFieldName_ => T_IndexOtherFieldName_;
        //>>    break; case FieldKind.UnaryBuffer:
        public Octets? T_UnaryBufferFieldName_ { get; init; }
        Octets? IT_ClassName_.T_UnaryBufferFieldName_ => T_UnaryBufferFieldName_;
        //>>    break; case FieldKind.ArrayBuffer:
        public ImmutableList<Octets?>? T_ArrayBufferFieldName_ { get; init; }
        IEnumerable<Octets?>? IT_ClassName_.T_ArrayBufferFieldName_ => T_ArrayBufferFieldName_;
        //>>    break; case FieldKind.IndexBuffer:
        public ImmutableDictionary<T_IndexType_, Octets?>? T_IndexBufferFieldName_ { get; init; }
        IEnumerable<KeyValuePair<string, Octets?>>? IT_ClassName_.T_IndexBufferFieldName_ => T_IndexBufferFieldName_;
        //>>    break; case FieldKind.UnaryString:
        public String? T_UnaryStringFieldName_ { get; init; }
        String? IT_ClassName_.T_UnaryStringFieldName_ => T_UnaryStringFieldName_;
        //>>    break; case FieldKind.ArrayString:
        public ImmutableList<String?>? T_ArrayStringFieldName_ { get; init; }
        IEnumerable<String?>? IT_ClassName_.T_ArrayStringFieldName_ => T_ArrayStringFieldName_;
        //>>    break; case FieldKind.IndexString:
        public ImmutableDictionary<T_IndexType_, String?>? T_IndexStringFieldName_ { get; init; }
        IEnumerable<KeyValuePair<string, String?>>? IT_ClassName_.T_IndexStringFieldName_ => T_IndexStringFieldName_;
        //>>    break; default: break;
        //>>}
        //>>}}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_ClassName_()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_ClassName_(T_ClassName_ source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
            //>>  using (NewScope(fs)) {
            //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            T_UnaryModelFieldName_ = source.T_UnaryModelFieldName_;
            //>>    break; case FieldKind.ArrayModel:
            T_ArrayModelFieldName_ = source.T_ArrayModelFieldName_;
            //>>    break; case FieldKind.IndexModel:
            T_IndexModelFieldName_ = source.T_IndexModelFieldName_;
            //>>    break; case FieldKind.UnaryMaybe:
            T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;
            //>>    break; case FieldKind.ArrayMaybe:
            T_ArrayMaybeFieldName_ = source.T_ArrayMaybeFieldName_;
            //>>    break; case FieldKind.IndexMaybe:
            T_IndexMaybeFieldName_ = source.T_IndexMaybeFieldName_;
            //>>    break; case FieldKind.UnaryOther:
            T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;
            //>>    break; case FieldKind.ArrayOther:
            T_ArrayOtherFieldName_ = source.T_ArrayOtherFieldName_;
            //>>    break; case FieldKind.IndexOther:
            T_IndexOtherFieldName_ = source.T_IndexOtherFieldName_;
            //>>    break; case FieldKind.UnaryBuffer:
            T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_;
            //>>    break; case FieldKind.ArrayBuffer:
            T_ArrayBufferFieldName_ = source.T_ArrayBufferFieldName_;
            //>>    break; case FieldKind.IndexBuffer:
            T_IndexBufferFieldName_ = source.T_IndexBufferFieldName_;
            //>>    break; case FieldKind.UnaryString:
            T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;
            //>>    break; case FieldKind.ArrayString:
            T_ArrayStringFieldName_ = source.T_ArrayStringFieldName_;
            //>>    break; case FieldKind.IndexString:
            T_IndexStringFieldName_ = source.T_IndexStringFieldName_;
            //>>    break; default: break;
            //>>}
            //>>}}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_ClassName_(IT_ClassName_? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
            //>>  using (NewScope(fs)) {
            //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            T_UnaryModelFieldName_ = T_ModelType_.CreateFrom(source.T_UnaryModelFieldName_);
            //>>    break; case FieldKind.ArrayModel:
            T_ArrayModelFieldName_ = source.T_ArrayModelFieldName_ is null
                ? default
                : ImmutableList<T_ModelType_?>.Empty.AddRange(source.T_ArrayModelFieldName_.Select(x => T_ModelType_.CreateFrom(x)));
            //>>    break; case FieldKind.IndexModel:
            T_IndexModelFieldName_ = source.T_IndexModelFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty.AddRange(
                    source.T_IndexModelFieldName_.Select(x => new KeyValuePair<T_IndexType_, T_ModelType_?>(x.Key, T_ModelType_.CreateFrom(x.Value))));
            //>>    break; case FieldKind.UnaryMaybe:
            T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;
            //>>    break; case FieldKind.ArrayMaybe:
            T_ArrayMaybeFieldName_ = source.T_ArrayMaybeFieldName_ is null
                ? default
                : ImmutableList<T_ExternalOtherType_?>.Empty.AddRange(source.T_ArrayMaybeFieldName_);
            //>>    break; case FieldKind.IndexMaybe:
            T_IndexMaybeFieldName_ = source.T_IndexMaybeFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalOtherType_?>.Empty.AddRange(source.T_IndexMaybeFieldName_);
            //>>    break; case FieldKind.UnaryOther:
            T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;
            //>>    break; case FieldKind.ArrayOther:
            T_ArrayOtherFieldName_ = source.T_ArrayOtherFieldName_ is null
                ? default
                : ImmutableList<T_ExternalOtherType_>.Empty.AddRange(source.T_ArrayOtherFieldName_);
            //>>    break; case FieldKind.IndexOther:
            T_IndexOtherFieldName_ = source.T_IndexOtherFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty.AddRange(source.T_IndexOtherFieldName_);
            //>>    break; case FieldKind.UnaryBuffer:
            T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_;
            //>>    break; case FieldKind.ArrayBuffer:
            T_ArrayBufferFieldName_ = source.T_ArrayBufferFieldName_ is null
                ? default
                : ImmutableList<Octets?>.Empty.AddRange(source.T_ArrayBufferFieldName_);
            //>>    break; case FieldKind.IndexBuffer:
            T_IndexBufferFieldName_ = source.T_IndexBufferFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, Octets?>.Empty.AddRange(source.T_IndexBufferFieldName_);
            //>>    break; case FieldKind.UnaryString:
            T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;
            //>>    break; case FieldKind.ArrayString:
            T_ArrayStringFieldName_ = source.T_ArrayStringFieldName_ is null
                ? default
                : ImmutableList<String?>.Empty.AddRange(source.T_ArrayStringFieldName_);
            //>>    break; case FieldKind.IndexString:
            T_IndexStringFieldName_ = source.T_IndexStringFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, String?>.Empty.AddRange(source.T_IndexStringFieldName_);
            //>>    break; default: break;
            //>>}
            //>>}}
        }

        public virtual bool Equals(T_ClassName_? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
            //>>  using (NewScope(fs)) {
            //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            if (!T_UnaryModelFieldName_.ValueEquals(other.T_UnaryModelFieldName_)) return false;
            //>>    break; case FieldKind.ArrayModel:
            if (!T_ArrayModelFieldName_.ArrayEquals(other.T_ArrayModelFieldName_)) return false;
            //>>    break; case FieldKind.IndexModel:
            if (!T_IndexModelFieldName_.IndexEquals(other.T_IndexModelFieldName_)) return false;
            //>>    break; case FieldKind.UnaryMaybe:
            if (!T_UnaryMaybeFieldName_.ValueEquals(other.T_UnaryMaybeFieldName_)) return false;
            //>>    break; case FieldKind.ArrayMaybe:
            if (!T_ArrayMaybeFieldName_.ArrayEquals(other.T_ArrayMaybeFieldName_)) return false;
            //>>    break; case FieldKind.IndexMaybe:
            if (!T_IndexMaybeFieldName_.IndexEquals(other.T_IndexMaybeFieldName_)) return false;
            //>>    break; case FieldKind.UnaryOther:
            if (!T_UnaryOtherFieldName_.ValueEquals(other.T_UnaryOtherFieldName_)) return false;
            //>>    break; case FieldKind.ArrayOther:
            if (!T_ArrayOtherFieldName_.ArrayEquals(other.T_ArrayOtherFieldName_)) return false;
            //>>    break; case FieldKind.IndexOther:
            if (!T_IndexOtherFieldName_.IndexEquals(other.T_IndexOtherFieldName_)) return false;
            //>>    break; case FieldKind.UnaryBuffer:
            if (!T_UnaryBufferFieldName_.ValueEquals(other.T_UnaryBufferFieldName_)) return false;
            //>>    break; case FieldKind.ArrayBuffer:
            if (!T_ArrayBufferFieldName_.ArrayEquals(other.T_ArrayBufferFieldName_)) return false;
            //>>    break; case FieldKind.IndexBuffer:
            if (!T_IndexBufferFieldName_.IndexEquals(other.T_IndexBufferFieldName_)) return false;
            //>>    break; case FieldKind.UnaryString:
            if (!T_UnaryStringFieldName_.ValueEquals(other.T_UnaryStringFieldName_)) return false;
            //>>    break; case FieldKind.ArrayString:
            if (!T_ArrayStringFieldName_.ArrayEquals(other.T_ArrayStringFieldName_)) return false;
            //>>    break; case FieldKind.IndexString:
            if (!T_IndexStringFieldName_.IndexEquals(other.T_IndexStringFieldName_)) return false;
            //>>    break; default: break;
            //>>}
            //>>}}
            return true;
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
            //>>  using (NewScope(fs)) {
            //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            hc.Add(T_UnaryModelFieldName_.CalcHashUnary());
            //>>    break; case FieldKind.ArrayModel:
            hc.Add(T_ArrayModelFieldName_.CalcHashArray());
            //>>    break; case FieldKind.IndexModel:
            hc.Add(T_IndexModelFieldName_.CalcHashIndex());
            //>>    break; case FieldKind.UnaryMaybe:
            hc.Add(T_UnaryMaybeFieldName_.CalcHashUnary());
            //>>    break; case FieldKind.ArrayMaybe:
            hc.Add(T_ArrayMaybeFieldName_.CalcHashArray());
            //>>    break; case FieldKind.IndexMaybe:
            hc.Add(T_IndexMaybeFieldName_.CalcHashIndex());
            //>>    break; case FieldKind.UnaryOther:
            hc.Add(T_UnaryOtherFieldName_.CalcHashUnary());
            //>>    break; case FieldKind.ArrayOther:
            hc.Add(T_ArrayOtherFieldName_.CalcHashArray());
            //>>    break; case FieldKind.IndexOther:
            hc.Add(T_IndexOtherFieldName_.CalcHashIndex());
            //>>    break; case FieldKind.UnaryBuffer:
            hc.Add(T_UnaryBufferFieldName_.CalcHashUnary());
            //>>    break; case FieldKind.ArrayBuffer:
            hc.Add(T_ArrayBufferFieldName_.CalcHashArray());
            //>>    break; case FieldKind.IndexBuffer:
            hc.Add(T_IndexBufferFieldName_.CalcHashIndex());
            //>>    break; case FieldKind.UnaryString:
            hc.Add(T_UnaryStringFieldName_.CalcHashUnary());
            //>>    break; case FieldKind.ArrayString:
            hc.Add(T_ArrayStringFieldName_.CalcHashArray());
            //>>    break; case FieldKind.IndexString:
            hc.Add(T_IndexStringFieldName_.CalcHashIndex());
            //>>    break; default: break;
            //>>}
            //>>}}
            return hc.ToHashCode();
        }

        private int? _hashCode = null;
        public override int GetHashCode()
        {
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }
    }

    //>>}}

}
// |metacode:template_end|
