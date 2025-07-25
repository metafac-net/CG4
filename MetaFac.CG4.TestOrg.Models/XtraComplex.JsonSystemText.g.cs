#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: JsonSystemText.4.0
// Metadata : MetaFac.CG4.TestOrg.Schema(.XtraComplex)
// </information>
#endregion
#nullable enable
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8019 // Unnecessary using directive
using MetaFac.Mutability;
using MetaFac.CG4.Runtime;
using MetaFac.CG4.Runtime.JsonSystemText;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Text.Json.Serialization;
using MetaFac.CG4.TestOrg.Models.XtraComplex.Contracts;
using DataFac.Memory;

namespace MetaFac.CG4.TestOrg.Models.XtraComplex.JsonSystemText
{


    public abstract partial class EntityBase : IFreezable, IEntityBase
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


    public sealed class Tree_Factory : IEntityFactory<ITree, Tree>
    {
        private static readonly Tree_Factory _instance = new Tree_Factory();
        public static Tree_Factory Instance => _instance;
        public Tree? CreateFrom(ITree? source) => (source is null) ? null : new Tree(source);
        public Tree Empty => new Tree();
    }
    public partial class Tree : EntityBase, ITree, IEquatable<Tree>
    {
        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        private Node? field_Value;
        INode? ITree.Value => field_Value;
        public Node? Value
        {
            get => field_Value;
            set => field_Value = value;
        }
        private Tree? field_A;
        ITree? ITree.A => field_A;
        public Tree? A
        {
            get => field_A;
            set => field_A = value;
        }
        private Tree? field_B;
        ITree? ITree.B => field_B;
        public Tree? B
        {
            get => field_B;
            set => field_B = value;
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
            field_Value = Node_Factory.Instance.CreateFrom(source.Value);
            field_A = Tree_Factory.Instance.CreateFrom(source.A);
            field_B = Tree_Factory.Instance.CreateFrom(source.B);
        }

        public void CopyFrom(ITree? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
            field_Value = Node_Factory.Instance.CreateFrom(source.Value);
            field_A = Tree_Factory.Instance.CreateFrom(source.A);
            field_B = Tree_Factory.Instance.CreateFrom(source.B);
        }

        public bool Equals(Tree? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!Value.ValueEquals(other.Value)) return false;
            if (!A.ValueEquals(other.A)) return false;
            if (!B.ValueEquals(other.B)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is Tree other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(Value.CalcHashUnary());
            hc.Add(A.CalcHashUnary());
            hc.Add(B.CalcHashUnary());
            return hc.ToHashCode();
        }
    }

    [JsonDerivedType(typeof(StrNode), StrNode.EntityTag)]
    [JsonDerivedType(typeof(NumNode), NumNode.EntityTag)]
    [JsonDerivedType(typeof(LongNode), LongNode.EntityTag)]
    [JsonDerivedType(typeof(DaynNode), DaynNode.EntityTag)]
    public partial class Node
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
    public partial class Node : EntityBase, INode, IEquatable<Node>
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

        public void CopyFrom(INode? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
        }

        public bool Equals(Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is Node other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            return hc.ToHashCode();
        }
    }

    public sealed class StrNode_Factory : IEntityFactory<IStrNode, StrNode>
    {
        private static readonly StrNode_Factory _instance = new StrNode_Factory();
        public static StrNode_Factory Instance => _instance;
        public StrNode? CreateFrom(IStrNode? source) => (source is null) ? null : new StrNode(source);
        public StrNode Empty => new StrNode();
    }
    public partial class StrNode : Node, IStrNode, IEquatable<StrNode>
    {
        public new const int EntityTag = 3;
        protected override int OnGetEntityTag() => EntityTag;

        private String? field_StrVal;
        String? IStrNode.StrVal => field_StrVal;
        public String? StrVal
        {
            get => field_StrVal;
            set => field_StrVal = value;
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
            base.CopyFrom(source);
            field_StrVal = source.StrVal;
        }

        public bool Equals(StrNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!StrVal.ValueEquals(other.StrVal)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is StrNode other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(StrVal.CalcHashUnary());
            return hc.ToHashCode();
        }
    }

    [JsonDerivedType(typeof(LongNode), LongNode.EntityTag)]
    [JsonDerivedType(typeof(DaynNode), DaynNode.EntityTag)]
    public partial class NumNode
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
    public partial class NumNode : Node, INumNode, IEquatable<NumNode>
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

        public void CopyFrom(INumNode? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
        }

        public bool Equals(NumNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is NumNode other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            return hc.ToHashCode();
        }
    }

    public sealed class LongNode_Factory : IEntityFactory<ILongNode, LongNode>
    {
        private static readonly LongNode_Factory _instance = new LongNode_Factory();
        public static LongNode_Factory Instance => _instance;
        public LongNode? CreateFrom(ILongNode? source) => (source is null) ? null : new LongNode(source);
        public LongNode Empty => new LongNode();
    }
    public partial class LongNode : NumNode, ILongNode, IEquatable<LongNode>
    {
        public new const int EntityTag = 5;
        protected override int OnGetEntityTag() => EntityTag;

        private Int64 field_LongVal;
        Int64 ILongNode.LongVal { get => field_LongVal; }
        public Int64 LongVal
        {
            get => field_LongVal;
            set => field_LongVal = value;
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
            base.CopyFrom(source);
            field_LongVal = source.LongVal;
        }

        public bool Equals(LongNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!LongVal.ValueEquals(other.LongVal)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is LongNode other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(LongVal.CalcHashUnary());
            return hc.ToHashCode();
        }
    }

    public sealed class DaynNode_Factory : IEntityFactory<IDaynNode, DaynNode>
    {
        private static readonly DaynNode_Factory _instance = new DaynNode_Factory();
        public static DaynNode_Factory Instance => _instance;
        public DaynNode? CreateFrom(IDaynNode? source) => (source is null) ? null : new DaynNode(source);
        public DaynNode Empty => new DaynNode();
    }
    public partial class DaynNode : NumNode, IDaynNode, IEquatable<DaynNode>
    {
        public new const int EntityTag = 6;
        protected override int OnGetEntityTag() => EntityTag;

        private System.DayOfWeek field_DaynVal;
        System.DayOfWeek IDaynNode.DaynVal { get => field_DaynVal; }
        public System.DayOfWeek DaynVal
        {
            get => field_DaynVal;
            set => field_DaynVal = value;
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
            base.CopyFrom(source);
            field_DaynVal = source.DaynVal;
        }

        public bool Equals(DaynNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!DaynVal.ValueEquals(other.DaynVal)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is DaynNode other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(DaynVal.CalcHashUnary());
            return hc.ToHashCode();
        }
    }


}
