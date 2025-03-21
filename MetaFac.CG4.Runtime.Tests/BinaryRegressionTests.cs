﻿using MessagePack;
using MetaFac.CG4.Runtime.MessagePack;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace MetaFac.CG4.Runtime.Tests
{
    public class BinaryRegressionTests
    {
        [Fact]
        public void BinaryValues()
        {
            // null
            {
                BinaryValue? data = null;
                var buffer = MessagePackSerializer.Serialize(data);
                string.Join('-', buffer.Select(b => b.ToString("X2")))
                    .ShouldBe("C0");
                var copy = MessagePackSerializer.Deserialize<BinaryValue>(buffer);
                copy.ShouldBeNull();
            }

            // empty
            {
                BinaryValue data = new BinaryValue(Array.Empty<byte>());
                var buffer = MessagePackSerializer.Serialize(data);
                string.Join('-', buffer.Select(b => b.ToString("X2")))
                    .ShouldBe("91-C4-00");
                var copy = MessagePackSerializer.Deserialize<BinaryValue>(buffer);
                copy.ShouldBe(data);
                copy.Equals(data).ShouldBeTrue();
            }

            // non-empty
            {
                BinaryValue data = new BinaryValue(new byte[] { 1, 2, 3 });
                var buffer = MessagePackSerializer.Serialize(data);
                string.Join('-', buffer.Select(b => b.ToString("X2")))
                    .ShouldBe("91-C4-03-01-02-03");
                var copy = MessagePackSerializer.Deserialize<BinaryValue>(buffer);
                copy.ShouldBe(data);
                copy.Equals(data).ShouldBeTrue();
            }
        }
    }
}
