using MetaFac.CG4.Attributes;
using MetaFac.Memory;
using System;

namespace MetaFac.CG4.Generators.UnitTests.FlattenedModels
{
    [Proxy("LabApps.Units.Quantity", "QuantityValue")]
    public struct Quantity { }

    [Proxy("System.DateTimeKind", "MyDateTimeKindValue")]
    public struct MyDateTimeKind { }

    public enum MyCustomEnum
    {
        DefaultValue,
        AValue,
        AnotherValue,
    }

    [Entity(1)]
    public class BuiltinTypes
    {
        [Member(1)] bool[]? Bools { get; }
        [Member(2)] sbyte[]? SBytes { get; }
        [Member(3)] byte[]? Bytes { get; }
        [Member(4)] short[]? Shorts { get; }
        [Member(5)] ushort[]? UShorts { get; }
        [Member(6)] char[]? Chars { get; }
        [Member(7)] int[]? Ints { get; }
        [Member(8)] uint[]? UInts { get; }
        [Member(9)] float[]? Floats { get; }
        [Member(10)] long[]? Longs { get; }
        [Member(11)] ulong[]? ULongs { get; }
        [Member(12)] double[]? Doubles { get; }
        [Member(13)] DateTime[]? DateTimes { get; }
        [Member(14)] TimeSpan[]? TimeSpans { get; }
        [Member(15)] decimal[]? Decimals { get; }
        [Member(16)] DateTimeOffset[]? DateTimeOffsets { get; }
        [Member(17)] Guid[]? Guids { get; }
        [Member(18)] string[]? Strings { get; }
        [Member(19)] Octets[]? Buffers { get; }
        [Member(20)] Quantity[]? Quantities { get; }
        [Member(21)] DayOfWeek[]? DaysOfWeek { get; }
        [Member(22)] MyDateTimeKind[]? MyDateTimeKinds { get; }
        [Member(23)] MyCustomEnum[]? MyCustomEnums { get; }
    }
}
