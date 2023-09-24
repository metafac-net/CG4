#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: Contracts.2.2
// Metadata : MetaFac.CG4.TestOrg.Schema(.BasicTypes)
// </information>
#endregion
#nullable enable
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8019 // Unnecessary using directive
using MetaFac.CG4.Runtime;
using MetaFac.Memory;
using MetaFac.Mutability;
using System;
using System.Collections.Generic;

namespace MetaFac.CG4.TestOrg.Models.BasicTypes.Contracts
{
    public enum MyCustomEnum
    {
        DefaultValue = 0,
        FirstValue = 1,
        SomeValue = 2,
        LastValue = 99,
    }
    public partial interface IBasic_bool : IEntityBase
    {
        Boolean ScalarRequired { get; }
        Boolean? ScalarOptional { get; }
        IReadOnlyList<Boolean>? VectorRequired { get; }
        IReadOnlyList<Boolean?>? VectorOptional { get; }
        IReadOnlyDictionary<String, Boolean>? MapRequired { get; }
        IReadOnlyDictionary<String, Boolean?>? MapOptional { get; }
        IReadOnlyDictionary<Boolean, String?>? MapKey { get; }
    }
    public partial interface IBasic_sbyte : IEntityBase
    {
        SByte ScalarRequired { get; }
        SByte? ScalarOptional { get; }
        IReadOnlyList<SByte>? VectorRequired { get; }
        IReadOnlyList<SByte?>? VectorOptional { get; }
        IReadOnlyDictionary<String, SByte>? MapRequired { get; }
        IReadOnlyDictionary<String, SByte?>? MapOptional { get; }
        IReadOnlyDictionary<SByte, String?>? MapKey { get; }
    }
    public partial interface IBasic_byte : IEntityBase
    {
        Byte ScalarRequired { get; }
        Byte? ScalarOptional { get; }
        IReadOnlyList<Byte>? VectorRequired { get; }
        IReadOnlyList<Byte?>? VectorOptional { get; }
        IReadOnlyDictionary<String, Byte>? MapRequired { get; }
        IReadOnlyDictionary<String, Byte?>? MapOptional { get; }
        IReadOnlyDictionary<Byte, String?>? MapKey { get; }
    }
    public partial interface IBasic_short : IEntityBase
    {
        Int16 ScalarRequired { get; }
        Int16? ScalarOptional { get; }
        IReadOnlyList<Int16>? VectorRequired { get; }
        IReadOnlyList<Int16?>? VectorOptional { get; }
        IReadOnlyDictionary<String, Int16>? MapRequired { get; }
        IReadOnlyDictionary<String, Int16?>? MapOptional { get; }
        IReadOnlyDictionary<Int16, String?>? MapKey { get; }
    }
    public partial interface IBasic_ushort : IEntityBase
    {
        UInt16 ScalarRequired { get; }
        UInt16? ScalarOptional { get; }
        IReadOnlyList<UInt16>? VectorRequired { get; }
        IReadOnlyList<UInt16?>? VectorOptional { get; }
        IReadOnlyDictionary<String, UInt16>? MapRequired { get; }
        IReadOnlyDictionary<String, UInt16?>? MapOptional { get; }
        IReadOnlyDictionary<UInt16, String?>? MapKey { get; }
    }
    public partial interface IBasic_char : IEntityBase
    {
        Char ScalarRequired { get; }
        Char? ScalarOptional { get; }
        IReadOnlyList<Char>? VectorRequired { get; }
        IReadOnlyList<Char?>? VectorOptional { get; }
        IReadOnlyDictionary<String, Char>? MapRequired { get; }
        IReadOnlyDictionary<String, Char?>? MapOptional { get; }
        IReadOnlyDictionary<Char, String?>? MapKey { get; }
    }
    public partial interface IBasic_int : IEntityBase
    {
        Int32 ScalarRequired { get; }
        Int32? ScalarOptional { get; }
        IReadOnlyList<Int32>? VectorRequired { get; }
        IReadOnlyList<Int32?>? VectorOptional { get; }
        IReadOnlyDictionary<String, Int32>? MapRequired { get; }
        IReadOnlyDictionary<String, Int32?>? MapOptional { get; }
        IReadOnlyDictionary<Int32, String?>? MapKey { get; }
    }
    public partial interface IBasic_uint : IEntityBase
    {
        UInt32 ScalarRequired { get; }
        UInt32? ScalarOptional { get; }
        IReadOnlyList<UInt32>? VectorRequired { get; }
        IReadOnlyList<UInt32?>? VectorOptional { get; }
        IReadOnlyDictionary<String, UInt32>? MapRequired { get; }
        IReadOnlyDictionary<String, UInt32?>? MapOptional { get; }
        IReadOnlyDictionary<UInt32, String?>? MapKey { get; }
    }
    public partial interface IBasic_float : IEntityBase
    {
        Single ScalarRequired { get; }
        Single? ScalarOptional { get; }
        IReadOnlyList<Single>? VectorRequired { get; }
        IReadOnlyList<Single?>? VectorOptional { get; }
        IReadOnlyDictionary<String, Single>? MapRequired { get; }
        IReadOnlyDictionary<String, Single?>? MapOptional { get; }
        IReadOnlyDictionary<Single, String?>? MapKey { get; }
    }
    public partial interface IBasic_long : IEntityBase
    {
        Int64 ScalarRequired { get; }
        Int64? ScalarOptional { get; }
        IReadOnlyList<Int64>? VectorRequired { get; }
        IReadOnlyList<Int64?>? VectorOptional { get; }
        IReadOnlyDictionary<String, Int64>? MapRequired { get; }
        IReadOnlyDictionary<String, Int64?>? MapOptional { get; }
        IReadOnlyDictionary<Int64, String?>? MapKey { get; }
    }
    public partial interface IBasic_ulong : IEntityBase
    {
        UInt64 ScalarRequired { get; }
        UInt64? ScalarOptional { get; }
        IReadOnlyList<UInt64>? VectorRequired { get; }
        IReadOnlyList<UInt64?>? VectorOptional { get; }
        IReadOnlyDictionary<String, UInt64>? MapRequired { get; }
        IReadOnlyDictionary<String, UInt64?>? MapOptional { get; }
        IReadOnlyDictionary<UInt64, String?>? MapKey { get; }
    }
    public partial interface IBasic_double : IEntityBase
    {
        Double ScalarRequired { get; }
        Double? ScalarOptional { get; }
        IReadOnlyList<Double>? VectorRequired { get; }
        IReadOnlyList<Double?>? VectorOptional { get; }
        IReadOnlyDictionary<String, Double>? MapRequired { get; }
        IReadOnlyDictionary<String, Double?>? MapOptional { get; }
        IReadOnlyDictionary<Double, String?>? MapKey { get; }
    }
    public partial interface IBasic_DateTime : IEntityBase
    {
        DateTime ScalarRequired { get; }
        DateTime? ScalarOptional { get; }
        IReadOnlyList<DateTime>? VectorRequired { get; }
        IReadOnlyList<DateTime?>? VectorOptional { get; }
        IReadOnlyDictionary<String, DateTime>? MapRequired { get; }
        IReadOnlyDictionary<String, DateTime?>? MapOptional { get; }
        IReadOnlyDictionary<DateTime, String?>? MapKey { get; }
    }
    public partial interface IBasic_TimeSpan : IEntityBase
    {
        TimeSpan ScalarRequired { get; }
        TimeSpan? ScalarOptional { get; }
        IReadOnlyList<TimeSpan>? VectorRequired { get; }
        IReadOnlyList<TimeSpan?>? VectorOptional { get; }
        IReadOnlyDictionary<String, TimeSpan>? MapRequired { get; }
        IReadOnlyDictionary<String, TimeSpan?>? MapOptional { get; }
        IReadOnlyDictionary<TimeSpan, String?>? MapKey { get; }
    }
    public partial interface IBasic_decimal : IEntityBase
    {
        Decimal ScalarRequired { get; }
        Decimal? ScalarOptional { get; }
        IReadOnlyList<Decimal>? VectorRequired { get; }
        IReadOnlyList<Decimal?>? VectorOptional { get; }
        IReadOnlyDictionary<String, Decimal>? MapRequired { get; }
        IReadOnlyDictionary<String, Decimal?>? MapOptional { get; }
        IReadOnlyDictionary<Decimal, String?>? MapKey { get; }
    }
    public partial interface IBasic_DateTimeOffset : IEntityBase
    {
        DateTimeOffset ScalarRequired { get; }
        DateTimeOffset? ScalarOptional { get; }
        IReadOnlyList<DateTimeOffset>? VectorRequired { get; }
        IReadOnlyList<DateTimeOffset?>? VectorOptional { get; }
        IReadOnlyDictionary<String, DateTimeOffset>? MapRequired { get; }
        IReadOnlyDictionary<String, DateTimeOffset?>? MapOptional { get; }
        IReadOnlyDictionary<DateTimeOffset, String?>? MapKey { get; }
    }
    public partial interface IBasic_Guid : IEntityBase
    {
        Guid ScalarRequired { get; }
        Guid? ScalarOptional { get; }
        IReadOnlyList<Guid>? VectorRequired { get; }
        IReadOnlyList<Guid?>? VectorOptional { get; }
        IReadOnlyDictionary<String, Guid>? MapRequired { get; }
        IReadOnlyDictionary<String, Guid?>? MapOptional { get; }
        IReadOnlyDictionary<Guid, String?>? MapKey { get; }
    }
    public partial interface IBasic_DayOfWeek : IEntityBase
    {
        System.DayOfWeek ScalarRequired { get; }
        System.DayOfWeek? ScalarOptional { get; }
        IReadOnlyList<System.DayOfWeek>? VectorRequired { get; }
        IReadOnlyList<System.DayOfWeek?>? VectorOptional { get; }
        IReadOnlyDictionary<String, System.DayOfWeek>? MapRequired { get; }
        IReadOnlyDictionary<String, System.DayOfWeek?>? MapOptional { get; }
        IReadOnlyDictionary<System.DayOfWeek, String?>? MapKey { get; }
    }
    public partial interface IBasic_MyCustomEnum : IEntityBase
    {
        MyCustomEnum ScalarRequired { get; }
        MyCustomEnum? ScalarOptional { get; }
        IReadOnlyList<MyCustomEnum>? VectorRequired { get; }
        IReadOnlyList<MyCustomEnum?>? VectorOptional { get; }
        IReadOnlyDictionary<String, MyCustomEnum>? MapRequired { get; }
        IReadOnlyDictionary<String, MyCustomEnum?>? MapOptional { get; }
        IReadOnlyDictionary<MyCustomEnum, String?>? MapKey { get; }
    }
    public partial interface IBasic_Quantity : IEntityBase
    {
        LabApps.Units.Quantity ScalarRequired { get; }
        LabApps.Units.Quantity? ScalarOptional { get; }
        IReadOnlyList<LabApps.Units.Quantity>? VectorRequired { get; }
        IReadOnlyList<LabApps.Units.Quantity?>? VectorOptional { get; }
        IReadOnlyDictionary<String, LabApps.Units.Quantity>? MapRequired { get; }
        IReadOnlyDictionary<String, LabApps.Units.Quantity?>? MapOptional { get; }
    }
    public partial interface IBasic_string : IEntityBase
    {
        String? Scalar { get; }
        IReadOnlyList<String?>? Vector { get; }
        IReadOnlyDictionary<String, String?>? MapValue { get; }
    }
}
