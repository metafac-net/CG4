using FluentAssertions;
using MessagePack;
using MetaFac.CG4.TestOrg.Models.BasicTypes.Contracts;
using System;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{

    [UsesVerify]
    public class JsonNewtonSoftPolymorphicRoundtripTests
    {
        [Fact]
        public async Task RoundtripPolymorphicNode_Depth1()
        {
            Polymorphic.RecordsV2.ValueNode original = new Polymorphic.RecordsV2.StringNode() { Id = 1, Name = "string", StrValue = "Value1" };
            Polymorphic.JsonNewtonSoft.ValueNode outgoing = Polymorphic.JsonNewtonSoft.ValueNode.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJson<Polymorphic.JsonNewtonSoft.ValueNode>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJson<Polymorphic.JsonNewtonSoft.ValueNode>();
            incoming.Should().Be(outgoing);
            Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

        [Fact]
        public async Task RoundtripPolymorphicNode_Depth2()
        {
            Polymorphic.RecordsV2.ValueNode original = new Polymorphic.RecordsV2.Int64Node() { Id = 1, Name = "long", LongValue = 123456L };
            Polymorphic.JsonNewtonSoft.ValueNode outgoing = Polymorphic.JsonNewtonSoft.ValueNode.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJson<Polymorphic.JsonNewtonSoft.ValueNode>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJson<Polymorphic.JsonNewtonSoft.ValueNode>();
            incoming.Should().Be(outgoing);
            Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

    }
}