using FluentAssertions;
using System.Linq;
using Xunit;

namespace MetaFac.CG3.TextProcessing.UnitTests
{
    public class TextProcessorTests
    {
        private readonly string[] originalTemplate = new string[]
        {
            "#region",
            "// Copyright (c) ACME Inc. 2020",
            "#endregion",
            "// |metacode:version=0.1|",
            "// |metacode:template_begin|",
            "#region Notices",
            "// T_CopyrightNotice_",
            "#endregion",
            "// class comment",
            "//>>    foreach(var i in new int[]{1,2,3})",
            "//>>    {",
            "public class T_ClassName",
            "{",
            "    // field comment",
            "    public string Field1 {get; set;} = \"abc\"; // trailing comment",
            "    public char Field2 {get; set;} = '\t';",
            "}",
            "//>>    }",
            "// |metacode:template_end|",
        };
        private readonly string[] expectedGenerated = new string[]
        {
            "#region",
            "// Copyright (c) ACME Inc. 2020",
            "#endregion",
            "// |metacode:version=0.1|",
            "// |metacode:generator_header|",
            "using System;",
            "using System.Linq;",
            "using MetaFac.CG3.Generators;",
            "namespace MyOrganisation.Generator",
            "{",
            "    public partial class Generator : GeneratorBase",
            "    {",
            "        public Generator() : base(\"MyGeneratorId\") { }",
            "        protected override void OnGenerate(TemplateScope outerScope)",
            "        {",
            "// |metacode:generator_body|",
            "Emit(\"#region Notices\");",
            "Emit(\"// T_CopyrightNotice_\");",
            "Emit(\"#endregion\");",
            "Emit(\"// class comment\");",
            "    foreach(var i in new int[]{1,2,3})",
            "    {",
            "Emit(\"public class T_ClassName\");",
            "Emit(\"{\");",
            "Emit(\"    // field comment\");",
            "Emit(\"    public string Field1 {get; set;} = \\\"abc\\\"; // trailing comment\");",
            "Emit(\"    public char Field2 {get; set;} = '\t';\");",
            "Emit(\"}\");",
            "    }",
            "// |metacode:generator_footer|",
            "        }",
            "    }",
            "}",
            "// |metacode:generator_end|",
        };

        [Fact]
        public void TemplateToGenerator()
        {
            var actualOutput = TextProcessor.ConvertTemplateToGenerator(
                originalTemplate, "MyOrganisation.Generator", "MyGeneratorId", new NotEncryptedTextCache()).ToArray();
            actualOutput.Should().BeEquivalentTo(expectedGenerated);
        }

        [Fact]
        public void GeneratorToTemplate()
        {
            string[] actualOutput = TextProcessor.ConvertGeneratorToTemplate(expectedGenerated, null).ToArray();
            actualOutput.Should().BeEquivalentTo(originalTemplate);
        }

    }
}