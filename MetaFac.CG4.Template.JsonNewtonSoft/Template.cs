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
using MetaFac.Mutability;
using MetaFac.CG4.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using T_Namespace_.Contracts;
using MetaFac.Memory;

namespace T_Namespace_.JsonNewtonSoft
{
    //>>using (Ignored())
    //>>{
    using T_ExternalOtherType_ = System.Int64;
    using T_ExternalMaybeType_ = System.DayOfWeek;
    using T_IndexType_ = System.String;
    //>>}

    //>>using (Ignored())
    //>>{
    public class T_ModelType_ : EntityBase, IT_ModelType_, IEquatable<T_ModelType_>
    {
        public static T_ModelType_? CreateFrom(IT_ModelType_? source)
        {
            if (source is null) return null;
            if (source is T_ModelType_ concrete) return concrete;
            return new T_ModelType_(source);
        }

        protected override int OnGetEntityTag() => 0;

        public int TestData { get; set; }

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

        public virtual bool Equals(T_ModelType_? other) => true;
        public override int GetHashCode() => 0;
        public override bool Equals(object? obj) => obj is T_ModelType_ other && Equals(other);
    }
    //>>}

    public abstract class EntityBase : IFreezable, IEntityBase
    {
        public static EntityBase Empty => throw new NotSupportedException();
        public const int EntityTag = 0;
        public EntityBase() { }
        public EntityBase(EntityBase? source) { }
        public EntityBase(IEntityBase? source) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFrom(IEntityBase? source) { }
        protected abstract int OnGetEntityTag();
        public int GetEntityTag() => OnGetEntityTag();
        public bool Equals(EntityBase? other) => true;
        public override int GetHashCode() => 0;

        public bool IsFreezable() => false;
        public bool IsFrozen() => false;
        public void Freeze() { }
        public bool TryFreeze() => true;
    }

    //>>using (Ignored())
    //>>{
    public class T_ParentName_ : EntityBase, IT_ParentName_
    {
        private static readonly T_ParentName_ _empty = new T_ParentName_();
        public static new T_ParentName_ Empty => _empty;

        public new const int EntityTag = 999;
        public T_ParentName_() { }
        public T_ParentName_(T_ParentName_? source) : base(source) { }
        public T_ParentName_(IT_ParentName_? source) : base(source) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFrom(IT_ParentName_? source)
        {
            base.CopyFrom(source);
        }

        protected override int OnGetEntityTag() => 0;
        public virtual bool Equals(T_ParentName_? other) => true;
        public override int GetHashCode() => 0;
    }
    //>>}

