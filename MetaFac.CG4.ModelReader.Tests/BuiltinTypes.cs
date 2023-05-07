﻿using MetaFac.Memory;
using System;
using MetaFac.CG4.Schemas;

namespace MetaFac.CG4.ModelReader.Tests.TestModel
{
    [Entity(1)]
    public class BuiltinTypes
    {
        [Member(1)] public bool[]? Bools { get; set; }
        [Member(2)] public sbyte[]? SBytes { get; set; }
        [Member(3)] public byte[]? Bytes { get; set; }
        [Member(4)] public short[]? Shorts { get; set; }
        [Member(5)] public ushort[]? UShorts { get; set; }
        [Member(6)] public char[]? Chars { get; set; }
        [Member(7)] public int[]? Ints { get; set; }
        [Member(8)] public uint[]? UInts { get; set; }
        [Member(9)] public float[]? Floats { get; set; }
        [Member(10)] public long[]? Longs { get; set; }
        [Member(11)] public ulong[]? ULongs { get; set; }
        [Member(12)] public double[]? Doubles { get; set; }
        [Member(13)] public DateTime[]? DateTimes { get; set; }
        [Member(14)] public TimeSpan[]? TimeSpans { get; set; }
        [Member(15)] public decimal[]? Decimals { get; set; }
        [Member(16)] public DateTimeOffset[]? DateTimeOffsets { get; set; }
        [Member(17)] public Guid[]? Guids { get; set; }
        [Member(18)] public String[]? Strings { get; set; }
        [Member(19)] public Octets[]? Buffers { get; set; }
    }

    [Proxy("LabApps.Units.Quantity", "QuantityValue")]
    public struct Quantity { }

    [Entity(2)]
    public class ExternalTypes
    {
        [Member(1)] public Quantity[]? Quantities { get; set; }
    }

    public enum MyCustomEnum
    {
        DefaultValue,
        FirstValue,
        SomeValue,
        LastValue,
    }

    //[Proxy(nameof(MyEnumKind), "MyEnumValue")]
    //public struct MyEnum { }

    [Proxy("System.DateTimeKind", "MyDateTimeKindValue")]
    public struct MyDateTimeKind { }

    [Entity(3)]
    public class EnumeratorTypes
    {
        [Member(1)] public DayOfWeek[]? DaysOfWeek { get; set; }
        [Member(2)] public MyCustomEnum[]? MyCustomEnums { get; set; }
        [Member(3)] public MyDateTimeKind[]? MyDateTimeKinds { get; set; }
    }
}