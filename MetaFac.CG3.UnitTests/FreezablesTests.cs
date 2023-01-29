using FluentAssertions;
using MetaFac.Collections.Freezables;
using System.Collections.Generic;
using T_Namespace_.Freezables;
using T_Namespace_.Interfaces;
using Xunit;

namespace MetaFac.CG3.Template.UnitTests
{
    using T_ConcreteOtherType_ = System.Int64;
    //>>using (Ignored()) {
    using T_IndexType_ = System.String;
    //>>}

    public class FreezablesTests
    {
        [Fact]
        public void Create_Empty()
        {
            var concrete = new T_ClassName_();
            concrete.IsFrozen().Should().BeFalse();
            concrete.Freeze();
            concrete.IsFrozen().Should().BeTrue();
            concrete.T_UnaryModelFieldName_.Should().BeNull();
            concrete.T_ArrayModelFieldName_.Should().BeNull();
            concrete.T_IndexModelFieldName_.Should().BeNull();
            concrete.T_UnaryOtherFieldName_.Should().Be(default);
            concrete.T_ArrayOtherFieldName_.Should().BeNull();
            concrete.T_IndexOtherFieldName_.Should().BeNull();
            concrete.T_UnaryMaybeFieldName_.Should().BeNull();
            concrete.T_ArrayMaybeFieldName_.Should().BeNull();
            concrete.T_IndexMaybeFieldName_.Should().BeNull();

            IT_ClassName_ external = concrete;
            external.T_UnaryModelFieldName_.Should().BeNull();
            external.T_ArrayModelFieldName_.Should().BeNull();
            external.T_IndexModelFieldName_.Should().BeNull();
            external.T_UnaryOtherFieldName_.Should().Be(default);
            external.T_ArrayOtherFieldName_.Should().BeNull();
            external.T_IndexOtherFieldName_.Should().BeNull();
            external.T_UnaryMaybeFieldName_.Should().BeNull();
            external.T_ArrayMaybeFieldName_.Should().BeNull();
            external.T_IndexMaybeFieldName_.Should().BeNull();

            var duplicate = new T_ClassName_(external);
            duplicate.IsFrozen().Should().BeFalse();
            duplicate.Freeze();
            duplicate.IsFrozen().Should().BeTrue();
            duplicate.Should().Be(concrete);
            duplicate.Equals(concrete).Should().BeTrue();
        }

        [Fact]
        public void Create_NonEmpty()
        {
            var concrete = new T_ClassName_();
            concrete.IsFrozen().Should().BeFalse();
            concrete.T_UnaryModelFieldName_ = new T_ModelType_(123);
            concrete.T_ArrayModelFieldName_ = new FreezableArray<T_ModelType_?>(new[] { new T_ModelType_(234) });
            concrete.T_IndexModelFieldName_ = new FreezableHashedDictionary<T_IndexType_, T_ModelType_?>(new[]
            {
                new KeyValuePair<T_IndexType_, T_ModelType_?>("987", new T_ModelType_(456)),
                new KeyValuePair<T_IndexType_, T_ModelType_?>("876", null)
            });

            concrete.T_UnaryOtherFieldName_ = 123L;
            concrete.T_ArrayOtherFieldName_ = new FreezableArray<T_ConcreteOtherType_>(new[] { 234L });
            concrete.T_IndexOtherFieldName_ = new FreezableHashedDictionary<T_IndexType_, T_ConcreteOtherType_>(new[]
            {
                new KeyValuePair<T_IndexType_, T_ConcreteOtherType_>("987", 456L),
                new KeyValuePair<T_IndexType_, T_ConcreteOtherType_>("876", default)
            });

            concrete.T_UnaryMaybeFieldName_ = null;
            concrete.T_ArrayMaybeFieldName_ = new FreezableArray<T_ConcreteOtherType_?>(new T_ConcreteOtherType_?[] { 234L });
            concrete.T_IndexMaybeFieldName_ = new FreezableHashedDictionary<T_IndexType_, T_ConcreteOtherType_?>(new[]
            {
                new KeyValuePair<T_IndexType_, T_ConcreteOtherType_?>("987", 456L),
                new KeyValuePair<T_IndexType_, T_ConcreteOtherType_?>("876", default)
            });
            concrete.Freeze();
            concrete.IsFrozen().Should().BeTrue();

            IT_ClassName_ external = concrete;
            external.T_UnaryModelFieldName_.Should().NotBeNull();
            external.T_ArrayModelFieldName_.Should().NotBeNull();
            external.T_IndexModelFieldName_.Should().NotBeNull();
            external.T_UnaryOtherFieldName_.Should().Be(123L);
            external.T_ArrayOtherFieldName_.Should().NotBeNull();
            external.T_IndexOtherFieldName_.Should().NotBeNull();
            external.T_UnaryMaybeFieldName_.Should().BeNull();
            external.T_ArrayMaybeFieldName_.Should().NotBeNull();
            external.T_IndexMaybeFieldName_.Should().NotBeNull();

            var duplicate = new T_ClassName_(external);
            duplicate.IsFrozen().Should().BeFalse();
            duplicate.Freeze();
            duplicate.IsFrozen().Should().BeTrue();
            duplicate.Should().Be(concrete);
            duplicate.Equals(concrete).Should().BeTrue();
        }
    }
}