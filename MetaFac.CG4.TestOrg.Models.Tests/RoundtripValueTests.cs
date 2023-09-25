using FluentAssertions;
using LabApps.Units;
using MessagePack;
using MetaFac.CG4.Runtime;
using MetaFac.CG4.TestOrg.Models.BasicTypes.Contracts;
using MetaFac.Mutability;
using System;
using System.Collections.Immutable;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{
    public class RoundtripValueTests
    {
        private static TOriginal RoundtripViaJsonNewtonSoft<TInterface, TOriginal, TTransport>(
            TOriginal original,
            IEntityFactory<TInterface, TOriginal> originalFactory,
            IEntityFactory<TInterface, TTransport> transportFactory)
            where TOriginal : TInterface
            where TTransport : TInterface
        {
            TTransport? outgoing = transportFactory.CreateFrom(original) ?? throw new Exception("Returned null!");
            string buffer = outgoing.SerializeToJson();
            TTransport incoming = buffer.DeserializeFromJson<TTransport>();
            incoming.Should().Be(outgoing);
            return originalFactory.CreateFrom(incoming) ?? throw new Exception("Returned null!");
        }

        private static TOriginal RoundtripViaMessagePack<TInterface, TOriginal, TTransport>(
            TOriginal original,
            IEntityFactory<TInterface, TOriginal> originalFactory,
            IEntityFactory<TInterface, TTransport> transportFactory)
            where TOriginal : TInterface
            where TTransport : TInterface
        {
            TTransport outgoing = transportFactory.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = MessagePackSerializer.Serialize(outgoing);
            TTransport incoming = MessagePackSerializer.Deserialize<TTransport>(buffer);
            incoming.Should().Be(outgoing);
            return originalFactory.CreateFrom(incoming) ?? throw new Exception("Returned null!");
        }

        private static void RoundtripViaAllTransports<TInterface, TOriginal, TTransport1, TTransport2>(
            TOriginal original,
            IEntityFactory<TInterface, TOriginal> origFactory,
            IEntityFactory<TInterface, TTransport1> msgpFactory,
            IEntityFactory<TInterface, TTransport2> jsonFactory
            )
            where TOriginal : TInterface
            where TTransport1 : TInterface
            where TTransport2 : TInterface
        {
            var duplicate1 = RoundtripViaMessagePack(original, origFactory, msgpFactory);
            duplicate1.Should().Be(original);
            duplicate1!.Equals(original).Should().BeTrue();
            var duplicate2 = RoundtripViaJsonNewtonSoft(original, origFactory, jsonFactory);
            duplicate2.Should().Be(original);
            duplicate2!.Equals(original).Should().BeTrue();
            // todo add more transports here
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [InlineData(null)]
        public void RoundtripValues_bool(bool? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_bool_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_bool_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_bool_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_bool()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(sbyte.MinValue)]
        [InlineData((sbyte)-1)]
        [InlineData((sbyte)0)]
        [InlineData((sbyte)1)]
        [InlineData(sbyte.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_sbyte(sbyte? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_sbyte_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_sbyte_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_sbyte_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_sbyte()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(byte.MinValue)]
        [InlineData((byte)1)]
        [InlineData((byte)(byte.MaxValue-1))]
        [InlineData(byte.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_byte(byte? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_byte_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_byte_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_byte_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_byte()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(short.MinValue)]
        [InlineData((short)-1)]
        [InlineData((short)0)]
        [InlineData((short)1)]
        [InlineData(short.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_short(short? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_short_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_short_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_short_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_short()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(ushort.MinValue)]
        [InlineData((ushort)1)]
        [InlineData((ushort)(ushort.MaxValue - 1))]
        [InlineData(ushort.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_ushort(ushort? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_ushort_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_ushort_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_ushort_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_ushort()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(char.MinValue)]
        [InlineData(' ')]
        [InlineData('~')]
        [InlineData(char.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_char(char? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_char_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_char_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_char_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_char()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData((int)-1)]
        [InlineData((int)0)]
        [InlineData((int)1)]
        [InlineData(int.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_int(int? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_int_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_int_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_int_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_int()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(uint.MinValue)]
        [InlineData((uint)1)]
        [InlineData((uint)(uint.MaxValue - 1))]
        [InlineData(uint.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_uint(uint? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_uint_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_uint_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_uint_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_uint()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(float.MinValue)]
        [InlineData(0F)]
        [InlineData(1F)]
        [InlineData(float.MaxValue)]
        [InlineData(float.Epsilon)]
        [InlineData(float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity)]
        [InlineData(float.NaN)]
#if NET7_0_OR_GREATER
        [InlineData(float.E)]
        [InlineData(float.Pi)]
        [InlineData(float.Tau)]
        // [InlineData(float.NegativeZero)]
#endif
        [InlineData(null)]
        public void RoundtripValues_float(float? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_float_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_float_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_float_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_float()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(long.MinValue)]
        [InlineData((long)-1)]
        [InlineData((long)0)]
        [InlineData((long)1)]
        [InlineData(long.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_long(long? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_long_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_long_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_long_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_long()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(ulong.MinValue)]
        [InlineData((ulong)1)]
        [InlineData((ulong)(ulong.MaxValue - 1))]
        [InlineData(ulong.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_ulong(ulong? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_ulong_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_ulong_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_ulong_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_ulong()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(double.MinValue)]
        [InlineData(0D)]
        [InlineData(1D)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NaN)]
#if NET7_0_OR_GREATER
        [InlineData(double.E)]
        [InlineData(double.Pi)]
        [InlineData(double.Tau)]
        // [InlineData(double.NegativeZero)]
#endif
        [InlineData(null)]
        public void RoundtripValues_double(double? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_double_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_double_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_double_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_double()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(DayOfWeek.Sunday)]
        [InlineData(DayOfWeek.Monday)]
        [InlineData(DayOfWeek.Friday)]
        [InlineData(DayOfWeek.Saturday)]
        [InlineData(null)]
        public void RoundtripValues_DayOfWeek(DayOfWeek? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_DayOfWeek_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_DayOfWeek_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_DayOfWeek_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_DayOfWeek()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("-1")]
        [InlineData("min")]
        [InlineData("max")]
        [InlineData(null)]
        public void RoundtripValues_decimal(string? input)
        {
            decimal? value = input switch
            {
                null => null,
                "min" => decimal.MinValue,
                "max" => decimal.MaxValue,
                _ => decimal.Parse(input)
            };
            var origFactory = BasicTypes.RecordsV2.Basic_decimal_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_decimal_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_decimal_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_decimal()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData("min")]
        [InlineData("max")]
        [InlineData("now")]
        [InlineData(null)]
        public void RoundtripValues_DateTime(string? input)
        {
            DateTime? value = input switch
            {
                null => null,
                "min" => DateTime.MinValue,
                "max" => DateTime.MaxValue,
                "now" => DateTime.UtcNow,
                _ => DateTime.Parse(input)
            };
            var origFactory = BasicTypes.RecordsV2.Basic_DateTime_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_DateTime_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_DateTime_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_DateTime()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData("min")]
        [InlineData("max")]
        [InlineData("00:00:00.000000")]
        [InlineData(null)]
        public void RoundtripValues_TimeSpan(string? input)
        {
            TimeSpan? value = input switch
            {
                null => null,
                "min" => TimeSpan.MinValue,
                "max" => TimeSpan.MaxValue,
                _ => TimeSpan.Parse(input)
            };
            var origFactory = BasicTypes.RecordsV2.Basic_TimeSpan_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_TimeSpan_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_TimeSpan_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_TimeSpan()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData("min")]
        [InlineData("max")]
        [InlineData("now")]
        [InlineData(null)]
        public void RoundtripValues_DateTimeOffset(string? input)
        {
            DateTimeOffset? value = input switch
            {
                null => null,
                "min" => DateTimeOffset.MinValue,
                "max" => DateTimeOffset.MaxValue,
                "now" => DateTimeOffset.UtcNow,
                _ => DateTimeOffset.Parse(input)
            };
            var origFactory = BasicTypes.RecordsV2.Basic_DateTimeOffset_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_DateTimeOffset_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_DateTimeOffset_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_DateTimeOffset()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData("empty")]
        [InlineData("any")]
        [InlineData(null)]
        public void RoundtripValues_Guid(string? input)
        {
            Guid? value = input switch
            {
                null => null,
                "empty" => Guid.Empty,
                "any" => Guid.NewGuid(),
                _ => Guid.Parse(input)
            };
            var origFactory = BasicTypes.RecordsV2.Basic_Guid_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_Guid_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_Guid_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_Guid()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData(MyCustomEnum.DefaultValue)]
        [InlineData(MyCustomEnum.FirstValue)]
        [InlineData(MyCustomEnum.SomeValue)]
        [InlineData(MyCustomEnum.LastValue)]
        [InlineData(null)]
        public void RoundtripValues_MyCustomEnum(MyCustomEnum? value)
        {
            var origFactory = BasicTypes.RecordsV2.Basic_MyCustomEnum_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_MyCustomEnum_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_MyCustomEnum_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_MyCustomEnum()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

        [Theory]
        [InlineData("empty")]
        [InlineData("zero")]
        [InlineData("one")]
        [InlineData("5 %")]
        [InlineData("40 kg")]
        [InlineData(null)]
        public void RoundtripValues_Quantity(string? input)
        {
            Quantity ParseQuantity(string input)
            {
                var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                double amount = double.Parse(parts[0]);
                Unit unit = parts.Length == 2 ? new Unit(parts[1]) : Unit.Undefined;
                return new Quantity(amount, unit);
            }
            Quantity? value = input switch
            {
                null => null,
                "empty" => Quantity.Empty,
                "zero" => Quantity.Zero,
                "one" => Quantity.One,
                _ => ParseQuantity(input)
            };
            var origFactory = BasicTypes.RecordsV2.Basic_Quantity_Factory.Instance;
            var jsonFactory = BasicTypes.JsonNewtonSoft.Basic_Quantity_Factory.Instance;
            var msgpFactory = BasicTypes.MessagePack.Basic_Quantity_Factory.Instance;
            var original = new BasicTypes.RecordsV2.Basic_Quantity()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            RoundtripViaAllTransports(original, origFactory, msgpFactory, jsonFactory);
        }

    }
}