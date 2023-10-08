#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: RecordsV2.2.3
// Metadata : MetaFac.CG4.TestOrg.Schema(.Polymorphic)
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
using MetaFac.CG4.TestOrg.ModelsNet7.Polymorphic.Contracts;

namespace MetaFac.CG4.TestOrg.ModelsNet7.Polymorphic.RecordsV2
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
        public bool IsFreezable() => false;
        public bool IsFrozen() => true;
        public void Freeze() { }
        public bool TryFreeze() => false;
    }


    public abstract partial record ValueNode : EntityBase, IValueNode
    {
    }
    public sealed class ValueNode_Factory : IEntityFactory<IValueNode, ValueNode>
    {
        private static readonly ValueNode_Factory _instance = new ValueNode_Factory();
        public static ValueNode_Factory Instance => _instance;

        public ValueNode? CreateFrom(IValueNode? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                case NumericNode.EntityTag: return NumericNode_Factory.Instance.CreateFrom((INumericNode)source);
                case Int32Node.EntityTag: return Int32Node_Factory.Instance.CreateFrom((IInt32Node)source);
                case Int64Node.EntityTag: return Int64Node_Factory.Instance.CreateFrom((IInt64Node)source);
                case StringNode.EntityTag: return StringNode_Factory.Instance.CreateFrom((IStringNode)source);
                case BooleanNode.EntityTag: return BooleanNode_Factory.Instance.CreateFrom((IBooleanNode)source);
                case CustomNode.EntityTag: return CustomNode_Factory.Instance.CreateFrom((ICustomNode)source);
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(ValueNode)} from {source.GetType().Name}");
            }
        }

        public ValueNode Empty => throw new NotSupportedException($"Cannot create abstract entity: {typeof(ValueNode)}");
    }
    public partial record ValueNode : EntityBase, IValueNode
    {
        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        public Int64 Id { get; init; }
        Int64 IValueNode.Id => Id;
        public String? Name { get; init; }
        String? IValueNode.Name => Name;

        public ValueNode() : base()
        {
        }

        public ValueNode(ValueNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Id = source.Id;
            Name = source.Name;
        }

        public ValueNode(IValueNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Id = source.Id;
            Name = source.Name;
        }

        public virtual bool Equals(ValueNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!Id.ValueEquals(other.Id)) return false;
            if (!Name.ValueEquals(other.Name)) return false;
            return base.Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(Id.CalcHashUnary());
            hc.Add(Name.CalcHashUnary());
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

    public abstract partial record NumericNode : ValueNode, INumericNode
    {
    }
    public sealed class NumericNode_Factory : IEntityFactory<INumericNode, NumericNode>
    {
        private static readonly NumericNode_Factory _instance = new NumericNode_Factory();
        public static NumericNode_Factory Instance => _instance;

        public NumericNode? CreateFrom(INumericNode? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                case Int32Node.EntityTag: return Int32Node_Factory.Instance.CreateFrom((IInt32Node)source);
                case Int64Node.EntityTag: return Int64Node_Factory.Instance.CreateFrom((IInt64Node)source);
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(NumericNode)} from {source.GetType().Name}");
            }
        }

        public NumericNode Empty => throw new NotSupportedException($"Cannot create abstract entity: {typeof(NumericNode)}");
    }
    public partial record NumericNode : ValueNode, INumericNode
    {
        public new const int EntityTag = 2;
        protected override int OnGetEntityTag() => EntityTag;


        public NumericNode() : base()
        {
        }

        public NumericNode(NumericNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
        }

        public NumericNode(INumericNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
        }

        public virtual bool Equals(NumericNode? other)
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

    public sealed class StringNode_Factory : IEntityFactory<IStringNode, StringNode>
    {
        private static readonly StringNode_Factory _instance = new StringNode_Factory();
        public static StringNode_Factory Instance => _instance;

        public StringNode? CreateFrom(IStringNode? source)
        {
            if (source is null) return null;
            if (source is StringNode thisEntity) return thisEntity;
            return new StringNode(source);
        }

        private static readonly StringNode _empty = new StringNode();
        public StringNode Empty => _empty;
    }
    public partial record StringNode : ValueNode, IStringNode
    {
        public new const int EntityTag = 3;
        protected override int OnGetEntityTag() => EntityTag;

        public String? StrValue { get; init; }
        String? IStringNode.StrValue => StrValue;

        public StringNode() : base()
        {
        }

        public StringNode(StringNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            StrValue = source.StrValue;
        }

        public StringNode(IStringNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            StrValue = source.StrValue;
        }

        public virtual bool Equals(StringNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!StrValue.ValueEquals(other.StrValue)) return false;
            return base.Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(StrValue.CalcHashUnary());
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

    public sealed class BooleanNode_Factory : IEntityFactory<IBooleanNode, BooleanNode>
    {
        private static readonly BooleanNode_Factory _instance = new BooleanNode_Factory();
        public static BooleanNode_Factory Instance => _instance;

        public BooleanNode? CreateFrom(IBooleanNode? source)
        {
            if (source is null) return null;
            if (source is BooleanNode thisEntity) return thisEntity;
            return new BooleanNode(source);
        }

        private static readonly BooleanNode _empty = new BooleanNode();
        public BooleanNode Empty => _empty;
    }
    public partial record BooleanNode : ValueNode, IBooleanNode
    {
        public new const int EntityTag = 4;
        protected override int OnGetEntityTag() => EntityTag;

        public Boolean BoolValue { get; init; }
        Boolean IBooleanNode.BoolValue => BoolValue;

        public BooleanNode() : base()
        {
        }

        public BooleanNode(BooleanNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            BoolValue = source.BoolValue;
        }

        public BooleanNode(IBooleanNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            BoolValue = source.BoolValue;
        }

        public virtual bool Equals(BooleanNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!BoolValue.ValueEquals(other.BoolValue)) return false;
            return base.Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(BoolValue.CalcHashUnary());
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

    public sealed class CustomNode_Factory : IEntityFactory<ICustomNode, CustomNode>
    {
        private static readonly CustomNode_Factory _instance = new CustomNode_Factory();
        public static CustomNode_Factory Instance => _instance;

        public CustomNode? CreateFrom(ICustomNode? source)
        {
            if (source is null) return null;
            if (source is CustomNode thisEntity) return thisEntity;
            return new CustomNode(source);
        }

        private static readonly CustomNode _empty = new CustomNode();
        public CustomNode Empty => _empty;
    }
    public partial record CustomNode : ValueNode, ICustomNode
    {
        public new const int EntityTag = 5;
        protected override int OnGetEntityTag() => EntityTag;

        public CustomEnum CustomValue { get; init; }
        CustomEnum ICustomNode.CustomValue => CustomValue;

        public CustomNode() : base()
        {
        }

        public CustomNode(CustomNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            CustomValue = source.CustomValue;
        }

        public CustomNode(ICustomNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            CustomValue = source.CustomValue;
        }

        public virtual bool Equals(CustomNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!CustomValue.ValueEquals(other.CustomValue)) return false;
            return base.Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(CustomValue.CalcHashUnary());
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

    public sealed class Int32Node_Factory : IEntityFactory<IInt32Node, Int32Node>
    {
        private static readonly Int32Node_Factory _instance = new Int32Node_Factory();
        public static Int32Node_Factory Instance => _instance;

        public Int32Node? CreateFrom(IInt32Node? source)
        {
            if (source is null) return null;
            if (source is Int32Node thisEntity) return thisEntity;
            return new Int32Node(source);
        }

        private static readonly Int32Node _empty = new Int32Node();
        public Int32Node Empty => _empty;
    }
    public partial record Int32Node : NumericNode, IInt32Node
    {
        public new const int EntityTag = 6;
        protected override int OnGetEntityTag() => EntityTag;

        public Int32 IntValue { get; init; }
        Int32 IInt32Node.IntValue => IntValue;

        public Int32Node() : base()
        {
        }

        public Int32Node(Int32Node? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            IntValue = source.IntValue;
        }

        public Int32Node(IInt32Node? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            IntValue = source.IntValue;
        }

        public virtual bool Equals(Int32Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!IntValue.ValueEquals(other.IntValue)) return false;
            return base.Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(IntValue.CalcHashUnary());
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

    public sealed class Int64Node_Factory : IEntityFactory<IInt64Node, Int64Node>
    {
        private static readonly Int64Node_Factory _instance = new Int64Node_Factory();
        public static Int64Node_Factory Instance => _instance;

        public Int64Node? CreateFrom(IInt64Node? source)
        {
            if (source is null) return null;
            if (source is Int64Node thisEntity) return thisEntity;
            return new Int64Node(source);
        }

        private static readonly Int64Node _empty = new Int64Node();
        public Int64Node Empty => _empty;
    }
    public partial record Int64Node : NumericNode, IInt64Node
    {
        public new const int EntityTag = 7;
        protected override int OnGetEntityTag() => EntityTag;

        public Int64 LongValue { get; init; }
        Int64 IInt64Node.LongValue => LongValue;

        public Int64Node() : base()
        {
        }

        public Int64Node(Int64Node? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            LongValue = source.LongValue;
        }

        public Int64Node(IInt64Node? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            LongValue = source.LongValue;
        }

        public virtual bool Equals(Int64Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!LongValue.ValueEquals(other.LongValue)) return false;
            return base.Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(LongValue.CalcHashUnary());
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