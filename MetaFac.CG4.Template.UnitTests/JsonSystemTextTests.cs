using MetaFac.CG4.Runtime;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json;
using T_Namespace_.Contracts;
using T_Namespace_.JsonSystemText;
using Xunit;

namespace MetaFac.CG4.Template.UnitTests
{
    using T_ExternalMaybeType_ = DayOfWeek;
    using T_IndexType_ = String;

    public class JsonSystemTextTests
    {
        [Fact]
        public void ImmutableBufferRoundtrip()
        {
            ReadOnlyMemory<byte> orig = new byte[] { 1, 2, 3 };
            ImmutableArray<byte> array1 = ImmutableArray.Create(orig.Span);
            ReadOnlyMemory<byte> copy = array1.AsMemory();
            ImmutableArray<byte> array2 = ImmutableArray.Create(copy.Span);

            copy.Length.ShouldBe(orig.Length);
            //copy.ShouldBeEquivalentTo(orig);

            array1.Length.ShouldBe(array2.Length);
            array1.ArrayEquals(array2).ShouldBeTrue();

            copy.ValueEquals(orig);
            array2.ValueEquals(array1);
        }

        [Fact]
        public void Create_Empty()
        {
            var concrete = T_EntityName__Factory.Instance.Empty;
            concrete.IsFreezable().ShouldBeFalse();
            concrete.IsFrozen().ShouldBeFalse();
            concrete.T_UnaryModelFieldName_.ShouldBeNull();
            concrete.T_ArrayModelFieldName_.ShouldBeNull();
            concrete.T_IndexModelFieldName_.ShouldBeNull();
            concrete.T_UnaryOtherFieldName_.ShouldBe(new SampleInternal(0));
            concrete.T_ArrayOtherFieldName_.ShouldBeNull();
            concrete.T_IndexOtherFieldName_.ShouldBeNull();
            concrete.T_UnaryMaybeFieldName_.ShouldBeNull();
            concrete.T_ArrayMaybeFieldName_.ShouldBeNull();
            concrete.T_IndexMaybeFieldName_.ShouldBeNull();
            concrete.T_UnaryBufferFieldName_.ShouldBeNull();
            concrete.T_ArrayBufferFieldName_.ShouldBeNull();
            concrete.T_IndexBufferFieldName_.ShouldBeNull();
            concrete.T_UnaryStringFieldName_.ShouldBeNull();
            concrete.T_ArrayStringFieldName_.ShouldBeNull();
            concrete.T_IndexStringFieldName_.ShouldBeNull();

            IT_EntityName_ external = concrete;
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
            duplicate.IsFreezable().ShouldBeFalse();
            duplicate.IsFrozen().ShouldBeFalse();
            duplicate.Freeze();
            duplicate.IsFrozen().ShouldBeFalse();

            duplicate.T_UnaryModelFieldName_.ShouldBe(concrete.T_UnaryModelFieldName_);
            duplicate.T_UnaryMaybeFieldName_.ShouldBe(concrete.T_UnaryMaybeFieldName_);
            duplicate.T_UnaryOtherFieldName_.ShouldBe(concrete.T_UnaryOtherFieldName_);
            duplicate.T_UnaryBufferFieldName_.ShouldBeEquivalentTo(concrete.T_UnaryBufferFieldName_);
            duplicate.T_UnaryStringFieldName_.ShouldBe(concrete.T_UnaryStringFieldName_);
            duplicate.T_ArrayModelFieldName_.ShouldBeEquivalentTo(concrete.T_ArrayModelFieldName_);
            duplicate.T_ArrayMaybeFieldName_.ShouldBeEquivalentTo(concrete.T_ArrayMaybeFieldName_);
            duplicate.T_ArrayOtherFieldName_.ShouldBeEquivalentTo(concrete.T_ArrayOtherFieldName_);
            duplicate.T_ArrayBufferFieldName_.ShouldBeEquivalentTo(concrete.T_ArrayBufferFieldName_);
            duplicate.T_ArrayStringFieldName_.ShouldBeEquivalentTo(concrete.T_ArrayStringFieldName_);
            duplicate.T_IndexModelFieldName_.ShouldBeEquivalentTo(concrete.T_IndexModelFieldName_);
            duplicate.T_IndexMaybeFieldName_.ShouldBeEquivalentTo(concrete.T_IndexMaybeFieldName_);
            duplicate.T_IndexOtherFieldName_.ShouldBeEquivalentTo(concrete.T_IndexOtherFieldName_);
            duplicate.T_IndexBufferFieldName_.ShouldBeEquivalentTo(concrete.T_IndexBufferFieldName_);
            duplicate.T_IndexStringFieldName_.ShouldBeEquivalentTo(concrete.T_IndexStringFieldName_);

            duplicate.ShouldBe(concrete);
            duplicate.Equals(concrete).ShouldBeTrue();
        }

