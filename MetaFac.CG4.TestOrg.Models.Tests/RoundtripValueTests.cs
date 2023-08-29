using FluentAssertions;
using MessagePack;
using MetaFac.CG4.TestOrg.Models.BasicTypes.Contracts;
using System;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{
    public class RoundtripValueTests
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [InlineData(null)]
        public void RoundtripValues_bool(bool? value)
        {
            var original = new BasicTypes.RecordsV2.Basic_bool() { ScalarOptional = value };
            {
                var outgoing = BasicTypes.MessagePack.Basic_bool.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_bool>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_bool.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_bool.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_bool>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_bool.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
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
            var original = new BasicTypes.RecordsV2.Basic_sbyte() { ScalarOptional = value };
            {
                var outgoing = BasicTypes.MessagePack.Basic_sbyte.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_sbyte>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_sbyte.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_sbyte.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_sbyte>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_sbyte.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(byte.MinValue)]
        [InlineData((byte)1)]
        [InlineData((byte)254)]
        [InlineData(byte.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_byte(byte? value)
        {
            var original = new BasicTypes.RecordsV2.Basic_byte() { ScalarOptional = value };
            {
                var outgoing = BasicTypes.MessagePack.Basic_byte.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_byte>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_byte.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_byte.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_byte>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_byte.CreateFrom(incoming) ?? throw new Exception("Returned null!");
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
            var original = new BasicTypes.RecordsV2.Basic_short() { ScalarOptional = value };
            {
                var outgoing = BasicTypes.MessagePack.Basic_short.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_short>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_short.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_short.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_short>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_short.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(ushort.MinValue)]
        [InlineData((ushort)1)]
        [InlineData((ushort)254)]
        [InlineData(ushort.MaxValue)]
        [InlineData(null)]
        public void RoundtripValues_ushort(ushort? value)
        {
            var original = new BasicTypes.RecordsV2.Basic_ushort() { ScalarOptional = value };
            {
                var outgoing = BasicTypes.MessagePack.Basic_ushort.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_ushort>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_ushort.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_ushort.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_ushort>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_ushort.CreateFrom(incoming) ?? throw new Exception("Returned null!");
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
            var original = new BasicTypes.RecordsV2.Basic_char() { ScalarOptional = value };
            {
                var outgoing = BasicTypes.MessagePack.Basic_char.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize(outgoing);
                var incoming = MessagePackSerializer.Deserialize<BasicTypes.MessagePack.Basic_char>(buffer);
                incoming.Should().Be(outgoing);
                var duplicate1 = BasicTypes.RecordsV2.Basic_char.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate1.Should().Be(original);
                duplicate1.Equals(original).Should().BeTrue();
            }
            {
                var outgoing = BasicTypes.JsonNewtonSoft.Basic_char.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJson();
                var incoming = buffer.DeserializeFromJson<BasicTypes.JsonNewtonSoft.Basic_char>();
                incoming.Should().Be(outgoing);
                var duplicate2 = BasicTypes.RecordsV2.Basic_char.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate2.Should().Be(original);
                duplicate2.Equals(original).Should().BeTrue();
            }
        }

    }
}