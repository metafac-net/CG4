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
//>>Define("BinaryFieldType","ReadOnlyMemory<byte>");
//>>Define("BaseClassName","EntityBase");
// <auto-generated />
#region Auto-generated
//--------------------------------------------------------------------------------
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
//
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
//
// To download and install the tool, the .NET CLI command is:
// dotnet tool install --global MetaFac.CG4.CLI
//
// For more information about using this tool, the help command is:
// mfcg4 g2c --help
//--------------------------------------------------------------------------------
#endregion
#nullable enable
using MetaFac.Mutability;
using MetaFac.CG4.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using T_Namespace_.Contracts;

namespace T_Namespace_.ClassesV2
{
    //>>using (Ignored()) {
    using T_ExternalOtherType_ = System.Int64;
    using T_IndexType_ = System.String;
    //>>}

    //>>using (Ignored()) {
    public class T_ModelType_ : EntityBase, IT_ModelType_, IEquatable<T_ModelType_>
    {
        public static T_ModelType_? CreateFrom(IT_ModelType_? source)
        {
            if (source is null) return null;
            if (source is T_ModelType_ concrete) return concrete;
            return new T_ModelType_(source);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowIsReadonly()
        {
            throw new InvalidOperationException("Cannot set properties when frozen");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref T CheckNotFrozen<T>(ref T value)
        {
            if (_isFrozen) ThrowIsReadonly();
            return ref value;
        }

        protected override int OnGetEntityTag() => 0;

        private int _testData;
        public int TestData
        {
            get => _testData;
            set => _testData = CheckNotFrozen(ref value);
        }

        public T_ModelType_() { }
        public T_ModelType_(int testData)
        {
            _testData = testData;
        }
        public T_ModelType_(IT_ModelType_ source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            _testData = source.TestData;
        }

        public virtual bool Equals(T_ModelType_? other) => true;
        public override int GetHashCode() => 0;
        public override bool Equals(object? obj) => obj is T_ModelType_ other && Equals(other);
    }
    //>>}

    public abstract class EntityBase : IFreezable, IEntityBase
    {
        public static EntityBase Empty => throw new NotSupportedException();
        public const int ClassTag = 0;
        public EntityBase() { }
        public EntityBase(EntityBase? source) { }
        public EntityBase(IEntityBase? source) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFrom(IEntityBase? source) { }
        protected abstract int OnGetEntityTag();
        public int GetEntityTag() => OnGetEntityTag();
        public virtual bool Equals(EntityBase? other) => true;
        public override int GetHashCode() => 0;

        protected volatile bool _isFrozen = false;
        public bool IsFreezable() => true;
        public bool IsFrozen() => _isFrozen;
        protected virtual void OnFreeze() { }
        public void Freeze()
        {
            if (_isFrozen) return;
            OnFreeze();
            _isFrozen = true;
        }
        public bool TryFreeze()
        {
            if (_isFrozen) return false;
            OnFreeze();
            _isFrozen = true;
            return true;
        }
    }

    //>>using (Ignored()) {
    public class T_BaseClassName_ : EntityBase, IT_BaseClassName_
    {
        private static readonly T_BaseClassName_ _empty = new T_BaseClassName_();
        public static new T_BaseClassName_ Empty => _empty;

        public new const int ClassTag = 999;
        public T_BaseClassName_() { }
        public T_BaseClassName_(T_BaseClassName_? source) : base(source) { }
        public T_BaseClassName_(IT_BaseClassName_? source) : base(source) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFrom(IT_BaseClassName_? source)
        {
            base.CopyFrom(source);
        }

        protected override int OnGetEntityTag() => 0;
        public virtual bool Equals(T_BaseClassName_? other) => true;
        public override int GetHashCode() => 0;
    }
    //>>}

    //>>foreach (var cd in outerScope.ClassDefs) {
    //>>using (NewScope(cd)) {
    //>>if (cd.IsAbstract) {
    public abstract partial class T_ClassName2_
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T_ClassName_? CreateFrom(IT_ClassName_? source)
        {
            if (source is null) return null;
            int classTag = source.GetEntityTag();
            switch (classTag)
            {
                //>>foreach (var derived in cd.AllDerivedClasses) {
                //>>    using (NewScope(derived.Tokens)) {
                case T_ClassName_.ClassTag: return T_ClassName_.CreateFrom((IT_ClassName_)source);
                //>>}}
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(T_ClassName_)} from {source.GetType().Name}");
            }
        }

    }
    //>>} else {
    public partial class T_ClassName_
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T_ClassName_? CreateFrom(IT_ClassName_? source)
        {
            if (source is null) return null;
            if (source is T_ClassName_ thisClass && thisClass._isFrozen) return thisClass;
            return new T_ClassName_(source);
        }