    //>>foreach (var cd in outerScope.EntityDefs)
    //>>{
    //>>    using (NewScope(cd))
    //>>    {
    //>>        if (cd.AllDerivedEntities.Count > 0)
    //>>        {
    public abstract partial class T_EntityName2_
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T_EntityName_? CreateFrom(IT_EntityName_? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                //>>            foreach (var derived in cd.DerivedEntities)
                //>>            {
                //>>                using (NewScope(derived))
                //>>                {
                case T_EntityName_.EntityTag: return T_EntityName_.CreateFrom((IT_EntityName_)source);
                //>>                }
                //>>            }
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(T_EntityName_)} from {source.GetType().Name}");
            }
        }

    }
    //>>        }
    //>>        else
    //>>        {
    public partial class T_EntityName_
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T_EntityName_? CreateFrom(IT_EntityName_? source)
        {
            if (source is null) return null;
            return new T_EntityName_(source);
        }

        private static T_EntityName_ CreateEmpty()
        {
            var empty = new T_EntityName_();
            empty.Freeze();
            return empty;
        }
        private static readonly T_EntityName_ _empty = CreateEmpty();
        public static new T_EntityName_ Empty => _empty;

    }
    //>>        }
    public partial class T_EntityName_ : T_ParentName_, IT_EntityName_, IEquatable<T_EntityName_>
    {
        //>>        using (Ignored())
        //>>        {
        private const int T_EntityTag_ = 99;
        //>>        }
        public new const int EntityTag = T_EntityTag_;
        protected override int OnGetEntityTag() => EntityTag;

        //>>        foreach (var fd in cd.MemberDefs)
        //>>        {
        //>>            using (NewScope(fd))
        //>>            {
        //>>                var memberInfo = new MemberInfo(fd, _engine.Current);
        //>>                switch (memberInfo.Kind)
        //>>                {
        //>>                    case FieldKind.UnaryModel:
        private T_ModelType_? field_T_UnaryModelFieldName_;
        IT_ModelType_? IT_EntityName_.T_UnaryModelFieldName_ => field_T_UnaryModelFieldName_;
        public T_ModelType_? T_UnaryModelFieldName_
        {
            get => field_T_UnaryModelFieldName_;
            set => field_T_UnaryModelFieldName_ = value;
        }
        //>>                        break;
        //>>                    case FieldKind.ArrayModel:
        private ImmutableList<T_ModelType_?>? field_T_ArrayModelFieldName_;
        IReadOnlyList<IT_ModelType_?>? IT_EntityName_.T_ArrayModelFieldName_ => field_T_ArrayModelFieldName_;
        public ImmutableList<T_ModelType_?>? T_ArrayModelFieldName_
        {
            get => field_T_ArrayModelFieldName_;
            set => field_T_ArrayModelFieldName_ = value;
        }
        //>>                        break;
        //>>                    case FieldKind.IndexModel:
        private ImmutableDictionary<T_IndexType_, T_ModelType_?>? field_T_IndexModelFieldName_;
        IReadOnlyDictionary<T_IndexType_, IT_ModelType_?>? IT_EntityName_.T_IndexModelFieldName_
            => field_T_IndexModelFieldName_ is null ? null
            : new DictionaryFacade<T_IndexType_, IT_ModelType_?, T_ModelType_?>(field_T_IndexModelFieldName_, (x) => x);
        public ImmutableDictionary<T_IndexType_, T_ModelType_?>? T_IndexModelFieldName_
        {
            get => field_T_IndexModelFieldName_;
            set => field_T_IndexModelFieldName_ = value;
        }
        //>>                        break;
        //>>                    case FieldKind.UnaryMaybe:
        private T_ExternalMaybeType_? field_T_UnaryMaybeFieldName_;
        T_ExternalMaybeType_? IT_EntityName_.T_UnaryMaybeFieldName_ => field_T_UnaryMaybeFieldName_;
        public T_ExternalMaybeType_? T_UnaryMaybeFieldName_
        {
            get => field_T_UnaryMaybeFieldName_;
            set => field_T_UnaryMaybeFieldName_ = value;
        }
        //>>                        break;
        //>>                    case FieldKind.ArrayMaybe:
        private ImmutableList<T_ExternalMaybeType_?>? field_T_ArrayMaybeFieldName_;
        IReadOnlyList<T_ExternalMaybeType_?>? IT_EntityName_.T_ArrayMaybeFieldName_ => field_T_ArrayMaybeFieldName_;
        public ImmutableList<T_ExternalMaybeType_?>? T_ArrayMaybeFieldName_
        {
            get => field_T_ArrayMaybeFieldName_;
            set => field_T_ArrayMaybeFieldName_ = value;
        }
        //>>                        break;
        //>>                    case FieldKind.IndexMaybe:
        private ImmutableDictionary<T_IndexType_, T_ExternalMaybeType_?>? field_T_IndexMaybeFieldName_;
        IReadOnlyDictionary<T_IndexType_, T_ExternalMaybeType_?>? IT_EntityName_.T_IndexMaybeFieldName_ => field_T_IndexMaybeFieldName_;
        public ImmutableDictionary<T_IndexType_, T_ExternalMaybeType_?>? T_IndexMaybeFieldName_
        {
            get => field_T_IndexMaybeFieldName_;
            set => field_T_IndexMaybeFieldName_ = value;
        }
        //>>                        break;
        //>>                    case FieldKind.UnaryOther:
        private T_ExternalOtherType_ field_T_UnaryOtherFieldName_;
        T_ExternalOtherType_ IT_EntityName_.T_UnaryOtherFieldName_ => field_T_UnaryOtherFieldName_;
        public T_ExternalOtherType_ T_UnaryOtherFieldName_
        {
            get => field_T_UnaryOtherFieldName_;
            set => field_T_UnaryOtherFieldName_ = value;
        }
        //>>                        break;
        //>>                    case FieldKind.ArrayOther:
        private ImmutableList<T_ExternalOtherType_>? field_T_ArrayOtherFieldName_;
        IReadOnlyList<T_ExternalOtherType_>? IT_EntityName_.T_ArrayOtherFieldName_ => field_T_ArrayOtherFieldName_;
        public ImmutableList<T_ExternalOtherType_>? T_ArrayOtherFieldName_
        {
            get => field_T_ArrayOtherFieldName_;
            set => field_T_ArrayOtherFieldName_ = value;
        }
        //>>                        break;
        //>>                    case FieldKind.IndexOther:
        private ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>? field_T_IndexOtherFieldName_;
        IReadOnlyDictionary<T_IndexType_, T_ExternalOtherType_>? IT_EntityName_.T_IndexOtherFieldName_ => T_IndexOtherFieldName_;
        public ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>? T_IndexOtherFieldName_
        {
            get => field_T_IndexOtherFieldName_;
            set => field_T_IndexOtherFieldName_ = value;
        }
        //>>                        break;
        //>>                    case FieldKind.UnaryBuffer:
        Octets? IT_EntityName_.T_UnaryBufferFieldName_ => T_UnaryBufferFieldName_ is null ? null : new Octets(T_UnaryBufferFieldName_);
        public byte[]? T_UnaryBufferFieldName_ { get; set; }
        //>>                        break;
        //>>                    case FieldKind.ArrayBuffer:
        IReadOnlyList<Octets?>? IT_EntityName_.T_ArrayBufferFieldName_ => T_ArrayBufferFieldName_ is null
            ? null
            : new List<Octets?>(T_ArrayBufferFieldName_.Select(x => x is null ? null : new Octets(x)));
        public byte[]?[]? T_ArrayBufferFieldName_ { get; set; }
        //>>                        break;
        //>>                    case FieldKind.IndexBuffer:
        IReadOnlyDictionary<T_IndexType_, Octets?>? IT_EntityName_.T_IndexBufferFieldName_ => T_IndexBufferFieldName_ is null
            ? null
            : T_IndexBufferFieldName_.ToDictionary(x => x.Key, x => x.Value is null ? null : new Octets(x.Value));
        public Dictionary<T_IndexType_, byte[]?>? T_IndexBufferFieldName_ { get; set; }
        //>>                        break;
        //>>                    case FieldKind.UnaryString:
        private String? field_T_UnaryStringFieldName_;
        String? IT_EntityName_.T_UnaryStringFieldName_ => field_T_UnaryStringFieldName_;
        public String? T_UnaryStringFieldName_
        {
            get => field_T_UnaryStringFieldName_;
            set => field_T_UnaryStringFieldName_ = value;
        }
        //>>                        break;
        //>>                    case FieldKind.ArrayString:
        private ImmutableList<String?>? field_T_ArrayStringFieldName_;
        IReadOnlyList<String?>? IT_EntityName_.T_ArrayStringFieldName_ => field_T_ArrayStringFieldName_;
        public ImmutableList<String?>? T_ArrayStringFieldName_
        {
            get => field_T_ArrayStringFieldName_;
            set => field_T_ArrayStringFieldName_ = value;
        }
        //>>                        break;
        //>>                    case FieldKind.IndexString:
        private ImmutableDictionary<T_IndexType_, String?>? field_T_IndexStringFieldName_;
        IReadOnlyDictionary<T_IndexType_, String?>? IT_EntityName_.T_IndexStringFieldName_ => field_T_IndexStringFieldName_;
        public ImmutableDictionary<T_IndexType_, String?>? T_IndexStringFieldName_
        {
            get => field_T_IndexStringFieldName_;
            set => field_T_IndexStringFieldName_ = value;
        }
        //>>                        break;
        //>>                    default: break;
        //>>                }
        //>>            }
        //>>        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_EntityName_() : base()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_EntityName_(T_EntityName_? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            //>>        foreach (var fd in cd.MemberDefs)
            //>>        {
            //>>            using (NewScope(fd))
            //>>            {
            //>>                var memberInfo = new MemberInfo(fd, _engine.Current);
            //>>                switch (memberInfo.Kind)
            //>>                {
            //>>                    case FieldKind.UnaryModel:
            field_T_UnaryModelFieldName_ = source.T_UnaryModelFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayModel:
            field_T_ArrayModelFieldName_ = source.T_ArrayModelFieldName_;
            //>>                        break;
            //>>                    case FieldKind.IndexModel:
            field_T_IndexModelFieldName_ = source.T_IndexModelFieldName_;
            //>>                        break;
            //>>                    case FieldKind.UnaryMaybe:
            field_T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayMaybe:
            field_T_ArrayMaybeFieldName_ = source.T_ArrayMaybeFieldName_;
            //>>                        break;
            //>>                    case FieldKind.IndexMaybe:
            field_T_IndexMaybeFieldName_ = source.T_IndexMaybeFieldName_;
            //>>                        break;
            //>>                    case FieldKind.UnaryOther:
            field_T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayOther:
            field_T_ArrayOtherFieldName_ = source.T_ArrayOtherFieldName_;
            //>>                        break;
            //>>                    case FieldKind.IndexOther:
            field_T_IndexOtherFieldName_ = source.T_IndexOtherFieldName_;
            //>>                        break;
            //>>                    case FieldKind.UnaryBuffer:
            this.T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayBuffer:
            this.T_ArrayBufferFieldName_ = source.T_ArrayBufferFieldName_;
            //>>                        break;
            //>>                    case FieldKind.IndexBuffer:
            this.T_IndexBufferFieldName_ = source.T_IndexBufferFieldName_;
            //>>                        break;
            //>>                    case FieldKind.UnaryString:
            field_T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayString:
            field_T_ArrayStringFieldName_ = source.T_ArrayStringFieldName_;
            //>>                        break;
            //>>                    case FieldKind.IndexString:
            field_T_IndexStringFieldName_ = source.T_IndexStringFieldName_;
            //>>                        break;
            //>>                    default: break;
            //>>                }
            //>>            }
            //>>        }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T_EntityName_(IT_EntityName_? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            //>>        foreach (var fd in cd.MemberDefs)
            //>>        {
            //>>            using (NewScope(fd))
            //>>            {
            //>>                var memberInfo = new MemberInfo(fd, _engine.Current);
            //>>                switch (memberInfo.Kind)
            //>>                {
            //>>                    case FieldKind.UnaryModel:
            field_T_UnaryModelFieldName_ = T_ModelType_.CreateFrom(source.T_UnaryModelFieldName_);
            //>>                        break;
            //>>                    case FieldKind.ArrayModel:
            field_T_ArrayModelFieldName_ = source.T_ArrayModelFieldName_ is null
                ? default
                : ImmutableList<T_ModelType_?>.Empty.AddRange(source.T_ArrayModelFieldName_.Select(x => T_ModelType_.CreateFrom(x)));
            //>>                        break;
            //>>                    case FieldKind.IndexModel:
            field_T_IndexModelFieldName_ = source.T_IndexModelFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty.AddRange(
                    source.T_IndexModelFieldName_.Select(x => new KeyValuePair<T_IndexType_, T_ModelType_?>(x.Key, T_ModelType_.CreateFrom(x.Value))));
            //>>                        break;
            //>>                    case FieldKind.UnaryMaybe:
            field_T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayMaybe:
            field_T_ArrayMaybeFieldName_ = source.T_ArrayMaybeFieldName_ is null
                ? default
                : ImmutableList<T_ExternalMaybeType_?>.Empty.AddRange(source.T_ArrayMaybeFieldName_);
            //>>                        break;
            //>>                    case FieldKind.IndexMaybe:
            field_T_IndexMaybeFieldName_ = source.T_IndexMaybeFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalMaybeType_?>.Empty.AddRange(source.T_IndexMaybeFieldName_);
            //>>                        break;
            //>>                    case FieldKind.UnaryOther:
            field_T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayOther:
            field_T_ArrayOtherFieldName_ = source.T_ArrayOtherFieldName_ is null
                ? default
                : ImmutableList<T_ExternalOtherType_>.Empty.AddRange(source.T_ArrayOtherFieldName_);
            //>>                        break;
            //>>                    case FieldKind.IndexOther:
            field_T_IndexOtherFieldName_ = source.T_IndexOtherFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty.AddRange(source.T_IndexOtherFieldName_);
            //>>                        break;
            //>>                    case FieldKind.UnaryBuffer:
            this.T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_ is null
                ? default
                : source.T_UnaryBufferFieldName_.Memory.ToArray();
            //>>                        break;
            //>>                    case FieldKind.ArrayBuffer:
            this.T_ArrayBufferFieldName_ = source.T_ArrayBufferFieldName_ is null
                ? default
                : source.T_ArrayBufferFieldName_.Select(x => x is null ? null : x.Memory.ToArray()).ToArray();
            //>>                        break;
            //>>                    case FieldKind.IndexBuffer:
            this.T_IndexBufferFieldName_ = source.T_IndexBufferFieldName_ is null
                ? default
                : source.T_IndexBufferFieldName_.ToDictionary(x => x.Key, x => x.Value is null ? null : x.Value.Memory.ToArray());
            //>>                        break;
            //>>                    case FieldKind.UnaryString:
            field_T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayString:
            field_T_ArrayStringFieldName_ = source.T_ArrayStringFieldName_ is null
                ? default
                : ImmutableList<String?>.Empty.AddRange(source.T_ArrayStringFieldName_);
            //>>                        break;
            //>>                    case FieldKind.IndexString:
            field_T_IndexStringFieldName_ = source.T_IndexStringFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, String?>.Empty.AddRange(source.T_IndexStringFieldName_);
            //>>                        break;
            //>>                    default: break;
            //>>                }
            //>>            }
            //>>        }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFrom(IT_EntityName_? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
            //>>        foreach (var fd in cd.MemberDefs)
            //>>        {
            //>>            using (NewScope(fd))
            //>>            {
            //>>                var memberInfo = new MemberInfo(fd, _engine.Current);
            //>>                switch (memberInfo.Kind)
            //>>                {
            //>>                    case FieldKind.UnaryModel:
            field_T_UnaryModelFieldName_ = T_ModelType_.CreateFrom(source.T_UnaryModelFieldName_);
            //>>                        break;
            //>>                    case FieldKind.ArrayModel:
            field_T_ArrayModelFieldName_ = source.T_ArrayModelFieldName_ is null
                ? default
                : ImmutableList<T_ModelType_?>.Empty.AddRange(source.T_ArrayModelFieldName_.Select(x => T_ModelType_.CreateFrom(x)));
            //>>                        break;
            //>>                    case FieldKind.IndexModel:
            field_T_IndexModelFieldName_ = source.T_IndexModelFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty.AddRange(
                    source.T_IndexModelFieldName_.Select(x => new KeyValuePair<T_IndexType_, T_ModelType_?>(x.Key, T_ModelType_.CreateFrom(x.Value))));
            //>>                        break;
            //>>                    case FieldKind.UnaryMaybe:
            field_T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayMaybe:
            field_T_ArrayMaybeFieldName_ = source.T_ArrayMaybeFieldName_ is null
                ? default
                : ImmutableList<T_ExternalMaybeType_?>.Empty.AddRange(source.T_ArrayMaybeFieldName_);
            //>>                        break;
            //>>                    case FieldKind.IndexMaybe:
            field_T_IndexMaybeFieldName_ = source.T_IndexMaybeFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalMaybeType_?>.Empty.AddRange(source.T_IndexMaybeFieldName_);
            //>>                        break;
            //>>                    case FieldKind.UnaryOther:
            field_T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayOther:
            field_T_ArrayOtherFieldName_ = source.T_ArrayOtherFieldName_ is null
                ? default
                : ImmutableList<T_ExternalOtherType_>.Empty.AddRange(source.T_ArrayOtherFieldName_);
            //>>                        break;
            //>>                    case FieldKind.IndexOther:
            field_T_IndexOtherFieldName_ = source.T_IndexOtherFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty.AddRange(source.T_IndexOtherFieldName_);
            //>>                        break;
            //>>                    case FieldKind.UnaryBuffer:
            this.T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_ is null
                ? default
                : source.T_UnaryBufferFieldName_.Memory.ToArray();
            //>>                        break;
            //>>                    case FieldKind.ArrayBuffer:
            this.T_ArrayBufferFieldName_ = source.T_ArrayBufferFieldName_ is null
                ? default
                : source.T_ArrayBufferFieldName_.Select(x => x is null ? null : x.Memory.ToArray()).ToArray();
            //>>                        break;
            //>>                    case FieldKind.IndexBuffer:
            this.T_IndexBufferFieldName_ = source.T_IndexBufferFieldName_ is null
                ? default
                : source.T_IndexBufferFieldName_.ToDictionary(x => x.Key, x => x.Value is null ? null : x.Value.Memory.ToArray());
            //>>                        break;
            //>>                    case FieldKind.UnaryString:
            field_T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayString:
            field_T_ArrayStringFieldName_ = source.T_ArrayStringFieldName_ is null
                ? default
                : ImmutableList<String?>.Empty.AddRange(source.T_ArrayStringFieldName_);
            //>>                        break;
            //>>                    case FieldKind.IndexString:
            field_T_IndexStringFieldName_ = source.T_IndexStringFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, String?>.Empty.AddRange(source.T_IndexStringFieldName_);
            //>>                        break;
            //>>                    default: break;
            //>>                }
            //>>            }
            //>>        }
        }

        public bool Equals(T_EntityName_? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            //>>        foreach (var fd in cd.MemberDefs)
            //>>        {
            //>>            using (NewScope(fd))
            //>>            {
            //>>                var memberInfo = new MemberInfo(fd, _engine.Current);
            //>>                switch (memberInfo.Kind)
            //>>                {
            //>>                    case FieldKind.UnaryModel:
            if (!T_UnaryModelFieldName_.ValueEquals(other.T_UnaryModelFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.ArrayModel:
            if (!T_ArrayModelFieldName_.ArrayEquals(other.T_ArrayModelFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.IndexModel:
            if (!T_IndexModelFieldName_.IndexEquals(other.T_IndexModelFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.UnaryMaybe:
            if (T_UnaryMaybeFieldName_ != other.T_UnaryMaybeFieldName_) return false;
            //>>                        break;
            //>>                    case FieldKind.ArrayMaybe:
            if (!T_ArrayMaybeFieldName_.ArrayEquals(other.T_ArrayMaybeFieldName_, (a, b) => a == b)) return false;
            //>>                        break;
            //>>                    case FieldKind.IndexMaybe:
            if (!T_IndexMaybeFieldName_.IndexEquals(other.T_IndexMaybeFieldName_, (a, b) => a == b)) return false;
            //>>                        break;
            //>>                    case FieldKind.UnaryOther:
            if (T_UnaryOtherFieldName_ != other.T_UnaryOtherFieldName_) return false;
            //>>                        break;
            //>>                    case FieldKind.ArrayOther:
            if (!T_ArrayOtherFieldName_.ArrayEquals(other.T_ArrayOtherFieldName_, (a, b) => a == b)) return false;
            //>>                        break;
            //>>                    case FieldKind.IndexOther:
            if (!T_IndexOtherFieldName_.IndexEquals(other.T_IndexOtherFieldName_, (a, b) => a == b)) return false;
            //>>                        break;
            //>>                    case FieldKind.UnaryBuffer:
            if (!T_UnaryBufferFieldName_.ValueEquals(other.T_UnaryBufferFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.ArrayBuffer:
            if (!T_ArrayBufferFieldName_.ArrayEquals(other.T_ArrayBufferFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.IndexBuffer:
            if (!T_IndexBufferFieldName_.IndexEquals(other.T_IndexBufferFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.UnaryString:
            if (!T_UnaryStringFieldName_.ValueEquals(other.T_UnaryStringFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.ArrayString:
            if (!T_ArrayStringFieldName_.ArrayEquals(other.T_ArrayStringFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.IndexString:
            if (!T_IndexStringFieldName_.IndexEquals(other.T_IndexStringFieldName_)) return false;
            //>>                        break;
            //>>                    default: break;
            //>>                }
            //>>            }
            //>>        }
            return true;
        }

        public override bool Equals(object? obj) => obj is T_EntityName_ other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            //>>        foreach (var fd in cd.MemberDefs)
            //>>        {
            //>>            using (NewScope(fd))
            //>>            {
            //>>                var memberInfo = new MemberInfo(fd, _engine.Current);
            //>>                switch (memberInfo.Kind)
            //>>                {
            //>>                    case FieldKind.UnaryModel:
            hc.Add(T_UnaryModelFieldName_.CalcHashUnary());
            //>>                        break;
            //>>                    case FieldKind.ArrayModel:
            hc.Add(T_ArrayModelFieldName_.CalcHashArray());
            //>>                        break;
            //>>                    case FieldKind.IndexModel:
            hc.Add(T_IndexModelFieldName_.CalcHashIndex());
            //>>                        break;
            //>>                    case FieldKind.UnaryMaybe:
            hc.Add(T_UnaryMaybeFieldName_.CalcHashUnary());
            //>>                        break;
            //>>                    case FieldKind.ArrayMaybe:
            hc.Add(T_ArrayMaybeFieldName_.CalcHashArray());
            //>>                        break;
            //>>                    case FieldKind.IndexMaybe:
            hc.Add(T_IndexMaybeFieldName_.CalcHashIndex());
            //>>                        break;
            //>>                    case FieldKind.UnaryOther:
            hc.Add(T_UnaryOtherFieldName_.CalcHashUnary());
            //>>                        break;
            //>>                    case FieldKind.ArrayOther:
            hc.Add(T_ArrayOtherFieldName_.CalcHashArray());
            //>>                        break;
            //>>                    case FieldKind.IndexOther:
            hc.Add(T_IndexOtherFieldName_.CalcHashIndex());
            //>>                        break;
            //>>                    case FieldKind.UnaryBuffer:
            hc.Add(T_UnaryBufferFieldName_.CalcHashUnary());
            //>>                        break;
            //>>                    case FieldKind.ArrayBuffer:
            hc.Add(T_ArrayBufferFieldName_.CalcHashArray());
            //>>                        break;
            //>>                    case FieldKind.IndexBuffer:
            hc.Add(T_IndexBufferFieldName_.CalcHashIndex());
            //>>                        break;
            //>>                    case FieldKind.UnaryString:
            hc.Add(T_UnaryStringFieldName_.CalcHashUnary());
            //>>                        break;
            //>>                    case FieldKind.ArrayString:
            hc.Add(T_ArrayStringFieldName_.CalcHashArray());
            //>>                        break;
            //>>                    case FieldKind.IndexString:
            hc.Add(T_IndexStringFieldName_.CalcHashIndex());
            //>>                        break;
            //>>                    default: break;
            //>>                }
            //>>            }
            //>>        }
            return hc.ToHashCode();
        }
    }

    //>>    }
    //>>}

    //>>using (Ignored())
    //>>{
    public class T_DerivedName_ : T_EntityName_, IT_DerivedName_
    {
        public T_DerivedName_() { }
        public T_DerivedName_(T_DerivedName_? source) : base(source) { }
        public T_DerivedName_(IT_DerivedName_? source) : base(source) { }
        public virtual bool Equals(T_DerivedName_? other) => true;
        public override int GetHashCode() => 0;
    }
    //>>}
}
// |metacode:template_end|
