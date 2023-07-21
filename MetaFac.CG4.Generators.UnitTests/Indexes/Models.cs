using MetaFac.CG4.Attributes;
using MetaFac.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //todo [Member(3)] public Dictionary<byte, Octets>? Index3 { get; }
        //todo [Member(4)] public Dictionary<Octets, Octets>? Index4 { get; }
    }
}