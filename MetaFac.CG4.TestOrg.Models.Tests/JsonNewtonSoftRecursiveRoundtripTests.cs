using MetaFac.CG4.TestOrg.Common;
using Shouldly;
using System;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{
    public class JsonNewtonSoftRecursiveRoundtripTests
    {
        [Fact]
        public async Task RoundtripTree_Empty()
        {
            var original = new Recursive.RecordsV2.Tree() { Id = 1 };
            var outgoing = Recursive.JsonNewtonSoft.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonNewtonSoft<Recursive.JsonNewtonSoft.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonNewtonSoft<Recursive.JsonNewtonSoft.Tree>();
            incoming.ShouldBe(outgoing);
            var duplicate = Recursive.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
        }

        [Fact]
        public async Task RoundtripTree_Height1a()
        {
            var original = new Recursive.RecordsV2.Tree()
            {
                Id = 1,
                A = new Recursive.RecordsV2.Tree() { Id = 2 }
            };
            var outgoing = Recursive.JsonNewtonSoft.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonNewtonSoft<Recursive.JsonNewtonSoft.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonNewtonSoft<Recursive.JsonNewtonSoft.Tree>();
            incoming.ShouldBe(outgoing);
            var duplicate = Recursive.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
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
            var outgoing = Recursive.JsonNewtonSoft.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonNewtonSoft<Recursive.JsonNewtonSoft.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonNewtonSoft<Recursive.JsonNewtonSoft.Tree>();
            incoming.ShouldBe(outgoing);
            var duplicate = Recursive.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
            duplicate.Id.ShouldBe(1);
            duplicate.A!.Id.ShouldBe(2);
            duplicate.B!.Id.ShouldBe(3);
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
            var outgoing = Recursive.JsonNewtonSoft.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonNewtonSoft<Recursive.JsonNewtonSoft.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonNewtonSoft<Recursive.JsonNewtonSoft.Tree>();
            incoming.ShouldBe(outgoing);
            var duplicate = Recursive.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
            duplicate.Id.ShouldBe(1);
            duplicate.A!.Id.ShouldBe(2);
            duplicate.B!.Id.ShouldBe(3);
            duplicate.A!.A!.Id.ShouldBe(4);
            duplicate.B!.B!.Id.ShouldBe(5);
        }

    }
}