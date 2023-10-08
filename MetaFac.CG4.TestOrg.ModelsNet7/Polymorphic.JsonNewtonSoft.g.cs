#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: JsonNewtonSoft.2.3
// Metadata : MetaFac.CG4.TestOrg.Schema(.Polymorphic)
// </information>
#endregion
#nullable enable
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8019 // Unnecessary using directive
using MetaFac.Mutability;
using MetaFac.CG4.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MetaFac.CG4.TestOrg.ModelsNet7.Polymorphic.Contracts;
using MetaFac.Memory;

namespace MetaFac.CG4.TestOrg.ModelsNet7.Polymorphic.JsonNewtonSoft
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
        public bool Equals(EntityBase? other) => true;
        public override int GetHashCode() => 0;

        public bool IsFreezable() => false;
        public bool IsFrozen() => false;
        public void Freeze() { }
        public bool TryFreeze() => true;
    }


    public abstract partial class ValueNode
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
    public partial class ValueNode : EntityBase, IValueNode, IEquatable<ValueNode>
    {
        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        private Int64 field_Id;
        Int64 IValueNode.Id { get => field_Id; }
        public Int64 Id
        {
            get => field_Id;
            set => field_Id = value;
        }
        private String? field_Name;
        String? IValueNode.Name => field_Name;
        public String? Name
        {
            get => field_Name;
            set => field_Name = value;
        }

        public ValueNode() : base()
        {
        }

        public ValueNode(ValueNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_Id = source.Id;
            field_Name = source.Name;
        }

        public ValueNode(IValueNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_Id = source.Id;
            field_Name = source.Name;
        }

        public void CopyFrom(IValueNode? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
            field_Id = source.Id;
            field_Name = source.Name;
        }

        public bool Equals(ValueNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!Id .ValueEquals(other.Id)) return false;
            if (!Name.ValueEquals(other.Name)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is ValueNode other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(Id.CalcHashUnary());
            hc.Add(Name.CalcHashUnary());
            return hc.ToHashCode();
        }
    }

    public abstract partial class NumericNode
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
    public partial class NumericNode : ValueNode, INumericNode, IEquatable<NumericNode>
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

        public void CopyFrom(INumericNode? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
        }

        public bool Equals(NumericNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is NumericNode other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            return hc.ToHashCode();
        }
    }

    public sealed class StringNode_Factory : IEntityFactory<IStringNode, StringNode>
    {
        private static readonly StringNode_Factory _instance = new StringNode_Factory();
        public static StringNode_Factory Instance => _instance;
        public StringNode? CreateFrom(IStringNode? source) => (source is null) ? null : new StringNode(source);
        public StringNode Empty => new StringNode();
    }
    public partial class StringNode : ValueNode, IStringNode, IEquatable<StringNode>
    {
        public new const int EntityTag = 3;
        protected override int OnGetEntityTag() => EntityTag;

        private String? field_StrValue;
        String? IStringNode.StrValue => field_StrValue;
        public String? StrValue
        {
            get => field_StrValue;
            set => field_StrValue = value;
        }

        public StringNode() : base()
        {
        }

        public StringNode(StringNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_StrValue = source.StrValue;
        }

        public StringNode(IStringNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_StrValue = source.StrValue;
        }

        public void CopyFrom(IStringNode? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
            field_StrValue = source.StrValue;
        }

        public bool Equals(StringNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!StrValue.ValueEquals(other.StrValue)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is StringNode other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(StrValue.CalcHashUnary());
            return hc.ToHashCode();
        }
    }

    public sealed class BooleanNode_Factory : IEntityFactory<IBooleanNode, BooleanNode>
    {
        private static readonly BooleanNode_Factory _instance = new BooleanNode_Factory();
        public static BooleanNode_Factory Instance => _instance;
        public BooleanNode? CreateFrom(IBooleanNode? source) => (source is null) ? null : new BooleanNode(source);
        public BooleanNode Empty => new BooleanNode();
    }
    public partial class BooleanNode : ValueNode, IBooleanNode, IEquatable<BooleanNode>
    {
        public new const int EntityTag = 4;
        protected override int OnGetEntityTag() => EntityTag;

        private Boolean field_BoolValue;
        Boolean IBooleanNode.BoolValue { get => field_BoolValue; }
        public Boolean BoolValue
        {
            get => field_BoolValue;
            set => field_BoolValue = value;
        }

        public BooleanNode() : base()
        {
        }

        public BooleanNode(BooleanNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_BoolValue = source.BoolValue;
        }

        public BooleanNode(IBooleanNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_BoolValue = source.BoolValue;
        }

        public void CopyFrom(IBooleanNode? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
            field_BoolValue = source.BoolValue;
        }

        public bool Equals(BooleanNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!BoolValue .ValueEquals(other.BoolValue)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is BooleanNode other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(BoolValue.CalcHashUnary());
            return hc.ToHashCode();
        }
    }

    public sealed class CustomNode_Factory : IEntityFactory<ICustomNode, CustomNode>
    {
        private static readonly CustomNode_Factory _instance = new CustomNode_Factory();
        public static CustomNode_Factory Instance => _instance;
        public CustomNode? CreateFrom(ICustomNode? source) => (source is null) ? null : new CustomNode(source);
        public CustomNode Empty => new CustomNode();
    }
    public partial class CustomNode : ValueNode, ICustomNode, IEquatable<CustomNode>
    {
        public new const int EntityTag = 5;
        protected override int OnGetEntityTag() => EntityTag;

        private CustomEnum field_CustomValue;
        CustomEnum ICustomNode.CustomValue { get => field_CustomValue; }
        public CustomEnum CustomValue
        {
            get => field_CustomValue;
            set => field_CustomValue = value;
        }

        public CustomNode() : base()
        {
        }

        public CustomNode(CustomNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_CustomValue = source.CustomValue;
        }

        public CustomNode(ICustomNode? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_CustomValue = source.CustomValue;
        }

        public void CopyFrom(ICustomNode? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
            field_CustomValue = source.CustomValue;
        }

        public bool Equals(CustomNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!CustomValue .ValueEquals(other.CustomValue)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is CustomNode other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(CustomValue.CalcHashUnary());
            return hc.ToHashCode();
        }
    }

    public sealed class Int32Node_Factory : IEntityFactory<IInt32Node, Int32Node>
    {
        private static readonly Int32Node_Factory _instance = new Int32Node_Factory();
        public static Int32Node_Factory Instance => _instance;
        public Int32Node? CreateFrom(IInt32Node? source) => (source is null) ? null : new Int32Node(source);
        public Int32Node Empty => new Int32Node();
    }
    public partial class Int32Node : NumericNode, IInt32Node, IEquatable<Int32Node>
    {
        public new const int EntityTag = 6;
        protected override int OnGetEntityTag() => EntityTag;

        private Int32 field_IntValue;
        Int32 IInt32Node.IntValue { get => field_IntValue; }
        public Int32 IntValue
        {
            get => field_IntValue;
            set => field_IntValue = value;
        }

        public Int32Node() : base()
        {
        }

        public Int32Node(Int32Node? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_IntValue = source.IntValue;
        }

        public Int32Node(IInt32Node? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_IntValue = source.IntValue;
        }

        public void CopyFrom(IInt32Node? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
            field_IntValue = source.IntValue;
        }

        public bool Equals(Int32Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!IntValue .ValueEquals(other.IntValue)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is Int32Node other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(IntValue.CalcHashUnary());
            return hc.ToHashCode();
        }
    }

    public sealed class Int64Node_Factory : IEntityFactory<IInt64Node, Int64Node>
    {
        private static readonly Int64Node_Factory _instance = new Int64Node_Factory();
        public static Int64Node_Factory Instance => _instance;
        public Int64Node? CreateFrom(IInt64Node? source) => (source is null) ? null : new Int64Node(source);
        public Int64Node Empty => new Int64Node();
    }
    public partial class Int64Node : NumericNode, IInt64Node, IEquatable<Int64Node>
    {
        public new const int EntityTag = 7;
        protected override int OnGetEntityTag() => EntityTag;

        private Int64 field_LongValue;
        Int64 IInt64Node.LongValue { get => field_LongValue; }
        public Int64 LongValue
        {
            get => field_LongValue;
            set => field_LongValue = value;
        }

        public Int64Node() : base()
        {
        }

        public Int64Node(Int64Node? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_LongValue = source.LongValue;
        }

        public Int64Node(IInt64Node? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_LongValue = source.LongValue;
        }

        public void CopyFrom(IInt64Node? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
            field_LongValue = source.LongValue;
        }

        public bool Equals(Int64Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!LongValue .ValueEquals(other.LongValue)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is Int64Node other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(LongValue.CalcHashUnary());
            return hc.ToHashCode();
        }
    }


#if NET6_0_OR_GREATER
    public struct HalfValue
    {
        public short Value { get; set; }
        public HalfValue() { }
        public HalfValue(short value) => Value = value;
        public override int GetHashCode() => HashCode.Combine(Value);
        public override bool Equals(object? obj) => obj is HalfValue other && Equals(other);
        public bool Equals(HalfValue other) => other.Value.Equals(Value);
        public static bool operator ==(HalfValue left, HalfValue right) => left.Equals(right);
        public static bool operator !=(HalfValue left, HalfValue right) => !left.Equals(right);

        public static implicit operator HalfValue(Half value) => new HalfValue(BitConverter.HalfToInt16Bits(value));
        public static implicit operator Half(HalfValue value) => BitConverter.Int16BitsToHalf(value.Value);
    }
#endif

}
