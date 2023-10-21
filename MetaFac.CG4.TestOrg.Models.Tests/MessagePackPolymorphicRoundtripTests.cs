using FluentAssertions;
using MessagePack;
using System;
using System.Linq;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{
    public class MessagePackPolymorphicRoundtripTests
    {
        [Fact]
        public void RoundtripPolymorphicNode_Depth1()
        {
            Polymorphic.RecordsV2.ValueNode original = new Polymorphic.RecordsV2.StringNode() { Id = 1, Name = "string", StringValue = "Value1" };
            Polymorphic.MessagePack.ValueNode outgoing = Polymorphic.MessagePack.ValueNode_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = MessagePackSerializer.Serialize<Polymorphic.MessagePack.ValueNode>(outgoing);
            string.Join("-", buffer.Select(b => b.ToString("X2"))).Should().Be(
                "92-03-94-C0-01-A6-73-74-72-69-6E-67-A6-56-61-6C-75-65-31");
            var incoming = MessagePackSerializer.Deserialize<Polymorphic.MessagePack.ValueNode>(buffer);
            incoming.Should().Be(outgoing);
            Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

        [Fact]
        public void RoundtripPolymorphicNode_Depth2()
        {
            Polymorphic.RecordsV2.ValueNode original = new Polymorphic.RecordsV2.Int64Node() { Id = 1, Name = "long", Int64Value = 123456L };
            Polymorphic.MessagePack.ValueNode outgoing = Polymorphic.MessagePack.ValueNode_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = MessagePackSerializer.Serialize<Polymorphic.MessagePack.ValueNode>(outgoing);
            string.Join("-", buffer.Select(b => b.ToString("X2"))).Should().Be(
                "92-07-94-C0-01-A4-6C-6F-6E-67-CE-00-01-E2-40");
            var incoming = MessagePackSerializer.Deserialize<Polymorphic.MessagePack.ValueNode>(buffer);
            incoming.Should().Be(outgoing);
            Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

    }
}