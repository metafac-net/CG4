#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: ClassesV2.1.4
// Metadata : MetaFac.CG4.TestOrg.Schema(.Recursive)
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
using MetaFac.CG4.TestOrg.Models.Recursive.Contracts;

namespace MetaFac.CG4.TestOrg.Models.Recursive.ClassesV2
{


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


    public partial class Tree
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Tree? CreateFrom(ITree? source)
        {
            if (source is null) return null;
            if (source is Tree thisEntity && thisEntity._isFrozen) return thisEntity;
            return new Tree(source);
        }

        private static Tree CreateEmpty()
        {
            var empty = new Tree();
            empty.Freeze();
            return empty;
        }
        private static readonly Tree _empty = CreateEmpty();
        public static new Tree Empty => _empty;

    }
    public partial class Tree : EntityBase, ITree, IEquatable<Tree>
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
            field_A?.Freeze();
            field_B?.Freeze();
            base.OnFreeze();
        }

        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        private Int32 field_Id;
        Int32 ITree.Id => field_Id;
        public Int32 Id
        {
            get => field_Id;
            set => field_Id = CheckNotFrozen(ref value);
        }
        private Tree? field_A;
        ITree? ITree.A => field_A;
        public Tree? A
        {
            get => field_A;
            set => field_A = CheckNotFrozen(ref value);
        }
        private Tree? field_B;
        ITree? ITree.B => field_B;
        public Tree? B
        {
            get => field_B;
            set => field_B = CheckNotFrozen(ref value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tree() : base()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tree(Tree? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_Id = source.Id;
            field_A = source.A;
            field_B = source.B;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tree(ITree? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_Id = source.Id;
            field_A = Tree.CreateFrom(source.A);
            field_B = Tree.CreateFrom(source.B);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFrom(ITree? source)
        {
            if (source is null) return;
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            field_Id = source.Id;
            field_A = Tree.CreateFrom(source.A);
            field_B = Tree.CreateFrom(source.B);
        }

        public virtual bool Equals(Tree? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (Id != other.Id) return false;
            if (!A.ValueEquals(other.A)) return false;
            if (!B.ValueEquals(other.B)) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is Tree other && Equals(other);

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(Id.CalcHashUnary());
            hc.Add(A.CalcHashUnary());
            hc.Add(B.CalcHashUnary());
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
