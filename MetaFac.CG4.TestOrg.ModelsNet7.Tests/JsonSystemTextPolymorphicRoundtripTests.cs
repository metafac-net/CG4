using FluentAssertions;

namespace MetaFac.CG4.TestOrg.ModelsNet7.Tests
{
    [UsesVerify]
    public class JsonSystemTextPolymorphicRoundtripTests
    {
        [Fact]
        public async Task RoundtripPolymorphicNode_Depth1()
        {
            Polymorphic.RecordsV2.ValueNode original = new Polymorphic.RecordsV2.StringNode() { Id = 1, Name = "string", StrValue = "Value1" };
            Polymorphic.JsonSystemText.ValueNode outgoing = Polymorphic.JsonSystemText.ValueNode_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonSystemText<Polymorphic.JsonSystemText.ValueNode>();
            var incoming = buffer.DeserializeFromJsonSystemText<Polymorphic.JsonSystemText.ValueNode>();
            incoming.Should().Be(outgoing);
            Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
            await Verifier.Verify(buffer);
        }

        [Fact]
        public async Task RoundtripPolymorphicNode_Depth2()
        {
            Polymorphic.RecordsV2.ValueNode original = new Polymorphic.RecordsV2.Int64Node() { Id = 1, Name = "long", LongValue = 123456L };
            Polymorphic.JsonSystemText.ValueNode outgoing = Polymorphic.JsonSystemText.ValueNode_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonSystemText<Polymorphic.JsonSystemText.ValueNode>();
            var incoming = buffer.DeserializeFromJsonSystemText<Polymorphic.JsonSystemText.ValueNode>();
            incoming.Should().Be(outgoing);
            Polymorphic.RecordsV2.ValueNode duplicate = Polymorphic.RecordsV2.ValueNode_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
            await Verifier.Verify(buffer);
        }

    }
}