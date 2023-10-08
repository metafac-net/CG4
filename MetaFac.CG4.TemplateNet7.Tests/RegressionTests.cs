using FluentAssertions;
using MetaFac.Memory;
using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using Xunit;

namespace MetaFac.CG4.TemplateNet7.Tests
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
            JsonSystemText,
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

        private static readonly System.Text.Json.JsonSerializerOptions msJsonSerializerOptions = new System.Text.Json.JsonSerializerOptions()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
        };

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
        [InlineData(WireFormat.JsonSystemText, "{}")]
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
            serialized.Should().Be(expected);

            // deserialize and compare to original
            var received = Deserialize(wf, serialized);
            received.Should().Be(original);
            received.Equals(original).Should().BeTrue();
            received.GetHashCode().Should().Be(original.GetHashCode());
        }

    }
}
