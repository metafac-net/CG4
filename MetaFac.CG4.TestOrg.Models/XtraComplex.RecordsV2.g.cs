#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: RecordsV2.1.4
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

namespace MetaFac.CG4.TestOrg.Models.XtraComplex.RecordsV2
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


    public partial record Tree
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Tree? CreateFrom(ITree? source)
        {
            if (source is null) return null;
            if (source is Tree thisEntity) return thisEntity;
            return new Tree(source);
        }

        private static readonly Tree _empty = new Tree();
        public static new Tree Empty => _empty;

    }
    public partial record Tree : EntityBase, ITree
    {
        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        public Node? Value { get; init; }
        INode? ITree.Value => Value;
        public Tree? A { get; init; }
        ITree? ITree.A => A;
        public Tree? B { get; init; }
        ITree? ITree.B => B;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tree() : base()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tree(Tree? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Value = source.Value;
            A = source.A;
            B = source.B;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tree(ITree? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Value = Node.CreateFrom(source.Value);
            A = Tree.CreateFrom(source.A);
            B = Tree.CreateFrom(source.B);
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
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }
    }

    public abstract partial record Node
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
                    throw new InvalidOperationException($"Unable to create {typeof(Node)} from {source.GetType().Name}");
            }
        }

    }
    public partial record Node : EntityBase, INode
    {
        public new const int EntityTag = 2;
        protected override int OnGetEntityTag() => EntityTag;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Node() : base()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Node(Node? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Node(INode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
        }

        public virtual bool Equals(Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return base.Equals(other);
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

    public partial record StrNode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StrNode? CreateFrom(IStrNode? source)
        {
            if (source is null) return null;
            if (source is StrNode thisEntity) return thisEntity;
            return new StrNode(source);
        }

        private static readonly StrNode _empty = new StrNode();
        public static new StrNode Empty => _empty;

    }
    public partial record StrNode : Node, IStrNode
    {
        public new const int EntityTag = 3;
        protected override int OnGetEntityTag() => EntityTag;

        public String? StrVal { get; init; }
        String? IStrNode.StrVal => StrVal;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StrNode() : base()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StrNode(StrNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            StrVal = source.StrVal;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StrNode(IStrNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            StrVal = source.StrVal;
        }

        public virtual bool Equals(StrNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!StrVal.ValueEquals(other.StrVal)) return false;
            return base.Equals(other);
        }

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
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }
    }

    public abstract partial record NumNode
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
                    throw new InvalidOperationException($"Unable to create {typeof(NumNode)} from {source.GetType().Name}");
            }
        }

    }
    public partial record NumNode : Node, INumNode
    {
        public new const int EntityTag = 4;
        protected override int OnGetEntityTag() => EntityTag;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NumNode() : base()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NumNode(NumNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NumNode(INumNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
        }

        public virtual bool Equals(NumNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return base.Equals(other);
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

    public partial record LongNode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LongNode? CreateFrom(ILongNode? source)
        {
            if (source is null) return null;
            if (source is LongNode thisEntity) return thisEntity;
            return new LongNode(source);
        }

        private static readonly LongNode _empty = new LongNode();
        public static new LongNode Empty => _empty;

    }
    public partial record LongNode : NumNode, ILongNode
    {
        public new const int EntityTag = 5;
        protected override int OnGetEntityTag() => EntityTag;

        public Int64 LongVal { get; init; }
        Int64 ILongNode.LongVal => LongVal;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LongNode() : base()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LongNode(LongNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            LongVal = source.LongVal;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LongNode(ILongNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            LongVal = source.LongVal;
        }

        public virtual bool Equals(LongNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (LongVal != other.LongVal) return false;
            return base.Equals(other);
        }

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
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }
    }

    public partial record ByteNode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ByteNode? CreateFrom(IByteNode? source)
        {
            if (source is null) return null;
            if (source is ByteNode thisEntity) return thisEntity;
            return new ByteNode(source);
        }

        private static readonly ByteNode _empty = new ByteNode();
        public static new ByteNode Empty => _empty;

    }
    public partial record ByteNode : NumNode, IByteNode
    {
        public new const int EntityTag = 6;
        protected override int OnGetEntityTag() => EntityTag;

        public Byte ByteVal { get; init; }
        Byte IByteNode.ByteVal => ByteVal;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ByteNode() : base()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ByteNode(ByteNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            ByteVal = source.ByteVal;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ByteNode(IByteNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            ByteVal = source.ByteVal;
        }

        public virtual bool Equals(ByteNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (ByteVal != other.ByteVal) return false;
            return base.Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(ByteVal.CalcHashUnary());
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
