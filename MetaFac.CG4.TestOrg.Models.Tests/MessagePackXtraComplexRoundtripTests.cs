using FluentAssertions;
using MessagePack;
using System;
using System.Linq;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{
    public class MessagePackXtraComplexRoundtripTests
    {
        [Fact]
        public void RoundtripTree_Empty()
        {
            var original = new XtraComplex.RecordsV2.Tree() { };
            var outgoing = XtraComplex.MessagePack.Tree.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = MessagePackSerializer.Serialize<XtraComplex.MessagePack.Tree>(outgoing);
            string.Join("-", buffer.Select(b => b.ToString("X2"))).Should().Be(
                "94-C0-C0-C0-C0");
            var incoming = MessagePackSerializer.Deserialize<XtraComplex.MessagePack.Tree>(buffer);
            incoming.Should().Be(outgoing);
            var duplicate = XtraComplex.RecordsV2.Tree.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

        [Fact]
        public void RoundtripTree_Height1()
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
            var outgoing = XtraComplex.MessagePack.Tree.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = MessagePackSerializer.Serialize<XtraComplex.MessagePack.Tree>(outgoing);
            string.Join("-", buffer.Select(b => b.ToString("X2"))).Should().Be(
                "94-C0-92-03-92-C0-A3-61-62-63-94-C0-92-06-92-C0-01-C0-C0-94-C0-92-05-92-C0-FF-C0-C0");
            var incoming = MessagePackSerializer.Deserialize<XtraComplex.MessagePack.Tree>(buffer);
            incoming.Should().Be(outgoing);
            var duplicate = XtraComplex.RecordsV2.Tree.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

        [Fact]
        public void RoundtripTree_Height2()
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
            var outgoing = XtraComplex.MessagePack.Tree.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = MessagePackSerializer.Serialize<XtraComplex.MessagePack.Tree>(outgoing);
            string.Join("-", buffer.Select(b => b.ToString("X2"))).Should().Be(
                "94-C0-92-03-92-C0-A3-61-62-63-94-C0-92-06-92-C0-01-94-C0-92-06-92-C0-02-C0-C0-C0-94-C0-92-05-92-C0-FF-C0-94-C0-92-05-92-C0-FE-C0-C0");
            var incoming = MessagePackSerializer.Deserialize<XtraComplex.MessagePack.Tree>(buffer);
            incoming.Should().Be(outgoing);
            var duplicate = XtraComplex.RecordsV2.Tree.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }
    }
}