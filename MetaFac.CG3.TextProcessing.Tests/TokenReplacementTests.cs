using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace MetaCode.TextProcessing.Tests
{
    public class TokenReplacementTests
    {
        [Theory]
        [InlineData("#region", "#region")]
        [InlineData("// Copyright (c) ACME Inc. 2020", "// Copyright (c) ACME Inc. 2020")]
        [InlineData("public string T_Undefined_;", "public string T_Undefined_;")]
        [InlineData("public class T_ClassName_ {}", "public class MyClass1 {}")]
        [InlineData("public string T_Name_ = T_Number_;", "public string Field = 1;")]
        [InlineData("public string T_T_Name_T_Number__;", "public string MyField;")] // recursion!
        public void ReplaceTokens(string input, string expectedOutput)
        {
            var replacer = new TokenReplacer("T_", "_",
                new Dictionary<string, string>()
                {
                    ["ClassName"] = "MyClass1",
                    ["Name"] = "Field",
                    ["Number"] = "1",
                    ["Field1"] = "MyField",
                });
            string actualOutput = replacer.ReplaceTokens(input);
            actualOutput.Should().Be(expectedOutput);
        }

    }
}