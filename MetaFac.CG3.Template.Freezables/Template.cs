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
//>>Define("BaseClassName","FreezableBase");
#region Auto-generated
//
// Warning: This code was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
//
// This file was generated by the MetaFac.CG3.CLI tool (or mfcg3)
// using a MetaFac generator and modified according to supplied model(s).
//
// Generator: T_GeneratorId_ T_GeneratorVersion_
// Metadata : T_MetadataSource_ T_MetadataVersion_
//
// For more information about using this tool, the help command is:
// mfcg3 g2c --help
//
// To download and install the tool, the .NET CLI command is:
// dotnet tool install --global MetaFac.CG3.CLI
//
//--------------------------------------------------------------------------------
#endregion
#nullable enable
using MetaFac.Collections.Freezables;
using MetaFac.Mutability;
using MetaFac.Memory;
using MetaFac.CG3.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using T_Namespace_.Interfaces;

namespace T_Namespace_.Freezables
{
    //>>using (Ignored()) {
    using T_ExternalOtherType_ = System.Int64;
    using T_IndexType_ = System.String;
    //>>}

    //>>using (Ignored()) {
    public class T_ModelType_ : FreezableBase, IT_ModelType_, IEquatable<T_ModelType_>
    {
        public static T_ModelType_? CreateFrom(IT_ModelType_? source)
        {
            if (source is null) return null;
            if (source is T_ModelType_ concrete && concrete.IsFrozen()) return concrete;
            return new T_ModelType_(source);
        }

        public int TestData { get; }

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

        public bool Equals(T_ModelType_? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (this.TestData != other.TestData) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj)
        {
            return (obj is T_ModelType_ other) && Equals(other);
        }

        public override int GetHashCode()
        {
            return TestData.GetHashCode();
        }
    }
    //>>}

    //>>foreach (var cs in outerScope.Iterators["Classes"].Iterations) {
    //>>using (NewScope(cs)) {
    public sealed partial class T_ClassName_ : FreezableBase, IT_ClassName_, ICopyFrom<T_ClassName_>, IEquatable<T_ClassName_>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowIsReadonly(string verb, [CallerMemberName] string? method = null)
        {
            throw new InvalidOperationException($"Cannot {verb} '{method}' when read-only");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T_ClassName_? CreateFrom(IT_ClassName_? source)
        {
            if (source is null) return null;
            if (source is T_ClassName_ thisClass && thisClass.IsFrozen()) return thisClass;
            return new T_ClassName_(source);
        }

        private static T_ClassName_ CreateEmpty()
        {
            var result = new T_ClassName_();
            result.Freeze();
            return result;
        }
#pragma warning disable 109
        public new static readonly T_ClassName_ Empty = CreateEmpty();
#pragma warning restore 109

        //>>using (Ignored()) {
        private const int T_ClassTag_ = 99;
        //>>}
        private const int ClassTag = T_ClassTag_;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref T CheckNotFrozen<T>(ref T value)
        {
            if (IsFrozen()) ThrowIsReadonly("set");
            return ref value;
        }

