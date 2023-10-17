#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: ClassesV2.2.4
// Metadata : MetaFac.CG4.TestOrg.Schema(.XtraComplex)
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
using MetaFac.CG4.TestOrg.Models.XtraComplex.Contracts;

namespace MetaFac.CG4.TestOrg.Models.XtraComplex.ClassesV2
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
            field_Value?.Freeze();
            field_A?.Freeze();
            field_B?.Freeze();
            base.OnFreeze();
        }

        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        private Node? field_Value;
        INode? ITree.Value => field_Value;
        public Node? Value
        {
            get => field_Value;
            set => field_Value = CheckNotFrozen(ref value);
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

        public Tree() : base()
        {
        }

        public Tree(Tree? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_Value = source.Value;
            field_A = source.A;
            field_B = source.B;
        }

        public Tree(ITree? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_Value = Node.CreateFrom(source.Value);
            field_A = Tree.CreateFrom(source.A);
            field_B = Tree.CreateFrom(source.B);
        }

        public void CopyFrom(ITree? source)
        {
            if (source is null) return;
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            field_Value = Node.CreateFrom(source.Value);
            field_A = Tree.CreateFrom(source.A);
            field_B = Tree.CreateFrom(source.B);
        }

        public virtual bool Equals(Tree? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!Value.ValueEquals(other.Value)) return false;
            if (!A.ValueEquals(other.A)) return false;
            if (!B.ValueEquals(other.B)) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is Tree other && Equals(other);

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(Value.CalcHashUnary());
            hc.Add(A.CalcHashUnary());
            hc.Add(B.CalcHashUnary());
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

    public abstract partial class Node
    {
        public static Node? CreateFrom(INode? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                case StrNode.EntityTag: return StrNode.CreateFrom((IStrNode)source);
                case NumNode.EntityTag: return NumNode.CreateFrom((INumNode)source);
                case LongNode.EntityTag: return LongNode.CreateFrom((ILongNode)source);
                case DaynNode.EntityTag: return DaynNode.CreateFrom((IDaynNode)source);
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(Node)} from {source.GetType().Name}");
            }
        }

    }
    public partial class Node : EntityBase, INode, IEquatable<Node>
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
            base.OnFreeze();
        }

        public new const int EntityTag = 2;
        protected override int OnGetEntityTag() => EntityTag;


        public Node() : base()
        {
        }

        public Node(Node? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
        }

        public Node(INode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
        }

        public void CopyFrom(INode? source)
        {
            if (source is null) return;
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
        }

        public virtual bool Equals(Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is Node other && Equals(other);

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
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

    public partial class StrNode
    {
        public static StrNode? CreateFrom(IStrNode? source)
        {
            if (source is null) return null;
            if (source is StrNode thisEntity && thisEntity._isFrozen) return thisEntity;
            return new StrNode(source);
        }

        private static StrNode CreateEmpty()
        {
            var empty = new StrNode();
            empty.Freeze();
            return empty;
        }
        private static readonly StrNode _empty = CreateEmpty();
        public static new StrNode Empty => _empty;

    }
    public partial class StrNode : Node, IStrNode, IEquatable<StrNode>
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
            base.OnFreeze();
        }

        public new const int EntityTag = 3;
        protected override int OnGetEntityTag() => EntityTag;

        private String? field_StrVal;
        String? IStrNode.StrVal => field_StrVal;
        public String? StrVal
        {
            get => field_StrVal;
            set => field_StrVal = CheckNotFrozen(ref value);
        }

        public StrNode() : base()
        {
        }

        public StrNode(StrNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_StrVal = source.StrVal;
        }

        public StrNode(IStrNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_StrVal = source.StrVal;
        }

        public void CopyFrom(IStrNode? source)
        {
            if (source is null) return;
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            field_StrVal = source.StrVal;
        }

        public virtual bool Equals(StrNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!StrVal.ValueEquals(other.StrVal)) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is StrNode other && Equals(other);

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(StrVal.CalcHashUnary());
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

    public abstract partial class NumNode
    {
        public static NumNode? CreateFrom(INumNode? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                case LongNode.EntityTag: return LongNode.CreateFrom((ILongNode)source);
                case DaynNode.EntityTag: return DaynNode.CreateFrom((IDaynNode)source);
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(NumNode)} from {source.GetType().Name}");
            }
        }

    }
    public partial class NumNode : Node, INumNode, IEquatable<NumNode>
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
            base.OnFreeze();
        }

        public new const int EntityTag = 4;
        protected override int OnGetEntityTag() => EntityTag;


        public NumNode() : base()
        {
        }

        public NumNode(NumNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
        }

        public NumNode(INumNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
        }

        public void CopyFrom(INumNode? source)
        {
            if (source is null) return;
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
        }

        public virtual bool Equals(NumNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is NumNode other && Equals(other);

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
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

    public partial class LongNode
    {
        public static LongNode? CreateFrom(ILongNode? source)
        {
            if (source is null) return null;
            if (source is LongNode thisEntity && thisEntity._isFrozen) return thisEntity;
            return new LongNode(source);
        }

        private static LongNode CreateEmpty()
        {
            var empty = new LongNode();
            empty.Freeze();
            return empty;
        }
        private static readonly LongNode _empty = CreateEmpty();
        public static new LongNode Empty => _empty;

    }
    public partial class LongNode : NumNode, ILongNode, IEquatable<LongNode>
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
            base.OnFreeze();
        }

        public new const int EntityTag = 5;
        protected override int OnGetEntityTag() => EntityTag;

        private Int64 field_LongVal;
        Int64 ILongNode.LongVal => field_LongVal;
        public Int64 LongVal
        {
            get => field_LongVal;
            set => field_LongVal = CheckNotFrozen(ref value);
        }

        public LongNode() : base()
        {
        }

        public LongNode(LongNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_LongVal = source.LongVal;
        }

        public LongNode(ILongNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_LongVal = source.LongVal;
        }

        public void CopyFrom(ILongNode? source)
        {
            if (source is null) return;
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            field_LongVal = source.LongVal;
        }

        public virtual bool Equals(LongNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!LongVal.ValueEquals(other.LongVal)) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is LongNode other && Equals(other);

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(LongVal.CalcHashUnary());
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

    public partial class DaynNode
    {
        public static DaynNode? CreateFrom(IDaynNode? source)
        {
            if (source is null) return null;
            if (source is DaynNode thisEntity && thisEntity._isFrozen) return thisEntity;
            return new DaynNode(source);
        }

        private static DaynNode CreateEmpty()
        {
            var empty = new DaynNode();
            empty.Freeze();
            return empty;
        }
        private static readonly DaynNode _empty = CreateEmpty();
        public static new DaynNode Empty => _empty;

    }
    public partial class DaynNode : NumNode, IDaynNode, IEquatable<DaynNode>
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
            base.OnFreeze();
        }

        public new const int EntityTag = 6;
        protected override int OnGetEntityTag() => EntityTag;

        private System.DayOfWeek field_DaynVal;
        System.DayOfWeek IDaynNode.DaynVal => field_DaynVal;
        public System.DayOfWeek DaynVal
        {
            get => field_DaynVal;
            set => field_DaynVal = CheckNotFrozen(ref value);
        }

        public DaynNode() : base()
        {
        }

        public DaynNode(DaynNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_DaynVal = source.DaynVal;
        }

        public DaynNode(IDaynNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_DaynVal = source.DaynVal;
        }

        public void CopyFrom(IDaynNode? source)
        {
            if (source is null) return;
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            field_DaynVal = source.DaynVal;
        }

        public virtual bool Equals(DaynNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!DaynVal.ValueEquals(other.DaynVal)) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is DaynNode other && Equals(other);

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(DaynVal.CalcHashUnary());
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
