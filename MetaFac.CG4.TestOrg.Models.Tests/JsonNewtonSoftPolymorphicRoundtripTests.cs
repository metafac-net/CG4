using FluentAssertions;
using MetaFac.CG4.TestOrg.Common;
using System;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{
    public class JsonNewtonSoftPolymorphicRoundtripTests
    {
        [Fact]
        public async Task RoundtripPolymorphicNode_Depth1()
        {
            Polymorphic.RecordsV2.ValueNode original = new Polymorphic.RecordsV2.StringNode() { Id = 1, Name = "string", StringValue = "Value1" };
            Polymorphic.JsonNewtonSoft.ValueNode outgoing = Polymorphic.JsonNewtonSoft.ValueNode_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonNewtonSoft<Polymorphic.JsonNewtonSoft.ValueNode>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonNewtonSoft<Polymorphic.JsonNewtonSoft.ValueNode>();
            incoming.Should().Be(outgoing);
            Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

        [Fact]
        public async Task RoundtripPolymorphicNode_Depth2()
        {
            Polymorphic.RecordsV2.ValueNode original = new Polymorphic.RecordsV2.Int64Node() { Id = 1, Name = "long", Int64Value = 123456L };
            Polymorphic.JsonNewtonSoft.ValueNode outgoing = Polymorphic.JsonNewtonSoft.ValueNode_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonNewtonSoft<Polymorphic.JsonNewtonSoft.ValueNode>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonNewtonSoft<Polymorphic.JsonNewtonSoft.ValueNode>();
            incoming.Should().Be(outgoing);
            Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

    }
}