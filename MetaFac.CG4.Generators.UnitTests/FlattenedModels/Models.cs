using MetaFac.CG4.Attributes;
using MetaFac.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaFac.CG4.Generators.UnitTests.FlattenedModels
{
    [Proxy("LabApps.Units.Quantity", "QuantityValue")]
    public struct Quantity { }

    [Proxy("System.DateTimeKind", "MyDateTimeKindValue")]
    public struct MyDateTimeKind { }

    [Proxy("System.DayOfWeek", "MyDayOfWeekValue")]
    public struct MyDayOfWeek { }

    [Entity(1)]
    public interface IBuiltinTypes
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
        [Member(20)] public Quantity[]? Quantities { get; set; }
        [Member(21)] public MyDayOfWeek[]? MyDaysOfWeek { get; set; }
        [Member(22)] public MyDateTimeKind[]? MyDateTimeKinds { get; set; }
    }
}
