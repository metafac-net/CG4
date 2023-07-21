using MetaFac.CG4.Attributes;
using MetaFac.Memory;
using System;
using System.Collections.Generic;
using System.Text;

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
        [Member(2)] public string?[]? Vector{ get; }
        [Member(3)] public Dictionary<string, string?>? MapValue { get; }
    }

    [Entity(31)]
    public class Basic_Octets
    {
        [Member(1)] public Octets? Scalar { get; }
        [Member(2)] public Octets?[]? Vector { get; }
        [Member(3)] public Dictionary<string, Octets?>? MapValue { get; }
        [Member(4)] public Dictionary<Octets, string>? MapKey { get; }
    }

}
