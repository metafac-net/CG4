﻿using MessagePack;
using DataFac.Memory;
using Shouldly;
using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using Xunit;

namespace MetaFac.CG4.Template.UnitTests
{
    public enum TemplateId
    {
        None = 0,
        Contracts = 1,
        MessagePack = 2,
        ClassesV2 = 3,
        RecordsV2 = 4,
        JsonNewtonSoft = 5,
        JsonSystemText = 6,
    }

    public class RegressionTests
    {
        public enum WireFormat
        {
            MessagePack,
            JsonNewtonSoft,
            JsonSystemText,
            // todo JsonMessagePack,
            // todo ProtobufNet3
            // todo Bond (Fast)
            // todo Bond (Compact)
            // todo Protobuf
        }

        public enum TestFieldId
        {
            None,
            UnaryOther,
            UnaryMaybe,
            UnaryModel,
            UnaryChars,
            UnaryBytes,
            ArrayOther,
            ArrayMaybe,
            ArrayModel,
            ArrayChars,
            ArrayBytes,
        }

        private static readonly Newtonsoft.Json.JsonSerializer nsJsonSerializer = new Newtonsoft.Json.JsonSerializer()
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            //NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore
        };

        private static readonly System.Text.Json.JsonSerializerOptions msJsonSerializerOptions = new System.Text.Json.JsonSerializerOptions()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
        };

        private static readonly MessagePackSerializerOptions messagePackOptions
            = MessagePackSerializerOptions
                .Standard
                .WithCompression(MessagePackCompression.Lz4Block);

        private static string SerializeToNewtonsoftJson<T>(T value)
        {
            using (var writer = new StringWriter())
            {
                nsJsonSerializer.Serialize(writer, value);
                return writer.ToString();
            }
        }

        private static T DeserializeFromNewtonsoftJson<T>(string buffer)
        {
            using var tr = new StringReader(buffer);
            using var reader = new Newtonsoft.Json.JsonTextReader(tr);
            return nsJsonSerializer.Deserialize<T>(reader) ?? throw new Newtonsoft.Json.JsonSerializationException();
        }

        private static string CreateAndSerialize(WireFormat wf, T_Namespace_.Contracts.IT_EntityName_ source)
        {
            switch (wf)
            {
                case WireFormat.JsonSystemText:
                    {
                        var original = new T_Namespace_.JsonSystemText.T_EntityName_(source);
                        original.Freeze();
                        string text = System.Text.Json.JsonSerializer.Serialize(original, msJsonSerializerOptions);
                        return text;
                    }
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
                        string text = SerializeToNewtonsoftJson(original);
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
                case WireFormat.JsonSystemText:
                    {
                        var duplicate = System.Text.Json.JsonSerializer.Deserialize<T_Namespace_.JsonSystemText.T_EntityName_>(text, msJsonSerializerOptions);
                        return new T_Namespace_.RecordsV2.T_EntityName_(duplicate);
                    }
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
                        var duplicate = DeserializeFromNewtonsoftJson<T_Namespace_.JsonNewtonSoft.T_EntityName_>(text);
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
                case TestFieldId.UnaryOther:
                    return original with { T_UnaryOtherFieldName_ = 1L };
                case TestFieldId.UnaryMaybe:
                    return original with { T_UnaryMaybeFieldName_ = DayOfWeek.Monday };
                case TestFieldId.UnaryModel:
                    return original with { T_UnaryModelFieldName_ = new T_Namespace_.RecordsV2.T_ModelType_() { TestData = 123 } };
                case TestFieldId.UnaryChars:
                    return original with { T_UnaryStringFieldName_ = "abc" };
                case TestFieldId.UnaryBytes:
                    return original with { T_UnaryBufferFieldName_ = new Octets(new byte[] { 1, 2, 3 }) };
                case TestFieldId.ArrayOther:
                    return original with { T_ArrayOtherFieldName_ = ImmutableList.Create(-1L, 0L, 1L) };
                case TestFieldId.ArrayMaybe:
                    return original with { T_ArrayMaybeFieldName_ = ImmutableList.Create<DayOfWeek?>(DayOfWeek.Monday, null, DayOfWeek.Tuesday) };
                case TestFieldId.ArrayModel:
                    return original with
                    {
                        T_ArrayModelFieldName_ = ImmutableList.Create<T_Namespace_.RecordsV2.T_ModelType_?>(
                            new T_Namespace_.RecordsV2.T_ModelType_() { TestData = 123 }, null, new T_Namespace_.RecordsV2.T_ModelType_() { TestData = 456 })
                    };
                case TestFieldId.ArrayChars:
                    return original with { T_ArrayStringFieldName_ = ImmutableList.Create<string?>("abc", null, "def") };
                case TestFieldId.ArrayBytes:
                    return original with { T_ArrayBufferFieldName_ = ImmutableList.Create<Octets?>(new Octets(new byte[] { 1, 2, 3 }), null, new Octets(new byte[] { 4, 5, 6 })) };
                default:
                    throw new ArgumentOutOfRangeException(nameof(fieldId), fieldId, null);
            }
        }

        [Theory]
        [InlineData(WireFormat.MessagePack, "C7-1C-63-D2-00-00-00-77-6F-DC-00-74-C0-00-C0-01-00-4E-03-63-00-90-00-C0-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.JsonNewtonSoft, "{}")]
        [InlineData(WireFormat.JsonSystemText, "{}")]
        public void RoundTrip_MultiFormat_Empty(WireFormat wf, string expected)
        {
            var original = new T_Namespace_.RecordsV2.T_EntityName_() { };
            string serialized = CreateAndSerialize(wf, original);

            // check serialized bytes for regression
            serialized.ShouldBe(expected);

            // deserialize and compare to original
            var received = Deserialize(wf, serialized);
            received.ShouldBe(original);
            received.Equals(original).ShouldBeTrue();
            received.GetHashCode().ShouldBe(original.GetHashCode());
        }

        [Theory]
        [InlineData(WireFormat.MessagePack, TestFieldId.UnaryOther,
            "C7-1C-63-D2-00-00-00-77-6F-DC-00-74-C0-00-C0-01-00-4E-03-63-00-90-01-C0-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.MessagePack, TestFieldId.UnaryMaybe,
            "C7-1F-63-D2-00-00-00-77-6F-DC-00-74-C0-00-C0-01-00-4E-00-63-00-C0-01-C0-C0-00-C0-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.MessagePack, TestFieldId.UnaryModel,
            "C7-20-63-D2-00-00-00-79-6F-DC-00-74-C0-00-C0-01-00-4E-41-00-92-C0-7B-65-00-90-00-C0-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.MessagePack, TestFieldId.UnaryChars,
            "C7-1C-63-D2-00-00-00-7A-6F-DC-00-74-C0-00-C0-01-00-4E-03-63-00-02-07-00-60-A3-61-62-63-C0-C0")]
        [InlineData(WireFormat.MessagePack, TestFieldId.UnaryBytes,
            "C7-21-63-D2-00-00-00-7C-6F-DC-00-74-C0-00-C0-01-00-4E-03-63-00-E0-00-C0-C0-91-C4-03-01-02-03-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.MessagePack, TestFieldId.ArrayOther,
            "C7-1F-63-D2-00-00-00-7A-6F-DC-00-74-C0-00-C0-01-00-4E-03-63-00-C0-00-93-FF-00-01-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.MessagePack, TestFieldId.ArrayMaybe,
            "C7-21-63-D2-00-00-00-7A-6F-DC-00-74-C0-00-C0-01-00-4E-01-63-00-E0-93-01-C0-02-C0-00-C0-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.MessagePack, TestFieldId.ArrayModel,
            "C7-28-63-D2-00-00-00-80-6F-DC-00-74-C0-00-C0-01-00-4E-C0-00-C0-93-92-C0-7B-C0-92-C0-CD-01-C8-6D-00-90-00-C0-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.MessagePack, TestFieldId.ArrayChars,
            "C7-21-63-D2-00-00-00-80-6F-DC-00-74-C0-00-C0-01-00-4E-03-63-00-03-07-00-B0-93-A3-61-62-63-C0-A3-64-65-66-C0")]
        [InlineData(WireFormat.MessagePack, TestFieldId.ArrayBytes,
            "C7-29-63-D2-00-00-00-84-6F-DC-00-74-C0-00-C0-01-00-4E-03-63-00-00-07-00-F0-03-93-91-C4-03-01-02-03-C0-91-C4-03-04-05-06-C0-C0-C0-C0")]
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.UnaryOther,
            """
            {
              "T_UnaryOtherFieldName_": {
                "Value": 1
              }
            }
            """)]
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.UnaryMaybe,
            """
            {
              "T_UnaryMaybeFieldName_": 1
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
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.UnaryChars,
            """
            {
              "T_UnaryStringFieldName_": "abc"
            }
            """)]
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.UnaryBytes,
            """
            {
              "T_UnaryBufferFieldName_": "AQID"
            }
            """)]
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.ArrayOther,
            """
            {
              "T_ArrayOtherFieldName_": [
                {
                  "Value": -1
                },
                {},
                {
                  "Value": 1
                }
              ]
            }
            """)]
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.ArrayMaybe,
            """
            {
              "T_ArrayMaybeFieldName_": [
                1,
                null,
                2
              ]
            }
            """)]
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.ArrayModel,
            """
            {
              "T_ArrayModelFieldName_": [
                {
                  "TestData": 123
                },
                null,
                {
                  "TestData": 456
                }
              ]
            }
            """)]
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.ArrayChars,
            """
            {
              "T_ArrayStringFieldName_": [
                "abc",
                null,
                "def"
              ]
            }
            """)]
        [InlineData(WireFormat.JsonNewtonSoft, TestFieldId.ArrayBytes,
            """
            {
              "T_ArrayBufferFieldName_": [
                "AQID",
                null,
                "BAUG"
              ]
            }
            """)]
        [InlineData(WireFormat.JsonSystemText, TestFieldId.UnaryOther,
            """
            {
              "T_UnaryOtherFieldName_": {
                "Value": 1
              }
            }
            """)]
        [InlineData(WireFormat.JsonSystemText, TestFieldId.UnaryMaybe,
            """
            {
              "T_UnaryMaybeFieldName_": 1
            }
            """)]
        [InlineData(WireFormat.JsonSystemText, TestFieldId.UnaryModel,
            """
            {
              "T_UnaryModelFieldName_": {
                "TestData": 123
              }
            }
            """)]
        [InlineData(WireFormat.JsonSystemText, TestFieldId.UnaryChars,
            """
            {
              "T_UnaryStringFieldName_": "abc"
            }
            """)]
        [InlineData(WireFormat.JsonSystemText, TestFieldId.UnaryBytes,
            """
            {
              "T_UnaryBufferFieldName_": "AQID"
            }
            """)]
        [InlineData(WireFormat.JsonSystemText, TestFieldId.ArrayOther,
            """
            {
              "T_ArrayOtherFieldName_": [
                {
                  "Value": -1
                },
                {},
                {
                  "Value": 1
                }
              ]
            }
            """)]
        [InlineData(WireFormat.JsonSystemText, TestFieldId.ArrayMaybe,
            """
            {
              "T_ArrayMaybeFieldName_": [
                1,
                null,
                2
              ]
            }
            """)]
        [InlineData(WireFormat.JsonSystemText, TestFieldId.ArrayModel,
            """
            {
              "T_ArrayModelFieldName_": [
                {
                  "TestData": 123
                },
                null,
                {
                  "TestData": 456
                }
              ]
            }
            """)]
        [InlineData(WireFormat.JsonSystemText, TestFieldId.ArrayChars,
            """
            {
              "T_ArrayStringFieldName_": [
                "abc",
                null,
                "def"
              ]
            }
            """)]
        [InlineData(WireFormat.JsonSystemText, TestFieldId.ArrayBytes,
            """
            {
              "T_ArrayBufferFieldName_": [
                "AQID",
                null,
                "BAUG"
              ]
            }
            """)]
        public void RoundTrip_MultiFormat_NonEmpty(WireFormat wf, TestFieldId fieldId, string expected)
        {
            var original = new T_Namespace_.RecordsV2.T_EntityName_() { };
            original = ModifyRecord(original, fieldId);
            string serialized = CreateAndSerialize(wf, original);

            // check serialized bytes for regression
            serialized.ShouldBe(expected);

            // deserialize and compare to original
            var received = Deserialize(wf, serialized);
            received.ShouldBe(original);
            received.Equals(original).ShouldBeTrue();
            received.GetHashCode().ShouldBe(original.GetHashCode());
        }

    }
}
