using FluentAssertions;
using MetaFac.CG4.Attributes;
using MetaFac.CG4.Runtime;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using T_Namespace_.Contracts;
using T_Namespace_.JsonNewtonSoft;
using Xunit;

namespace MetaFac.CG4.Template.UnitTests
{
    using T_ExternalMaybeType_ = DayOfWeek;
    using T_ExternalOtherType_ = Int64;
    using T_IndexType_ = String;

    public class JsonNewtonSoftTests
    {
        [Fact]
        public void ImmutableBufferRoundtrip()
        {
            ReadOnlyMemory<byte> orig = new byte[] { 1, 2, 3 };
            ImmutableArray<byte> array1 = orig.ToImmutableArray();
            ReadOnlyMemory<byte> copy = array1.AsMemory();
            ImmutableArray<byte> array2 = copy.ToImmutableArray();

            copy.Length.Should().Be(orig.Length);
            //copy.Should().BeEquivalentTo(orig);

            array1.Length.Should().Be(array2.Length);
            array1.ArrayEquals(array2).Should().BeTrue();

            copy.ValueEquals(orig);
            array2.ValueEquals(array1);
        }

        [Fact]
        public void Create_Empty()
        {
            var concrete = T_EntityName__Factory.Instance.Empty;
            concrete.IsFreezable().Should().BeFalse();
            concrete.IsFrozen().Should().BeFalse();
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

            IT_EntityName_ external = concrete;
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
            duplicate.IsFreezable().Should().BeFalse();
            duplicate.IsFrozen().Should().BeFalse();
            duplicate.Freeze();
            duplicate.IsFrozen().Should().BeFalse();

            duplicate.T_UnaryModelFieldName_.Should().Be(concrete.T_UnaryModelFieldName_);
            duplicate.T_UnaryMaybeFieldName_.Should().Be(concrete.T_UnaryMaybeFieldName_);
            duplicate.T_UnaryOtherFieldName_.Should().Be(concrete.T_UnaryOtherFieldName_);
            duplicate.T_UnaryBufferFieldName_.Should().BeEquivalentTo(concrete.T_UnaryBufferFieldName_);
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

            duplicate.Should().Be(concrete);
            duplicate.Equals(concrete).Should().BeTrue();
        }

        private static readonly JsonSerializer serializer = new JsonSerializer()
        {
            Formatting = Formatting.Indented,
            //NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        private static string SerializeToJson<T>(T value)
        {
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, value);
                return writer.ToString();
            }
        }

        private static T DeserializeFromJson<T>(string buffer)
        {
            using var tr = new StringReader(buffer);
            using var reader = new JsonTextReader(tr);
            return serializer.Deserialize<T>(reader) ?? throw new JsonSerializationException();
        }

        [Fact]
        public void Roundtrip_Empty()
        {
            T_EntityName_ original = new T_EntityName_();
            string buffer = SerializeToJson(original);
            buffer.Length.Should().Be(2);

            T_EntityName_ duplicate = DeserializeFromJson<T_EntityName_>(buffer);
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
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
                T_ArrayOtherFieldName_ = ImmutableList<T_ExternalOtherType_>.Empty.Add(234L),
                T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty
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
            external.T_UnaryModelFieldName_.Should().NotBeNull();
            external.T_ArrayModelFieldName_.Should().NotBeNull();
            external.T_IndexModelFieldName_.Should().NotBeNull();
            external.T_UnaryOtherFieldName_.Should().Be(123L);
            external.T_ArrayOtherFieldName_.Should().NotBeNull();
            external.T_IndexOtherFieldName_.Should().NotBeNull();
            external.T_UnaryMaybeFieldName_.Should().BeNull();
            external.T_ArrayMaybeFieldName_.Should().NotBeNull();
            external.T_IndexMaybeFieldName_.Should().NotBeNull();
            external.T_UnaryBufferFieldName_.Should().NotBeNull();
            external.T_UnaryBufferFieldName_!.Length.Should().Be(4);

            var duplicate = new T_EntityName_(external);
            duplicate.T_UnaryModelFieldName_.Should().Be(original.T_UnaryModelFieldName_);
            duplicate.T_UnaryMaybeFieldName_.Should().Be(original.T_UnaryMaybeFieldName_);
            duplicate.T_UnaryOtherFieldName_.Should().Be(original.T_UnaryOtherFieldName_);
            duplicate.T_UnaryBufferFieldName_.ArrayEquals(original.T_UnaryBufferFieldName_).Should().BeTrue();
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

            duplicate.Equals(original).Should().BeTrue();
            duplicate.Should().Be(original);

            int originalHash = original.GetHashCode();
            int duplicateHash = duplicate.GetHashCode();
            duplicateHash.Should().Be(originalHash);
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
                T_ArrayOtherFieldName_ = ImmutableList<T_ExternalOtherType_>.Empty.Add(234L),
                T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty
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
            duplicate.T_UnaryModelFieldName_.Should().Be(original.T_UnaryModelFieldName_);
            duplicate.T_UnaryMaybeFieldName_.Should().Be(original.T_UnaryMaybeFieldName_);
            duplicate.T_UnaryOtherFieldName_.Should().Be(original.T_UnaryOtherFieldName_);
            duplicate.T_UnaryBufferFieldName_.ArrayEquals(original.T_UnaryBufferFieldName_).Should().BeTrue();
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

            duplicate.Equals(original).Should().BeTrue();
            duplicate.Should().Be(original);

            int originalHash = original.GetHashCode();
            int duplicateHash = duplicate.GetHashCode();
            duplicateHash.Should().Be(originalHash);
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
                T_ArrayOtherFieldName_ = ImmutableList<T_ExternalOtherType_>.Empty.Add(234L),
                T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty
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
            duplicate.T_UnaryModelFieldName_.Should().Be(original.T_UnaryModelFieldName_);
            duplicate.T_UnaryMaybeFieldName_.Should().Be(original.T_UnaryMaybeFieldName_);
            duplicate.T_UnaryOtherFieldName_.Should().Be(original.T_UnaryOtherFieldName_);
            duplicate.T_UnaryBufferFieldName_.ArrayEquals(original.T_UnaryBufferFieldName_).Should().BeTrue();
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

            duplicate.Equals(original).Should().BeTrue();
            duplicate.Should().Be(original);

            int originalHash = original.GetHashCode();
            int duplicateHash = duplicate.GetHashCode();
            duplicateHash.Should().Be(originalHash);
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
                T_ArrayOtherFieldName_ = ImmutableList<T_ExternalOtherType_>.Empty.Add(234L),
                T_IndexOtherFieldName_ = ImmutableDictionary<T_IndexType_, T_ExternalOtherType_>.Empty
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
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();

            int originalHash = original.GetHashCode();
            int duplicateHash = duplicate.GetHashCode();
            duplicateHash.Should().Be(originalHash);
        }

    }
}