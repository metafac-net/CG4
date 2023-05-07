using FluentAssertions;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace MetaFac.CG4.Template.UnitTests
{
    //>>using (Ignored()) {
    using T_IndexType_ = System.String;
    //>>}

    public class RoundtripTests
    {
        [Fact]
        public void RoundTrip_Freezable_Via_Mutable_Empty()
        {
            var m1 = new T_Namespace_.ClassesV2.T_ClassName_() { };
            var f1 = new T_Namespace_.MessagePack.T_ClassName_(m1);
            f1.Freeze();

            var m2 = new T_Namespace_.ClassesV2.T_ClassName_(f1);
            m2.Should().Be(m1);
            m2.Equals(m1).Should().BeTrue();
            m2.GetHashCode().Should().Be(m1.GetHashCode());

            var f2 = new T_Namespace_.MessagePack.T_ClassName_(m2);
            f2.Freeze();
            f2.Should().Be(f1);
            f2.Equals(f1).Should().BeTrue();
            f2.GetHashCode().Should().Be(f1.GetHashCode());
        }

        [Fact]
        public void RoundTrip_Freezable_Via_Mutable_NonEmpty()
        {
            var m1 = new T_Namespace_.ClassesV2.T_ClassName_()
            {
                T_UnaryModelFieldName_ = new T_Namespace_.ClassesV2.T_ModelType_() { TestData = 123 },
                T_ArrayModelFieldName_ = ImmutableList<T_Namespace_.ClassesV2.T_ModelType_?>.Empty.Add(new T_Namespace_.ClassesV2.T_ModelType_() { TestData = 234 } ),
                T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_Namespace_.ClassesV2.T_ModelType_?>.Empty
                    .Add("987", new T_Namespace_.ClassesV2.T_ModelType_() { TestData = 456 })
                    .Add("876", null),
            };
            var f1 = new T_Namespace_.MessagePack.T_ClassName_(m1);
            f1.Freeze();

            var m2 = new T_Namespace_.ClassesV2.T_ClassName_(f1);
            m2.Should().Be(m1);
            m2.Equals(m1).Should().BeTrue();
            //m2.GetHashCode().Should().Be(m1.GetHashCode());

            var f2 = new T_Namespace_.MessagePack.T_ClassName_(m2);
            f2.Freeze();
            f2.Should().Be(f1);
            f2.Equals(f1).Should().BeTrue();
            f2.GetHashCode().Should().Be(f1.GetHashCode());
        }
    }
}
