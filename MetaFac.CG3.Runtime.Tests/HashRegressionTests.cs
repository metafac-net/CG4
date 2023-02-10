using FluentAssertions;
using Xunit;

namespace MetaFac.CG3.Runtime.Tests
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
