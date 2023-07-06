using FluentAssertions;
using MetaFac.CG4.ModelBuilding;
using MetaFac.CG4.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.ModelReader.Tests
{
    [UsesVerify]
    public class JsonReformatterTests
    {
        [Fact]
        public void TextSpanEquality()
        {
            TextSpan ts1a = default;
            TextSpan ts1b = new TextSpan();
            TextSpan ts1c = new TextSpan("", 0, 0);
            ts1b.Equals(ts1a).Should().BeTrue();
            ts1c.Equals(ts1a).Should().BeTrue();

            TextSpan ts2a = new TextSpan("abcdef", 2, 3);
            TextSpan ts2b = new TextSpan("bcdefg", 1, 3);
            TextSpan ts2c = new TextSpan("cdefgh", 0, 3);
            ts2b.Equals(ts2a).Should().BeTrue();
            ts2c.Equals(ts2a).Should().BeTrue();
        }

        [Fact]
        public async Task ReformatterEmpty()
        {
            const string input =
            """
            {
            }
            """;

            // act
            string formatted = JsonReformatter.ReformatJson(input);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task OldReformatterNonTrivial()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .AddModelDef("Model1", null)
                    .AddEntity("Entity1", null)
                        .AddMember("Member1", null, "string", true, 0, null, false, "Summary for Member1")
                    .AddEntity("Entity2", null)
                .Build();

            string input = metadata.ToJson(true);

            // act
            string formatted = JsonReformatterOld.Reformat(input);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task ReformatterNonTrivial()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .AddModelDef("Model1", null)
                    .AddEntity("Entity1", null)
                        .AddMember("Member1", null, "string", true, 0, null, false, "Summary for Member1")
                    .AddEntity("Entity2", null)
                .Build();

            string input = metadata.ToJson(true);

            // act
            string formatted = JsonReformatter.ReformatJson(input);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact(Skip = "Requires structure depth tracking")]
        public async Task ReformatWithChangedIndent()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .AddModelDef("Model1", null)
                    .AddEntity("Entity1", null)
                        .AddMember("Member1", null, "string", true, 0, null, false, "Summary for Member1")
                    .AddEntity("Entity2", null)
                .Build();

            string input = metadata.ToJson(true);

            // act
            JsonReformatterOptions options = JsonReformatterOptions.Default.WithIndentSize(4);
            string formatted = JsonReformatter.ReformatJson(input, options);

            // assert
            await Verifier.Verify(formatted);
        }
    }
}
