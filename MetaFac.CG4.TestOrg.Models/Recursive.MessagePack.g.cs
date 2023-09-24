#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: MessagePack.2.2
// Metadata : MetaFac.CG4.TestOrg.Schema(.Recursive)
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
using System.Runtime.CompilerServices;
using MetaFac.CG4.TestOrg.Models.Recursive.Contracts;

namespace MetaFac.CG4.TestOrg.Models.Recursive.MessagePack
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void CheckNotFrozen()
        {
            if (_isFrozen) ThrowIsReadonly();
        }

        public EntityBase() { }
        public EntityBase(EntityBase source) { }
        public void CopyFrom(EntityBase source)
        {
            CheckNotFrozen();
        }
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


    public sealed class Tree_Factory : IEntityFactory<ITree, Tree>
    {
        private static readonly Tree_Factory _instance = new Tree_Factory();
        public static Tree_Factory Instance => _instance;

        public Tree? CreateFrom(ITree? source)
        {
            if (source is null) return null;
            if (source is Tree thisEntity) return thisEntity;
            return new Tree(source);
        }

        private static readonly Tree _empty = new Tree().Frozen();
        public Tree Empty => _empty;
    }
    [MessagePackObject]
    public partial class Tree : EntityBase, ITree, IEquatable<Tree>, ICopyFrom<Tree>
    {
        protected override void OnFreeze()
        {
            field_A?.Freeze();
            field_B?.Freeze();
            base.OnFreeze();
        }

        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private Int32 field_Id;
        private Tree? field_A;
        private Tree? field_B;

        // ---------- accessors ----------
        [Key(1)]
        public Int32 Id
        {
            get => field_Id;
            set => field_Id = CheckNotFrozen(ref value);
        }
        [Key(2)]
        public Tree? A
        {
            get => field_A;
            set => field_A = CheckNotFrozen(ref value);
        }
        [Key(3)]
        public Tree? B
        {
            get => field_B;
            set => field_B = CheckNotFrozen(ref value);
        }

        // ---------- ITree methods ----------
        Int32 ITree.Id => field_Id.ToExternal();
        ITree? ITree.A => field_A;
        ITree? ITree.B => field_B;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tree()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tree(Tree source) : base(source)
        {
            field_Id = source.field_Id;
            field_A = source.field_A;
            field_B = source.field_B;
        }

        public void CopyFrom(Tree source)
        {
            base.CopyFrom(source);
            field_Id = source.field_Id;
            field_A = source.field_A;
            field_B = source.field_B;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tree(ITree source) : base(source)
        {
            field_Id = source.Id.ToInternal();
            field_A = Tree_Factory.Instance.CreateFrom(source.A);
            field_B = Tree_Factory.Instance.CreateFrom(source.B);
        }

        public bool Equals(Tree? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_Id.ValueEquals(other.field_Id)) return false;
            if (!field_A.ValueEquals(other.field_A)) return false;
            if (!field_B.ValueEquals(other.field_B)) return false;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Tree left, Tree right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Tree left, Tree right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return obj is Tree other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_Id.CalcHashUnary());
            hc.Add(field_A.CalcHashUnary());
            hc.Add(field_B.CalcHashUnary());
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
