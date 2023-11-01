using MetaFac.CG4.Attributes;
using MetaFac.Memory;
using System;
using System.Numerics;

namespace MetaFac.CG4.TestOrg.Schema.Polymorphic
{
    public enum CustomEnum
    {
        Value0,
        Value1,
    }

    [Entity(1)]
    public class ValueNode
    {
        [Member(1)] public long Id { get; set; }
        [Member(2)] public string? Name { get; set; }
    }

    [Entity(2)]
    public class NumericNode : ValueNode
    {
    }

    [Entity(4)]
    public class BooleanNode : ValueNode
    {
        [Member(3)] public bool BoolValue { get; set; }
    }

    [Entity(5)]
    public class CustomNode : ValueNode
    {
        [Member(3)] public CustomEnum CustomValue { get; set; }
    }

    [Entity(6)]
    public class Int32Node : NumericNode
    {
        [Member(3)] public int Int32Value { get; set; }
    }

    [Entity(8)]
    public class SByteNode : NumericNode
    {
        [Member(3)] public sbyte SByteValue { get; set; }
    }

    [Entity(9)]
    public class ByteNode : NumericNode
    {
        [Member(3)] public byte ByteValue { get; set; }
    }

    [Entity(10)]
    public class Int16Node : NumericNode
    {
        [Member(3)] public short Int16Value { get; set; }
    }

    [Entity(11)]
    public class UInt16Node : NumericNode
    {
        [Member(3)] public ushort UInt16Value { get; set; }
    }

    [Entity(12)]
    public class CharNode : ValueNode
    {
        [Member(3)] public Char CharValue { get; set; }
    }

#if NET6_0_OR_GREATER
    [Entity(13)]
    public class HalfNode : NumericNode
    {
        [Member(3)] public Half HalfValue { get; set; }
    }
#endif

    [Entity(14)] public class UInt32Node : NumericNode {  [Member(3)] public UInt32 UInt32Value { get; set; }}
    [Entity(15)] public class SingleNode : NumericNode { [Member(3)] public Single SingleValue { get; set; } }
    [Entity(16)] public class DateTimeNode : ValueNode { [Member(3)] public DateTime DateTimeValue { get; set; } }
    [Entity(17)] public class TimeSpanNode : ValueNode { [Member(3)] public TimeSpan TimeSpanValue { get; set; } }
#if NET6_0_OR_GREATER
    [Entity(18)] public class DateOnlyNode : ValueNode { [Member(3)] public DateOnly DateOnlyValue { get; set; } }
    [Entity(19)] public class TimeOnlyNode : ValueNode { [Member(3)] public TimeOnly TimeOnlyValue { get; set; } }
#endif
    [Entity(7)] public class Int64Node : NumericNode { [Member(3)] public Int64 Int64Value { get; set; } }
    [Entity(20)] public class UInt64Node : NumericNode { [Member(3)] public UInt64 UInt64Value { get; set; } }
    [Entity(21)] public class DoubleNode : NumericNode { [Member(3)] public Double DoubleValue { get; set; } }
    [Entity(3)] public class StringNode : ValueNode { [Member(3)] public string? StringValue { get; set; } }
    [Entity(22)] public class OctetsNode : ValueNode { [Member(3)] public Octets? OctetsValue { get; set; } }
    [Entity(23)] public class GuidNode : ValueNode { [Member(3)] public Guid GuidValue { get; set; } }
    [Entity(24)] public class DecimalNode : NumericNode { [Member(3)] public Decimal DecimalValue { get; set; } }
    [Entity(25)] public class DateTimeOffsetNode : ValueNode { [Member(3)] public DateTimeOffset DateTimeOffsetValue { get; set; } }
    [Entity(26)] public class BigIntNode : NumericNode { [Member(3)] public BigInteger Value { get; set; } }
    [Entity(27)] public class ComplexNode : NumericNode { [Member(3)] public Complex Value { get; set; } }

}
