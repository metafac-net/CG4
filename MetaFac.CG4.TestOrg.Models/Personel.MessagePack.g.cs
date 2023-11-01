#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: MessagePack.2.6
// Metadata : MetaFac.CG4.TestOrg.Schema(.Personel)
// </information>
#endregion
#nullable enable
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8019 // Unnecessary using directive
#pragma warning disable CS8019 // Unnecessary using directive
using MetaFac.Memory;
using MetaFac.Mutability;
using MessagePack;
using MetaFac.CG4.Runtime;
using MetaFac.CG4.Runtime.MessagePack;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using MetaFac.CG4.TestOrg.Models.Personel.Contracts;

namespace MetaFac.CG4.TestOrg.Models.Personel.MessagePack
{


    public abstract class EntityBase : IFreezable, IEntityBase, IEquatable<EntityBase>, ICopyFrom<EntityBase>
    {
        public static EntityBase Empty => throw new NotSupportedException();
        public const int EntityTag = 0;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowIsReadonly()
        {
            throw new InvalidOperationException("Cannot set properties when frozen");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected ref T CheckNotFrozen<T>(ref T value)
        {
            if (_isFrozen) ThrowIsReadonly();
            return ref value;
        }

        public EntityBase() { }
        public EntityBase(EntityBase source) { }
        public void CopyFrom(EntityBase source) { }
        public EntityBase(IEntityBase source) { }
        protected abstract int OnGetEntityTag();
        public int GetEntityTag() => OnGetEntityTag();

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

        public bool Equals(EntityBase? other) => true;
        public override bool Equals(object? obj) => obj is EntityBase other && this.Equals(other);
        public override int GetHashCode() => 0;
    }


    public sealed class Person_Factory : IEntityFactory<IPerson, Person>
    {
        private static readonly Person_Factory _instance = new Person_Factory();
        public static Person_Factory Instance => _instance;

        public Person? CreateFrom(IPerson? source)
        {
            if (source is null) return null;
            if (source is Person sibling && sibling.IsFrozen()) return sibling;
            return new Person(source);
        }

        private static readonly Person _empty = new Person().Frozen();
        public Person Empty => _empty;
    }
    [MessagePackObject]
    public partial class Person : EntityBase, IPerson, IEquatable<Person>, ICopyFrom<Person>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private String? field_FamilyName;
        private String? field_FirstName;
        private GenderEnum field_Gender;
        private System.DayOfWeek field_DayOfBirth;

        // ---------- accessors ----------
        [Key(1)]
        public String? FamilyName
        {
            get => field_FamilyName;
            set => field_FamilyName = CheckNotFrozen(ref value);
        }
        [Key(2)]
        public String? FirstName
        {
            get => field_FirstName;
            set => field_FirstName = CheckNotFrozen(ref value);
        }
        [Key(4)]
        public GenderEnum Gender
        {
            get => field_Gender;
            set => field_Gender = CheckNotFrozen(ref value);
        }
        [Key(5)]
        public System.DayOfWeek DayOfBirth
        {
            get => field_DayOfBirth;
            set => field_DayOfBirth = CheckNotFrozen(ref value);
        }

        // ---------- IPerson methods ----------
        String? IPerson.FamilyName => field_FamilyName;
        String? IPerson.FirstName => field_FirstName;
        GenderEnum IPerson.Gender => field_Gender.ToExternal();
        System.DayOfWeek IPerson.DayOfBirth => field_DayOfBirth.ToExternal();

        public Person()
        {
        }

        public Person(Person source) : base(source)
        {
            field_FamilyName = source.field_FamilyName;
            field_FirstName = source.field_FirstName;
            field_Gender = source.field_Gender;
            field_DayOfBirth = source.field_DayOfBirth;
        }

        public void CopyFrom(Person source)
        {
            base.CopyFrom(source);
            field_FamilyName = source.field_FamilyName;
            field_FirstName = source.field_FirstName;
            field_Gender = source.field_Gender;
            field_DayOfBirth = source.field_DayOfBirth;
        }

        public Person(IPerson source) : base(source)
        {
            field_FamilyName = source.FamilyName;
            field_FirstName = source.FirstName;
            field_Gender = source.Gender.ToInternal();
            field_DayOfBirth = source.DayOfBirth.ToInternal();
        }

        public bool Equals(Person? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_FamilyName.ValueEquals(other.field_FamilyName)) return false;
            if (!field_FirstName.ValueEquals(other.field_FirstName)) return false;
            if (!field_Gender.ValueEquals(other.field_Gender)) return false;
            if (!field_DayOfBirth.ValueEquals(other.field_DayOfBirth)) return false;
            return base.Equals(other);
        }

        public static bool operator ==(Person left, Person right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        public static bool operator !=(Person left, Person right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Person other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_FamilyName.CalcHashUnary());
            hc.Add(field_FirstName.CalcHashUnary());
            hc.Add(field_Gender.CalcHashUnary());
            hc.Add(field_DayOfBirth.CalcHashUnary());
            hc.Add(base.GetHashCode());
            return hc.ToHashCode();
        }

        private int? _hashCode = null;
        public override int GetHashCode()
        {
            if (!_isFrozen) return CalcHashCode();
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }

    }


}
