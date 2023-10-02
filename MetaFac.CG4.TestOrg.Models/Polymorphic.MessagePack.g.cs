#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: MessagePack.2.3
// Metadata : MetaFac.CG4.TestOrg.Schema(.Polymorphic)
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
using MetaFac.CG4.TestOrg.Models.Polymorphic.Contracts;

namespace MetaFac.CG4.TestOrg.Models.Polymorphic.MessagePack
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


    [Union(NumericNode.EntityTag, typeof(NumericNode))]
    [Union(Int32Node.EntityTag, typeof(Int32Node))]
    [Union(Int64Node.EntityTag, typeof(Int64Node))]
    [Union(StringNode.EntityTag, typeof(StringNode))]
    [Union(BooleanNode.EntityTag, typeof(BooleanNode))]
    [Union(CustomNode.EntityTag, typeof(CustomNode))]
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
    [MessagePackObject]
    public partial class ValueNode : EntityBase, IValueNode, IEquatable<ValueNode>, ICopyFrom<ValueNode>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private Int64 field_Id;
        private String? field_Name;

        // ---------- accessors ----------
        [Key(1)]
        public Int64 Id
        {
            get => field_Id;
            set => field_Id = CheckNotFrozen(ref value);
        }
        [Key(2)]
        public String? Name
        {
            get => field_Name;
            set => field_Name = CheckNotFrozen(ref value);
        }

        // ---------- IValueNode methods ----------
        Int64 IValueNode.Id => field_Id.ToExternal();
        String? IValueNode.Name => field_Name;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueNode()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueNode(ValueNode source) : base(source)
        {
            field_Id = source.field_Id;
            field_Name = source.field_Name;
        }

        public void CopyFrom(ValueNode source)
        {
            base.CopyFrom(source);
            field_Id = source.field_Id;
            field_Name = source.field_Name;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueNode(IValueNode source) : base(source)
        {
            field_Id = source.Id.ToInternal();
            field_Name = source.Name;
        }

        public bool Equals(ValueNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_Id.ValueEquals(other.field_Id)) return false;
            if (!field_Name.ValueEquals(other.field_Name)) return false;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(ValueNode left, ValueNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ValueNode left, ValueNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return obj is ValueNode other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_Id.CalcHashUnary());
            hc.Add(field_Name.CalcHashUnary());
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

    [Union(Int32Node.EntityTag, typeof(Int32Node))]
    [Union(Int64Node.EntityTag, typeof(Int64Node))]
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
    [MessagePackObject]
    public partial class NumericNode : ValueNode, INumericNode, IEquatable<NumericNode>, ICopyFrom<NumericNode>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 2;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------

        // ---------- accessors ----------

        // ---------- INumericNode methods ----------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NumericNode()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NumericNode(NumericNode source) : base(source)
        {
        }

        public void CopyFrom(NumericNode source)
        {
            base.CopyFrom(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NumericNode(INumericNode source) : base(source)
        {
        }

        public bool Equals(NumericNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(NumericNode left, NumericNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(NumericNode left, NumericNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return obj is NumericNode other && Equals(other);
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

    public sealed class StringNode_Factory : IEntityFactory<IStringNode, StringNode>
    {
        private static readonly StringNode_Factory _instance = new StringNode_Factory();
        public static StringNode_Factory Instance => _instance;

        public StringNode? CreateFrom(IStringNode? source)
        {
            if (source is null) return null;
            if (source is StringNode sibling && sibling.IsFrozen()) return sibling;
            return new StringNode(source);
        }

        private static readonly StringNode _empty = new StringNode().Frozen();
        public StringNode Empty => _empty;
    }
    [MessagePackObject]
    public partial class StringNode : ValueNode, IStringNode, IEquatable<StringNode>, ICopyFrom<StringNode>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 3;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private String? field_StrValue;

        // ---------- accessors ----------
        [Key(3)]
        public String? StrValue
        {
            get => field_StrValue;
            set => field_StrValue = CheckNotFrozen(ref value);
        }

        // ---------- IStringNode methods ----------
        String? IStringNode.StrValue => field_StrValue;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StringNode()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StringNode(StringNode source) : base(source)
        {
            field_StrValue = source.field_StrValue;
        }

        public void CopyFrom(StringNode source)
        {
            base.CopyFrom(source);
            field_StrValue = source.field_StrValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StringNode(IStringNode source) : base(source)
        {
            field_StrValue = source.StrValue;
        }

        public bool Equals(StringNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_StrValue.ValueEquals(other.field_StrValue)) return false;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(StringNode left, StringNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(StringNode left, StringNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return obj is StringNode other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_StrValue.CalcHashUnary());
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

    public sealed class BooleanNode_Factory : IEntityFactory<IBooleanNode, BooleanNode>
    {
        private static readonly BooleanNode_Factory _instance = new BooleanNode_Factory();
        public static BooleanNode_Factory Instance => _instance;

        public BooleanNode? CreateFrom(IBooleanNode? source)
        {
            if (source is null) return null;
            if (source is BooleanNode sibling && sibling.IsFrozen()) return sibling;
            return new BooleanNode(source);
        }

        private static readonly BooleanNode _empty = new BooleanNode().Frozen();
        public BooleanNode Empty => _empty;
    }
    [MessagePackObject]
    public partial class BooleanNode : ValueNode, IBooleanNode, IEquatable<BooleanNode>, ICopyFrom<BooleanNode>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 4;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private Boolean field_BoolValue;

        // ---------- accessors ----------
        [Key(3)]
        public Boolean BoolValue
        {
            get => field_BoolValue;
            set => field_BoolValue = CheckNotFrozen(ref value);
        }

        // ---------- IBooleanNode methods ----------
        Boolean IBooleanNode.BoolValue => field_BoolValue.ToExternal();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BooleanNode()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BooleanNode(BooleanNode source) : base(source)
        {
            field_BoolValue = source.field_BoolValue;
        }

        public void CopyFrom(BooleanNode source)
        {
            base.CopyFrom(source);
            field_BoolValue = source.field_BoolValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BooleanNode(IBooleanNode source) : base(source)
        {
            field_BoolValue = source.BoolValue.ToInternal();
        }

        public bool Equals(BooleanNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_BoolValue.ValueEquals(other.field_BoolValue)) return false;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(BooleanNode left, BooleanNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(BooleanNode left, BooleanNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return obj is BooleanNode other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_BoolValue.CalcHashUnary());
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

    public sealed class CustomNode_Factory : IEntityFactory<ICustomNode, CustomNode>
    {
        private static readonly CustomNode_Factory _instance = new CustomNode_Factory();
        public static CustomNode_Factory Instance => _instance;

        public CustomNode? CreateFrom(ICustomNode? source)
        {
            if (source is null) return null;
            if (source is CustomNode sibling && sibling.IsFrozen()) return sibling;
            return new CustomNode(source);
        }

        private static readonly CustomNode _empty = new CustomNode().Frozen();
        public CustomNode Empty => _empty;
    }
    [MessagePackObject]
    public partial class CustomNode : ValueNode, ICustomNode, IEquatable<CustomNode>, ICopyFrom<CustomNode>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 5;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private CustomEnum field_CustomValue;

        // ---------- accessors ----------
        [Key(3)]
        public CustomEnum CustomValue
        {
            get => field_CustomValue;
            set => field_CustomValue = CheckNotFrozen(ref value);
        }

        // ---------- ICustomNode methods ----------
        CustomEnum ICustomNode.CustomValue => field_CustomValue.ToExternal();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CustomNode()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CustomNode(CustomNode source) : base(source)
        {
            field_CustomValue = source.field_CustomValue;
        }

        public void CopyFrom(CustomNode source)
        {
            base.CopyFrom(source);
            field_CustomValue = source.field_CustomValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CustomNode(ICustomNode source) : base(source)
        {
            field_CustomValue = source.CustomValue.ToInternal();
        }

        public bool Equals(CustomNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_CustomValue.ValueEquals(other.field_CustomValue)) return false;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(CustomNode left, CustomNode right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(CustomNode left, CustomNode right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return obj is CustomNode other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_CustomValue.CalcHashUnary());
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

    public sealed class Int32Node_Factory : IEntityFactory<IInt32Node, Int32Node>
    {
        private static readonly Int32Node_Factory _instance = new Int32Node_Factory();
        public static Int32Node_Factory Instance => _instance;

        public Int32Node? CreateFrom(IInt32Node? source)
        {
            if (source is null) return null;
            if (source is Int32Node sibling && sibling.IsFrozen()) return sibling;
            return new Int32Node(source);
        }

        private static readonly Int32Node _empty = new Int32Node().Frozen();
        public Int32Node Empty => _empty;
    }
    [MessagePackObject]
    public partial class Int32Node : NumericNode, IInt32Node, IEquatable<Int32Node>, ICopyFrom<Int32Node>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 6;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private Int32 field_IntValue;

        // ---------- accessors ----------
        [Key(3)]
        public Int32 IntValue
        {
            get => field_IntValue;
            set => field_IntValue = CheckNotFrozen(ref value);
        }

        // ---------- IInt32Node methods ----------
        Int32 IInt32Node.IntValue => field_IntValue.ToExternal();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int32Node()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int32Node(Int32Node source) : base(source)
        {
            field_IntValue = source.field_IntValue;
        }

        public void CopyFrom(Int32Node source)
        {
            base.CopyFrom(source);
            field_IntValue = source.field_IntValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int32Node(IInt32Node source) : base(source)
        {
            field_IntValue = source.IntValue.ToInternal();
        }

        public bool Equals(Int32Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_IntValue.ValueEquals(other.field_IntValue)) return false;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Int32Node left, Int32Node right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Int32Node left, Int32Node right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return obj is Int32Node other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_IntValue.CalcHashUnary());
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

    public sealed class Int64Node_Factory : IEntityFactory<IInt64Node, Int64Node>
    {
        private static readonly Int64Node_Factory _instance = new Int64Node_Factory();
        public static Int64Node_Factory Instance => _instance;

        public Int64Node? CreateFrom(IInt64Node? source)
        {
            if (source is null) return null;
            if (source is Int64Node sibling && sibling.IsFrozen()) return sibling;
            return new Int64Node(source);
        }

        private static readonly Int64Node _empty = new Int64Node().Frozen();
        public Int64Node Empty => _empty;
    }
    [MessagePackObject]
    public partial class Int64Node : NumericNode, IInt64Node, IEquatable<Int64Node>, ICopyFrom<Int64Node>
    {
        protected override void OnFreeze()
        {
            base.OnFreeze();
        }

        public new const int EntityTag = 7;
        protected override int OnGetEntityTag() => EntityTag;

        // ---------- private fields ----------
        private Int64 field_LongValue;

        // ---------- accessors ----------
        [Key(3)]
        public Int64 LongValue
        {
            get => field_LongValue;
            set => field_LongValue = CheckNotFrozen(ref value);
        }

        // ---------- IInt64Node methods ----------
        Int64 IInt64Node.LongValue => field_LongValue.ToExternal();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int64Node()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int64Node(Int64Node source) : base(source)
        {
            field_LongValue = source.field_LongValue;
        }

        public void CopyFrom(Int64Node source)
        {
            base.CopyFrom(source);
            field_LongValue = source.field_LongValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int64Node(IInt64Node source) : base(source)
        {
            field_LongValue = source.LongValue.ToInternal();
        }

        public bool Equals(Int64Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!field_LongValue.ValueEquals(other.field_LongValue)) return false;
            return base.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Int64Node left, Int64Node right)
        {
            if (left is null) return (right is null);
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Int64Node left, Int64Node right)
        {
            if (left is null) return !(right is null);
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return obj is Int64Node other && Equals(other);
        }

        private int CalcHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(field_LongValue.CalcHashUnary());
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
