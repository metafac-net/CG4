using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using T_Namespace_.Contracts;
using T_Namespace_.RecordsV2;
using Xunit;

namespace MetaFac.CG4.Template.UnitTests
{
    using T_ConcreteMaybeType_ = System.DayOfWeek;
    using T_ConcreteOtherType_ = Int64;
    using T_IndexType_ = String;

    public class RecordsV2Tests
    {
        [Fact]
        public void Create_Empty()
        {
            var original = T_EntityName_.Empty;
            original.T_UnaryModelFieldName_.Should().BeNull();
            original.T_ArrayModelFieldName_.Should().BeNull();
            original.T_IndexModelFieldName_.Should().BeNull();
            original.T_UnaryOtherFieldName_.Should().Be(default);
            original.T_ArrayOtherFieldName_.Should().BeNull();
            original.T_IndexOtherFieldName_.Should().BeNull();
            original.T_UnaryMaybeFieldName_.Should().BeNull();
            original.T_ArrayMaybeFieldName_.Should().BeNull();
            original.T_IndexMaybeFieldName_.Should().BeNull();
            original.T_UnaryBufferFieldName_.Should().BeNull();
            original.T_ArrayBufferFieldName_.Should().BeNull();
            original.T_IndexBufferFieldName_.Should().BeNull();
            original.T_UnaryStringFieldName_.Should().BeNull();
            original.T_ArrayStringFieldName_.Should().BeNull();
            original.T_IndexStringFieldName_.Should().BeNull();

            IT_EntityName_ external = original;
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

            var duplicate = new T_EntityName_(external);
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

            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
            Equals(duplicate, original).Should().BeTrue();
        }

        [Fact]
        public void Create_NonEmpty()
        {
            var original = new T_EntityName_()
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
                T_ArrayMaybeFieldName_ = ImmutableList<T_ConcreteMaybeType_?>.Empty.AddRange(new T_ConcreteMaybeType_?[] { T_ConcreteMaybeType_.Monday }),
                T_IndexMaybeFieldName_ = ImmutableDictionary<T_IndexType_, T_ConcreteMaybeType_?>.Empty.AddRange(new[]
                {
                    new KeyValuePair<T_IndexType_, T_ConcreteMaybeType_?>("987",  T_ConcreteMaybeType_.Tuesday),
                    new KeyValuePair<T_IndexType_, T_ConcreteMaybeType_?>("876", default)
                }),
            };

            IT_EntityName_ external = original;
            external.T_UnaryModelFieldName_.Should().NotBeNull();
            external.T_ArrayModelFieldName_.Should().NotBeNull();
            external.T_IndexModelFieldName_.Should().NotBeNull();
            external.T_UnaryOtherFieldName_.Should().Be(123L);
            external.T_ArrayOtherFieldName_.Should().NotBeNull();
            external.T_IndexOtherFieldName_.Should().NotBeNull();
            external.T_UnaryMaybeFieldName_.Should().BeNull();
            external.T_ArrayMaybeFieldName_.Should().NotBeNull();
            external.T_IndexMaybeFieldName_.Should().NotBeNull();

            var duplicate = new T_EntityName_(external);
            duplicate.T_UnaryModelFieldName_.Should().Be(original.T_UnaryModelFieldName_);
            duplicate.T_UnaryMaybeFieldName_.Should().Be(original.T_UnaryMaybeFieldName_);
            duplicate.T_UnaryOtherFieldName_.Should().Be(original.T_UnaryOtherFieldName_);
            duplicate.T_UnaryBufferFieldName_.Should().BeEquivalentTo(original.T_UnaryBufferFieldName_);
            duplicate.T_UnaryStringFieldName_.Should().Be(original.T_UnaryStringFieldName_);
            duplicate.T_ArrayModelFieldName_.Should().BeEquivalentTo(original.T_ArrayModelFieldName_);
            duplicate.T_ArrayMaybeFieldName_.Should().BeEquivalentTo(original.T_ArrayMaybeFieldName_);
            duplicate.T_ArrayOtherFieldName_.Should().BeEquivalentTo(original.T_ArrayOtherFieldName_);
            duplicate.T_ArrayBufferFieldName_.Should().BeEquivalentTo(original.T_ArrayBufferFieldName_);
            duplicate.T_ArrayStringFieldName_.Should().BeEquivalentTo(original.T_ArrayStringFieldName_);
            duplicate.T_IndexModelFieldName_.Should().BeEquivalentTo(original.T_IndexModelFieldName_);
            duplicate.T_IndexMaybeFieldName_.Should().BeEquivalentTo(original.T_IndexMaybeFieldName_);
            duplicate.T_IndexOtherFieldName_.Should().BeEquivalentTo(original.T_IndexOtherFieldName_);
            duplicate.T_IndexBufferFieldName_.Should().BeEquivalentTo(original.T_IndexBufferFieldName_);
            duplicate.T_IndexStringFieldName_.Should().BeEquivalentTo(original.T_IndexStringFieldName_);

            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
            Equals(duplicate, original).Should().BeTrue();
        }
    }
}
