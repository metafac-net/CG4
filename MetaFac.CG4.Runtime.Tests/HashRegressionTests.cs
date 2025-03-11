using Shouldly;
using Xunit;

namespace MetaFac.CG4.Runtime.Tests
{
    public class HashRegressionTests
    {
        [Fact]
        public void BasicTypes()
        {
            0.CalcHashUnary().ShouldBe(0);
            int.MaxValue.CalcHashUnary().ShouldBe(2147483647);
            int.MinValue.CalcHashUnary().ShouldBe(-2147483648);
        }
    }
}
