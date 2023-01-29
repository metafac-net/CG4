using FluentAssertions;
using System.Collections.Generic;
using System.Collections.Immutable;
using T_Namespace_.Interfaces;
using T_Namespace_.Records;
using Xunit;

namespace MetaCode.TS3.UnitTests
{
    using T_ConcreteOtherType_ = System.Int64;
    using T_IndexType_ = System.String;

    public class RecordsTests
    {
        [Fact]
        public void Create_Empty()
        {
            var concrete = T_ClassName_.Empty;
            concrete.T_UnaryModelFieldName_.Should().BeNull();
            concrete.T_ArrayModelFieldName_.Should().BeNull();
            concrete.T_IndexModelFieldName_.Should().BeNull();
            concrete.T_UnaryOtherFieldName_.Should().Be(default);
            concrete.T_ArrayOtherFieldName_.Should().BeNull();
            concrete.T_IndexOtherFieldName_.Should().BeNull();
            concrete.T_UnaryMaybeFieldName_.Should().BeNull();
            concrete.T_ArrayMaybeFieldName_.Should().BeNull();
            concrete.T_IndexMaybeFieldName_.Should().BeNull();
            concrete.T_UnaryBufferFieldName_.Should().BeNull();
            concrete.T_ArrayBufferFieldName_.Should().BeNull();
            concrete.T_IndexBufferFieldName_.Should().BeNull();
            concrete.T_UnaryStringFieldName_.Should().BeNull();
            concrete.T_ArrayStringFieldName_.Should().BeNull();
            concrete.T_IndexStringFieldName_.Should().BeNull();

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
            external.T_UnaryBufferFieldName_.Should().BeNull();
            external.T_ArrayBufferFieldName_.Should().BeNull();
            external.T_IndexBufferFieldName_.Should().BeNull();
            external.T_UnaryStringFieldName_.Should().BeNull();
            external.T_ArrayStringFieldName_.Should().BeNull();
            external.T_IndexStringFieldName_.Should().BeNull();

            var duplicate = new T_ClassName_(external);
            duplicate.T_UnaryModelFieldName_.Should().BeNull();
            duplicate.T_ArrayModelFieldName_.Should().BeNull();
            duplicate.T_IndexModelFieldName_.Should().BeNull();
            duplicate.T_UnaryOtherFieldName_.Should().Be(default);
            duplicate.T_ArrayOtherFieldName_.Should().BeNull();
            duplicate.T_IndexOtherFieldName_.Should().BeNull();
            duplicate.T_UnaryMaybeFieldName_.Should().BeNull();
            duplicate.T_ArrayMaybeFieldName_.Should().BeNull();
            duplicate.T_IndexMaybeFieldName_.Should().BeNull();
            duplicate.T_UnaryBufferFieldName_.Should().BeNull();
            duplicate.T_ArrayBufferFieldName_.Should().BeNull();
            duplicate.T_IndexBufferFieldName_.Should().BeNull();
            duplicate.T_UnaryStringFieldName_.Should().BeNull();
            duplicate.T_ArrayStringFieldName_.Should().BeNull();
            duplicate.T_IndexStringFieldName_.Should().BeNull();

            duplicate.Should().Be(concrete);
            duplicate.Equals(concrete).Should().BeTrue();
        }

        [Fact]
        public void Create_NonEmpty()
        {
            var concrete = new T_ClassName_()
            {
                T_UnaryModelFieldName_ = new T_ModelType_(123),
                T_ArrayModelFieldName_ = ImmutableList<T_ModelType_?>.Empty.AddRange(new[] { new T_ModelType_(234) }),
                T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty.AddRange(new[]
                {
                    new KeyValuePair<T_IndexType_, T_ModelType_?>("987", new T_ModelType_(456)),
                    new KeyValuePair<T_IndexType_, T_ModelType_?>("876", null)
                }),
                T_UnaryOtherFieldName_ = 123L,
                T_ArrayOtherFieldName_ = ImmutableList<T_ConcreteOtherType_>.Empty.AddRange(new[] { 234L }),
                T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, T_ConcreteOtherType_>.Empty.AddRange(new[]
                {
                    new KeyValuePair<T_IndexType_, T_ConcreteOtherType_>("987", 456L),
                    new KeyValuePair<T_IndexType_, T_ConcreteOtherType_>("876", default)
                }),
                T_UnaryMaybeFieldName_ = null,
                T_ArrayMaybeFieldName_ = ImmutableList<T_ConcreteOtherType_?>.Empty.AddRange(new T_ConcreteOtherType_?[] { 234L }),
                T_IndexMaybeFieldName_ = ImmutableDictionary<T_IndexType_, T_ConcreteOtherType_?>.Empty.AddRange(new[]
                {
                    new KeyValuePair<T_IndexType_, T_ConcreteOtherType_?>("987", 456L),
                    new KeyValuePair<T_IndexType_, T_ConcreteOtherType_?>("876", default)
                }),
            };

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
            duplicate.T_UnaryModelFieldName_.Should().Be(concrete.T_UnaryModelFieldName_);
            duplicate.T_UnaryMaybeFieldName_.Should().Be(concrete.T_UnaryMaybeFieldName_);
            duplicate.T_UnaryOtherFieldName_.Should().Be(concrete.T_UnaryOtherFieldName_);
            Equals(duplicate.T_UnaryBufferFieldName_, concrete.T_UnaryBufferFieldName_).Should().BeTrue();
            duplicate.T_UnaryStringFieldName_.Should().Be(concrete.T_UnaryStringFieldName_);
            duplicate.T_ArrayModelFieldName_.Should().BeEquivalentTo(concrete.T_ArrayModelFieldName_);
            duplicate.T_ArrayMaybeFieldName_.Should().BeEquivalentTo(concrete.T_ArrayMaybeFieldName_);
            duplicate.T_ArrayOtherFieldName_.Should().BeEquivalentTo(concrete.T_ArrayOtherFieldName_);
            duplicate.T_ArrayBufferFieldName_.Should().BeEquivalentTo(concrete.T_ArrayBufferFieldName_);
            duplicate.T_ArrayStringFieldName_.Should().BeEquivalentTo(concrete.T_ArrayStringFieldName_);
            duplicate.T_IndexModelFieldName_.Should().BeEquivalentTo(concrete.T_IndexModelFieldName_);
            duplicate.T_IndexMaybeFieldName_.Should().BeEquivalentTo(concrete.T_IndexMaybeFieldName_);
            duplicate.T_IndexOtherFieldName_.Should().BeEquivalentTo(concrete.T_IndexOtherFieldName_);
            duplicate.T_IndexBufferFieldName_.Should().BeEquivalentTo(concrete.T_IndexBufferFieldName_);
            duplicate.T_IndexStringFieldName_.Should().BeEquivalentTo(concrete.T_IndexStringFieldName_);

            duplicate.Equals(concrete).Should().BeTrue();
            duplicate.Should().Be(concrete);
        }
    }
}
