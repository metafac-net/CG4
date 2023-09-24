using FluentAssertions;
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
            TOriginal duplicate = originalFactory.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
            return duplicate;
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
            TOriginal duplicate = originalFactory.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
            return duplicate;
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [InlineData(null)]
        public void RoundtripValues_bool(bool? value)
        {
            var origFactory = new BasicTypes.RecordsV2.Basic_bool_Factory();
            var jsonFactory = new BasicTypes.JsonNewtonSoft.Basic_bool_Factory();
            var msgpFactory = new BasicTypes.MessagePack.Basic_bool_Factory();
            var original = new BasicTypes.RecordsV2.Basic_bool()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var duplicate1 = RoundtripViaMessagePack<IBasic_bool, BasicTypes.RecordsV2.Basic_bool, BasicTypes.MessagePack.Basic_bool>(
                    original, origFactory, msgpFactory);
            }
            {
                var duplicate2 = RoundtripViaJsonNewtonSoft<IBasic_bool, BasicTypes.RecordsV2.Basic_bool, BasicTypes.JsonNewtonSoft.Basic_bool>(
                    original, origFactory, jsonFactory);
            }
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
            var origFactory = new BasicTypes.RecordsV2.Basic_sbyte_Factory();
            var jsonFactory = new BasicTypes.JsonNewtonSoft.Basic_sbyte_Factory();
            var msgpFactory = new BasicTypes.MessagePack.Basic_sbyte_Factory();
            var original = new BasicTypes.RecordsV2.Basic_sbyte()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var duplicate1 = RoundtripViaMessagePack<IBasic_sbyte, BasicTypes.RecordsV2.Basic_sbyte, BasicTypes.MessagePack.Basic_sbyte>(
                    original, origFactory, msgpFactory);
            }
            {
                var duplicate2 = RoundtripViaJsonNewtonSoft<IBasic_sbyte, BasicTypes.RecordsV2.Basic_sbyte, BasicTypes.JsonNewtonSoft.Basic_sbyte>(
                    original, origFactory, jsonFactory);
            }
        }

        [Theory]
        [InlineData(byte.MinValue)]
        [InlineData((byte)1)]
        [InlineData((byte)(byte.MaxValue-1))]
        [InlineData(byte.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_byte(byte? value)
        {
            var original = new BasicTypes.RecordsV2.Basic_byte()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var outgoing = BasicTypes.MessagePack.Basic_byte.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_byte>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_byte_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_byte.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_byte>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_byte_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
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
            var original = new BasicTypes.RecordsV2.Basic_short()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var outgoing = BasicTypes.MessagePack.Basic_short.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_short>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_short_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_short.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_short>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_short_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(ushort.MinValue)]
        [InlineData((ushort)1)]
        [InlineData((ushort)(ushort.MaxValue - 1))]
        [InlineData(ushort.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_ushort(ushort? value)
        {
            var original = new BasicTypes.RecordsV2.Basic_ushort()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var outgoing = BasicTypes.MessagePack.Basic_ushort.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_ushort>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_ushort_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_ushort.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_ushort>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_ushort_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(char.MinValue)]
        [InlineData(' ')]
        [InlineData('~')]
        [InlineData(char.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_char(char? value)
        {
            var original = new BasicTypes.RecordsV2.Basic_char()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var outgoing = BasicTypes.MessagePack.Basic_char.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_char>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_char_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_char.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_char>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_char_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
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
            var original = new BasicTypes.RecordsV2.Basic_int()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var outgoing = BasicTypes.MessagePack.Basic_int.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_int>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_int_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_int.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_int>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_int_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(uint.MinValue)]
        [InlineData((uint)1)]
        [InlineData((uint)(uint.MaxValue - 1))]
        [InlineData(uint.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_uint(uint? value)
        {
            var original = new BasicTypes.RecordsV2.Basic_uint()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var outgoing = BasicTypes.MessagePack.Basic_uint.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_uint>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_uint_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_uint.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_uint>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_uint_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
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
            var original = new BasicTypes.RecordsV2.Basic_float()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var outgoing = BasicTypes.MessagePack.Basic_float.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_float>(buffer);
                incoming.Equals(outgoing).Should().BeTrue();
                var duplicate1 = BasicTypes.RecordsV2.Basic_float_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_float.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_float>();
                incoming.Equals(outgoing).Should().BeTrue();
                var duplicate2 = BasicTypes.RecordsV2.Basic_float_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Equals(original).Should().BeTrue();
            }
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
            var original = new BasicTypes.RecordsV2.Basic_long()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var outgoing = BasicTypes.MessagePack.Basic_long.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_long>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_long_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_long.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_long>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_long_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(ulong.MinValue)]
        [InlineData((ulong)1)]
        [InlineData((ulong)(ulong.MaxValue - 1))]
        [InlineData(ulong.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_ulong(ulong? value)
        {
            var original = new BasicTypes.RecordsV2.Basic_ulong()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var outgoing = BasicTypes.MessagePack.Basic_ulong.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_ulong>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_ulong_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_ulong.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_ulong>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_ulong_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
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
            var original = new BasicTypes.RecordsV2.Basic_double()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var outgoing = BasicTypes.MessagePack.Basic_double.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_double>(buffer);
                incoming.Equals(outgoing).Should().BeTrue();
                var duplicate1 = BasicTypes.RecordsV2.Basic_double_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_double.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_double>();
                incoming.Equals(outgoing).Should().BeTrue();
                var duplicate2 = BasicTypes.RecordsV2.Basic_double_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Equals(original).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(DayOfWeek.Sunday)]
        [InlineData(DayOfWeek.Monday)]
        [InlineData(DayOfWeek.Friday)]
        [InlineData(DayOfWeek.Saturday)]
        [InlineData(null)]
        public void RoundtripValues_DayOfWeek(DayOfWeek? value)
        {
            var original = new BasicTypes.RecordsV2.Basic_DayOfWeek()
            {
                ScalarOptional = value,
                VectorOptional = ImmutableList.Create(value)
            };
            {
                var outgoing = BasicTypes.MessagePack.Basic_DayOfWeek.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_DayOfWeek>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_DayOfWeek_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_DayOfWeek.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_DayOfWeek>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_DayOfWeek_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
        }

        // todo decimal
        // todo datetime
        // todo timespan
        // todo datetimeoffset
        // todo dayofweek

    }
}