using FluentAssertions;
using Xunit;

namespace MetaCode.Runtime.Tests
{
    public class HashRegressionTests
    {
        [Fact]
        public void BasicTypes()
        {
            ((int)0).CalcHashUnary().Should().Be(0);
            (int.MaxValue).CalcHashUnary().Should().Be(2147483647);
            (int.MinValue).CalcHashUnary().Should().Be(-2147483648);
        }
    }
}
