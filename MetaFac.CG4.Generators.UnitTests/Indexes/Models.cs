using MetaFac.CG4.Attributes;
using System.Collections.Generic;

namespace MetaFac.CG4.Generators.UnitTests.Indexes
{
    public enum MyCustomEnum
    {
        DefaultValue,
        AValue,
        AnotherValue,
    }

    [Entity(1)]
    public class IndexTypes
    {
        [Member(1)] public Dictionary<string, long>? Index1 { get; }
        [Member(2)] public Dictionary<byte, long>? Index2 { get; }
        [Member(3)] public Dictionary<MyCustomEnum, long>? Index3 { get; }

        //todo [Member(4)] public Dictionary<Octets, long>? Index4 { get; }
    }
}