        private static T_ClassName_ CreateEmpty()
        {
            var empty = new T_ClassName_();
            empty.Freeze();
            return empty;
        }
        private static readonly T_ClassName_ _empty = CreateEmpty();
        public static new T_ClassName_ Empty => _empty;

    }
    //>>}
    public partial class T_ClassName_ : T_BaseClassName_, IT_ClassName_, IEquatable<T_ClassName_>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowIsReadonly()
        {
            throw new InvalidOperationException("Cannot set properties when frozen");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref T CheckNotFrozen<T>(ref T value)
        {
            if (_isFrozen) ThrowIsReadonly();
            return ref value;
        }

        protected override void OnFreeze()
        {
            //>>foreach (var fd in cd.FieldDefs) {
            //>>  using (NewScope(fd)) {
            //>>    var fieldInfo = new FieldInfo(fd, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            field_T_UnaryModelFieldName_?.Freeze();
            //>>    break; case FieldKind.ArrayModel:
            if (!(field_T_ArrayModelFieldName_ is null))
            {
                foreach (var element in field_T_ArrayModelFieldName_)
                {
                    element?.Freeze();
                }
            }
            //>>    break; case FieldKind.IndexModel:
            if (!(field_T_IndexModelFieldName_ is null))
            {
                foreach (var element in field_T_IndexModelFieldName_.Values)
                {
                    element?.Freeze();
                }
            }
            //>>    break; default: break;
            //>>}
            //>>}}
            base.OnFreeze();
        }

        //>>using (Ignored()) {
        private const int T_ClassTag_ = 99;
        //>>}
        public new const int ClassTag = T_ClassTag_;
        protected override int OnGetEntityTag() => ClassTag;

        //>>foreach (var fd in cd.FieldDefs) {
        //>>  using (NewScope(fd)) {
        //>>    var fieldInfo = new FieldInfo(fd, _engine.Current);
        //>>switch (fieldInfo.Kind)
        //>>{
        //>>    case FieldKind.UnaryModel:
        private T_ModelType_? field_T_UnaryModelFieldName_;
        IT_ModelType_? IT_ClassName_.T_UnaryModelFieldName_ => field_T_UnaryModelFieldName_;
        public T_ModelType_? T_UnaryModelFieldName_
        {
            get => field_T_UnaryModelFieldName_;
            set => field_T_UnaryModelFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.ArrayModel:
        public ImmutableList<T_ModelType_?>? field_T_ArrayModelFieldName_;
        IReadOnlyList<IT_ModelType_?>? IT_ClassName_.T_ArrayModelFieldName_ => field_T_ArrayModelFieldName_;
        public ImmutableList<T_ModelType_?>? T_ArrayModelFieldName_
        {
            get => field_T_ArrayModelFieldName_;
            set => field_T_ArrayModelFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.IndexModel:
        private ImmutableDictionary<T_IndexType_, T_ModelType_?>? field_T_IndexModelFieldName_;
        IReadOnlyDictionary<T_IndexType_, IT_ModelType_?>? IT_ClassName_.T_IndexModelFieldName_
            => field_T_IndexModelFieldName_ is null ? null
            : new DictionaryFacade<T_IndexType_, IT_ModelType_?, T_ModelType_?>(field_T_IndexModelFieldName_, (x) => x);
        public ImmutableDictionary<T_IndexType_, T_ModelType_?>? T_IndexModelFieldName_
        {
            get => field_T_IndexModelFieldName_;
            set => field_T_IndexModelFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.UnaryMaybe:
        private T_ExternalOtherType_? field_T_UnaryMaybeFieldName_;
        T_ExternalOtherType_? IT_ClassName_.T_UnaryMaybeFieldName_ => field_T_UnaryMaybeFieldName_;
        public T_ExternalOtherType_? T_UnaryMaybeFieldName_
        {
            get => field_T_UnaryMaybeFieldName_;
            set => field_T_UnaryMaybeFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.ArrayMaybe:
        private ImmutableList<T_ExternalOtherType_?>? field_T_ArrayMaybeFieldName_;
        IReadOnlyList<T_ExternalOtherType_?>? IT_ClassName_.T_ArrayMaybeFieldName_ => field_T_ArrayMaybeFieldName_;
        public ImmutableList<T_ExternalOtherType_?>? T_ArrayMaybeFieldName_
        {
            get => field_T_ArrayMaybeFieldName_;
            set => field_T_ArrayMaybeFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.IndexMaybe:
        private ImmutableDictionary<T_IndexType_, T_ExternalOtherType_?>? field_T_IndexMaybeFieldName_;
        IReadOnlyDictionary<T_IndexType_, T_ExternalOtherType_?>? IT_ClassName_.T_IndexMaybeFieldName_ => field_T_IndexMaybeFieldName_;
        public ImmutableDictionary<T_IndexType_, T_ExternalOtherType_?>? T_IndexMaybeFieldName_
        {
            get => field_T_IndexMaybeFieldName_;
            set => field_T_IndexMaybeFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.UnaryOther:
        private T_ExternalOtherType_ field_T_UnaryOtherFieldName_;
        T_ExternalOtherType_ IT_ClassName_.T_UnaryOtherFieldName_ => field_T_UnaryOtherFieldName_;
        public T_ExternalOtherType_ T_UnaryOtherFieldName_
        {
            get => field_T_UnaryOtherFieldName_;
            set => field_T_UnaryOtherFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.ArrayOther:
        private ImmutableList<T_ExternalOtherType_>? field_T_ArrayOtherFieldName_;
        IReadOnlyList<T_ExternalOtherType_>? IT_ClassName_.T_ArrayOtherFieldName_ => field_T_ArrayOtherFieldName_;
        public ImmutableList<T_ExternalOtherType_>? T_ArrayOtherFieldName_
        {
            get => field_T_ArrayOtherFieldName_;
            set => field_T_ArrayOtherFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.IndexOther:
        private ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>? field_T_IndexOtherFieldName_;
        IReadOnlyDictionary<T_IndexType_, T_ExternalOtherType_>? IT_ClassName_.T_IndexOtherFieldName_ => T_IndexOtherFieldName_;
        public ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>? T_IndexOtherFieldName_
        {
            get => field_T_IndexOtherFieldName_;
            set => field_T_IndexOtherFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.UnaryBuffer:
        private ReadOnlyMemory<byte> field_T_UnaryBufferFieldName_;
        ReadOnlyMemory<byte> IT_ClassName_.T_UnaryBufferFieldName_ => field_T_UnaryBufferFieldName_;
        public ReadOnlyMemory<byte> T_UnaryBufferFieldName_
        {
            get => field_T_UnaryBufferFieldName_;
            set => field_T_UnaryBufferFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.ArrayBuffer:
        private ImmutableList<ReadOnlyMemory<byte>>? field_T_ArrayBufferFieldName_;
        IReadOnlyList<ReadOnlyMemory<byte>>? IT_ClassName_.T_ArrayBufferFieldName_ => field_T_ArrayBufferFieldName_;
        public ImmutableList<ReadOnlyMemory<byte>>? T_ArrayBufferFieldName_
        {
            get => field_T_ArrayBufferFieldName_;
            set => field_T_ArrayBufferFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.IndexBuffer:
        private ImmutableDictionary<T_IndexType_, ReadOnlyMemory<byte>>? field_T_IndexBufferFieldName_;
        IReadOnlyDictionary<T_IndexType_, ReadOnlyMemory<byte>>? IT_ClassName_.T_IndexBufferFieldName_ => field_T_IndexBufferFieldName_;
        public ImmutableDictionary<T_IndexType_, ReadOnlyMemory<byte>>? T_IndexBufferFieldName_
        {
            get => field_T_IndexBufferFieldName_;
            set => field_T_IndexBufferFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.UnaryString:
        private String? field_T_UnaryStringFieldName_;
        String? IT_ClassName_.T_UnaryStringFieldName_ => field_T_UnaryStringFieldName_;
        public String? T_UnaryStringFieldName_
        {
            get => field_T_UnaryStringFieldName_;
            set => field_T_UnaryStringFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.ArrayString:
        private ImmutableList<String?>? field_T_ArrayStringFieldName_;
        IReadOnlyList<String?>? IT_ClassName_.T_ArrayStringFieldName_ => field_T_ArrayStringFieldName_;
        public ImmutableList<String?>? T_ArrayStringFieldName_
        {
            get => field_T_ArrayStringFieldName_;
            set => field_T_ArrayStringFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; case FieldKind.IndexString:
        private ImmutableDictionary<T_IndexType_, String?>? field_T_IndexStringFieldName_;
        IReadOnlyDictionary<T_IndexType_, String?>? IT_ClassName_.T_IndexStringFieldName_ => field_T_IndexStringFieldName_;
        public ImmutableDictionary<T_IndexType_, String?>? T_IndexStringFieldName_
        {
            get => field_T_IndexStringFieldName_;
            set => field_T_IndexStringFieldName_ = CheckNotFrozen(ref value);
        }
        //>>    break; default: break;
        //>>}
        //>>}}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_ClassName_() : base()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_ClassName_(T_ClassName_? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            //>>foreach (var fd in cd.FieldDefs) {
            //>>  using (NewScope(fd)) {
            //>>    var fieldInfo = new FieldInfo(fd, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            field_T_UnaryModelFieldName_ = source.T_UnaryModelFieldName_;
            //>>    break; case FieldKind.ArrayModel:
            field_T_ArrayModelFieldName_ = source.T_ArrayModelFieldName_;
            //>>    break; case FieldKind.IndexModel:
            field_T_IndexModelFieldName_ = source.T_IndexModelFieldName_;
            //>>    break; case FieldKind.UnaryMaybe:
            field_T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;
            //>>    break; case FieldKind.ArrayMaybe:
            field_T_ArrayMaybeFieldName_ = source.T_ArrayMaybeFieldName_;
            //>>    break; case FieldKind.IndexMaybe:
            field_T_IndexMaybeFieldName_ = source.T_IndexMaybeFieldName_;
            //>>    break; case FieldKind.UnaryOther:
            field_T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;
            //>>    break; case FieldKind.ArrayOther:
            field_T_ArrayOtherFieldName_ = source.T_ArrayOtherFieldName_;
            //>>    break; case FieldKind.IndexOther:
            field_T_IndexOtherFieldName_ = source.T_IndexOtherFieldName_;
            //>>    break; case FieldKind.UnaryBuffer:
            field_T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_;
            //>>    break; case FieldKind.ArrayBuffer:
            field_T_ArrayBufferFieldName_ = source.T_ArrayBufferFieldName_;
            //>>    break; case FieldKind.IndexBuffer:
            field_T_IndexBufferFieldName_ = source.T_IndexBufferFieldName_;
            //>>    break; case FieldKind.UnaryString:
            field_T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;
            //>>    break; case FieldKind.ArrayString:
            field_T_ArrayStringFieldName_ = source.T_ArrayStringFieldName_;
            //>>    break; case FieldKind.IndexString:
            field_T_IndexStringFieldName_ = source.T_IndexStringFieldName_;
            //>>    break; default: break;
            //>>}
            //>>}}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_ClassName_(IT_ClassName_? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            //>>foreach (var fd in cd.FieldDefs) {
            //>>  using (NewScope(fd)) {
            //>>    var fieldInfo = new FieldInfo(fd, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            field_T_UnaryModelFieldName_ = T_ModelType_.CreateFrom(source.T_UnaryModelFieldName_);
            //>>    break; case FieldKind.ArrayModel:
            field_T_ArrayModelFieldName_ = source.T_ArrayModelFieldName_ is null
                ? default
                : ImmutableList<T_ModelType_?>.Empty.AddRange(source.T_ArrayModelFieldName_.Select(x => T_ModelType_.CreateFrom(x)));
            //>>    break; case FieldKind.IndexModel:
            field_T_IndexModelFieldName_ = source.T_IndexModelFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty.AddRange(
                    source.T_IndexModelFieldName_.Select(x => new KeyValuePair<T_IndexType_, T_ModelType_?>(x.Key, T_ModelType_.CreateFrom(x.Value))));
            //>>    break; case FieldKind.UnaryMaybe:
            field_T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;
            //>>    break; case FieldKind.ArrayMaybe:
            field_T_ArrayMaybeFieldName_ = source.T_ArrayMaybeFieldName_ is null
                ? default
                : ImmutableList<T_ExternalOtherType_?>.Empty.AddRange(source.T_ArrayMaybeFieldName_);
            //>>    break; case FieldKind.IndexMaybe:
            field_T_IndexMaybeFieldName_ = source.T_IndexMaybeFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalOtherType_?>.Empty.AddRange(source.T_IndexMaybeFieldName_);
            //>>    break; case FieldKind.UnaryOther:
            field_T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;
            //>>    break; case FieldKind.ArrayOther:
            field_T_ArrayOtherFieldName_ = source.T_ArrayOtherFieldName_ is null
                ? default
                : ImmutableList<T_ExternalOtherType_>.Empty.AddRange(source.T_ArrayOtherFieldName_);
            //>>    break; case FieldKind.IndexOther:
            field_T_IndexOtherFieldName_ = source.T_IndexOtherFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty.AddRange(source.T_IndexOtherFieldName_);
            //>>    break; case FieldKind.UnaryBuffer:
            field_T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_;
            //>>    break; case FieldKind.ArrayBuffer:
            field_T_ArrayBufferFieldName_ = source.T_ArrayBufferFieldName_ is null
                ? default
                : ImmutableList<ReadOnlyMemory<byte>>.Empty.AddRange(source.T_ArrayBufferFieldName_);
            //>>    break; case FieldKind.IndexBuffer:
            field_T_IndexBufferFieldName_ = source.T_IndexBufferFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, ReadOnlyMemory<byte>>.Empty.AddRange(source.T_IndexBufferFieldName_);
            //>>    break; case FieldKind.UnaryString:
            field_T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;
            //>>    break; case FieldKind.ArrayString:
            field_T_ArrayStringFieldName_ = source.T_ArrayStringFieldName_ is null
                ? default
                : ImmutableList<String?>.Empty.AddRange(source.T_ArrayStringFieldName_);
            //>>    break; case FieldKind.IndexString:
            field_T_IndexStringFieldName_ = source.T_IndexStringFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, String?>.Empty.AddRange(source.T_IndexStringFieldName_);
            //>>    break; default: break;
            //>>}
            //>>}}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFrom(IT_ClassName_? source)
        {
            if (source is null) return;
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            //>>foreach (var fd in cd.FieldDefs) {
            //>>  using (NewScope(fd)) {
            //>>    var fieldInfo = new FieldInfo(fd, _engine.Current);
            //>>switch (fieldInfo.Kind)
            //>>{
            //>>    case FieldKind.UnaryModel:
            field_T_UnaryModelFieldName_ = T_ModelType_.CreateFrom(source.T_UnaryModelFieldName_);
            //>>    break; case FieldKind.ArrayModel:
            field_T_ArrayModelFieldName_ = source.T_ArrayModelFieldName_ is null
                ? default
                : ImmutableList<T_ModelType_?>.Empty.AddRange(source.T_ArrayModelFieldName_.Select(x => T_ModelType_.CreateFrom(x)));
            //>>    break; case FieldKind.IndexModel:
            field_T_IndexModelFieldName_ = source.T_IndexModelFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty.AddRange(
                    source.T_IndexModelFieldName_.Select(x => new KeyValuePair<T_IndexType_, T_ModelType_?>(x.Key, T_ModelType_.CreateFrom(x.Value))));
            //>>    break; case FieldKind.UnaryMaybe:
            field_T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;
            //>>    break; case FieldKind.ArrayMaybe:
            field_T_ArrayMaybeFieldName_ = source.T_ArrayMaybeFieldName_ is null
                ? default
                : ImmutableList<T_ExternalOtherType_?>.Empty.AddRange(source.T_ArrayMaybeFieldName_);
            //>>    break; case FieldKind.IndexMaybe:
            field_T_IndexMaybeFieldName_ = source.T_IndexMaybeFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalOtherType_?>.Empty.AddRange(source.T_IndexMaybeFieldName_);
            //>>    break; case FieldKind.UnaryOther:
            field_T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;
            //>>    break; case FieldKind.ArrayOther:
            field_T_ArrayOtherFieldName_ = source.T_ArrayOtherFieldName_ is null
                ? default
                : ImmutableList<T_ExternalOtherType_>.Empty.AddRange(source.T_ArrayOtherFieldName_);
            //>>    break; case FieldKind.IndexOther:
            field_T_IndexOtherFieldName_ = source.T_IndexOtherFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty.AddRange(source.T_IndexOtherFieldName_);
            //>>    break; case FieldKind.UnaryBuffer:
            field_T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_;
            //>>    break; case FieldKind.ArrayBuffer:
            field_T_ArrayBufferFieldName_ = source.T_ArrayBufferFieldName_ is null
                ? default
                : ImmutableList<ReadOnlyMemory<byte>>.Empty.AddRange(source.T_ArrayBufferFieldName_);
            //>>    break; case FieldKind.IndexBuffer:
            field_T_IndexBufferFieldName_ = source.T_IndexBufferFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, ReadOnlyMemory<byte>>.Empty.AddRange(source.T_IndexBufferFieldName_);
            //>>    break; case FieldKind.UnaryString:
            field_T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;
            //>>    break; case FieldKind.ArrayString:
            field_T_ArrayStringFieldName_ = source.T_ArrayStringFieldName_ is null
                ? default
                : ImmutableList<String?>.Empty.AddRange(source.T_ArrayStringFieldName_);
            //>>    break; case FieldKind.IndexString:
            field_T_IndexStringFieldName_ = source.T_IndexStringFieldName_ is null
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
            //>>foreach (var fd in cd.FieldDefs) {
            //>>  using (NewScope(fd)) {
            //>>    var fieldInfo = new FieldInfo(fd, _engine.Current);
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
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is T_ClassName_ other && Equals(other);

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            //>>foreach (var fd in cd.FieldDefs) {
            //>>  using (NewScope(fd)) {
            //>>    var fieldInfo = new FieldInfo(fd, _engine.Current);
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
            hc.Add(base.GetHashCode());
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

    //>>using (Ignored()) {
    public class T_SuperClassName_ : T_ClassName_, IT_SuperClassName_
    {
        public T_SuperClassName_() { }
        public T_SuperClassName_(T_SuperClassName_? source) : base(source) { }
        public T_SuperClassName_(IT_SuperClassName_? source) : base(source) { }
        public virtual bool Equals(T_SuperClassName_? other) => true;
        public override int GetHashCode() => 0;
    }
    //>>}
}
// |metacode:template_end|
