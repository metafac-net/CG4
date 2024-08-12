using FluentAssertions;
using MetaFac.CG4.Runtime.MessagePack;
using MetaFac.Memory;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using T_Namespace_.Contracts;
using Xunit;

namespace MetaFac.CG4.Template.UnitTests
{
    using T_ExternalMaybeType_ = DayOfWeek;
    using T_ExternalOtherType_ = Int64;
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
                TemplateId.JsonNewtonSoft => new T_Namespace_.JsonNewtonSoft.T_EntityName_()
                {
                    T_UnaryModelFieldName_ = new T_Namespace_.JsonNewtonSoft.T_ModelType_(123),
                    T_ArrayModelFieldName_ = ImmutableList<T_Namespace_.JsonNewtonSoft.T_ModelType_?>.Empty.Add(new T_Namespace_.JsonNewtonSoft.T_ModelType_(234)),
                    T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_Namespace_.JsonNewtonSoft.T_ModelType_?>.Empty
                    .Add("987", new T_Namespace_.JsonNewtonSoft.T_ModelType_(456))
                    .Add("876", null),
                    T_UnaryOtherFieldName_ = 123L,
                    T_ArrayOtherFieldName_ = ImmutableList<T_Namespace_.JsonNewtonSoft.SampleInternal>.Empty.Add(234L),
                    T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, T_Namespace_.JsonNewtonSoft.SampleInternal>.Empty
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
                TemplateId.ClassesV2 => new T_Namespace_.ClassesV2.T_EntityName_()
                {
                    T_UnaryModelFieldName_ = new T_Namespace_.ClassesV2.T_ModelType_(123),
                    T_ArrayModelFieldName_ = ImmutableList<T_Namespace_.ClassesV2.T_ModelType_?>.Empty.Add(new T_Namespace_.ClassesV2.T_ModelType_(234)),
                    T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_Namespace_.ClassesV2.T_ModelType_?>.Empty
                    .Add("987", new T_Namespace_.ClassesV2.T_ModelType_(456))
                    .Add("876", null),
                    T_UnaryOtherFieldName_ = 123L,
                    T_ArrayOtherFieldName_ = ImmutableList<T_ExternalOtherType_>.Empty.Add(234L),
                    T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty
                    .Add("987", 456L)
                    .Add("876", default),
                    T_UnaryMaybeFieldName_ = null,
                    T_ArrayMaybeFieldName_ = ImmutableList<T_ExternalMaybeType_?>.Empty.Add(null).Add(T_ExternalMaybeType_.Monday),
                    T_IndexMaybeFieldName_ = ImmutableDictionary<T_IndexType_, T_ExternalMaybeType_?>.Empty
                    .Add("987", T_ExternalMaybeType_.Tuesday)
                    .Add("876", default),
                    T_UnaryBufferFieldName_ = new Octets(new byte[] { 1, 2, 3, 4 }),
                    T_ArrayBufferFieldName_ = ImmutableList.Create<Octets?>(
                        new Octets(new byte[] { 1, 2, 3, 4 }),
                        new Octets(new byte[] { 5, 6, 7, 8 })
                    ),
                    T_IndexBufferFieldName_ = ImmutableDictionary<T_IndexType_, Octets?>.Empty.AddRange(
                        new Dictionary<T_IndexType_, Octets?>
                        {
                            ["a"] = new Octets(new byte[] { 1, 2, 3, 4 }),
                            ["b"] = new Octets(new byte[] { 5, 6, 7, 8 }),
                        }
                    ),
                },
                TemplateId.MessagePack => new T_Namespace_.MessagePack.T_EntityName_()
                {
                    T_UnaryModelFieldName_ = new T_Namespace_.MessagePack.T_ModelType_(123),
                    T_ArrayModelFieldName_ = ImmutableList<T_Namespace_.MessagePack.T_ModelType_?>.Empty.Add(new T_Namespace_.MessagePack.T_ModelType_(234)),
                    T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_Namespace_.MessagePack.T_ModelType_?>.Empty
                    .Add("987", new T_Namespace_.MessagePack.T_ModelType_(456))
                    .Add("876", null),
                    T_UnaryOtherFieldName_ = 123L,
                    T_ArrayOtherFieldName_ = ImmutableList<T_ExternalOtherType_>.Empty.Add(234L),
                    T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty
                    .Add("987", 456L)
                    .Add("876", default),
                    T_UnaryMaybeFieldName_ = null,
                    T_ArrayMaybeFieldName_ = ImmutableList<T_ExternalMaybeType_?>.Empty.Add(null).Add(T_ExternalMaybeType_.Monday),
                    T_IndexMaybeFieldName_ = ImmutableDictionary<T_IndexType_, T_ExternalMaybeType_?>.Empty
                    .Add("987", T_ExternalMaybeType_.Tuesday)
                    .Add("876", default),
                    T_UnaryBufferFieldName_ = new Octets(new byte[] { 1, 2, 3, 4 }),
                    T_ArrayBufferFieldName_ = ImmutableList.Create<BinaryValue?>(
                        new Octets(new byte[] { 1, 2, 3, 4 }),
                        new Octets(new byte[] { 5, 6, 7, 8 })
                    ),
                    T_IndexBufferFieldName_ = ImmutableDictionary<T_IndexType_, BinaryValue?>.Empty.AddRange(
                        new Dictionary<T_IndexType_, BinaryValue?>
                        {
                            ["a"] = new Octets(new byte[] { 1, 2, 3, 4 }),
                            ["b"] = new Octets(new byte[] { 5, 6, 7, 8 }),
                        }
                    ),
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
                case TemplateId.JsonNewtonSoft:
                    ((T_Namespace_.JsonNewtonSoft.T_EntityName_)record).T_UnaryOtherFieldName_ = 234L;
                    break;
                case TemplateId.ClassesV2:
                    ((T_Namespace_.ClassesV2.T_EntityName_)record).T_UnaryOtherFieldName_ = 234L;
                    break;
                case TemplateId.MessagePack:
                    ((T_Namespace_.MessagePack.T_EntityName_)record).T_UnaryOtherFieldName_ = 234L;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(generator), generator, null);
            }

        }

        [Theory]
        [InlineData(TemplateId.ClassesV2)]
        [InlineData(TemplateId.MessagePack)]
        [InlineData(TemplateId.JsonNewtonSoft)]
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