using FluentAssertions;
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
        public void RoundTrip_Record_Via_MessagePack_Empty()
        {
            var r1 = new T_Namespace_.RecordsV2.T_EntityName_() { };

            var m1 = new T_Namespace_.MessagePack.T_EntityName_(r1);
            m1.Freeze();
            byte[] buffer = MessagePack.MessagePackSerializer.Serialize(m1);
            var m2 = MessagePack.MessagePackSerializer.Deserialize<T_Namespace_.MessagePack.T_EntityName_>(buffer);

            var r2 = new T_Namespace_.RecordsV2.T_EntityName_(m2);
            r2.Should().Be(r1);
            r2.Equals(r1).Should().BeTrue();
            r2.GetHashCode().Should().Be(r1.GetHashCode());
        }

        [Fact]
        public void RoundTrip_Freezable_Via_Mutable_NonEmpty()
        {
            var m1 = new T_Namespace_.ClassesV2.T_EntityName_()
            {
                T_UnaryModelFieldName_ = new T_Namespace_.ClassesV2.T_ModelType_() { TestData = 123 },
                T_ArrayModelFieldName_ = ImmutableList<T_Namespace_.ClassesV2.T_ModelType_?>.Empty.Add(new T_Namespace_.ClassesV2.T_ModelType_() { TestData = 234 }),
                T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_Namespace_.ClassesV2.T_ModelType_?>.Empty
                    .Add("987", new T_Namespace_.ClassesV2.T_ModelType_() { TestData = 456 })
                    .Add("876", null),
            };
            var f1 = new T_Namespace_.MessagePack.T_EntityName_(m1);
            f1.Freeze();

            var m2 = new T_Namespace_.ClassesV2.T_EntityName_(f1);
            m2.Should().Be(m1);
            m2.Equals(m1).Should().BeTrue();
            //m2.GetHashCode().Should().Be(m1.GetHashCode());

            var f2 = new T_Namespace_.MessagePack.T_EntityName_(m2);
            f2.Freeze();
            f2.Should().Be(f1);
            f2.Equals(f1).Should().BeTrue();
            f2.GetHashCode().Should().Be(f1.GetHashCode());
        }

    }
}
