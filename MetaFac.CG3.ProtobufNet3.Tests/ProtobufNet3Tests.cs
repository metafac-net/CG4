using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using ProtoBuf;
using Xunit;

using T_Namespace_.Interfaces;
using T_Namespace_.ProtobufNet3;

namespace MetaCode.TS3.ProtobufNet3.Tests
{
    //>>using (Ignored()) {
    using T_IndexType_ = System.String;
    using T_ExternalOtherType_ = System.Int64;
    using T_ConcreteOtherType_ = System.Int64;
    //>>}

    public class ProtobufNet3Tests
    {
        [Fact]
        public void Create_Empty()
        {
            var concrete = new T_ClassName_();
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
            external.T_UnaryStringFieldName_.Should().Be(default);
            external.T_ArrayStringFieldName_.Should().BeNull();
            external.T_IndexStringFieldName_.Should().BeNull();

            var duplicate = new T_ClassName_(external);
            duplicate.Should().Be(concrete);
            duplicate.Equals(concrete).Should().BeTrue();
        }

        [Fact]
        public void Create_NonEmpty()
        {
            var concrete = new T_ClassName_();
            concrete.T_UnaryModelFieldName_ = new T_ModelType_() { TestData = 123 };
            concrete.T_ArrayModelFieldName_ = new[] { new T_ModelType_() { TestData = 234 } };
            concrete.T_IndexModelFieldName_ = new Dictionary<T_IndexType_, T_ModelType_?>()
            {
                ["987"] = new T_ModelType_() { TestData = 456 },
                ["876"] = null,
            };

            concrete.T_UnaryOtherFieldName_ = 123L;
            concrete.T_ArrayOtherFieldName_ = new[] { 234L };
            concrete.T_IndexOtherFieldName_ = new Dictionary<T_IndexType_, T_ConcreteOtherType_>()
            {
                ["987"] = 456L,
                ["876"] = default(T_ConcreteOtherType_),
            };

            concrete.T_UnaryMaybeFieldName_ = null;
            concrete.T_ArrayMaybeFieldName_ = new T_ConcreteOtherType_?[] { null, 234L };
            concrete.T_IndexMaybeFieldName_ = new Dictionary<T_IndexType_, T_ConcreteOtherType_?>()
            {
                ["987"] = 456L,
                ["876"] = null,
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
            duplicate.Should().Be(concrete);
            duplicate.Equals(concrete).Should().BeTrue();
        }

        [Fact]
        public void Roundtrip_Empty()
        {
            var original = new T_ClassName_();
            byte[] buffer;
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize<T_ClassName_>(ms, original);
                buffer = ms.ToArray();
            }
            T_ClassName_ duplicate;
            using (var ms = new MemoryStream(buffer))
            {
                duplicate = Serializer.Deserialize<T_ClassName_>(ms);
            }
            duplicate.Should().Be(original);
            duplicate.Equals(original).Should().BeTrue();
        }

        [Fact]
        public void Roundtrip_NonEmpty()
        {
            var original = new T_ClassName_();
            original.T_UnaryModelFieldName_ = new T_ModelType_() { TestData = 123 };
            original.T_ArrayModelFieldName_ = new[] { new T_ModelType_() { TestData = 234 } };
            original.T_IndexModelFieldName_ = new Dictionary<T_IndexType_, T_ModelType_?>()
            {
                ["987"] = new T_ModelType_() { TestData = 456 },
                ["876"] = new T_ModelType_() { TestData = 567 }, // todo protobuf-net ignores null elements!
            };

            original.T_UnaryOtherFieldName_ = 123L;
            original.T_ArrayOtherFieldName_ = new[] { 234L };
            original.T_IndexOtherFieldName_ = new Dictionary<T_IndexType_, T_ConcreteOtherType_>()
            {
                ["987"] = 456L,
                ["876"] = default(T_ConcreteOtherType_),
            };

            original.T_UnaryMaybeFieldName_ = null;
            original.T_ArrayMaybeFieldName_ = new T_ConcreteOtherType_?[] { 234L }; // todo protobuf-net ignores null elements!
            original.T_IndexMaybeFieldName_ = new Dictionary<T_IndexType_, T_ConcreteOtherType_?>()
            {
                ["987"] = 456L,
                ["876"] = 567L, // todo protobuf-net ignores null elements!
            };

            byte[] buffer;
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize<T_ClassName_>(ms, original);
                buffer = ms.ToArray();
            }
            T_ClassName_ duplicate;
            using (var ms = new MemoryStream(buffer))
            {
                duplicate = Serializer.Deserialize<T_ClassName_>(ms);
            }
            duplicate.Equals(original).Should().BeTrue();
            duplicate.Should().Be(original);
        }

    }
}
