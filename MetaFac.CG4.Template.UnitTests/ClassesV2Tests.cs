using Shouldly;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using T_Namespace_.ClassesV2;
using T_Namespace_.Contracts;
using Xunit;

namespace MetaFac.CG4.Template.UnitTests
{
    using T_ConcreteMaybeType_ = System.DayOfWeek;
    using T_ConcreteOtherType_ = Int64;
    using T_IndexType_ = String;

    public class ClassesV2Tests
    {
        [Fact]
        public void Create_Empty()
        {
            var original = T_EntityName_.Empty;
            original.Freeze();
            original.IsFrozen().ShouldBeTrue();

            original.T_UnaryModelFieldName_.ShouldBeNull();
            original.T_ArrayModelFieldName_.ShouldBeNull();
            original.T_IndexModelFieldName_.ShouldBeNull();
            original.T_UnaryOtherFieldName_.ShouldBe(default);
            original.T_ArrayOtherFieldName_.ShouldBeNull();
            original.T_IndexOtherFieldName_.ShouldBeNull();
            original.T_UnaryMaybeFieldName_.ShouldBeNull();
            original.T_ArrayMaybeFieldName_.ShouldBeNull();
            original.T_IndexMaybeFieldName_.ShouldBeNull();
            original.T_UnaryBufferFieldName_.ShouldBeNull();
            original.T_ArrayBufferFieldName_.ShouldBeNull();
            original.T_IndexBufferFieldName_.ShouldBeNull();
            original.T_UnaryStringFieldName_.ShouldBeNull();
            original.T_ArrayStringFieldName_.ShouldBeNull();
            original.T_IndexStringFieldName_.ShouldBeNull();

            IT_EntityName_ external = original;
            external.T_UnaryModelFieldName_.ShouldBeNull();
            external.T_ArrayModelFieldName_.ShouldBeNull();
            external.T_IndexModelFieldName_.ShouldBeNull();
            external.T_UnaryOtherFieldName_.ShouldBe(default);
            external.T_ArrayOtherFieldName_.ShouldBeNull();
            external.T_IndexOtherFieldName_.ShouldBeNull();
            external.T_UnaryMaybeFieldName_.ShouldBeNull();
            external.T_ArrayMaybeFieldName_.ShouldBeNull();
            external.T_IndexMaybeFieldName_.ShouldBeNull();
            external.T_UnaryBufferFieldName_.ShouldBeNull();
            external.T_ArrayBufferFieldName_.ShouldBeNull();
            external.T_IndexBufferFieldName_.ShouldBeNull();
            external.T_UnaryStringFieldName_.ShouldBeNull();
            external.T_ArrayStringFieldName_.ShouldBeNull();
            external.T_IndexStringFieldName_.ShouldBeNull();

            var duplicate = new T_EntityName_(external);
            duplicate.T_UnaryModelFieldName_.ShouldBeNull();
            duplicate.T_ArrayModelFieldName_.ShouldBeNull();
            duplicate.T_IndexModelFieldName_.ShouldBeNull();
            duplicate.T_UnaryOtherFieldName_.ShouldBe(default);
            duplicate.T_ArrayOtherFieldName_.ShouldBeNull();
            duplicate.T_IndexOtherFieldName_.ShouldBeNull();
            duplicate.T_UnaryMaybeFieldName_.ShouldBeNull();
            duplicate.T_ArrayMaybeFieldName_.ShouldBeNull();
            duplicate.T_IndexMaybeFieldName_.ShouldBeNull();
            duplicate.T_UnaryBufferFieldName_.ShouldBeNull();
            duplicate.T_ArrayBufferFieldName_.ShouldBeNull();
            duplicate.T_IndexBufferFieldName_.ShouldBeNull();
            duplicate.T_UnaryStringFieldName_.ShouldBeNull();
            duplicate.T_ArrayStringFieldName_.ShouldBeNull();
            duplicate.T_IndexStringFieldName_.ShouldBeNull();

            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
            Equals(duplicate, original).ShouldBeTrue();
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
            original.Freeze();
            original.IsFrozen().ShouldBeTrue();
            original.T_UnaryModelFieldName_.IsFrozen().ShouldBeTrue();
            original.T_ArrayModelFieldName_[0]?.IsFrozen().ShouldBeTrue();
            original.T_IndexModelFieldName_["987"]?.IsFrozen().ShouldBeTrue();

            IT_EntityName_ external = original;
            external.T_UnaryModelFieldName_.ShouldNotBeNull();
            external.T_ArrayModelFieldName_.ShouldNotBeNull();
            external.T_IndexModelFieldName_.ShouldNotBeNull();
            external.T_UnaryOtherFieldName_.ShouldBe(123L);
            external.T_ArrayOtherFieldName_.ShouldNotBeNull();
            external.T_IndexOtherFieldName_.ShouldNotBeNull();
            external.T_UnaryMaybeFieldName_.ShouldBeNull();
            external.T_ArrayMaybeFieldName_.ShouldNotBeNull();
            external.T_IndexMaybeFieldName_.ShouldNotBeNull();

            var duplicate = new T_EntityName_(external);
            duplicate.T_UnaryModelFieldName_.ShouldBe(original.T_UnaryModelFieldName_);
            duplicate.T_UnaryMaybeFieldName_.ShouldBe(original.T_UnaryMaybeFieldName_);
            duplicate.T_UnaryOtherFieldName_.ShouldBe(original.T_UnaryOtherFieldName_);
            duplicate.T_UnaryBufferFieldName_.ShouldBeEquivalentTo(original.T_UnaryBufferFieldName_);
            duplicate.T_UnaryStringFieldName_.ShouldBe(original.T_UnaryStringFieldName_);
            duplicate.T_ArrayModelFieldName_.ShouldBeEquivalentTo(original.T_ArrayModelFieldName_);
            duplicate.T_ArrayMaybeFieldName_.ShouldBeEquivalentTo(original.T_ArrayMaybeFieldName_);
            duplicate.T_ArrayOtherFieldName_.ShouldBeEquivalentTo(original.T_ArrayOtherFieldName_);
            duplicate.T_ArrayBufferFieldName_.ShouldBeEquivalentTo(original.T_ArrayBufferFieldName_);
            duplicate.T_ArrayStringFieldName_.ShouldBeEquivalentTo(original.T_ArrayStringFieldName_);
            duplicate.T_IndexModelFieldName_.ShouldBeEquivalentTo(original.T_IndexModelFieldName_);
            duplicate.T_IndexMaybeFieldName_.ShouldBeEquivalentTo(original.T_IndexMaybeFieldName_);
            duplicate.T_IndexOtherFieldName_.ShouldBeEquivalentTo(original.T_IndexOtherFieldName_);
            duplicate.T_IndexBufferFieldName_.ShouldBeEquivalentTo(original.T_IndexBufferFieldName_);
            duplicate.T_IndexStringFieldName_.ShouldBeEquivalentTo(original.T_IndexStringFieldName_);

            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
            Equals(duplicate, original).ShouldBeTrue();
        }
    }
}
