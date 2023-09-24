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
using MetaFac.Memory;
using MetaFac.Mutability;
using MetaFac.CG4.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using T_Namespace_.Contracts;

namespace T_Namespace_.RecordsV2
{
    //>>using (Ignored())
    //>>{
    using T_ExternalOtherType_ = System.Int64;
    using T_ExternalMaybeType_ = System.DayOfWeek;
    using T_IndexType_ = System.String;

    internal static class IgnoredExtensions
    {
        public static bool ValueEquals(this DayOfWeek? self, in DayOfWeek? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            return self.Value == other.Value;
        }
    }

    //>>}

    //>>using (Ignored())
    //>>{
    public sealed class T_ModelType__Factory : IEntityFactory<IT_ModelType_, T_ModelType_>
    {
        private static readonly T_ModelType__Factory _instance = new T_ModelType__Factory();
        public static T_ModelType__Factory Instance => _instance;

        public T_ModelType_? CreateFrom(IT_ModelType_? source)
        {
            if (source is null) return null;
            if (source is T_ModelType_ thisEntity) return thisEntity;
            return new T_ModelType_(source);
        }

        private readonly T_ModelType_ _empty = new T_ModelType_();
        public T_ModelType_ Empty => _empty;
    }
    public record T_ModelType_ : EntityBase, IT_ModelType_
    {
        public static T_ModelType_? CreateFrom(IT_ModelType_? source)
        {
            if (source is null) return null;
            if (source is T_ModelType_ concrete) return concrete;
            return new T_ModelType_(source);
        }

        protected override int OnGetEntityTag() => 0;

        public int TestData { get; init; }

        public T_ModelType_() { }
        public T_ModelType_(int testData)
        {
            TestData = testData;
        }
        public T_ModelType_(IT_ModelType_ source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            TestData = source.TestData;
        }
    }
    //>>}

    public abstract record EntityBase : IFreezable, IEntityBase
    {
        public EntityBase() { }
        public EntityBase(EntityBase? source) { }
        public EntityBase(IEntityBase? source) { }
        public const int EntityTag = 0;
        protected abstract int OnGetEntityTag();
        public int GetEntityTag() => OnGetEntityTag();
        public virtual bool Equals(EntityBase? other) => true;
        public override int GetHashCode() => 0;
        public bool IsFreezable() => false;
        public bool IsFrozen() => true;
        public void Freeze() { }
        public bool TryFreeze() => false;
    }

    //>>using (Ignored())
    //>>{
    public record T_ParentName_ : EntityBase, IT_ParentName_
    {
        public T_ParentName_() { }
        public T_ParentName_(T_ParentName_? source) : base(source) { }
        public T_ParentName_(IT_ParentName_? source) : base(source) { }
        public new const int EntityTag = 0;
        protected override int OnGetEntityTag() => EntityTag;
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
    public abstract partial record T_EntityName2_ : T_ParentName_, IT_EntityName2_
    {
    }
    public sealed class T_EntityName2__Factory : IEntityFactory<IT_EntityName_, T_EntityName_>
    {
        private static readonly T_EntityName2__Factory _instance = new T_EntityName2__Factory();
        public static T_EntityName2__Factory Instance => _instance;

        public T_EntityName_? CreateFrom(IT_EntityName_? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                //>>            foreach (var derived in cd.DerivedEntities)
                //>>            {
                //>>                using (NewScope(derived))
                //>>                {
                case T_EntityName_.EntityTag: return T_EntityName__Factory.Instance.CreateFrom((IT_EntityName_)source);
                //>>                }
                //>>            }
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(T_EntityName_)} from {source.GetType().Name}");
            }
        }

