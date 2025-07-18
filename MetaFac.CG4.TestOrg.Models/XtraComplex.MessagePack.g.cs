#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: MessagePack.4.0
// Metadata : MetaFac.CG4.TestOrg.Schema(.XtraComplex)
// </information>
#endregion
#nullable enable
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8019 // Unnecessary using directive
#pragma warning disable CS8019 // Unnecessary using directive
using DataFac.Memory;
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
using MetaFac.CG4.TestOrg.Models.XtraComplex.Contracts;

namespace MetaFac.CG4.TestOrg.Models.XtraComplex.MessagePack
{


    public abstract partial class EntityBase : IFreezable, IEntityBase, IEquatable<EntityBase>, ICopyFrom<EntityBase>
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
        public void CopyFrom(EntityBase source) => CheckNotFrozen();
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
            if (source is Tree sibling && sibling.IsFrozen()) return sibling;
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
            field_Value?.Freeze();
            field_A?.Freeze();
            field_B?.Freeze();
            base.OnFreeze();
        }

        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private Node? field_Value;
        private Tree? field_A;
        private Tree? field_B;

        // ---------- accessors ----------
        [Key(1)]
        public Node? Value
        {
            get => field_Value;
            set => field_Value = CheckNotFrozen(ref value);
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
        INode? ITree.Value => field_Value;
        ITree? ITree.A => field_A;
        ITree? ITree.B => field_B;

        public Tree()
        {
        }

        public Tree(Tree source) : base(source)
        {
            field_Value = source.field_Value;
            field_A = source.field_A;
            field_B = source.field_B;
        }

        public void CopyFrom(Tree source)
        {
            base.CopyFrom(source);
            field_Value = source.field_Value;
            field_A = source.field_A;
            field_B = source.field_B;
        }

        public Tree(ITree source) : base(source)
        {
            field_Value = Node_Factory.Instance.CreateFrom(source.Value);
            field_A = Tree_Factory.Instance.CreateFrom(source.A);
            field_B = Tree_Factory.Instance.CreateFrom(source.B);
        }

        public bool Equals(Tree? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_Value.ValueEquals(other.field_Value)) return false;
            if (!field_A.ValueEquals(other.field_A)) return false;
            if (!field_B.ValueEquals(other.field_B)) return false;
            return base.Equals(other);
        }

        public static bool operator ==(Tree left, Tree right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        public static bool operator !=(Tree left, Tree right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Tree other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_Value.CalcHashUnary());
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

    [Union(StrNode.EntityTag, typeof(StrNode))]
    [Union(NumNode.EntityTag, typeof(NumNode))]
    [Union(LongNode.EntityTag, typeof(LongNode))]
    [Union(DaynNode.EntityTag, typeof(DaynNode))]
    public abstract partial class Node
    {
    }
    public sealed class Node_Factory : IEntityFactory<INode, Node>
    {
        private static readonly Node_Factory _instance = new Node_Factory();
        public static Node_Factory Instance => _instance;

        public Node? CreateFrom(INode? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                case StrNode.EntityTag: return StrNode_Factory.Instance.CreateFrom((IStrNode)source);
                case NumNode.EntityTag: return NumNode_Factory.Instance.CreateFrom((INumNode)source);
                case LongNode.EntityTag: return LongNode_Factory.Instance.CreateFrom((ILongNode)source);
                case DaynNode.EntityTag: return DaynNode_Factory.Instance.CreateFrom((IDaynNode)source);
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(Node)} from {source.GetType().Name}");
            }
        }

        public Node Empty => throw new NotSupportedException($"Cannot create abstract entity: {typeof(Node)}");
    }
    [MessagePackObject]
    public partial class Node : EntityBase, INode, IEquatable<Node>, ICopyFrom<Node>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 2;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------

        // ---------- accessors ----------

        // ---------- INode methods ----------

        public Node()
        {
        }

        public Node(Node source) : base(source)
        {
        }

        public void CopyFrom(Node source)
        {
            base.CopyFrom(source);
        }

        public Node(INode source) : base(source)
        {
        }

        public bool Equals(Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return base.Equals(other);
        }

        public static bool operator ==(Node left, Node right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        public static bool operator !=(Node left, Node right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Node other && Equals(other);
        }

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

    public sealed class StrNode_Factory : IEntityFactory<IStrNode, StrNode>
    {
        private static readonly StrNode_Factory _instance = new StrNode_Factory();
        public static StrNode_Factory Instance => _instance;

        public StrNode? CreateFrom(IStrNode? source)
        {
            if (source is null) return null;
            if (source is StrNode sibling && sibling.IsFrozen()) return sibling;
            return new StrNode(source);
        }

        private static readonly StrNode _empty = new StrNode().Frozen();
        public StrNode Empty => _empty;
    }
    [MessagePackObject]
    public partial class StrNode : Node, IStrNode, IEquatable<StrNode>, ICopyFrom<StrNode>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 3;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private String? field_StrVal;

        // ---------- accessors ----------
        [Key(1)]
        public String? StrVal
        {
            get => field_StrVal;
            set => field_StrVal = CheckNotFrozen(ref value);
        }

        // ---------- IStrNode methods ----------
        String? IStrNode.StrVal => field_StrVal;

        public StrNode()
        {
        }

        public StrNode(StrNode source) : base(source)
        {
            field_StrVal = source.field_StrVal;
        }

        public void CopyFrom(StrNode source)
        {
            base.CopyFrom(source);
            field_StrVal = source.field_StrVal;
        }

        public StrNode(IStrNode source) : base(source)
        {
            field_StrVal = source.StrVal;
        }

        public bool Equals(StrNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_StrVal.ValueEquals(other.field_StrVal)) return false;
            return base.Equals(other);
        }

        public static bool operator ==(StrNode left, StrNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        public static bool operator !=(StrNode left, StrNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            return obj is StrNode other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_StrVal.CalcHashUnary());
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

    [Union(LongNode.EntityTag, typeof(LongNode))]
    [Union(DaynNode.EntityTag, typeof(DaynNode))]
    public abstract partial class NumNode
    {
    }
    public sealed class NumNode_Factory : IEntityFactory<INumNode, NumNode>
    {
        private static readonly NumNode_Factory _instance = new NumNode_Factory();
        public static NumNode_Factory Instance => _instance;

        public NumNode? CreateFrom(INumNode? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                case LongNode.EntityTag: return LongNode_Factory.Instance.CreateFrom((ILongNode)source);
                case DaynNode.EntityTag: return DaynNode_Factory.Instance.CreateFrom((IDaynNode)source);
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(NumNode)} from {source.GetType().Name}");
            }
        }

        public NumNode Empty => throw new NotSupportedException($"Cannot create abstract entity: {typeof(NumNode)}");
    }
    [MessagePackObject]
    public partial class NumNode : Node, INumNode, IEquatable<NumNode>, ICopyFrom<NumNode>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 4;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------

        // ---------- accessors ----------

        // ---------- INumNode methods ----------

        public NumNode()
        {
        }

        public NumNode(NumNode source) : base(source)
        {
        }

        public void CopyFrom(NumNode source)
        {
            base.CopyFrom(source);
        }

        public NumNode(INumNode source) : base(source)
        {
        }

        public bool Equals(NumNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return base.Equals(other);
        }

        public static bool operator ==(NumNode left, NumNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        public static bool operator !=(NumNode left, NumNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            return obj is NumNode other && Equals(other);
        }

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

    public sealed class LongNode_Factory : IEntityFactory<ILongNode, LongNode>
    {
        private static readonly LongNode_Factory _instance = new LongNode_Factory();
        public static LongNode_Factory Instance => _instance;

        public LongNode? CreateFrom(ILongNode? source)
        {
            if (source is null) return null;
            if (source is LongNode sibling && sibling.IsFrozen()) return sibling;
            return new LongNode(source);
        }

        private static readonly LongNode _empty = new LongNode().Frozen();
        public LongNode Empty => _empty;
    }
    [MessagePackObject]
    public partial class LongNode : NumNode, ILongNode, IEquatable<LongNode>, ICopyFrom<LongNode>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 5;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private Int64 field_LongVal;

        // ---------- accessors ----------
        [Key(1)]
        public Int64 LongVal
        {
            get => field_LongVal;
            set => field_LongVal = CheckNotFrozen(ref value);
        }

        // ---------- ILongNode methods ----------
        Int64 ILongNode.LongVal => field_LongVal.ToExternal();

        public LongNode()
        {
        }

        public LongNode(LongNode source) : base(source)
        {
            field_LongVal = source.field_LongVal;
        }

        public void CopyFrom(LongNode source)
        {
            base.CopyFrom(source);
            field_LongVal = source.field_LongVal;
        }

        public LongNode(ILongNode source) : base(source)
        {
            field_LongVal = source.LongVal.ToInternal();
        }

        public bool Equals(LongNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_LongVal.ValueEquals(other.field_LongVal)) return false;
            return base.Equals(other);
        }

        public static bool operator ==(LongNode left, LongNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        public static bool operator !=(LongNode left, LongNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            return obj is LongNode other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_LongVal.CalcHashUnary());
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

    public sealed class DaynNode_Factory : IEntityFactory<IDaynNode, DaynNode>
    {
        private static readonly DaynNode_Factory _instance = new DaynNode_Factory();
        public static DaynNode_Factory Instance => _instance;

        public DaynNode? CreateFrom(IDaynNode? source)
        {
            if (source is null) return null;
            if (source is DaynNode sibling && sibling.IsFrozen()) return sibling;
            return new DaynNode(source);
        }

        private static readonly DaynNode _empty = new DaynNode().Frozen();
        public DaynNode Empty => _empty;
    }
    [MessagePackObject]
    public partial class DaynNode : NumNode, IDaynNode, IEquatable<DaynNode>, ICopyFrom<DaynNode>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 6;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private System.DayOfWeek field_DaynVal;

        // ---------- accessors ----------
        [Key(1)]
        public System.DayOfWeek DaynVal
        {
            get => field_DaynVal;
            set => field_DaynVal = CheckNotFrozen(ref value);
        }

        // ---------- IDaynNode methods ----------
        System.DayOfWeek IDaynNode.DaynVal => field_DaynVal.ToExternal();

        public DaynNode()
        {
        }

        public DaynNode(DaynNode source) : base(source)
        {
            field_DaynVal = source.field_DaynVal;
        }

        public void CopyFrom(DaynNode source)
        {
            base.CopyFrom(source);
            field_DaynVal = source.field_DaynVal;
        }

        public DaynNode(IDaynNode source) : base(source)
        {
            field_DaynVal = source.DaynVal.ToInternal();
        }

        public bool Equals(DaynNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_DaynVal.ValueEquals(other.field_DaynVal)) return false;
            return base.Equals(other);
        }

        public static bool operator ==(DaynNode left, DaynNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        public static bool operator !=(DaynNode left, DaynNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            return obj is DaynNode other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_DaynVal.CalcHashUnary());
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
