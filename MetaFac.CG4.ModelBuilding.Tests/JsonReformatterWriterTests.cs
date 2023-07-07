using MetaFac.CG4.ModelBuilding;
using MetaFac.CG4.Models;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.ModelReader.Tests
{
    [UsesVerify]
    public class JsonReformatterWriterTests
    {
        private readonly JsonWriterOptions writerOptions = new JsonWriterOptions() { Indented = true };

        [Fact]
        public async Task Reformatter_01_Empty_Minimal()
        {
            const string input = "{}";

            // act
            string formatted = JsonReformatter.Reformat(input, default, writerOptions);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Reformatter_02_SingleValue_Null()
        {
            const string input = """{ "Name": null }""";

            // act
            string formatted = JsonReformatter.Reformat(input, default, writerOptions);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Reformatter_03_SingleValue_True()
        {
            const string input = """{ "Name": true }""";

            // act
            string formatted = JsonReformatter.Reformat(input, default, writerOptions);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Reformatter_04_SingleValue_False()
        {
            const string input = """{ "Name": false }""";

            // act
            string formatted = JsonReformatter.Reformat(input, default, writerOptions);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Reformatter_05_SingleValue_String()
        {
            const string input = 
                """
                {
                    "Name": "abc\tdef ghi"
                }
                """;

            // act
            string formatted = JsonReformatter.Reformat(input, default, writerOptions);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Reformatter_06_SingleValue_Number()
        {
            const string input = """{ "Name": 1E+37 }"""; // note: < float.MaxValue

            // act
            string formatted = JsonReformatter.Reformat(input, default, writerOptions);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Reformatter_07_Complex()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .AddModelDef("Model1", null)
                    .AddEntity("Entity1", null)
                        .AddMember("Member1", null, "string", true, 0, null, false)
                    .AddEntity("Entity2", null)
                .Build();

            string input = metadata.ToJson();

            // act
            string formatted = JsonReformatter.Reformat(input, default, writerOptions);

            // assert
            await Verifier.Verify(formatted);
        }

        [Fact]
        public async Task Reformatter_08_Comment()
        {
            const string input =
                """
                {
                    /* comment */ 
                    "Name": null
                }
                """;

            // act
            var readerOptions = new JsonReaderOptions() { CommentHandling = JsonCommentHandling.Allow };
            string formatted = JsonReformatter.Reformat(input, readerOptions, writerOptions);

            // assert
            await Verifier.Verify(formatted);
        }

    }
}