        //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
        //>>  using (NewScope(fs)) {
        //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
        //>>switch (fieldInfo.Kind)
        //>>{
        //>>    case FieldKind.UnaryModel:
        private T_ModelType_? field_T_UnaryModelFieldName_;
        public T_ModelType_? T_UnaryModelFieldName_
        {
            get => field_T_UnaryModelFieldName_;
            set => field_T_UnaryModelFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.ArrayModel:
        private FreezableArray<T_ModelType_?>? field_T_ArrayModelFieldName_;
        public FreezableArray<T_ModelType_?>? T_ArrayModelFieldName_
        {
            get => field_T_ArrayModelFieldName_;
            set => field_T_ArrayModelFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.IndexModel:
        private FreezableHashedDictionary<T_IndexType_, T_ModelType_?>? field_T_IndexModelFieldName_;
        public FreezableHashedDictionary<T_IndexType_, T_ModelType_?>? T_IndexModelFieldName_
        {
            get => field_T_IndexModelFieldName_;
            set => field_T_IndexModelFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.UnaryMaybe:
        private T_ExternalOtherType_? field_T_UnaryMaybeFieldName_;
        public T_ExternalOtherType_? T_UnaryMaybeFieldName_
        {
            get => field_T_UnaryMaybeFieldName_;
            set => field_T_UnaryMaybeFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.ArrayMaybe:
        private FreezableArray<T_ExternalOtherType_?>? field_T_ArrayMaybeFieldName_;
        public FreezableArray<T_ExternalOtherType_?>? T_ArrayMaybeFieldName_
        {
            get => field_T_ArrayMaybeFieldName_;
            set => field_T_ArrayMaybeFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.IndexMaybe:
        private FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_?>? field_T_IndexMaybeFieldName_;
        public FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_?>? T_IndexMaybeFieldName_
        {
            get => field_T_IndexMaybeFieldName_;
            set => field_T_IndexMaybeFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.UnaryOther:
        private T_ExternalOtherType_ field_T_UnaryOtherFieldName_;
        public T_ExternalOtherType_ T_UnaryOtherFieldName_
        {
            get => field_T_UnaryOtherFieldName_;
            set => field_T_UnaryOtherFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.ArrayOther:
        private FreezableArray<T_ExternalOtherType_>? field_T_ArrayOtherFieldName_;
        public FreezableArray<T_ExternalOtherType_>? T_ArrayOtherFieldName_
        {
            get => field_T_ArrayOtherFieldName_;
            set => field_T_ArrayOtherFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.IndexOther:
        private FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_>? field_T_IndexOtherFieldName_;
        public FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_>? T_IndexOtherFieldName_
        {
            get => field_T_IndexOtherFieldName_;
            set => field_T_IndexOtherFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.UnaryBuffer:
        private Octets? field_T_UnaryBufferFieldName_;
        public Octets? T_UnaryBufferFieldName_
        {
            get => field_T_UnaryBufferFieldName_;
            set => field_T_UnaryBufferFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.ArrayBuffer:
        private FreezableArray<Octets?>? field_T_ArrayBufferFieldName_;
        public FreezableArray<Octets?>? T_ArrayBufferFieldName_
        {
            get => field_T_ArrayBufferFieldName_;
            set => field_T_ArrayBufferFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.IndexBuffer:
        private FreezableHashedDictionary<T_IndexType_, Octets?>? field_T_IndexBufferFieldName_;
        public FreezableHashedDictionary<T_IndexType_, Octets?>? T_IndexBufferFieldName_
        {
            get => field_T_IndexBufferFieldName_;
            set => field_T_IndexBufferFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.UnaryString:
        private String? field_T_UnaryStringFieldName_;
        public String? T_UnaryStringFieldName_
        {
            get => field_T_UnaryStringFieldName_;
            set => field_T_UnaryStringFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.ArrayString:
        private FreezableArray<String?>? field_T_ArrayStringFieldName_;
        public FreezableArray<String?>? T_ArrayStringFieldName_
        {
            get => field_T_ArrayStringFieldName_;
            set => field_T_ArrayStringFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.IndexString:
        private FreezableHashedDictionary<T_IndexType_, String?>? field_T_IndexStringFieldName_;
        public FreezableHashedDictionary<T_IndexType_, String?>? T_IndexStringFieldName_
        {
            get => field_T_IndexStringFieldName_;
            set => field_T_IndexStringFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; default: break;
        //>>}
        //>>}}


        //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
        //>>  using (NewScope(fs)) {
        //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
        //>>switch (fieldInfo.Kind)
        //>>{
        //>>    case FieldKind.UnaryModel:
        IT_ModelType_? IT_ClassName_.T_UnaryModelFieldName_ => field_T_UnaryModelFieldName_;
        //>>    break; case FieldKind.ArrayModel:
        IEnumerable<IT_ModelType_?>? IT_ClassName_.T_ArrayModelFieldName_ => field_T_ArrayModelFieldName_;
        //>>    break; case FieldKind.IndexModel:
        IEnumerable<KeyValuePair<T_IndexType_, IT_ModelType_?>>? IT_ClassName_.T_IndexModelFieldName_ => field_T_IndexModelFieldName_?
            .Select(kvp => new KeyValuePair<T_IndexType_, IT_ModelType_?>(kvp.Key, kvp.Value));
        //>>    break; case FieldKind.UnaryMaybe:
        T_ExternalOtherType_? IT_ClassName_.T_UnaryMaybeFieldName_ => field_T_UnaryMaybeFieldName_;
        //>>    break; case FieldKind.ArrayMaybe:
        IEnumerable<T_ExternalOtherType_?>? IT_ClassName_.T_ArrayMaybeFieldName_ => field_T_ArrayMaybeFieldName_;
        //>>    break; case FieldKind.IndexMaybe:
        IEnumerable<KeyValuePair<T_IndexType_, T_ExternalOtherType_?>>? IT_ClassName_.T_IndexMaybeFieldName_ => field_T_IndexMaybeFieldName_;
        //>>    break; case FieldKind.UnaryOther:
        T_ExternalOtherType_ IT_ClassName_.T_UnaryOtherFieldName_ => field_T_UnaryOtherFieldName_;
        //>>    break; case FieldKind.ArrayOther:
        IEnumerable<T_ExternalOtherType_>? IT_ClassName_.T_ArrayOtherFieldName_ => field_T_ArrayOtherFieldName_;
        //>>    break; case FieldKind.IndexOther:
        IEnumerable<KeyValuePair<T_IndexType_, T_ExternalOtherType_>>? IT_ClassName_.T_IndexOtherFieldName_ => field_T_IndexOtherFieldName_;
        //>>    break; case FieldKind.UnaryBuffer:
        Octets? IT_ClassName_.T_UnaryBufferFieldName_ => field_T_UnaryBufferFieldName_;
        //>>    break; case FieldKind.ArrayBuffer:
        IEnumerable<Octets?>? IT_ClassName_.T_ArrayBufferFieldName_ => field_T_ArrayBufferFieldName_;
        //>>    break; case FieldKind.IndexBuffer:
        IEnumerable<KeyValuePair<T_IndexType_, Octets?>>? IT_ClassName_.T_IndexBufferFieldName_ => field_T_IndexBufferFieldName_;
        //>>    break; case FieldKind.UnaryString:
        String? IT_ClassName_.T_UnaryStringFieldName_ => field_T_UnaryStringFieldName_;
        //>>    break; case FieldKind.ArrayString:
        IEnumerable<String?>? IT_ClassName_.T_ArrayStringFieldName_ => field_T_ArrayStringFieldName_;
        //>>    break; case FieldKind.IndexString:
        IEnumerable<KeyValuePair<T_IndexType_, String?>>? IT_ClassName_.T_IndexStringFieldName_ => field_T_IndexStringFieldName_;
        //>>    break; default: break;
        //>>}
        //>>}}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_ClassName_()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_ClassName_(T_ClassName_ source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
            //>>  using (NewScope(fs)) {
            //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            field_T_UnaryModelFieldName_ = source.field_T_UnaryModelFieldName_;
            //>>    break; case FieldKind.ArrayModel:
            field_T_ArrayModelFieldName_ = source.field_T_ArrayModelFieldName_;
            //>>    break; case FieldKind.IndexModel:
            field_T_IndexModelFieldName_ = source.field_T_IndexModelFieldName_;
            //>>    break; case FieldKind.UnaryMaybe:
            field_T_UnaryMaybeFieldName_ = source.field_T_UnaryMaybeFieldName_;
            //>>    break; case FieldKind.ArrayMaybe:
            field_T_ArrayMaybeFieldName_ = source.field_T_ArrayMaybeFieldName_;
            //>>    break; case FieldKind.IndexMaybe:
            field_T_IndexMaybeFieldName_ = source.field_T_IndexMaybeFieldName_;
            //>>    break; case FieldKind.UnaryOther:
            field_T_UnaryOtherFieldName_ = source.field_T_UnaryOtherFieldName_;
            //>>    break; case FieldKind.ArrayOther:
            field_T_ArrayOtherFieldName_ = source.field_T_ArrayOtherFieldName_;
            //>>    break; case FieldKind.IndexOther:
            field_T_IndexOtherFieldName_ = source.field_T_IndexOtherFieldName_;
            //>>    break; case FieldKind.UnaryBuffer:
            field_T_UnaryBufferFieldName_ = source.field_T_UnaryBufferFieldName_;
            //>>    break; case FieldKind.ArrayBuffer:
            field_T_ArrayBufferFieldName_ = source.field_T_ArrayBufferFieldName_;
            //>>    break; case FieldKind.IndexBuffer:
            field_T_IndexBufferFieldName_ = source.field_T_IndexBufferFieldName_;
            //>>    break; case FieldKind.UnaryString:
            field_T_UnaryStringFieldName_ = source.field_T_UnaryStringFieldName_;
            //>>    break; case FieldKind.ArrayString:
            field_T_ArrayStringFieldName_ = source.field_T_ArrayStringFieldName_;
            //>>    break; case FieldKind.IndexString:
            field_T_IndexStringFieldName_ = source.field_T_IndexStringFieldName_;
            //>>    break; default: break;
            //>>}
            //>>}}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_ClassName_(IT_ClassName_ source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
            //>>  using (NewScope(fs)) {
            //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            field_T_UnaryModelFieldName_ = T_ModelType_.CreateFrom(source.T_UnaryModelFieldName_);
            //>>    break; case FieldKind.ArrayModel:
            field_T_ArrayModelFieldName_ = FreezableArray<T_ModelType_?>.CreateFrom(source.T_ArrayModelFieldName_?.Select(x => T_ModelType_.CreateFrom(x)));
            //>>    break; case FieldKind.IndexModel:
            field_T_IndexModelFieldName_ = FreezableHashedDictionary<T_IndexType_, T_ModelType_?>.CreateFrom(
                source.T_IndexModelFieldName_?.Select(x => new KeyValuePair<T_IndexType_, T_ModelType_?>(x.Key, T_ModelType_.CreateFrom(x.Value))));
            //>>    break; case FieldKind.UnaryMaybe:
            field_T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;
            //>>    break; case FieldKind.ArrayMaybe:
            field_T_ArrayMaybeFieldName_ = FreezableArray<T_ExternalOtherType_?>.CreateFrom(source.T_ArrayMaybeFieldName_);
            //>>    break; case FieldKind.IndexMaybe:
            field_T_IndexMaybeFieldName_ = FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_?>.CreateFrom(source.T_IndexMaybeFieldName_);
            //>>    break; case FieldKind.UnaryOther:
            field_T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;
            //>>    break; case FieldKind.ArrayOther:
            field_T_ArrayOtherFieldName_ = FreezableArray<T_ExternalOtherType_>.CreateFrom(source.T_ArrayOtherFieldName_);
            //>>    break; case FieldKind.IndexOther:
            field_T_IndexOtherFieldName_ = FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_>.CreateFrom(source.T_IndexOtherFieldName_);
            //>>    break; case FieldKind.UnaryBuffer:
            field_T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_;
            //>>    break; case FieldKind.ArrayBuffer:
            field_T_ArrayBufferFieldName_ = FreezableArray<Octets?>.CreateFrom(source.T_ArrayBufferFieldName_);
            //>>    break; case FieldKind.IndexBuffer:
            field_T_IndexBufferFieldName_ = FreezableHashedDictionary<T_IndexType_, Octets?>.CreateFrom(source.T_IndexBufferFieldName_);
            //>>    break; case FieldKind.UnaryString:
            field_T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;
            //>>    break; case FieldKind.ArrayString:
            field_T_ArrayStringFieldName_ = FreezableArray<String?>.CreateFrom(source.T_ArrayStringFieldName_);
            //>>    break; case FieldKind.IndexString:
            field_T_IndexStringFieldName_ = FreezableHashedDictionary<T_IndexType_, String?>.CreateFrom(source.T_IndexStringFieldName_);
            //>>    break; default: break;
            //>>}
            //>>}}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFrom(T_ClassName_? source)
        {
            if (IsFrozen()) ThrowIsReadonly("call");
            if (source is null) return;
            base.CopyFrom(source);

            //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
            //>>  using (NewScope(fs)) {
            //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            field_T_UnaryModelFieldName_ = source.field_T_UnaryModelFieldName_;
            //>>    break; case FieldKind.ArrayModel:
            field_T_ArrayModelFieldName_ = source.field_T_ArrayModelFieldName_;
            //>>    break; case FieldKind.IndexModel:
            field_T_IndexModelFieldName_ = source.field_T_IndexModelFieldName_;
            //>>    break; case FieldKind.UnaryMaybe:
            field_T_UnaryMaybeFieldName_ = source.field_T_UnaryMaybeFieldName_;
            //>>    break; case FieldKind.ArrayMaybe:
            field_T_ArrayMaybeFieldName_ = source.field_T_ArrayMaybeFieldName_;
            //>>    break; case FieldKind.IndexMaybe:
            field_T_IndexMaybeFieldName_ = source.field_T_IndexMaybeFieldName_;
            //>>    break; case FieldKind.UnaryOther:
            field_T_UnaryOtherFieldName_ = source.field_T_UnaryOtherFieldName_;
            //>>    break; case FieldKind.ArrayOther:
            field_T_ArrayOtherFieldName_ = source.field_T_ArrayOtherFieldName_;
            //>>    break; case FieldKind.IndexOther:
            field_T_IndexOtherFieldName_ = source.field_T_IndexOtherFieldName_;
            //>>    break; case FieldKind.UnaryBuffer:
            field_T_UnaryBufferFieldName_ = source.field_T_UnaryBufferFieldName_;
            //>>    break; case FieldKind.ArrayBuffer:
            field_T_ArrayBufferFieldName_ = source.field_T_ArrayBufferFieldName_;
            //>>    break; case FieldKind.IndexBuffer:
            field_T_IndexBufferFieldName_ = source.field_T_IndexBufferFieldName_;
            //>>    break; case FieldKind.UnaryString:
            field_T_UnaryStringFieldName_ = source.field_T_UnaryStringFieldName_;
            //>>    break; case FieldKind.ArrayString:
            field_T_ArrayStringFieldName_ = source.field_T_ArrayStringFieldName_;
            //>>    break; case FieldKind.IndexString:
            field_T_IndexStringFieldName_ = source.field_T_IndexStringFieldName_;
            //>>    break; default: break;
            //>>}
            //>>}}
        }

        protected override void OnFreeze()
        {
            //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
            //>>  using (NewScope(fs)) {
            //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            field_T_UnaryModelFieldName_?.Freeze();
            //>>    break; case FieldKind.ArrayModel:
            field_T_ArrayModelFieldName_?.Freeze();
            //>>    break; case FieldKind.IndexModel:
            field_T_IndexModelFieldName_?.Freeze();
            //>>    break; case FieldKind.UnaryMaybe:
            //>>    break; case FieldKind.ArrayMaybe:
            field_T_ArrayMaybeFieldName_?.Freeze();
            //>>    break; case FieldKind.IndexMaybe:
            field_T_IndexMaybeFieldName_?.Freeze();
            //>>    break; case FieldKind.UnaryOther:
            //>>    break; case FieldKind.ArrayOther:
            field_T_ArrayOtherFieldName_?.Freeze();
            //>>    break; case FieldKind.IndexOther:
            field_T_IndexOtherFieldName_?.Freeze();
            //>>    break; case FieldKind.UnaryBuffer:
            //>>    break; case FieldKind.ArrayBuffer:
            field_T_ArrayBufferFieldName_?.Freeze();
            //>>    break; case FieldKind.IndexBuffer:
            field_T_IndexBufferFieldName_?.Freeze();
            //>>    break; case FieldKind.UnaryString:
            //>>    break; case FieldKind.ArrayString:
            field_T_ArrayStringFieldName_?.Freeze();
            //>>    break; case FieldKind.IndexString:
            field_T_IndexStringFieldName_?.Freeze();
            //>>    break; default: break;
            //>>}
            //>>}}
            base.OnFreeze();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(T_ClassName_? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
            //>>  using (NewScope(fs)) {
            //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            if (!field_T_UnaryModelFieldName_.ValueEquals(other.field_T_UnaryModelFieldName_)) return false;
            //>>    break; case FieldKind.ArrayModel:
            if (!field_T_ArrayModelFieldName_.ArrayEquals(other.field_T_ArrayModelFieldName_)) return false;
            //>>    break; case FieldKind.IndexModel:
            if (!field_T_IndexModelFieldName_.IndexEquals(other.field_T_IndexModelFieldName_)) return false;
            //>>    break; case FieldKind.UnaryMaybe:
            if (!field_T_UnaryMaybeFieldName_.ValueEquals(other.field_T_UnaryMaybeFieldName_)) return false;
            //>>    break; case FieldKind.ArrayMaybe:
            if (!field_T_ArrayMaybeFieldName_.ArrayEquals(other.field_T_ArrayMaybeFieldName_)) return false;
            //>>    break; case FieldKind.IndexMaybe:
            if (!field_T_IndexMaybeFieldName_.IndexEquals(other.field_T_IndexMaybeFieldName_)) return false;
            //>>    break; case FieldKind.UnaryOther:
            if (!field_T_UnaryOtherFieldName_.ValueEquals(other.field_T_UnaryOtherFieldName_)) return false;
            //>>    break; case FieldKind.ArrayOther:
            if (!field_T_ArrayOtherFieldName_.ArrayEquals(other.field_T_ArrayOtherFieldName_)) return false;
            //>>    break; case FieldKind.IndexOther:
            if (!field_T_IndexOtherFieldName_.IndexEquals(other.field_T_IndexOtherFieldName_)) return false;
            //>>    break; case FieldKind.UnaryBuffer:
            if (!field_T_UnaryBufferFieldName_.ValueEquals(other.field_T_UnaryBufferFieldName_)) return false;
            //>>    break; case FieldKind.ArrayBuffer:
            if (!field_T_ArrayBufferFieldName_.ArrayEquals(other.field_T_ArrayBufferFieldName_)) return false;
            //>>    break; case FieldKind.IndexBuffer:
            if (!field_T_IndexBufferFieldName_.IndexEquals(other.field_T_IndexBufferFieldName_)) return false;
            //>>    break; case FieldKind.UnaryString:
            if (!field_T_UnaryStringFieldName_.ValueEquals(other.field_T_UnaryStringFieldName_)) return false;
            //>>    break; case FieldKind.ArrayString:
            if (!field_T_ArrayStringFieldName_.ArrayEquals(other.field_T_ArrayStringFieldName_)) return false;
            //>>    break; case FieldKind.IndexString:
            if (!field_T_IndexStringFieldName_.IndexEquals(other.field_T_IndexStringFieldName_)) return false;
            //>>    break; default: break;
            //>>}
            //>>}}
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(T_ClassName_ left, T_ClassName_ right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null) return false;
            if (right is null) return false;
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(T_ClassName_ left, T_ClassName_ right)
        {
            if (ReferenceEquals(left, right)) return false;
            if (left is null) return true;
            if (right is null) return true;
            return !(left.Equals(right));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return obj is T_ClassName_ other && Equals(other);
        }

        public override int GetHashCode()
        {
            int hash = base.GetHashCode();
            unchecked
            {
                //>>foreach (var fs in cs.Iterators["Fields"].Iterations) {
                //>>  using (NewScope(fs)) {
                //>>    var fieldInfo = new FieldInfo(fs, _engine.Current);
                //>>switch (fieldInfo.Kind)
                //>>{
                //>>    case FieldKind.UnaryModel:
                hash = (hash * 397) ^ (field_T_UnaryModelFieldName_.CalcHashUnary());
                //>>    break; case FieldKind.ArrayModel:
                hash = (hash * 397) ^ (field_T_ArrayModelFieldName_.CalcHashArray());
                //>>    break; case FieldKind.IndexModel:
                hash = (hash * 397) ^ (field_T_IndexModelFieldName_.CalcHashIndex());
                //>>    break; case FieldKind.UnaryMaybe:
                hash = (hash * 397) ^ (field_T_UnaryMaybeFieldName_.CalcHashUnary());
                //>>    break; case FieldKind.ArrayMaybe:
                hash = (hash * 397) ^ (field_T_ArrayMaybeFieldName_.CalcHashArray());
                //>>    break; case FieldKind.IndexMaybe:
                hash = (hash * 397) ^ (field_T_IndexMaybeFieldName_.CalcHashIndex());
                //>>    break; case FieldKind.UnaryOther:
                hash = (hash * 397) ^ (field_T_UnaryOtherFieldName_.CalcHashUnary());
                //>>    break; case FieldKind.ArrayOther:
                hash = (hash * 397) ^ (field_T_ArrayOtherFieldName_.CalcHashArray());
                //>>    break; case FieldKind.IndexOther:
                hash = (hash * 397) ^ (field_T_IndexOtherFieldName_.CalcHashIndex());
                //>>    break; case FieldKind.UnaryBuffer:
                hash = (hash * 397) ^ (field_T_UnaryBufferFieldName_.CalcHashUnary());
                //>>    break; case FieldKind.ArrayBuffer:
                hash = (hash * 397) ^ (field_T_ArrayBufferFieldName_.CalcHashArray());
                //>>    break; case FieldKind.IndexBuffer:
                hash = (hash * 397) ^ (field_T_IndexBufferFieldName_.CalcHashIndex());
                //>>    break; case FieldKind.UnaryString:
                hash = (hash * 397) ^ (field_T_UnaryStringFieldName_.CalcHashUnary());
                //>>    break; case FieldKind.ArrayString:
                hash = (hash * 397) ^ (field_T_ArrayStringFieldName_.CalcHashArray());
                //>>    break; case FieldKind.IndexString:
                hash = (hash * 397) ^ (field_T_IndexStringFieldName_.CalcHashIndex());
                //>>    break; default: break;
                //>>}
                //>>}}
            }
            return hash;
        }

    }

    //>>}}

}
// |metacode:template_end|
