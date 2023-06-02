using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.SourceGenerator.UnitTests
{
    [UsesVerify]
    public class GeneratorTests2_MessagePack
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

                    [CG4Generate(GeneratorId.MessagePack, "Models.json")]
                    internal static partial class Marker_MessagePack { }
                }
                """;

            var generatorResult = GeneratorTestHelper.RunSourceGenerator(inputSource, 2,
                MetadataReference.CreateFromFile(typeof(MessagePack.MessagePackObjectAttribute).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(MetaFac.CG4.Runtime.MessagePack.GuidValue).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Collections.Immutable.ImmutableArray).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Linq.Enumerable).GetTypeInfo().Assembly.Location)
                );

            // custom generation checks
            generatorResult.GeneratedSources.Length.Should().Be(2);
            GeneratedSourceResult outputSource = generatorResult.GeneratedSources[1];

            outputSource.HintName.Should().Be("MetaFac.CG4.TestOrg.Models.MessagePack.g.cs");
            string outputCode = string.Join(Environment.NewLine, outputSource.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }
    }
}
