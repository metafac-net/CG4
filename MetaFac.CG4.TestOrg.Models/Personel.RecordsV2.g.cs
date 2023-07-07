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
using MetaFac.Memory;
using MetaFac.Mutability;
using MetaFac.CG4.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using MetaFac.CG4.TestOrg.Models.Personel.Contracts;

namespace MetaFac.CG4.TestOrg.Models.Personel.RecordsV2
{


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
        public static EntityBase Empty => throw new NotSupportedException();
        public bool IsFreezable() => false;
        public bool IsFrozen() => true;
        public void Freeze() { }
        public bool TryFreeze() => false;
    }


    public abstract partial record Person
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Person? CreateFrom(IPerson? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(Person)} from {source.GetType().Name}");
            }
        }

    }
    public partial record Person : EntityBase, IPerson
    {
        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        public String? FamilyName { get; init; }
        String? IPerson.FamilyName => FamilyName;
        public String? FirstName { get; init; }
        String? IPerson.FirstName => FirstName;
        public GenderEnum Gender { get; init; }
        GenderEnum IPerson.Gender => Gender;
        public System.DayOfWeek DayOfBirth { get; init; }
        System.DayOfWeek IPerson.DayOfBirth => DayOfBirth;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Person() : base()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Person(Person? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            FamilyName = source.FamilyName;
            FirstName = source.FirstName;
            Gender = source.Gender;
            DayOfBirth = source.DayOfBirth;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Person(IPerson? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            FamilyName = source.FamilyName;
            FirstName = source.FirstName;
            Gender = source.Gender;
            DayOfBirth = source.DayOfBirth;
        }

        public virtual bool Equals(Person? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!FamilyName.ValueEquals(other.FamilyName)) return false;
            if (!FirstName.ValueEquals(other.FirstName)) return false;
            if (Gender != other.Gender) return false;
            if (DayOfBirth != other.DayOfBirth) return false;
            return base.Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(FamilyName.CalcHashUnary());
            hc.Add(FirstName.CalcHashUnary());
            hc.Add(Gender.CalcHashUnary());
            hc.Add(DayOfBirth.CalcHashUnary());
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



}