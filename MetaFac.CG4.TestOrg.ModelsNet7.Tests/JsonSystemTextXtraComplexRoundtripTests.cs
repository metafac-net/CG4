using FluentAssertions;
using Xunit;

namespace MetaFac.CG4.TestOrg.ModelsNet7.Tests
{
    [UsesVerify]
    public class JsonSystemTextXtraComplexRoundtripTests
    {
        [Fact]
        public async Task RoundtripTree_Empty()
        {
            var original = new XtraComplex.RecordsV2.Tree() { };
            var outgoing = XtraComplex.JsonSystemText.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonSystemText<XtraComplex.JsonSystemText.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonSystemText<XtraComplex.JsonSystemText.Tree>();
            incoming.Should().Be(outgoing);
            var duplicate = XtraComplex.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

        [Fact]
        public async Task RoundtripTree_Height1()
        {
            var original = new XtraComplex.RecordsV2.Tree()
            {
                Value = new XtraComplex.RecordsV2.StrNode() { StrVal = "abc" },
                A = new XtraComplex.RecordsV2.Tree()
                {
                    Value = new XtraComplex.RecordsV2.DaynNode() { DaynVal = DayOfWeek.Monday }
                },
                B = new XtraComplex.RecordsV2.Tree()
                {
                    Value = new XtraComplex.RecordsV2.LongNode() { LongVal = -1L }
                },
            };
            var outgoing = XtraComplex.JsonSystemText.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonSystemText<XtraComplex.JsonSystemText.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonSystemText<XtraComplex.JsonSystemText.Tree>();
            incoming.Should().Be(outgoing);
            var duplicate = XtraComplex.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

        [Fact]
        public async Task RoundtripTree_Height2()
        {
            var original = new XtraComplex.RecordsV2.Tree()
            {
                Value = new XtraComplex.RecordsV2.StrNode() { StrVal = "abc" },
                A = new XtraComplex.RecordsV2.Tree()
                {
                    Value = new XtraComplex.RecordsV2.DaynNode() { DaynVal = DayOfWeek.Monday },
                    A = new XtraComplex.RecordsV2.Tree()
                    {
                        Value = new XtraComplex.RecordsV2.DaynNode() { DaynVal = DayOfWeek.Tuesday }
                    }
                },
                B = new XtraComplex.RecordsV2.Tree()
                {
                    Value = new XtraComplex.RecordsV2.LongNode() { LongVal = -1L },
                    B = new XtraComplex.RecordsV2.Tree()
                    {
                        Value = new XtraComplex.RecordsV2.LongNode() { LongVal = -2L }
                    }
                },
            };
            var outgoing = XtraComplex.JsonSystemText.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonSystemText<XtraComplex.JsonSystemText.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonSystemText<XtraComplex.JsonSystemText.Tree>();
            incoming.Should().Be(outgoing);
            var duplicate = XtraComplex.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }
    }
}