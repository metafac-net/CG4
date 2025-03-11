using MessagePack;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{
    public class MessagePackRecursiveRoundtripTests
    {
        [Fact]
        public void RoundtripTree_Empty()
        {
            var original = new Recursive.RecordsV2.Tree() { Id = 1 };
            var outgoing = Recursive.MessagePack.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = MessagePackSerializer.Serialize<Recursive.MessagePack.Tree>(outgoing);
            string.Join("-", buffer.Select(b => b.ToString("X2"))).ShouldBe(
                "94-C0-01-C0-C0");
            var incoming = MessagePackSerializer.Deserialize<Recursive.MessagePack.Tree>(buffer);
            incoming.ShouldBe(outgoing);
            var duplicate = Recursive.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
        }

        [Fact]
        public void RoundtripTree_Height1a()
        {
            var original = new Recursive.RecordsV2.Tree()
            {
                Id = 1,
                A = new Recursive.RecordsV2.Tree() { Id = 2 }
            };
            var outgoing = Recursive.MessagePack.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = MessagePackSerializer.Serialize<Recursive.MessagePack.Tree>(outgoing);
            string.Join("-", buffer.Select(b => b.ToString("X2"))).ShouldBe(
                "94-C0-01-94-C0-02-C0-C0-C0");
            var incoming = MessagePackSerializer.Deserialize<Recursive.MessagePack.Tree>(buffer);
            incoming.ShouldBe(outgoing);
            var duplicate = Recursive.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
        }

        [Fact]
        public void RoundtripTree_Height1b()
        {
            var original = new Recursive.RecordsV2.Tree()
            {
                Id = 1,
                A = new Recursive.RecordsV2.Tree() { Id = 2 },
                B = new Recursive.RecordsV2.Tree() { Id = 3 }
            };
            var outgoing = Recursive.MessagePack.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = MessagePackSerializer.Serialize<Recursive.MessagePack.Tree>(outgoing);
            string.Join("-", buffer.Select(b => b.ToString("X2"))).ShouldBe(
                "94-C0-01-94-C0-02-C0-C0-94-C0-03-C0-C0");
            var incoming = MessagePackSerializer.Deserialize<Recursive.MessagePack.Tree>(buffer);
            incoming.ShouldBe(outgoing);
            var duplicate = Recursive.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
            duplicate.Id.ShouldBe(1);
            duplicate.A!.Id.ShouldBe(2);
            duplicate.B!.Id.ShouldBe(3);
        }

        [Fact]
        public void RoundtripTree_Height2()
        {
            var original = new Recursive.RecordsV2.Tree()
            {
                Id = 1,
                A = new Recursive.RecordsV2.Tree() { Id = 2, A = new Recursive.RecordsV2.Tree() { Id = 4 } },
                B = new Recursive.RecordsV2.Tree() { Id = 3, B = new Recursive.RecordsV2.Tree() { Id = 5 } }
            };
            var outgoing = Recursive.MessagePack.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = MessagePackSerializer.Serialize<Recursive.MessagePack.Tree>(outgoing);
            string.Join("-", buffer.Select(b => b.ToString("X2"))).ShouldBe(
                "94-C0-01-94-C0-02-94-C0-04-C0-C0-C0-94-C0-03-C0-94-C0-05-C0-C0");
            var incoming = MessagePackSerializer.Deserialize<Recursive.MessagePack.Tree>(buffer);
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