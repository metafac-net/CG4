using FluentAssertions;
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

        private static readonly JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };

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

        private static string CreateAndSerialize(WireFormat wf, T_Namespace_.Contracts.IT_EntityName_ source)
        {
            switch (wf)
            {
                case WireFormat.MessagePack:
                    {
                        var options = MessagePackSerializerOptions.Standard
                            .WithCompression(MessagePackCompression.Lz4Block);
                        var original = new T_Namespace_.MessagePack.T_EntityName_(source);
                        original.Freeze();
                        byte[] buffer = MessagePackSerializer.Serialize(original, options);
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
                        var options = MessagePackSerializerOptions.Standard
                            .WithCompression(MessagePackCompression.Lz4Block);
                        var duplicate = MessagePackSerializer.Deserialize<T_Namespace_.MessagePack.T_EntityName_>(buffer, options);
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

        [Theory]
        [InlineData(WireFormat.MessagePack, "C7-1C-63-D2-00-00-00-77-6F-DC-00-74-C0-00-C0-01-00-4E-03-63-00-90-00-C0-C0-C0-C0-C0-C0-C0-C0")]
        [InlineData(WireFormat.JsonNewtonSoft,
            """
            {
              "T_UnaryModelFieldName_": null,
              "T_ArrayModelFieldName_": null,
              "T_IndexModelFieldName_": null,
              "T_UnaryMaybeFieldName_": null,
              "T_ArrayMaybeFieldName_": null,
              "T_IndexMaybeFieldName_": null,
              "T_UnaryOtherFieldName_": 0,
              "T_ArrayOtherFieldName_": null,
              "T_IndexOtherFieldName_": null,
              "T_UnaryBufferFieldName_": null,
              "T_ArrayBufferFieldName_": null,
              "T_IndexBufferFieldName_": null,
              "T_UnaryStringFieldName_": null,
              "T_ArrayStringFieldName_": null,
              "T_IndexStringFieldName_": null
            }
            """)]
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

    }
}
