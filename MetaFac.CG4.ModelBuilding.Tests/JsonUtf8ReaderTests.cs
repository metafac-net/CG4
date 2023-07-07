using MetaFac.CG4.ModelBuilding;
using MetaFac.CG4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.ModelReader.Tests
{
    [UsesVerify]
    public class JsonUtf8ReaderTests
    {
        public readonly struct JsonToken2
        {
            public readonly int Depth;
            public readonly JsonTokenType TokenType;
            public readonly string? Text;
            public readonly double Number;

            public JsonToken2(int depth, JsonTokenType tokenType)
            {
                Depth = depth;
                TokenType = tokenType;
            }
            public JsonToken2(int depth, JsonTokenType tokenType, string text)
            {
                Depth = depth;
                TokenType = tokenType;
                Text = text;
            }
            public JsonToken2(int depth, JsonTokenType tokenType, double number)
            {
                Depth = depth;
                TokenType = tokenType;
                Number = number;
            }

            public override string ToString()
            {
                return TokenType switch
                {
                    JsonTokenType.Number => $"[{Depth},Number({Number})]",
                    JsonTokenType.String => $"[{Depth},String({Text})]",
                    JsonTokenType.PropertyName => $"[{Depth},Property({Text})]",
                    _ => $"[{Depth},{TokenType}]"
                };
            }
        }
        private static List<JsonToken2> ReadTokens(ReadOnlySpan<byte> jsonData)
        {
            var tokens = new List<JsonToken2>();
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
                        tokens.Add(new JsonToken2(depth, tokenType));
                        break;
                    case JsonTokenType.PropertyName:
                        string propText = reader.GetString() ?? throw new InvalidDataException("Property name cannot be null");
                        tokens.Add(new JsonToken2(depth, tokenType, propText));
                        break;
                    case JsonTokenType.String:
                        string? strText = reader.GetString();
                        if (strText is null)
                            tokens.Add(new JsonToken2(depth, JsonTokenType.Null));
                        else
                            tokens.Add(new JsonToken2(depth, JsonTokenType.String, strText));
                        break;
                    case JsonTokenType.Number:
                        var number = reader.GetDouble();
                        tokens.Add(new JsonToken2(depth, tokenType, number));
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

        [Fact]
        public async Task Lexer_01_Empty()
        {
            const string input = "{}";

            // act
            var tokens = ReadTokens(Encoding.UTF8.GetBytes(input));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_02_PropertyString()
        {
            const string input =
                """
                { 
                    "Name": "abc" 
                }
                """;

            // act
            var tokens = ReadTokens(Encoding.UTF8.GetBytes(input));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_03_PropertyNull()
        {
            const string input =
                """
                { 
                    "Name": null 
                }
                """;

            // act
            var tokens = ReadTokens(Encoding.UTF8.GetBytes(input));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_04_PropertyNumber()
        {
            const string input =
                """
                { 
                    "Name": 123E-6 
                }
                """;

            // act
            var tokens = ReadTokens(Encoding.UTF8.GetBytes(input));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_05_Complex()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .AddModelDef("Model1", null)
                    .AddEntity("Entity1", null)
                        .AddMember("Member1", null, "string", true, 0, null, false)
                    .AddEntity("Entity2", null)
                .Build();

            string input = metadata.ToJson(true);

            // act
            var tokens = ReadTokens(Encoding.UTF8.GetBytes(input));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_06_PropertyArray()
        {
            const string input =
                """
                { 
                    "Name": [1, null, "abc", true]
                }
                """;

            // act
            var tokens = ReadTokens(Encoding.UTF8.GetBytes(input));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

    }
}
