using MetaFac.CG4.ModelBuilding;
using MetaFac.CG4.Models;
using System;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.ModelReader.Tests
{
    [UsesVerify]
    public class JsonLexerTests
    {
        [Fact]
        public async Task Lexer_01_Empty()
        {
            const string input = "{}";

            // act
            var tokens = JsonLexer.GetTokens(new ReadOnlyMemory<char>(input.ToCharArray()));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_02_SingleValue_Null()
        {
            const string input = """{ "Name": null }""";

            // act
            var tokens = JsonLexer.GetTokens(new ReadOnlyMemory<char>(input.ToCharArray()));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_03_SingleValue_True()
        {
            const string input = """{ "Name": true }""";

            // act
            var tokens = JsonLexer.GetTokens(new ReadOnlyMemory<char>(input.ToCharArray()));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_04_SingleValue_False()
        {
            const string input = """{ "Name": false }""";

            // act
            var tokens = JsonLexer.GetTokens(new ReadOnlyMemory<char>(input.ToCharArray()));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_05_SingleValue_Integer()
        {
            const string input = """{ "Name": +123 }""";

            // act
            var tokens = JsonLexer.GetTokens(new ReadOnlyMemory<char>(input.ToCharArray()));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_06_SingleValue_Decimal()
        {
            const string input = """{ "Name": -123.456 }""";

            // act
            var tokens = JsonLexer.GetTokens(new ReadOnlyMemory<char>(input.ToCharArray()));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_07_SingleValue_Exponent()
        {
            const string input = """{ "Name": -1.2E-10 }""";

            // act
            var tokens = JsonLexer.GetTokens(new ReadOnlyMemory<char>(input.ToCharArray()));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_08_SingleValue_SpecialChars()
        {
            const string input = """{ "Name": "\t©\r\n" }""";

            // act
            var tokens = JsonLexer.GetTokens(new ReadOnlyMemory<char>(input.ToCharArray()));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_10_ArrayEmpty()
        {
            const string input = """{ "Items": []}""";

            // act
            var tokens = JsonLexer.GetTokens(new ReadOnlyMemory<char>(input.ToCharArray()));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_11_ArrayValues()
        {
            const string input = """{ "Items": [ 123, "abc", null, true]}""";

            // act
            var tokens = JsonLexer.GetTokens(new ReadOnlyMemory<char>(input.ToCharArray()));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Lexer_12_Complex()
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
            var tokens = JsonLexer.GetTokens(new ReadOnlyMemory<char>(input.ToCharArray()));
            string formatted = string.Join(Environment.NewLine, tokens);

            // assert
            await Verifier.Verify(formatted);
        }

    }
}
