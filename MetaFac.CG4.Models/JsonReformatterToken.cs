using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace MetaFac.CG4.Models
{
    public static class JsonReformatter
    {
        public static IReadOnlyList<JsonReformatterToken> ReadTokens(ReadOnlySpan<byte> jsonData)
        {
            var tokens = new List<JsonReformatterToken>();
            var reader = new Utf8JsonReader(jsonData, true, default);
            while (reader.Read())
            {
                var tokenType = reader.TokenType;
                int depth = reader.CurrentDepth;
                switch (tokenType)
                {
                    case JsonTokenType.StartObject:
                    case JsonTokenType.EndObject:
                    case JsonTokenType.StartArray:
                    case JsonTokenType.EndArray:
                    case JsonTokenType.Null:
                    case JsonTokenType.True:
                    case JsonTokenType.False:
                        tokens.Add(new JsonReformatterToken(depth, tokenType));
                        break;
                    case JsonTokenType.PropertyName:
                        string propText = reader.GetString() ?? throw new InvalidDataException("Property name cannot be null");
                        tokens.Add(new JsonReformatterToken(depth, tokenType, propText));
                        break;
                    case JsonTokenType.String:
                        string strText = reader.GetString() ?? throw new InvalidDataException("String value cannot be null");
                        tokens.Add(new JsonReformatterToken(depth, JsonTokenType.String, strText));
                        break;
                    case JsonTokenType.Number:
                        var rawBytes = new ReadOnlyMemory<byte>(reader.ValueSpan.ToArray());
                        tokens.Add(new JsonReformatterToken(depth, tokenType, rawBytes));
                        break;
                    case JsonTokenType.None:
                        break;
                    case JsonTokenType.Comment:
                        break;
                    default:
                        throw new NotImplementedException($"TokenType: {reader.TokenType}");
                }
            }
            return tokens;
        }

        public static string WriteTokens(IReadOnlyList<JsonReformatterToken> tokens, JsonWriterOptions writerOptions = default)
        {
            using var ms = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(ms, writerOptions);
            foreach (var token in tokens)
            {
                var tokenType = token.TokenType;
                switch (tokenType)
                {
                    case JsonTokenType.StartObject:
                        writer.WriteStartObject();
                        break;
                    case JsonTokenType.EndObject:
                        writer.WriteEndObject();
                        break;
                    case JsonTokenType.StartArray:
                        writer.WriteStartArray();
                        break;
                    case JsonTokenType.EndArray:
                        writer.WriteEndArray();
                        break;
                    case JsonTokenType.PropertyName:
                        writer.WritePropertyName(token.Text);
                        break;
                    case JsonTokenType.Null:
                        writer.WriteNullValue();
                        break;
                    case JsonTokenType.True:
                        writer.WriteBooleanValue(true);
                        break;
                    case JsonTokenType.False:
                        writer.WriteBooleanValue(false);
                        break;
                    case JsonTokenType.String:
                        writer.WriteStringValue(token.Text);
                        break;
                    case JsonTokenType.Number:
                        writer.WriteRawValue(token.RawBytes.Span);
                        break;
                    default:
                        throw new NotImplementedException($"JsonTokenType: {tokenType}");
                }
            }
            writer.Flush();
            string result = Encoding.UTF8.GetString(ms.ToArray());
            return result;
        }

        public static string Reformat(string input, JsonReaderOptions readerOptions = default, JsonWriterOptions writerOptions = default)
        {
            ReadOnlySpan<byte> jsonData = Encoding.UTF8.GetBytes(input);
            var reader = new Utf8JsonReader(jsonData, readerOptions);
            using var ms = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(ms, writerOptions);
            while (reader.Read())
            {
                var tokenType = reader.TokenType;
                switch (tokenType)
                {
                    case JsonTokenType.None:
                        break;
                    case JsonTokenType.StartObject:
                        writer.WriteStartObject();
                        break;
                    case JsonTokenType.EndObject:
                        writer.WriteEndObject();
                        break;
                    case JsonTokenType.StartArray:
                        writer.WriteStartArray();
                        break;
                    case JsonTokenType.EndArray:
                        writer.WriteEndArray();
                        break;
                    case JsonTokenType.Null:
                        writer.WriteNullValue();
                        break;
                    case JsonTokenType.True:
                        writer.WriteBooleanValue(true);
                        break;
                    case JsonTokenType.False:
                        writer.WriteBooleanValue(false);
                        break;
                    case JsonTokenType.PropertyName:
                        writer.WritePropertyName(reader.ValueSpan);
                        break;
                    case JsonTokenType.String:
                        writer.WriteStringValue(reader.ValueSpan);
                        break;
                    case JsonTokenType.Number:
                        writer.WriteRawValue(reader.ValueSpan);
                        break;
                    case JsonTokenType.Comment:
                        writer.WriteCommentValue(reader.ValueSpan);
                        break;
                    default:
                        throw new JsonException($"Received unexpected JsonTokenType: {reader.TokenType}");
                }
            }
            writer.Flush();
            string result = Encoding.UTF8.GetString(ms.ToArray());
            return result;
        }

    }
    public readonly struct JsonReformatterToken
    {
        public readonly int Depth;
        public readonly JsonTokenType TokenType;
        public readonly string Text;
        public readonly ReadOnlyMemory<byte> RawBytes;

        public JsonReformatterToken(int depth, JsonTokenType tokenType)
        {
            Depth = depth;
            TokenType = tokenType;
            Text = string.Empty;
        }
        public JsonReformatterToken(int depth, JsonTokenType tokenType, string text)
        {
            Depth = depth;
            TokenType = tokenType;
            Text = text;
        }
        public JsonReformatterToken(int depth, JsonTokenType tokenType, ReadOnlyMemory<byte> rawBytes)
        {
            Depth = depth;
            TokenType = tokenType;
            RawBytes = rawBytes;
            Text = string.Empty;
        }

        public override string ToString()
        {
            return TokenType switch
            {
                JsonTokenType.Number => $"[{Depth},Number({Encoding.UTF8.GetString(RawBytes.ToArray())})]",
                JsonTokenType.String => $"[{Depth},String({Text})]",
                JsonTokenType.PropertyName => $"[{Depth},Property({Text})]",
                _ => $"[{Depth},{TokenType}]"
            };
        }
    }
}
