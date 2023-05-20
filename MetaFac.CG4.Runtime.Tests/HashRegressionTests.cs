using FluentAssertions;
using MessagePack;
using MetaFac.CG4.Runtime.MessagePack;
using System;
using System.Linq;
using Xunit;

namespace MetaFac.CG4.Runtime.Tests
{
    public class HashRegressionTests
    {
        [Fact]
        public void BasicTypes()
        {
            0.CalcHashUnary().Should().Be(0);
            int.MaxValue.CalcHashUnary().Should().Be(2147483647);
            int.MinValue.CalcHashUnary().Should().Be(-2147483648);
        }
    }
}
