#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: RecordsV2.2.10
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
using System.Numerics;
using MetaFac.CG4.TestOrg.Models.XtraComplex.Contracts;

namespace MetaFac.CG4.TestOrg.Models.XtraComplex.RecordsV2
{


    public abstract partial record EntityBase : IFreezable, IEntityBase
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

        private static readonly Tree _empty = new Tree();
        public Tree Empty => _empty;
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

        public Tree() : base()
        {
        }

        public Tree(Tree? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Value = source.Value;
            A = source.A;
            B = source.B;
        }

        public Tree(ITree? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Value = Node_Factory.Instance.CreateFrom(source.Value);
            A = Tree_Factory.Instance.CreateFrom(source.A);
            B = Tree_Factory.Instance.CreateFrom(source.B);
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

    public abstract partial record Node : EntityBase, INode
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
    public partial record Node : EntityBase, INode
    {
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

    public sealed class StrNode_Factory : IEntityFactory<IStrNode, StrNode>
    {
        private static readonly StrNode_Factory _instance = new StrNode_Factory();
        public static StrNode_Factory Instance => _instance;

        public StrNode? CreateFrom(IStrNode? source)
        {
            if (source is null) return null;
            if (source is StrNode thisEntity) return thisEntity;
            return new StrNode(source);
        }

        private static readonly StrNode _empty = new StrNode();
        public StrNode Empty => _empty;
    }
    public partial record StrNode : Node, IStrNode
    {
        public new const int EntityTag = 3;
        protected override int OnGetEntityTag() => EntityTag;

        public String? StrVal { get; init; }
        String? IStrNode.StrVal => StrVal;

        public StrNode() : base()
        {
        }

        public StrNode(StrNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            StrVal = source.StrVal;
        }

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

    public abstract partial record NumNode : Node, INumNode
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
    public partial record NumNode : Node, INumNode
    {
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

    public sealed class LongNode_Factory : IEntityFactory<ILongNode, LongNode>
    {
        private static readonly LongNode_Factory _instance = new LongNode_Factory();
        public static LongNode_Factory Instance => _instance;

        public LongNode? CreateFrom(ILongNode? source)
        {
            if (source is null) return null;
            if (source is LongNode thisEntity) return thisEntity;
            return new LongNode(source);
        }

        private static readonly LongNode _empty = new LongNode();
        public LongNode Empty => _empty;
    }
    public partial record LongNode : NumNode, ILongNode
    {
        public new const int EntityTag = 5;
        protected override int OnGetEntityTag() => EntityTag;

        public Int64 LongVal { get; init; }
        Int64 ILongNode.LongVal => LongVal;

        public LongNode() : base()
        {
        }

        public LongNode(LongNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            LongVal = source.LongVal;
        }

        public LongNode(ILongNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            LongVal = source.LongVal;
        }

        public virtual bool Equals(LongNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!LongVal.ValueEquals(other.LongVal)) return false;
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

    public sealed class DaynNode_Factory : IEntityFactory<IDaynNode, DaynNode>
    {
        private static readonly DaynNode_Factory _instance = new DaynNode_Factory();
        public static DaynNode_Factory Instance => _instance;

        public DaynNode? CreateFrom(IDaynNode? source)
        {
            if (source is null) return null;
            if (source is DaynNode thisEntity) return thisEntity;
            return new DaynNode(source);
        }

        private static readonly DaynNode _empty = new DaynNode();
        public DaynNode Empty => _empty;
    }
    public partial record DaynNode : NumNode, IDaynNode
    {
        public new const int EntityTag = 6;
        protected override int OnGetEntityTag() => EntityTag;

        public System.DayOfWeek DaynVal { get; init; }
        System.DayOfWeek IDaynNode.DaynVal => DaynVal;

        public DaynNode() : base()
        {
        }

        public DaynNode(DaynNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            DaynVal = source.DaynVal;
        }

        public DaynNode(IDaynNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            DaynVal = source.DaynVal;
        }

        public virtual bool Equals(DaynNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!DaynVal.ValueEquals(other.DaynVal)) return false;
            return base.Equals(other);
        }

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
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }
    }



}
