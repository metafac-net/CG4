using FluentAssertions;
using System.Collections.Generic;
using System.Collections.Immutable;
using T_Namespace_.Immutables;
using T_Namespace_.Interfaces;
using Xunit;

namespace MetaFac.CG3.Template.UnitTests
{
    using T_ConcreteOtherType_ = System.Int64;
    //>>using (Ignored()) {
    using T_IndexType_ = System.String;
    //>>}

    public class ImmutablesTests
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

            var duplicate = new T_ClassName_(external);
            duplicate.Should().Be(concrete);
            duplicate.Equals(concrete).Should().BeTrue();
        }

        [Fact]
        public void Create_NonEmpty()
        {
            var builder = T_ClassName_.Empty.ToBuilder();
            builder.T_UnaryModelFieldName_ = new T_ModelType_(123);
            builder.T_ArrayModelFieldName_ = ImmutableList<T_ModelType_?>.Empty.AddRange(new[] { new T_ModelType_(234) });
            builder.T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty.AddRange(new[]
            {
                new KeyValuePair<T_IndexType_, T_ModelType_?>("987", new T_ModelType_(456)),
                new KeyValuePair<T_IndexType_, T_ModelType_?>("876", null)
            });

            builder.T_UnaryOtherFieldName_ = 123L;
            builder.T_ArrayOtherFieldName_ = ImmutableList<T_ConcreteOtherType_>.Empty.AddRange(new[] { 234L });
            builder.T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, T_ConcreteOtherType_>.Empty.AddRange(new[]
            {
                new KeyValuePair<T_IndexType_, T_ConcreteOtherType_>("987", 456L),
                new KeyValuePair<T_IndexType_, T_ConcreteOtherType_>("876", default)
            });

            builder.T_UnaryMaybeFieldName_ = null;
            builder.T_ArrayMaybeFieldName_ = ImmutableList<T_ConcreteOtherType_?>.Empty.AddRange(new T_ConcreteOtherType_?[] { 234L });
            builder.T_IndexMaybeFieldName_ = ImmutableDictionary<T_IndexType_, T_ConcreteOtherType_?>.Empty.AddRange(new[]
            {
                new KeyValuePair<T_IndexType_, T_ConcreteOtherType_?>("987", 456L),
                new KeyValuePair<T_IndexType_, T_ConcreteOtherType_?>("876", default)
            });

            T_ClassName_ concrete = builder.Build();

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
            duplicate.Should().Be(concrete);
            duplicate.Equals(concrete).Should().BeTrue();
        }
    }
}