        private static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault,
        };

        private static string SerializeToJson<T>(T value)
        {
            return JsonSerializer.Serialize(value, serializerOptions);
        }

        private static T DeserializeFromJson<T>(string buffer)
        {
            return JsonSerializer.Deserialize<T>(buffer) ?? throw new JsonException();
        }

        [Fact]
        public void Roundtrip_Empty()
        {
            T_EntityName_ original = new T_EntityName_();
            string buffer = SerializeToJson(original);
            buffer.Length.ShouldBe(2);

            T_EntityName_ duplicate = DeserializeFromJson<T_EntityName_>(buffer);
            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();
        }

        [Fact]
        public void Create_NonEmpty1()
        {
            var original = new T_EntityName_()
            {
                T_UnaryModelFieldName_ = new T_ModelType_(123),
                T_ArrayModelFieldName_ = ImmutableList<T_ModelType_?>.Empty.Add(new T_ModelType_(234)),
                T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty
                    .Add("987", new T_ModelType_(456))
                    .Add("876", null),
                T_UnaryOtherFieldName_ = 123L,
                T_ArrayOtherFieldName_ = ImmutableList<SampleInternal>.Empty.Add(234L),
                T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, SampleInternal>.Empty
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
            };
            original.Freeze();

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
            external.T_UnaryBufferFieldName_.ShouldNotBeNull();
            external.T_UnaryBufferFieldName_!.Length.ShouldBe(4);

            var duplicate = new T_EntityName_(external);
            duplicate.T_UnaryModelFieldName_.ShouldBe(original.T_UnaryModelFieldName_);
            duplicate.T_UnaryMaybeFieldName_.ShouldBe(original.T_UnaryMaybeFieldName_);
            duplicate.T_UnaryOtherFieldName_.ShouldBe(original.T_UnaryOtherFieldName_);
            duplicate.T_UnaryBufferFieldName_.ArrayEquals(original.T_UnaryBufferFieldName_).ShouldBeTrue();
            duplicate.T_UnaryStringFieldName_.ShouldBe(original.T_UnaryStringFieldName_);
            duplicate.T_ArrayModelFieldName_.ShouldBeEquivalentTo(original.T_ArrayModelFieldName_);
            duplicate.T_ArrayMaybeFieldName_.ShouldBeEquivalentTo(original.T_ArrayMaybeFieldName_);
            duplicate.T_ArrayOtherFieldName_.ShouldBeEquivalentTo(original.T_ArrayOtherFieldName_);
            duplicate.T_ArrayBufferFieldName_.ShouldBeEquivalentTo(original.T_ArrayBufferFieldName_);
            duplicate.T_ArrayStringFieldName_.ShouldBeEquivalentTo(original.T_ArrayStringFieldName_);
            duplicate.T_IndexModelFieldName_.ShouldBeEquivalentTo(original.T_IndexModelFieldName_);
            duplicate.T_IndexMaybeFieldName_.ShouldBeEquivalentTo(original.T_IndexMaybeFieldName_);
            duplicate.T_IndexOtherFieldName_.ShouldBeEquivalentTo(original.T_IndexOtherFieldName_);
            duplicate.T_IndexBufferFieldName_.IndexEquals(original.T_IndexBufferFieldName_).ShouldBeTrue();
            duplicate.T_IndexStringFieldName_.ShouldBeEquivalentTo(original.T_IndexStringFieldName_);

            duplicate.Equals(original).ShouldBeTrue();
            duplicate.ShouldBe(original);

            int originalHash = original.GetHashCode();
            int duplicateHash = duplicate.GetHashCode();
            duplicateHash.ShouldBe(originalHash);
        }

        [Fact]
        public void Create_NonEmpty2()
        {
            var original = new T_EntityName_()
            {
                T_UnaryModelFieldName_ = new T_ModelType_(123),
                T_ArrayModelFieldName_ = ImmutableList<T_ModelType_?>.Empty.Add(new T_ModelType_(234)),
                T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty
                    .Add("987", new T_ModelType_(456))
                    .Add("876", null),
                T_UnaryOtherFieldName_ = 123L,
                T_ArrayOtherFieldName_ = ImmutableList<SampleInternal>.Empty.Add(234L),
                T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, SampleInternal>.Empty
                    .Add("987", 456L)
                    .Add("876", default),
                T_UnaryMaybeFieldName_ = null,
                T_ArrayMaybeFieldName_ = ImmutableList<T_ExternalMaybeType_?>.Empty.Add(null).Add(DayOfWeek.Monday),
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
            };
            original.Freeze();

            var duplicate = new T_EntityName_(original);
            duplicate.T_UnaryModelFieldName_.ShouldBe(original.T_UnaryModelFieldName_);
            duplicate.T_UnaryMaybeFieldName_.ShouldBe(original.T_UnaryMaybeFieldName_);
            duplicate.T_UnaryOtherFieldName_.ShouldBe(original.T_UnaryOtherFieldName_);
            duplicate.T_UnaryBufferFieldName_.ArrayEquals(original.T_UnaryBufferFieldName_).ShouldBeTrue();
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

            duplicate.Equals(original).ShouldBeTrue();
            duplicate.ShouldBe(original);

            int originalHash = original.GetHashCode();
            int duplicateHash = duplicate.GetHashCode();
            duplicateHash.ShouldBe(originalHash);
        }

