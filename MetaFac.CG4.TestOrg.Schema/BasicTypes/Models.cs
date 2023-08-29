using MetaFac.CG4.Attributes;
using System;
using System.Collections.Generic;

namespace MetaFac.CG4.TestOrg.Schema.BasicTypes
{
    [Entity(1)]
    public class Basic_bool
    {
        [Member(1)] public bool ScalarRequired { get; }
        [Member(2)] public bool? ScalarOptional { get; }
        [Member(3)] public bool[]? VectorRequired { get; }
        [Member(4)] public bool?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, bool>? MapRequired { get; }
        [Member(6)] public Dictionary<string, bool?>? MapOptional { get; }
        [Member(7)] public Dictionary<bool, string?>? MapKey { get; }
    }

    [Entity(2)]
    public class Basic_sbyte
    {
        [Member(1)] public sbyte ScalarRequired { get; }
        [Member(2)] public sbyte? ScalarOptional { get; }
        [Member(3)] public sbyte[]? VectorRequired { get; }
        [Member(4)] public sbyte?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, sbyte>? MapRequired { get; }
        [Member(6)] public Dictionary<string, sbyte?>? MapOptional { get; }
        [Member(7)] public Dictionary<sbyte, string?>? MapKey { get; }
    }

    [Entity(3)]
    public class Basic_byte
    {
        [Member(1)] public byte ScalarRequired { get; }
        [Member(2)] public byte? ScalarOptional { get; }
        [Member(3)] public byte[]? VectorRequired { get; }
        [Member(4)] public byte?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, byte>? MapRequired { get; }
        [Member(6)] public Dictionary<string, byte?>? MapOptional { get; }
        [Member(7)] public Dictionary<byte, string?>? MapKey { get; }
    }

    [Entity(4)]
    public class Basic_short
    {
        [Member(1)] public short ScalarRequired { get; }
        [Member(2)] public short? ScalarOptional { get; }
        [Member(3)] public short[]? VectorRequired { get; }
        [Member(4)] public short?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, short>? MapRequired { get; }
        [Member(6)] public Dictionary<string, short?>? MapOptional { get; }
        [Member(7)] public Dictionary<short, string?>? MapKey { get; }
    }

    [Entity(5)]
    public class Basic_ushort
    {
        [Member(1)] public ushort ScalarRequired { get; }
        [Member(2)] public ushort? ScalarOptional { get; }
        [Member(3)] public ushort[]? VectorRequired { get; }
        [Member(4)] public ushort?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, ushort>? MapRequired { get; }
        [Member(6)] public Dictionary<string, ushort?>? MapOptional { get; }
        [Member(7)] public Dictionary<ushort, string?>? MapKey { get; }
    }

    [Entity(6)]
    public class Basic_char
    {
        [Member(1)] public char ScalarRequired { get; }
        [Member(2)] public char? ScalarOptional { get; }
        [Member(3)] public char[]? VectorRequired { get; }
        [Member(4)] public char?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, char>? MapRequired { get; }
        [Member(6)] public Dictionary<string, char?>? MapOptional { get; }
        [Member(7)] public Dictionary<char, string?>? MapKey { get; }
    }

    [Entity(7)]
    public class Basic_int
    {
        [Member(1)] public int ScalarRequired { get; }
        [Member(2)] public int? ScalarOptional { get; }
        [Member(3)] public int[]? VectorRequired { get; }
        [Member(4)] public int?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, int>? MapRequired { get; }
        [Member(6)] public Dictionary<string, int?>? MapOptional { get; }
        [Member(7)] public Dictionary<int, string?>? MapKey { get; }
    }

    [Entity(8)]
    public class Basic_uint
    {
        [Member(1)] public uint ScalarRequired { get; }
        [Member(2)] public uint? ScalarOptional { get; }
        [Member(3)] public uint[]? VectorRequired { get; }
        [Member(4)] public uint?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, uint>? MapRequired { get; }
        [Member(6)] public Dictionary<string, uint?>? MapOptional { get; }
        [Member(7)] public Dictionary<uint, string?>? MapKey { get; }
    }

    [Entity(9)]
    public class Basic_float
    {
        [Member(1)] public float ScalarRequired { get; }
        [Member(2)] public float? ScalarOptional { get; }
        [Member(3)] public float[]? VectorRequired { get; }
        [Member(4)] public float?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, float>? MapRequired { get; }
        [Member(6)] public Dictionary<string, float?>? MapOptional { get; }
        [Member(7)] public Dictionary<float, string?>? MapKey { get; }
    }