        public T_EntityName_ Empty => throw new NotSupportedException($"Cannot create abstract entity: {typeof(T_EntityName_)}");
    }
    //>>        }
    //>>        else
    //>>        {
    public sealed class T_EntityName__Factory : IEntityFactory<IT_EntityName_, T_EntityName_>
    {
        private static readonly T_EntityName__Factory _instance = new T_EntityName__Factory();
        public static T_EntityName__Factory Instance => _instance;

        public T_EntityName_? CreateFrom(IT_EntityName_? source)
        {
            if (source is null) return null;
            if (source is T_EntityName_ thisEntity) return thisEntity;
            return new T_EntityName_(source);
        }

        private readonly T_EntityName_ _empty = new T_EntityName_();
        public T_EntityName_ Empty => _empty;
    }
    //>>        }
    public partial record T_EntityName_ : T_ParentName_, IT_EntityName_
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
        public T_ModelType_? T_UnaryModelFieldName_ { get; init; }
        IT_ModelType_? IT_EntityName_.T_UnaryModelFieldName_ => T_UnaryModelFieldName_;
        //>>                        break;
        //>>                    case FieldKind.ArrayModel:
        public ImmutableList<T_ModelType_?>? T_ArrayModelFieldName_ { get; init; }
        IReadOnlyList<IT_ModelType_?>? IT_EntityName_.T_ArrayModelFieldName_ => T_ArrayModelFieldName_;
        //>>                        break;
        //>>                    case FieldKind.IndexModel:
        public ImmutableDictionary<T_IndexType_, T_ModelType_?>? T_IndexModelFieldName_ { get; init; }
        IReadOnlyDictionary<T_IndexType_, IT_ModelType_?>? IT_EntityName_.T_IndexModelFieldName_
            => T_IndexModelFieldName_ is null ? null
            : new DictionaryFacade<T_IndexType_, IT_ModelType_?, T_ModelType_?>(T_IndexModelFieldName_, (x) => x);
        //>>                        break;
        //>>                    case FieldKind.UnaryMaybe:
        public T_ExternalMaybeType_? T_UnaryMaybeFieldName_ { get; init; }
        T_ExternalMaybeType_? IT_EntityName_.T_UnaryMaybeFieldName_ => T_UnaryMaybeFieldName_;
        //>>                        break;
        //>>                    case FieldKind.ArrayMaybe:
        public ImmutableList<T_ExternalMaybeType_?>? T_ArrayMaybeFieldName_ { get; init; }
        IReadOnlyList<T_ExternalMaybeType_?>? IT_EntityName_.T_ArrayMaybeFieldName_ => T_ArrayMaybeFieldName_;
        //>>                        break;
        //>>                    case FieldKind.IndexMaybe:
        public ImmutableDictionary<T_IndexType_, T_ExternalMaybeType_?>? T_IndexMaybeFieldName_ { get; init; }
        IReadOnlyDictionary<T_IndexType_, T_ExternalMaybeType_?>? IT_EntityName_.T_IndexMaybeFieldName_ => T_IndexMaybeFieldName_;
        //>>                        break;
        //>>                    case FieldKind.UnaryOther:
        public T_ExternalOtherType_ T_UnaryOtherFieldName_ { get; init; }
        T_ExternalOtherType_ IT_EntityName_.T_UnaryOtherFieldName_ => T_UnaryOtherFieldName_;
        //>>                        break;
        //>>                    case FieldKind.ArrayOther:
        public ImmutableList<T_ExternalOtherType_>? T_ArrayOtherFieldName_ { get; init; }
        IReadOnlyList<T_ExternalOtherType_>? IT_EntityName_.T_ArrayOtherFieldName_ => T_ArrayOtherFieldName_;
        //>>                        break;
        //>>                    case FieldKind.IndexOther:
        public ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>? T_IndexOtherFieldName_ { get; init; }
        IReadOnlyDictionary<T_IndexType_, T_ExternalOtherType_>? IT_EntityName_.T_IndexOtherFieldName_ => T_IndexOtherFieldName_;
        //>>                        break;
        //>>                    case FieldKind.UnaryBuffer:
        public Octets? T_UnaryBufferFieldName_ { get; init; }
        Octets? IT_EntityName_.T_UnaryBufferFieldName_ => T_UnaryBufferFieldName_;
        //>>                        break;
        //>>                    case FieldKind.ArrayBuffer:
        public ImmutableList<Octets?>? T_ArrayBufferFieldName_ { get; init; }
        IReadOnlyList<Octets?>? IT_EntityName_.T_ArrayBufferFieldName_ => T_ArrayBufferFieldName_;
        //>>                        break;
        //>>                    case FieldKind.IndexBuffer:
        public ImmutableDictionary<T_IndexType_, Octets?>? T_IndexBufferFieldName_ { get; init; }
        IReadOnlyDictionary<T_IndexType_, Octets?>? IT_EntityName_.T_IndexBufferFieldName_ => T_IndexBufferFieldName_;
        //>>                        break;
        //>>                    case FieldKind.UnaryString:
        public String? T_UnaryStringFieldName_ { get; init; }
        String? IT_EntityName_.T_UnaryStringFieldName_ => T_UnaryStringFieldName_;
        //>>                        break;
        //>>                    case FieldKind.ArrayString:
        public ImmutableList<String?>? T_ArrayStringFieldName_ { get; init; }
        IReadOnlyList<String?>? IT_EntityName_.T_ArrayStringFieldName_ => T_ArrayStringFieldName_;
        //>>                        break;
        //>>                    case FieldKind.IndexString:
        public ImmutableDictionary<T_IndexType_, String?>? T_IndexStringFieldName_ { get; init; }
        IReadOnlyDictionary<T_IndexType_, String?>? IT_EntityName_.T_IndexStringFieldName_ => T_IndexStringFieldName_;
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
            T_UnaryModelFieldName_ = source.T_UnaryModelFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayModel:
            T_ArrayModelFieldName_ = source.T_ArrayModelFieldName_;
            //>>                        break;
            //>>                    case FieldKind.IndexModel:
            T_IndexModelFieldName_ = source.T_IndexModelFieldName_;
            //>>                        break;
            //>>                    case FieldKind.UnaryMaybe:
            T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayMaybe:
            T_ArrayMaybeFieldName_ = source.T_ArrayMaybeFieldName_;
            //>>                        break;
            //>>                    case FieldKind.IndexMaybe:
            T_IndexMaybeFieldName_ = source.T_IndexMaybeFieldName_;
            //>>                        break;
            //>>                    case FieldKind.UnaryOther:
            T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayOther:
            T_ArrayOtherFieldName_ = source.T_ArrayOtherFieldName_;
            //>>                        break;
            //>>                    case FieldKind.IndexOther:
            T_IndexOtherFieldName_ = source.T_IndexOtherFieldName_;
            //>>                        break;
            //>>                    case FieldKind.UnaryBuffer:
            T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayBuffer:
            T_ArrayBufferFieldName_ = source.T_ArrayBufferFieldName_;
            //>>                        break;
            //>>                    case FieldKind.IndexBuffer:
            T_IndexBufferFieldName_ = source.T_IndexBufferFieldName_;
            //>>                        break;
            //>>                    case FieldKind.UnaryString:
            T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayString:
            T_ArrayStringFieldName_ = source.T_ArrayStringFieldName_;
            //>>                        break;
            //>>                    case FieldKind.IndexString:
            T_IndexStringFieldName_ = source.T_IndexStringFieldName_;
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
            T_UnaryModelFieldName_ = T_ModelType__Factory.Instance.CreateFrom(source.T_UnaryModelFieldName_);
            //>>                        break;
            //>>                    case FieldKind.ArrayModel:
            T_ArrayModelFieldName_ = source.T_ArrayModelFieldName_ is null
                ? default
                : ImmutableList<T_ModelType_?>.Empty.AddRange(source.T_ArrayModelFieldName_.Select(x => T_ModelType__Factory.Instance.CreateFrom(x)));
            //>>                        break;
            //>>                    case FieldKind.IndexModel:
            T_IndexModelFieldName_ = source.T_IndexModelFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty.AddRange(
                    source.T_IndexModelFieldName_.Select(x => new KeyValuePair<T_IndexType_, T_ModelType_?>(x.Key, T_ModelType__Factory.Instance.CreateFrom(x.Value))));
            //>>                        break;
            //>>                    case FieldKind.UnaryMaybe:
            T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayMaybe:
            T_ArrayMaybeFieldName_ = source.T_ArrayMaybeFieldName_ is null
                ? default
                : ImmutableList<T_ExternalMaybeType_?>.Empty.AddRange(source.T_ArrayMaybeFieldName_);
            //>>                        break;
            //>>                    case FieldKind.IndexMaybe:
            T_IndexMaybeFieldName_ = source.T_IndexMaybeFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalMaybeType_?>.Empty.AddRange(source.T_IndexMaybeFieldName_);
            //>>                        break;
            //>>                    case FieldKind.UnaryOther:
            T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayOther:
            T_ArrayOtherFieldName_ = source.T_ArrayOtherFieldName_ is null
                ? default
                : ImmutableList<T_ExternalOtherType_>.Empty.AddRange(source.T_ArrayOtherFieldName_);
            //>>                        break;
            //>>                    case FieldKind.IndexOther:
            T_IndexOtherFieldName_ = source.T_IndexOtherFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty.AddRange(source.T_IndexOtherFieldName_);
            //>>                        break;
            //>>                    case FieldKind.UnaryBuffer:
            T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayBuffer:
            T_ArrayBufferFieldName_ = source.T_ArrayBufferFieldName_ is null
                ? default
                : ImmutableList<Octets?>.Empty.AddRange(source.T_ArrayBufferFieldName_
                    .Select(x => (Octets?)x));
            //>>                        break;
            //>>                    case FieldKind.IndexBuffer:
            T_IndexBufferFieldName_ = source.T_IndexBufferFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, Octets?>.Empty.AddRange(source.T_IndexBufferFieldName_
                    .Select(x => new KeyValuePair<T_IndexType_, Octets?>(x.Key, x.Value)));
            //>>                        break;
            //>>                    case FieldKind.UnaryString:
            T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;
            //>>                        break;
            //>>                    case FieldKind.ArrayString:
            T_ArrayStringFieldName_ = source.T_ArrayStringFieldName_ is null
                ? default
                : ImmutableList<String?>.Empty.AddRange(source.T_ArrayStringFieldName_);
            //>>                        break;
            //>>                    case FieldKind.IndexString:
            T_IndexStringFieldName_ = source.T_IndexStringFieldName_ is null
                ? default
                : ImmutableDictionary<T_IndexType_, String?>.Empty.AddRange(source.T_IndexStringFieldName_);
            //>>                        break;
            //>>                    default: break;
            //>>                }
            //>>            }
            //>>        }
        }

        public virtual bool Equals(T_EntityName_? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
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
            if (!T_UnaryMaybeFieldName_.ValueEquals(other.T_UnaryMaybeFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.ArrayMaybe:
            if (!T_ArrayMaybeFieldName_.ArrayEquals(other.T_ArrayMaybeFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.IndexMaybe:
            if (!T_IndexMaybeFieldName_.IndexEquals(other.T_IndexMaybeFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.UnaryOther:
            if (!T_UnaryOtherFieldName_.ValueEquals(other.T_UnaryOtherFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.ArrayOther:
            if (!T_ArrayOtherFieldName_.ArrayEquals(other.T_ArrayOtherFieldName_)) return false;
            //>>                        break;
            //>>                    case FieldKind.IndexOther:
            if (!T_IndexOtherFieldName_.IndexEquals(other.T_IndexOtherFieldName_)) return false;
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
            return base.Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
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

    //>>    }
    //>>}

    //>>using (Ignored())
    //>>{
    public sealed record T_DerivedName_ : T_EntityName_, IT_DerivedName_
    {
        public T_DerivedName_() { }
        public T_DerivedName_(T_DerivedName_? source) : base(source) { }
        public T_DerivedName_(IT_DerivedName_? source) : base(source) { }
    }
    //>>}

}
// |metacode:template_end|
