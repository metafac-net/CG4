using MetaFac.CG4.TestOrg.Common;
using Shouldly;
using System;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{
    public class JsonSystemTextPolymorphicRoundtripTests
    {
        [Fact]
        public async Task RoundtripPolymorphicNode_Depth1()
        {
            Polymorphic.RecordsV2.ValueNode original = new Polymorphic.RecordsV2.StringNode() { Id = 1, Name = "string", StringValue = "Value1" };
            Polymorphic.JsonSystemText.ValueNode outgoing = Polymorphic.JsonSystemText.ValueNode_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonSystemText<Polymorphic.JsonSystemText.ValueNode>();
            var incoming = buffer.DeserializeFromJsonSystemText<Polymorphic.JsonSystemText.ValueNode>();
            incoming.ShouldBe(outgoing);
            Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
            await Verifier.Verify(buffer);
        }

        [Fact]
        public async Task RoundtripPolymorphicNode_Depth2()
        {
            Polymorphic.RecordsV2.ValueNode original = new Polymorphic.RecordsV2.Int64Node() { Id = 1, Name = "long", Int64Value = 123456L };
            Polymorphic.JsonSystemText.ValueNode outgoing = Polymorphic.JsonSystemText.ValueNode_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonSystemText<Polymorphic.JsonSystemText.ValueNode>();
            var incoming = buffer.DeserializeFromJsonSystemText<Polymorphic.JsonSystemText.ValueNode>();
            incoming.ShouldBe(outgoing);
            Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
            await Verifier.Verify(buffer);
        }

    }
}