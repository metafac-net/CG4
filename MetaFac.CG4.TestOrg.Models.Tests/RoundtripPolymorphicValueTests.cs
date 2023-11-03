using FluentAssertions;
using MessagePack;
using MetaFac.CG4.TestOrg.Constants;
using MetaFac.Memory;
using System;
using System.Numerics;
using System.Text;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{
    public class RoundtripPolymorphicValueTests
    {
        private static Polymorphic.Contracts.IValueNode CreateValue(BuiltinValueKind kind)
        {
            return kind switch
            {
                BuiltinValueKind.Boolean => new Polymorphic.RecordsV2.BooleanNode() { Id = 1, Name = "Id1", BoolValue = true },
                BuiltinValueKind.SByte => new Polymorphic.RecordsV2.SByteNode() { Id = 1, Name = "Id1", SByteValue = SByte.MinValue },
                BuiltinValueKind.Byte => new Polymorphic.RecordsV2.ByteNode() { Id = 1, Name = "Id1", ByteValue = Byte.MaxValue },
                BuiltinValueKind.Int16 => new Polymorphic.RecordsV2.Int16Node() { Id = 1, Name = "Id1", Int16Value = Int16.MinValue },
                BuiltinValueKind.UInt16 => new Polymorphic.RecordsV2.UInt16Node() { Id = 1, Name = "Id1", UInt16Value = UInt16.MaxValue },
                BuiltinValueKind.Char => new Polymorphic.RecordsV2.CharNode() { Id = 1, Name = "Id1", CharValue = Char.MaxValue },
                BuiltinValueKind.Half => new Polymorphic.RecordsV2.HalfNode() { Id = 1, Name = "Id1", HalfValue = Half.MaxValue },
                BuiltinValueKind.Int32 => new Polymorphic.RecordsV2.Int32Node() { Id = 1, Name = "Id1", Int32Value = Int32.MinValue },
                BuiltinValueKind.UInt32 => new Polymorphic.RecordsV2.UInt32Node() { Id = 1, Name = "Id1", UInt32Value = UInt32.MaxValue },
                BuiltinValueKind.Single => new Polymorphic.RecordsV2.SingleNode() { Id = 1, Name = "Id1", SingleValue = Single.MaxValue },
                BuiltinValueKind.DateTime => new Polymorphic.RecordsV2.DateTimeNode() { Id = 1, Name = "Id1", DateTimeValue = DateTime.MaxValue },
                BuiltinValueKind.TimeSpan => new Polymorphic.RecordsV2.TimeSpanNode() { Id = 1, Name = "Id1", TimeSpanValue = TimeSpan.MaxValue },
                BuiltinValueKind.DateOnly => new Polymorphic.RecordsV2.DateOnlyNode() { Id = 1, Name = "Id1", DateOnlyValue = DateOnly.MaxValue },
                BuiltinValueKind.TimeOnly => new Polymorphic.RecordsV2.TimeOnlyNode() { Id = 1, Name = "Id1", TimeOnlyValue = TimeOnly.MaxValue },
                BuiltinValueKind.Int64 => new Polymorphic.RecordsV2.Int64Node() { Id = 1, Name = "Id1", Int64Value = Int64.MinValue },
                BuiltinValueKind.UInt64 => new Polymorphic.RecordsV2.UInt64Node() { Id = 1, Name = "Id1", UInt64Value = UInt64.MaxValue },
                BuiltinValueKind.Double => new Polymorphic.RecordsV2.DoubleNode() { Id = 1, Name = "Id1", DoubleValue = Double.MaxValue },
                BuiltinValueKind.Decimal => new Polymorphic.RecordsV2.DecimalNode() { Id = 1, Name = "Id1", DecimalValue = Decimal.MaxValue },
                BuiltinValueKind.Guid => new Polymorphic.RecordsV2.GuidNode() { Id = 1, Name = "Id1", GuidValue = Guid.NewGuid() },
                BuiltinValueKind.DateTimeOffset => new Polymorphic.RecordsV2.DateTimeOffsetNode() { Id = 1, Name = "Id1", DateTimeOffsetValue = DateTimeOffset.MaxValue },
                BuiltinValueKind.String => new Polymorphic.RecordsV2.StringNode() { Id = 1, Name = "Id1", StringValue = "abcdef" },
                BuiltinValueKind.Octets => new Polymorphic.RecordsV2.OctetsNode() { Id = 1, Name = "Id1", OctetsValue = new Octets(Encoding.UTF8.GetBytes("abcdef")) },
                BuiltinValueKind.Custom => new Polymorphic.RecordsV2.CustomNode() { Id = 1, Name = "Id1", CustomValue = Polymorphic.Contracts.CustomEnum.Value1 },
                BuiltinValueKind.BigInteger => new Polymorphic.RecordsV2.BigIntNode() { Id = 1, Name = "Id1", Value = BigInteger.MinusOne },
                BuiltinValueKind.Complex => new Polymorphic.RecordsV2.ComplexNode() { Id = 1, Name = "Id1", Value = Complex.ImaginaryOne },
                _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, null)
            };
        }

        [Theory]
        [InlineData(BuiltinValueKind.Boolean)]
        [InlineData(BuiltinValueKind.SByte)]
        [InlineData(BuiltinValueKind.Byte)]
        [InlineData(BuiltinValueKind.Int16)]
        [InlineData(BuiltinValueKind.UInt16)]
        [InlineData(BuiltinValueKind.Char)]
        [InlineData(BuiltinValueKind.Half)]
        [InlineData(BuiltinValueKind.Int32)]
        [InlineData(BuiltinValueKind.UInt32)]
        [InlineData(BuiltinValueKind.Single)]
        [InlineData(BuiltinValueKind.DateTime)]
        [InlineData(BuiltinValueKind.TimeSpan)]
        [InlineData(BuiltinValueKind.DateOnly)]
        [InlineData(BuiltinValueKind.TimeOnly)]
        [InlineData(BuiltinValueKind.Int64)]
        [InlineData(BuiltinValueKind.UInt64)]
        [InlineData(BuiltinValueKind.Double)]
        [InlineData(BuiltinValueKind.Decimal)]
        [InlineData(BuiltinValueKind.Guid)]
        [InlineData(BuiltinValueKind.DateTimeOffset)]
        [InlineData(BuiltinValueKind.String)]
        [InlineData(BuiltinValueKind.Octets)]
        [InlineData(BuiltinValueKind.Custom)]
        [InlineData(BuiltinValueKind.BigInteger)]
        [InlineData(BuiltinValueKind.Complex)]
        public void RoundtripPolymorphicNode(BuiltinValueKind kind)
        {
            Polymorphic.Contracts.IValueNode value = CreateValue(kind);
            Polymorphic.RecordsV2.ValueNode original = Polymorphic.RecordsV2.ValueNode_Factory.Instance.CreateFrom(value) ?? throw new Exception("Returned null!");
            // JsonNewstonSoft
            {
                Polymorphic.JsonNewtonSoft.ValueNode outgoing = Polymorphic.JsonNewtonSoft.ValueNode_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = outgoing.SerializeToJsonNewtonSoft<Polymorphic.JsonNewtonSoft.ValueNode>();
                var incoming = buffer.DeserializeFromJsonNewtonSoft<Polymorphic.JsonNewtonSoft.ValueNode>();
                incoming.Should().Be(outgoing);
                Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate.Should().Be(original);
                duplicate.Equals(original).Should().BeTrue();
            }
            // MessagePack
            {
                Polymorphic.MessagePack.ValueNode outgoing = Polymorphic.MessagePack.ValueNode_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
                var buffer = MessagePackSerializer.Serialize<Polymorphic.MessagePack.ValueNode>(outgoing);
                var incoming = MessagePackSerializer.Deserialize<Polymorphic.MessagePack.ValueNode>(buffer);
                incoming.Should().Be(outgoing);
                Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
                duplicate.Should().Be(original);
                duplicate.Equals(original).Should().BeTrue();
            }
        }

    }
}