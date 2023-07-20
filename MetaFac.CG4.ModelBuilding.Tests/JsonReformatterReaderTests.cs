using MetaFac.CG4.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.ModelBuilding.Tests
{
    [UsesVerify]
    public class JsonReformatterReaderTests
    {
        [Fact]
        public async Task Lexer_01_Empty()
        {
            const string input = "{}";

            // act
            var tokens = JsonReformatter.ReadTokens(Encoding.UTF8.GetBytes(input));
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
            var tokens = JsonReformatter.ReadTokens(Encoding.UTF8.GetBytes(input));
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
            var tokens = JsonReformatter.ReadTokens(Encoding.UTF8.GetBytes(input));
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
            var tokens = JsonReformatter.ReadTokens(Encoding.UTF8.GetBytes(input));
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
                    .AddEnumType("Enum1")
                        .AddEnumItem("None", 0)
                        .AddEnumItem("Value1", 1)
                        .AddEnumItem("Value2", 2)
                .Build();

            string input = metadata.ToJson(true);

            // act
            var tokens = JsonReformatter.ReadTokens(Encoding.UTF8.GetBytes(input));
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
            var tokens = JsonReformatter.ReadTokens(Encoding.UTF8.GetBytes(input));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

    }
}
