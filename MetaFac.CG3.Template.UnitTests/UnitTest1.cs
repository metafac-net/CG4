using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace MetaFac.CG3.Template.UnitTests
{
    //>>using (Ignored()) {
    using T_IndexType_ = System.String;
    //>>}

    public class RoundtripTests
    {
        [Fact]
        public void RoundTrip_Freezable_Via_Mutable_Empty()
        {
            var m1 = new T_Namespace_.JsonPoco.T_ClassName_() { };
            var f1 = new T_Namespace_.Freezables.T_ClassName_(m1);
            f1.Freeze();

            var m2 = new T_Namespace_.JsonPoco.T_ClassName_(f1);
            m2.Should().Be(m1);
            m2.Equals(m1).Should().BeTrue();
            m2.GetHashCode().Should().Be(m1.GetHashCode());

            var f2 = new T_Namespace_.Freezables.T_ClassName_(m2);
            f2.Freeze();
            f2.Should().Be(f1);
            f2.Equals(f1).Should().BeTrue();
            f2.GetHashCode().Should().Be(f1.GetHashCode());
        }

        [Fact]
        public void RoundTrip_Freezable_Via_Mutable_NonEmpty()
        {
            var m1 = new T_Namespace_.JsonPoco.T_ClassName_()
            {
                T_UnaryModelFieldName_ = new T_Namespace_.JsonPoco.T_ModelType_() { TestData = 123 },
                T_ArrayModelFieldName_ = new[] { new T_Namespace_.JsonPoco.T_ModelType_() { TestData = 234 } },
                T_IndexModelFieldName_ = new Dictionary<T_IndexType_, T_Namespace_.JsonPoco.T_ModelType_?>()
                {
                    ["987"] = new T_Namespace_.JsonPoco.T_ModelType_() { TestData = 456 },
                    ["876"] = null,
                }
            };
            var f1 = new T_Namespace_.Freezables.T_ClassName_(m1);
            f1.Freeze();

            var m2 = new T_Namespace_.JsonPoco.T_ClassName_(f1);
            m2.Should().Be(m1);
            m2.Equals(m1).Should().BeTrue();
            //m2.GetHashCode().Should().Be(m1.GetHashCode());

            var f2 = new T_Namespace_.Freezables.T_ClassName_(m2);
            f2.Freeze();
            f2.Should().Be(f1);
            f2.Equals(f1).Should().BeTrue();
            f2.GetHashCode().Should().Be(f1.GetHashCode());
        }
    }
}
