﻿using FluentAssertions;
using MessagePack;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaFac.CG4.Template.UnitTests
{
    public class RegressionTests
    {
        public enum WireFormat
        {
            MessagePack,
            JsonNewtonSoft,
        }

        public enum TestFieldId
        {
            None,
            UnaryOther,
            UnaryMaybe,
            UnaryModel,
        }

        private static readonly JsonSerializer jsonSerializer = new JsonSerializer()
        {
            Formatting = Formatting.Indented,
            //NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        private static readonly MessagePackSerializerOptions messagePackOptions
            = MessagePackSerializerOptions
                .Standard
                .WithCompression(MessagePackCompression.Lz4Block);

        private static string SerializeToJson<T>(T value)
        {
            using (var writer = new StringWriter())
            {
                jsonSerializer.Serialize(writer, value);
                return writer.ToString();
            }
        }

        private static T DeserializeFromJson<T>(string buffer)
        {
            using var tr = new StringReader(buffer);
            using var reader = new JsonTextReader(tr);
            return jsonSerializer.Deserialize<T>(reader) ?? throw new JsonSerializationException();
        }

        private static string CreateAndSerialize(WireFormat wf, T_Namespace_.Contracts.IT_EntityName_ source)
        {
            switch (wf)
            {
                case WireFormat.MessagePack:
                    {
                        var original = new T_Namespace_.MessagePack.T_EntityName_(source);
                        original.Freeze();
                        byte[] buffer = MessagePackSerializer.Serialize(original, messagePackOptions);
                        string text = string.Join('-', buffer.Select(b => b.ToString("X2")));
                        return text;
                    }
                case WireFormat.JsonNewtonSoft:
                    {
                        var original = new T_Namespace_.JsonNewtonSoft.T_EntityName_(source);
                        original.Freeze();
                        string text = SerializeToJson(original);
                        return text;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(wf), wf, null);
            }
        }

        private static T_Namespace_.RecordsV2.T_EntityName_ Deserialize(WireFormat wf, string text)
        {
            switch (wf)
            {
                case WireFormat.MessagePack:
                    {
                        var bytes = text.Split('-');
                        byte[] buffer = new byte[bytes.Length];
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            buffer[i] = byte.Parse(bytes[i], System.Globalization.NumberStyles.HexNumber);
                        }
                        var duplicate = MessagePackSerializer.Deserialize<T_Namespace_.MessagePack.T_EntityName_>(buffer, messagePackOptions);
                        return new T_Namespace_.RecordsV2.T_EntityName_(duplicate);
                    }
                case WireFormat.JsonNewtonSoft:
                    {
                        var duplicate = DeserializeFromJson<T_Namespace_.JsonNewtonSoft.T_EntityName_>(text);
                        return new T_Namespace_.RecordsV2.T_EntityName_(duplicate);
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(wf), wf, null);
            }
        }

        private static T_Namespace_.RecordsV2.T_EntityName_ ModifyRecord(T_Namespace_.RecordsV2.T_EntityName_ original, TestFieldId fieldId)
        {
            switch (fieldId)
            {
                case TestFieldId.UnaryOther: return original with { T_UnaryOtherFieldName_ = 1L };
                case TestFieldId.UnaryMaybe: return original with { T_UnaryMaybeFieldName_ = 2L };
                case TestFieldId.UnaryModel: return original with { T_UnaryModelFieldName_ = new T_Namespace_.RecordsV2.T_ModelType_() { TestData = 123 } };
                default: return original;
            }
        }

        [Theory]
        [InlineData(WireFormat.MessagePack, "C7-1C-63-D2-00-00-00-77-6F-DC-00-74-C0-00-C0-01-00-4E-03-63-00-90-00-C0-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.JsonNewtonSoft, "{}")]
        public void RoundTrip_MultiFormat_Empty(WireFormat wf, string expected)
        {
            var original = new T_Namespace_.RecordsV2.T_EntityName_() { };
            string serialized = CreateAndSerialize(wf, original);

            // check serialized bytes for regression
            serialized.Should().Be(expected);

            // deserialize and compare to original
            var received = Deserialize(wf, serialized);
            received.Should().Be(original);
            received.Equals(original).Should().BeTrue();
            received.GetHashCode().Should().Be(original.GetHashCode());
        }

        [Theory]
        [InlineData(WireFormat.MessagePack, TestFieldId.UnaryOther, 
            "C7-1C-63-D2-00-00-00-77-6F-DC-00-74-C0-00-C0-01-00-4E-03-63-00-90-01-C0-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.MessagePack, TestFieldId.UnaryMaybe, 
            "C7-1F-63-D2-00-00-00-77-6F-DC-00-74-C0-00-C0-01-00-4E-00-63-00-C0-02-C0-C0-00-C0-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.MessagePack, TestFieldId.UnaryModel, 
            "C7-20-63-D2-00-00-00-79-6F-DC-00-74-C0-00-C0-01-00-4E-41-00-92-C0-7B-65-00-90-00-C0-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.UnaryOther,
            """
            {
              "T_UnaryOtherFieldName_": 1
            }
            """)]
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.UnaryMaybe,
            """
            {
              "T_UnaryMaybeFieldName_": 2
            }
            """)]
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.UnaryModel,
            """
            {
              "T_UnaryModelFieldName_": {
                "TestData": 123
              }
            }
            """)]
        public void RoundTrip_MultiFormat_NonEmpty(WireFormat wf, TestFieldId fieldId, string expected)
        {
            var original = new T_Namespace_.RecordsV2.T_EntityName_() { };
            original = ModifyRecord(original, fieldId);
            string serialized = CreateAndSerialize(wf, original);

            // check serialized bytes for regression
            serialized.Should().Be(expected);

            // deserialize and compare to original
            var received = Deserialize(wf, serialized);
            received.Should().Be(original);
            received.Equals(original).Should().BeTrue();
            received.GetHashCode().Should().Be(original.GetHashCode());
        }

    }
}