        [Fact]
        public void Create_NonEmpty3()
        {
            var original = new T_EntityName_()
            {
                T_UnaryModelFieldName_ = new T_ModelType_(123),
                T_ArrayModelFieldName_ = ImmutableList<T_ModelType_?>.Empty.Add(new T_ModelType_(234)),
                T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty
                    .Add("987", new T_ModelType_(456))
                    .Add("876", null),
                T_UnaryOtherFieldName_ = 123L,
                T_ArrayOtherFieldName_ = ImmutableList<SampleInternal>.Empty.Add(234L),
                T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, SampleInternal>.Empty
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
            };
            original.Freeze();

            var duplicate = new T_EntityName_();
            duplicate.CopyFrom(original);
            duplicate.T_UnaryModelFieldName_.ShouldBe(original.T_UnaryModelFieldName_);
            duplicate.T_UnaryMaybeFieldName_.ShouldBe(original.T_UnaryMaybeFieldName_);
            duplicate.T_UnaryOtherFieldName_.ShouldBe(original.T_UnaryOtherFieldName_);
            duplicate.T_UnaryBufferFieldName_.ArrayEquals(original.T_UnaryBufferFieldName_).ShouldBeTrue();
            duplicate.T_UnaryStringFieldName_.ShouldBe(original.T_UnaryStringFieldName_);
            duplicate.T_ArrayModelFieldName_.ShouldBeEquivalentTo(original.T_ArrayModelFieldName_);
            duplicate.T_ArrayMaybeFieldName_.ShouldBeEquivalentTo(original.T_ArrayMaybeFieldName_);
            duplicate.T_ArrayOtherFieldName_.ShouldBeEquivalentTo(original.T_ArrayOtherFieldName_);
            duplicate.T_ArrayBufferFieldName_.ShouldBeEquivalentTo(original.T_ArrayBufferFieldName_);
            duplicate.T_ArrayStringFieldName_.ShouldBeEquivalentTo(original.T_ArrayStringFieldName_);
            duplicate.T_IndexModelFieldName_.ShouldBeEquivalentTo(original.T_IndexModelFieldName_);
            duplicate.T_IndexMaybeFieldName_.ShouldBeEquivalentTo(original.T_IndexMaybeFieldName_);
            duplicate.T_IndexOtherFieldName_.ShouldBeEquivalentTo(original.T_IndexOtherFieldName_);
            duplicate.T_IndexBufferFieldName_.IndexEquals(original.T_IndexBufferFieldName_).ShouldBeTrue();
            duplicate.T_IndexStringFieldName_.ShouldBeEquivalentTo(original.T_IndexStringFieldName_);

            duplicate.Equals(original).ShouldBeTrue();
            duplicate.ShouldBe(original);

            int originalHash = original.GetHashCode();
            int duplicateHash = duplicate.GetHashCode();
            duplicateHash.ShouldBe(originalHash);
        }

        [Fact]
        public void Roundtrip_NonEmpty()
        {
            var original = new T_EntityName_()
            {
                T_UnaryModelFieldName_ = new T_ModelType_(123),
                T_ArrayModelFieldName_ = ImmutableList<T_ModelType_?>.Empty.Add(new T_ModelType_(234)),
                T_IndexModelFieldName_ = ImmutableDictionary<T_IndexType_, T_ModelType_?>.Empty
                    .Add("987", new T_ModelType_(456))
                    .Add("876", null),
                T_UnaryOtherFieldName_ = 123L,
                T_ArrayOtherFieldName_ = ImmutableList<SampleInternal>.Empty.Add(234L),
                T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, SampleInternal>.Empty
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
            };
            var buffer = SerializeToJson(original);
            var duplicate = DeserializeFromJson<T_EntityName_>(buffer);
            duplicate.ShouldBe(original);
            duplicate.Equals(original).ShouldBeTrue();

            int originalHash = original.GetHashCode();
            int duplicateHash = duplicate.GetHashCode();
            duplicateHash.ShouldBe(originalHash);
        }

    }
}