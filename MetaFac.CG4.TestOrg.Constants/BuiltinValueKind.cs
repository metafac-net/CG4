using Newtonsoft.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml;

namespace MetaFac.CG4.TestOrg.Common
{
    public enum BuiltinValueKind
    {
        Boolean,
        SByte,
        Byte,
        Int16,
        UInt16,
        Char,
        Int32,
        UInt32,
        Single,
        Int64,
        UInt64,
        Double,
        DateTime,
        TimeSpan,
        Decimal,
        Guid,
        DateTimeOffset,
        String,
        Octets,
        Half,
        DateOnly,
        TimeOnly,
        Custom,
        BigInteger,
        Complex,
        Version
    }
}
