using FluentAssertions;
using Microsoft.CodeAnalysis;
using System;
using System.Linq;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.SourceGenerator.UnitTests
{
    [UsesVerify]
    public class GeneratorTests1_ContractsOnly
    {
        [Fact]
        public async Task NormalRun()
        {
            var inputSource =
                """
                using MetaFac.CG4.Attributes;
                namespace MetaFac.CG4.TestOrg.Models
                {
                    [CG4Generate(GeneratorId.Contracts, "Models.json")]
                    internal static partial class Marker_Contracts { }
                }
                """;

            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, 1);
            generatorResult.GeneratedSources.Length.Should().Be(1);
            GeneratedSourceResult outputSource = generatorResult.GeneratedSources[0];

            // custom generation checks
            outputSource.HintName.Should().Be("MetaFac.CG4.TestOrg.Models.Contracts.g.cs");
            string outputCode = string.Join(Environment.NewLine, outputSource.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }
    }
}
