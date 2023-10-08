#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: JsonNewtonSoft.2.3
// Metadata : MetaFac.CG4.TestOrg.Schema(.Personel)
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
using MetaFac.CG4.TestOrg.ModelsNet7.Personel.Contracts;
using MetaFac.Memory;

namespace MetaFac.CG4.TestOrg.ModelsNet7.Personel.JsonNewtonSoft
{


    public abstract class EntityBase : IFreezable, IEntityBase
    {
        public static EntityBase Empty => throw new NotSupportedException();
        public const int EntityTag = 0;
        public EntityBase() { }
        public EntityBase(EntityBase? source) { }
        public EntityBase(IEntityBase? source) { }
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


    public sealed class Person_Factory : IEntityFactory<IPerson, Person>
    {
        private static readonly Person_Factory _instance = new Person_Factory();
        public static Person_Factory Instance => _instance;
        public Person? CreateFrom(IPerson? source) => (source is null) ? null : new Person(source);
        public Person Empty => new Person();
    }
    public partial class Person : EntityBase, IPerson, IEquatable<Person>
    {
        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        private String? field_FamilyName;
        String? IPerson.FamilyName => field_FamilyName;
        public String? FamilyName
        {
            get => field_FamilyName;
            set => field_FamilyName = value;
        }
        private String? field_FirstName;
        String? IPerson.FirstName => field_FirstName;
        public String? FirstName
        {
            get => field_FirstName;
            set => field_FirstName = value;
        }
        private GenderEnum field_Gender;
        GenderEnum IPerson.Gender { get => field_Gender; }
        public GenderEnum Gender
        {
            get => field_Gender;
            set => field_Gender = value;
        }
        private System.DayOfWeek field_DayOfBirth;
        System.DayOfWeek IPerson.DayOfBirth { get => field_DayOfBirth; }
        public System.DayOfWeek DayOfBirth
        {
            get => field_DayOfBirth;
            set => field_DayOfBirth = value;
        }

        public Person() : base()
        {
        }

        public Person(Person? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_FamilyName = source.FamilyName;
            field_FirstName = source.FirstName;
            field_Gender = source.Gender;
            field_DayOfBirth = source.DayOfBirth;
        }

        public Person(IPerson? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_FamilyName = source.FamilyName;
            field_FirstName = source.FirstName;
            field_Gender = source.Gender;
            field_DayOfBirth = source.DayOfBirth;
        }

        public void CopyFrom(IPerson? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
            field_FamilyName = source.FamilyName;
            field_FirstName = source.FirstName;
            field_Gender = source.Gender;
            field_DayOfBirth = source.DayOfBirth;
        }

        public bool Equals(Person? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!FamilyName.ValueEquals(other.FamilyName)) return false;
            if (!FirstName.ValueEquals(other.FirstName)) return false;
            if (!Gender .ValueEquals(other.Gender)) return false;
            if (!DayOfBirth .ValueEquals(other.DayOfBirth)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is Person other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(FamilyName.CalcHashUnary());
            hc.Add(FirstName.CalcHashUnary());
            hc.Add(Gender.CalcHashUnary());
            hc.Add(DayOfBirth.CalcHashUnary());
            return hc.ToHashCode();
        }
    }


}
