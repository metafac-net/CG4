using FluentAssertions;
using System.Collections.Immutable;
using T_Namespace_.Contracts;
using Xunit;

namespace MetaFac.CG4.TemplateNet7.Tests
{
    using T_ExternalMaybeType_ = DayOfWeek;
    using T_IndexType_ = String;

    public class HashCodeTests
    {
        private static IT_EntityName_ CreateTestRecord(TemplateId generator)
        {
            return generator switch
            {
                TemplateId.JsonSystemText => new T_Namespace_.JsonSystemText.T_EntityName_()
                {
                    T_UnaryModelFieldName_ = new T_Namespace_.JsonSystemText.T_ModelType_(123),
                    T_ArrayModelFieldName_ = ImmutableList<T_Namespace_.JsonSystemText.T_ModelType_?>.Empty.Add(new T_Namespace_.JsonSystemText.T_ModelType_(234)),
                    T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_Namespace_.JsonSystemText.T_ModelType_?>.Empty
                    .Add("987", new T_Namespace_.JsonSystemText.T_ModelType_(456))
                    .Add("876", null),
                    T_UnaryOtherFieldName_ = 123L,
                    T_ArrayOtherFieldName_ = ImmutableList<T_Namespace_.JsonSystemText.SampleInternal>.Empty.Add(234L),
                    T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, T_Namespace_.JsonSystemText.SampleInternal>.Empty
                    .Add("987", 456L)
                    .Add("876", default),
                    T_UnaryMaybeFieldName_ = null,
                    T_ArrayMaybeFieldName_ = ImmutableList<T_ExternalMaybeType_?>.Empty.Add(null).Add(T_ExternalMaybeType_.Monday),
                    T_IndexMaybeFieldName_ = ImmutableDictionary<T_IndexType_, T_ExternalMaybeType_?>.Empty
                    .Add("987", T_ExternalMaybeType_.Tuesday)
                    .Add("876", default),
                    T_UnaryBufferFieldName_ = new byte[] { 1, 2, 3, 4 },
                    T_ArrayBufferFieldName_ = new byte[]?[]
                    {
                        new byte[] { 1, 2, 3, 4 },
                        new byte[] { 5, 6, 7, 8 },
                    },
                    T_IndexBufferFieldName_ = new Dictionary<T_IndexType_, byte[]?>()
                    {
                        ["a"] = new byte[] { 1, 2, 3, 4 },
                        ["b"] = new byte[] { 5, 6, 7, 8 },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(generator), generator, null)
            };
        }
        private static void ModifyTestRecord(TemplateId generator, IT_EntityName_ record)
        {
            switch (generator)
            {
                case TemplateId.JsonSystemText:
                    ((T_Namespace_.JsonSystemText.T_EntityName_)record).T_UnaryOtherFieldName_ = 234L;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(generator), generator, null);
            }

        }

        [Theory]
        [InlineData(TemplateId.JsonSystemText)]
        public void HashShouldChangeWhenModified(TemplateId generator)
        {
            // arrange
            var original = CreateTestRecord(generator);
            int originalHash = original.GetHashCode();

            // act
            ModifyTestRecord(generator, original);

            // assert
            int modifiedHash = original.GetHashCode();
            modifiedHash.Should().NotBe(originalHash);
        }

    }
}