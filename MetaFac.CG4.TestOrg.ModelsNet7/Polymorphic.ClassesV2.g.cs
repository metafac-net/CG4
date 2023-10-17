#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: ClassesV2.2.4
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
using System.Runtime.CompilerServices;
using MetaFac.CG4.TestOrg.ModelsNet7.Polymorphic.Contracts;

namespace MetaFac.CG4.TestOrg.ModelsNet7.Polymorphic.ClassesV2
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


    public abstract partial class ValueNode
    {
        public static ValueNode? CreateFrom(IValueNode? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                case NumericNode.EntityTag: return NumericNode.CreateFrom((INumericNode)source);
                case Int32Node.EntityTag: return Int32Node.CreateFrom((IInt32Node)source);
                case Int64Node.EntityTag: return Int64Node.CreateFrom((IInt64Node)source);
                case StringNode.EntityTag: return StringNode.CreateFrom((IStringNode)source);
                case BooleanNode.EntityTag: return BooleanNode.CreateFrom((IBooleanNode)source);
                case CustomNode.EntityTag: return CustomNode.CreateFrom((ICustomNode)source);
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(ValueNode)} from {source.GetType().Name}");
            }
        }

    }
    public partial class ValueNode : EntityBase, IValueNode, IEquatable<ValueNode>
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

        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        private Int64 field_Id;
        Int64 IValueNode.Id => field_Id;
        public Int64 Id
        {
            get => field_Id;
            set => field_Id = CheckNotFrozen(ref value);
        }
        private String? field_Name;
        String? IValueNode.Name => field_Name;
        public String? Name
        {
            get => field_Name;
            set => field_Name = CheckNotFrozen(ref value);
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
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            field_Id = source.Id;
            field_Name = source.Name;
        }

        public virtual bool Equals(ValueNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!Id.ValueEquals(other.Id)) return false;
            if (!Name.ValueEquals(other.Name)) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is ValueNode other && Equals(other);

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
            if (!_isFrozen) return CalcHashCode();
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }
    }

    public abstract partial class NumericNode
    {
        public static NumericNode? CreateFrom(INumericNode? source)
        {
            if (source is null) return null;
            int entityTag = source.GetEntityTag();
            switch (entityTag)
            {
                case Int32Node.EntityTag: return Int32Node.CreateFrom((IInt32Node)source);
                case Int64Node.EntityTag: return Int64Node.CreateFrom((IInt64Node)source);
                default:
                    throw new InvalidOperationException($"Unable to create {typeof(NumericNode)} from {source.GetType().Name}");
            }
        }

    }
    public partial class NumericNode : ValueNode, INumericNode, IEquatable<NumericNode>
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
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
        }

        public virtual bool Equals(NumericNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is NumericNode other && Equals(other);

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

    public partial class StringNode
    {
        public static StringNode? CreateFrom(IStringNode? source)
        {
            if (source is null) return null;
            if (source is StringNode thisEntity && thisEntity._isFrozen) return thisEntity;
            return new StringNode(source);
        }

        private static StringNode CreateEmpty()
        {
            var empty = new StringNode();
            empty.Freeze();
            return empty;
        }
        private static readonly StringNode _empty = CreateEmpty();
        public static new StringNode Empty => _empty;

    }
    public partial class StringNode : ValueNode, IStringNode, IEquatable<StringNode>
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

        private String? field_StrValue;
        String? IStringNode.StrValue => field_StrValue;
        public String? StrValue
        {
            get => field_StrValue;
            set => field_StrValue = CheckNotFrozen(ref value);
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
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            field_StrValue = source.StrValue;
        }

        public virtual bool Equals(StringNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!StrValue.ValueEquals(other.StrValue)) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is StringNode other && Equals(other);

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
            if (!_isFrozen) return CalcHashCode();
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }
    }

    public partial class BooleanNode
    {
        public static BooleanNode? CreateFrom(IBooleanNode? source)
        {
            if (source is null) return null;
            if (source is BooleanNode thisEntity && thisEntity._isFrozen) return thisEntity;
            return new BooleanNode(source);
        }

        private static BooleanNode CreateEmpty()
        {
            var empty = new BooleanNode();
            empty.Freeze();
            return empty;
        }
        private static readonly BooleanNode _empty = CreateEmpty();
        public static new BooleanNode Empty => _empty;

    }
    public partial class BooleanNode : ValueNode, IBooleanNode, IEquatable<BooleanNode>
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

        private Boolean field_BoolValue;
        Boolean IBooleanNode.BoolValue => field_BoolValue;
        public Boolean BoolValue
        {
            get => field_BoolValue;
            set => field_BoolValue = CheckNotFrozen(ref value);
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
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            field_BoolValue = source.BoolValue;
        }

        public virtual bool Equals(BooleanNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!BoolValue.ValueEquals(other.BoolValue)) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is BooleanNode other && Equals(other);

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
            if (!_isFrozen) return CalcHashCode();
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }
    }

    public partial class CustomNode
    {
        public static CustomNode? CreateFrom(ICustomNode? source)
        {
            if (source is null) return null;
            if (source is CustomNode thisEntity && thisEntity._isFrozen) return thisEntity;
            return new CustomNode(source);
        }

        private static CustomNode CreateEmpty()
        {
            var empty = new CustomNode();
            empty.Freeze();
            return empty;
        }
        private static readonly CustomNode _empty = CreateEmpty();
        public static new CustomNode Empty => _empty;

    }
    public partial class CustomNode : ValueNode, ICustomNode, IEquatable<CustomNode>
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

        private CustomEnum field_CustomValue;
        CustomEnum ICustomNode.CustomValue => field_CustomValue;
        public CustomEnum CustomValue
        {
            get => field_CustomValue;
            set => field_CustomValue = CheckNotFrozen(ref value);
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
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            field_CustomValue = source.CustomValue;
        }

        public virtual bool Equals(CustomNode? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!CustomValue.ValueEquals(other.CustomValue)) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is CustomNode other && Equals(other);

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
            if (!_isFrozen) return CalcHashCode();
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }
    }

    public partial class Int32Node
    {
        public static Int32Node? CreateFrom(IInt32Node? source)
        {
            if (source is null) return null;
            if (source is Int32Node thisEntity && thisEntity._isFrozen) return thisEntity;
            return new Int32Node(source);
        }

        private static Int32Node CreateEmpty()
        {
            var empty = new Int32Node();
            empty.Freeze();
            return empty;
        }
        private static readonly Int32Node _empty = CreateEmpty();
        public static new Int32Node Empty => _empty;

    }
    public partial class Int32Node : NumericNode, IInt32Node, IEquatable<Int32Node>
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

        private Int32 field_IntValue;
        Int32 IInt32Node.IntValue => field_IntValue;
        public Int32 IntValue
        {
            get => field_IntValue;
            set => field_IntValue = CheckNotFrozen(ref value);
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
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            field_IntValue = source.IntValue;
        }

        public virtual bool Equals(Int32Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!IntValue.ValueEquals(other.IntValue)) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is Int32Node other && Equals(other);

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
            if (!_isFrozen) return CalcHashCode();
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }
    }

    public partial class Int64Node
    {
        public static Int64Node? CreateFrom(IInt64Node? source)
        {
            if (source is null) return null;
            if (source is Int64Node thisEntity && thisEntity._isFrozen) return thisEntity;
            return new Int64Node(source);
        }

        private static Int64Node CreateEmpty()
        {
            var empty = new Int64Node();
            empty.Freeze();
            return empty;
        }
        private static readonly Int64Node _empty = CreateEmpty();
        public static new Int64Node Empty => _empty;

    }
    public partial class Int64Node : NumericNode, IInt64Node, IEquatable<Int64Node>
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

        public new const int EntityTag = 7;
        protected override int OnGetEntityTag() => EntityTag;

        private Int64 field_LongValue;
        Int64 IInt64Node.LongValue => field_LongValue;
        public Int64 LongValue
        {
            get => field_LongValue;
            set => field_LongValue = CheckNotFrozen(ref value);
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
            if (_isFrozen) ThrowIsReadonly();
            base.CopyFrom(source);
            field_LongValue = source.LongValue;
        }

        public virtual bool Equals(Int64Node? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!LongValue.ValueEquals(other.LongValue)) return false;
            return base.Equals(other);
        }

        public override bool Equals(object? obj) => obj is Int64Node other && Equals(other);

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
            if (!_isFrozen) return CalcHashCode();
            if (_hashCode is null)
                _hashCode = CalcHashCode();
            return _hashCode.Value;
        }
    }

}