    [Entity(17)]
    public class Basic_decimal
    {
        [Member(1)] public decimal ScalarRequired { get; }
        [Member(2)] public decimal? ScalarOptional { get; }
        [Member(3)] public decimal[]? VectorRequired { get; }
        [Member(4)] public decimal?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, decimal>? MapRequired { get; }
        [Member(6)] public Dictionary<string, decimal?>? MapOptional { get; }
        [Member(7)] public Dictionary<decimal, string?>? MapKey { get; }
    }

    [Entity(18)]
    public class Basic_DateTimeOffset
    {
        [Member(1)] public DateTimeOffset ScalarRequired { get; }
        [Member(2)] public DateTimeOffset? ScalarOptional { get; }
        [Member(3)] public DateTimeOffset[]? VectorRequired { get; }
        [Member(4)] public DateTimeOffset?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, DateTimeOffset>? MapRequired { get; }
        [Member(6)] public Dictionary<string, DateTimeOffset?>? MapOptional { get; }
        [Member(7)] public Dictionary<DateTimeOffset, string?>? MapKey { get; }
    }

    [Entity(19)]
    public class Basic_Guid
    {
        [Member(1)] public Guid ScalarRequired { get; }
        [Member(2)] public Guid? ScalarOptional { get; }
        [Member(3)] public Guid[]? VectorRequired { get; }
        [Member(4)] public Guid?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, Guid>? MapRequired { get; }
        [Member(6)] public Dictionary<string, Guid?>? MapOptional { get; }
        [Member(7)] public Dictionary<Guid, string?>? MapKey { get; }
    }

    [Entity(20)]
    public class Basic_DayOfWeek
    {
        [Member(1)] public DayOfWeek ScalarRequired { get; }
        [Member(2)] public DayOfWeek? ScalarOptional { get; }
        [Member(3)] public DayOfWeek[]? VectorRequired { get; }
        [Member(4)] public DayOfWeek?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, DayOfWeek>? MapRequired { get; }
        [Member(6)] public Dictionary<string, DayOfWeek?>? MapOptional { get; }
        [Member(7)] public Dictionary<DayOfWeek, string?>? MapKey { get; }
    }

    public enum MyCustomEnum
    {
        DefaultValue,
        FirstValue,
        SomeValue,
        LastValue = 99,
    }

    [Entity(21)]
    public class Basic_MyCustomEnum
    {
        [Member(1)] public MyCustomEnum ScalarRequired { get; }
        [Member(2)] public MyCustomEnum? ScalarOptional { get; }
        [Member(3)] public MyCustomEnum[]? VectorRequired { get; }
        [Member(4)] public MyCustomEnum?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, MyCustomEnum>? MapRequired { get; }
        [Member(6)] public Dictionary<string, MyCustomEnum?>? MapOptional { get; }
        [Member(7)] public Dictionary<MyCustomEnum, string?>? MapKey { get; }
    }

    [Proxy("LabApps.Units.Quantity", "QuantityValue")]
    public struct Quantity { }

    [Entity(22)]
    public class Basic_Quantity
    {
        [Member(1)] public Quantity ScalarRequired { get; }
        [Member(2)] public Quantity? ScalarOptional { get; }
        [Member(3)] public Quantity[]? VectorRequired { get; }
        [Member(4)] public Quantity?[]? VectorOptional { get; }
        [Member(5)] public Dictionary<string, Quantity>? MapRequired { get; }
        [Member(6)] public Dictionary<string, Quantity?>? MapOptional { get; }
        // todo [Member(7)] public Dictionary<Quantity, string?>? MapKey { get; }
    }

    [Entity(30)]
    public class Basic_string
    {
        [Member(1)] public string? Scalar { get; }
        [Member(2)] public string?[]? Vector { get; }
        [Member(3)] public Dictionary<string, string?>? MapValue { get; }
    }

    // todo
    //[Entity(31)]
    //public class Basic_Octets
    //{
    //    [Member(1)] public Octets? Scalar { get; }
    //    [Member(2)] public Octets?[]? Vector { get; }
    //    [Member(3)] public Dictionary<string, Octets?>? MapValue { get; }
    //    [Member(4)] public Dictionary<Octets, string>? MapKey { get; }
    //}

}
