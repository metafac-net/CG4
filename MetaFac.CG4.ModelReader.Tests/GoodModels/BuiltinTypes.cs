using System;
using MetaFac.CG4.Attributes;
using MetaFac.Memory;

namespace MetaFac.CG4.ModelReader.Tests.GoodModels
{
    [Entity(1)]
    [Token("Token1", "Value1")]
    public class BuiltinTypes
    {
        [Member(1)] public bool[]? Bools { get; }
        [Member(2)] public sbyte[]? SBytes { get; }
        [Member(3)] public byte[]? Bytes { get; }
        [Member(4)] public short[]? Shorts { get; }
        [Member(5)] public ushort[]? UShorts { get; }
        [Member(6)] public char[]? Chars { get; }
        [Member(7)] public int[]? Ints { get; }
        [Member(8)] public uint[]? UInts { get; }
        [Member(9)] public float[]? Floats { get; }
        [Member(10)] public long[]? Longs { get; }
        [Member(11)] public ulong[]? ULongs { get; }
        [Member(12)] public double[]? Doubles { get; }
        [Member(13)] public DateTime[]? DateTimes { get; }
        [Member(14)] public TimeSpan[]? TimeSpans { get; }
        [Member(15)] public decimal[]? Decimals { get; }
        [Member(16)] public DateTimeOffset[]? DateTimeOffsets { get; }
        [Member(17)] public Guid[]? Guids { get; }
        [Member(18)] public string[]? Strings { get; }
        [Member(19)] public Octets[]? Buffers { get; }
    }

    [Proxy("LabApps.Units.Quantity", "QuantityValue")]
    public struct Quantity { }

    [Entity(2)]
    [Token("Token2", "Value2")]
    public class ExternalTypes
    {
        [Member(1)] public Quantity[]? Quantities { get; }
    }

    public enum MyCustomEnum
    {
        DefaultValue,
        FirstValue,
        SomeValue,
        LastValue = 99,
    }

    //[Proxy(nameof(MyEnumKind), "MyEnumValue")]
    //public struct MyEnum { }

    [Proxy("System.DateTimeKind", "MyDateTimeKindValue")]
    public struct MyDateTimeKind { }

    [Entity(3)]
    public class EnumeratorTypes
    {
        [Member(1)] public DayOfWeek[]? DaysOfWeek { get; }
        [Member(2)] public MyCustomEnum[]? MyCustomEnums { get; }
        [Member(3)] public MyDateTimeKind[]? MyDateTimeKinds { get; }
    }
}