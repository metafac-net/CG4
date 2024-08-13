using FluentAssertions;
using MetaFac.CG4.TestOrg.Common;
using System;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{
    public class JsonSystemTextRecursiveRoundtripTests
    {
        [Fact]
        public async Task RoundtripTree_Empty()
        {
            var original = new Recursive.RecordsV2.Tree() { Id = 1 };
            var outgoing = Recursive.JsonSystemText.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonSystemText<Recursive.JsonSystemText.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonSystemText<Recursive.JsonSystemText.Tree>();
            incoming.Should().Be(outgoing);
            var duplicate = Recursive.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

        [Fact]
        public async Task RoundtripTree_Height1a()
        {
            var original = new Recursive.RecordsV2.Tree()
            {
                Id = 1,
                A = new Recursive.RecordsV2.Tree() { Id = 2 }
            };
            var outgoing = Recursive.JsonSystemText.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonSystemText<Recursive.JsonSystemText.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonSystemText<Recursive.JsonSystemText.Tree>();
            incoming.Should().Be(outgoing);
            var duplicate = Recursive.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

        [Fact]
        public async Task RoundtripTree_Height1b()
        {
            var original = new Recursive.RecordsV2.Tree()
            {
                Id = 1,
                A = new Recursive.RecordsV2.Tree() { Id = 2 },
                B = new Recursive.RecordsV2.Tree() { Id = 3 }
            };
            var outgoing = Recursive.JsonSystemText.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonSystemText<Recursive.JsonSystemText.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonSystemText<Recursive.JsonSystemText.Tree>();
            incoming.Should().Be(outgoing);
            var duplicate = Recursive.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
            duplicate.Id.Should().Be(1);
            duplicate.A!.Id.Should().Be(2);
            duplicate.B!.Id.Should().Be(3);
        }

        [Fact]
        public async Task RoundtripTree_Height2()
        {
            var original = new Recursive.RecordsV2.Tree()
            {
                Id = 1,
                A = new Recursive.RecordsV2.Tree() { Id = 2, A = new Recursive.RecordsV2.Tree() { Id = 4 } },
                B = new Recursive.RecordsV2.Tree() { Id = 3, B = new Recursive.RecordsV2.Tree() { Id = 5 } }
            };
            var outgoing = Recursive.JsonSystemText.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonSystemText<Recursive.JsonSystemText.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonSystemText<Recursive.JsonSystemText.Tree>();
            incoming.Should().Be(outgoing);
            var duplicate = Recursive.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
            duplicate.Id.Should().Be(1);
            duplicate.A!.Id.Should().Be(2);
            duplicate.B!.Id.Should().Be(3);
            duplicate.A!.A!.Id.Should().Be(4);
            duplicate.B!.B!.Id.Should().Be(5);
        }

    }
}