#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: MessagePack.1.4
// Metadata : MetaFac.CG4.TestOrg.Schema(.XtraComplex)
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
using MetaFac.CG4.TestOrg.Models.XtraComplex.Contracts;

namespace MetaFac.CG4.TestOrg.Models.XtraComplex.MessagePack
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


    public partial class Tree
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Tree? CreateFrom(ITree? source)
        {
            if (source is null) return null;
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tree()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tree(ITree source) : base(source)
        {
            field_Value = Node.CreateFrom(source.Value);
            field_A = Tree.CreateFrom(source.A);
            field_B = Tree.CreateFrom(source.B);
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
            hc.Add(field_Value.CalcHashUnary());
            hc.Add(field_A.CalcHashUnary());
            hc.Add(field_B.CalcHashUnary());
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

    [Union(StrNode.EntityTag, typeof(StrNode))]
    [Union(NumNode.EntityTag, typeof(NumNode))]
    [Union(LongNode.EntityTag, typeof(LongNode))]
    [Union(ByteNode.EntityTag, typeof(ByteNode))]
    public abstract partial class Node
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Node? CreateFrom(INode? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                case StrNode.EntityTag: return StrNode.CreateFrom((IStrNode)source);
                case NumNode.EntityTag: return NumNode.CreateFrom((INumNode)source);
                case LongNode.EntityTag: return LongNode.CreateFrom((ILongNode)source);
                case ByteNode.EntityTag: return ByteNode.CreateFrom((IByteNode)source);
                default:
                    throw new ArgumentOutOfRangeException(nameof(entityTag), entityTag, null);
            }
        }
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Node()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Node(Node source) : base(source)
        {
        }

        public void CopyFrom(Node source)
        {
            base.CopyFrom(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Node(INode source) : base(source)
        {
        }

        public bool Equals(Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Node left, Node right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Node left, Node right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }

    }

    public partial class StrNode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StrNode? CreateFrom(IStrNode? source)
        {
            if (source is null) return null;
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StrNode()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StrNode(StrNode source) : base(source)
        {
            field_StrVal = source.field_StrVal;
        }

        public void CopyFrom(StrNode source)
        {
            base.CopyFrom(source);
            field_StrVal = source.field_StrVal;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(StrNode left, StrNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(StrNode left, StrNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }

    }

    [Union(LongNode.EntityTag, typeof(LongNode))]
    [Union(ByteNode.EntityTag, typeof(ByteNode))]
    public abstract partial class NumNode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NumNode? CreateFrom(INumNode? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                case LongNode.EntityTag: return LongNode.CreateFrom((ILongNode)source);
                case ByteNode.EntityTag: return ByteNode.CreateFrom((IByteNode)source);
                default:
                    throw new ArgumentOutOfRangeException(nameof(entityTag), entityTag, null);
            }
        }
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NumNode()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NumNode(NumNode source) : base(source)
        {
        }

        public void CopyFrom(NumNode source)
        {
            base.CopyFrom(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NumNode(INumNode source) : base(source)
        {
        }

        public bool Equals(NumNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(NumNode left, NumNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(NumNode left, NumNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }

    }

    public partial class LongNode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LongNode? CreateFrom(ILongNode? source)
        {
            if (source is null) return null;
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LongNode()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LongNode(LongNode source) : base(source)
        {
            field_LongVal = source.field_LongVal;
        }

        public void CopyFrom(LongNode source)
        {
            base.CopyFrom(source);
            field_LongVal = source.field_LongVal;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LongNode(ILongNode source) : base(source)
        {
            field_LongVal = source.LongVal.ToInternal();
        }

        public bool Equals(LongNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (field_LongVal != other.field_LongVal) return false;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(LongNode left, LongNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(LongNode left, LongNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }

    }

    public partial class ByteNode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteNode? CreateFrom(IByteNode? source)
        {
            if (source is null) return null;
            return new ByteNode(source);
        }

        private static ByteNode CreateEmpty()
        {
            var empty = new ByteNode();
            empty.Freeze();
            return empty;
        }
        private static readonly ByteNode _empty = CreateEmpty();
        public static new ByteNode Empty => _empty;

    }
    [MessagePackObject]
    public partial class ByteNode : NumNode, IByteNode, IEquatable<ByteNode>, ICopyFrom<ByteNode>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 6;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private Byte field_ByteVal;

        // ---------- accessors ----------
        [Key(1)]
        public Byte ByteVal
        {
            get => field_ByteVal;
            set => field_ByteVal = CheckNotFrozen(ref value);
        }

        // ---------- IByteNode methods ----------
        Byte IByteNode.ByteVal => field_ByteVal.ToExternal();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ByteNode()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ByteNode(ByteNode source) : base(source)
        {
            field_ByteVal = source.field_ByteVal;
        }

        public void CopyFrom(ByteNode source)
        {
            base.CopyFrom(source);
            field_ByteVal = source.field_ByteVal;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ByteNode(IByteNode source) : base(source)
        {
            field_ByteVal = source.ByteVal.ToInternal();
        }

        public bool Equals(ByteNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (field_ByteVal != other.field_ByteVal) return false;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(ByteNode left, ByteNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ByteNode left, ByteNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return obj is ByteNode other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_ByteVal.CalcHashUnary());
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