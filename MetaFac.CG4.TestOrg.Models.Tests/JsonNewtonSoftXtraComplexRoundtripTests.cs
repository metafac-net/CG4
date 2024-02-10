﻿using FluentAssertions;
using MetaFac.CG4.TestOrg.Common;
using System;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.TestOrg.Models.Tests
{
    public class JsonNewtonSoftXtraComplexRoundtripTests
    {
        [Fact]
        public async Task RoundtripTree_Empty()
        {
            var original = new XtraComplex.RecordsV2.Tree() { };
            var outgoing = XtraComplex.JsonNewtonSoft.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonNewtonSoft<XtraComplex.JsonNewtonSoft.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonNewtonSoft<XtraComplex.JsonNewtonSoft.Tree>();
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
            var outgoing = XtraComplex.JsonNewtonSoft.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonNewtonSoft<XtraComplex.JsonNewtonSoft.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonNewtonSoft<XtraComplex.JsonNewtonSoft.Tree>();
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
            var outgoing = XtraComplex.JsonNewtonSoft.Tree_Factory.Instance.CreateFrom(original) ?? throw new Exception("Returned null!");
            var buffer = outgoing.SerializeToJsonNewtonSoft<XtraComplex.JsonNewtonSoft.Tree>();
            await Verifier.Verify(buffer);
            var incoming = buffer.DeserializeFromJsonNewtonSoft<XtraComplex.JsonNewtonSoft.Tree>();
            incoming.Should().Be(outgoing);
            var duplicate = XtraComplex.RecordsV2.Tree_Factory.Instance.CreateFrom(incoming) ?? throw new Exception("Returned null!");
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }
    }
}