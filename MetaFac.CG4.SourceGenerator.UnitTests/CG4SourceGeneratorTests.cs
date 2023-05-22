using FluentAssertions;
using MetaFac.CG4.Attributes;
using MetaFac.CG4.Runtime;
using MetaFac.CG4.TestOrg.Schema.Personel;
using MetaFac.Memory;
using MetaFac.Mutability;
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
    public class CG4SourceGeneratorTests
    {
        private static Compilation CreateCompilation(string source)
        {
            Assembly runtimeAssm = Assembly.Load("System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");

            return CSharpCompilation.Create("compilation",
                        new[] { CSharpSyntaxTree.ParseText(source) },
                        new[]
                        {
                            MetadataReference.CreateFromFile(runtimeAssm.Location),
                            MetadataReference.CreateFromFile(typeof(Attribute).GetTypeInfo().Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(EntityAttribute).GetTypeInfo().Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(Octets).GetTypeInfo().Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(IFreezable).GetTypeInfo().Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(IEntityBase).GetTypeInfo().Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(IPerson).GetTypeInfo().Assembly.Location),
                        },
                        new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }

        private static GeneratedSourceResult RunSourceGenerator(string source)
        {
            // Create the 'input' compilation that the generator will act on
            Compilation inputCompilation = CreateCompilation(source);

            // directly create an instance of the generator
            // (Note: in the compiler this is loaded from an assembly, and created via reflection at runtime)
            var generator = new CG4SourceGenerator();

            // Create the driver that will control the generation, passing in our generator
            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

            // Run the generation pass
            // (Note: the generator driver itself is immutable, and all calls return an updated version of the driver that you should use for subsequent calls)
            driver = driver.RunGeneratorsAndUpdateCompilation(inputCompilation, out var outputCompilation, out var diagnostics);

            // We can now assert things about the resulting compilation:
            diagnostics.Should().BeEmpty(); // there were no diagnostics created by the generators
            outputCompilation.SyntaxTrees.Should().HaveCount(2); // we have two syntax trees, the original 'user' provided one, and the one added by the generator
            outputCompilation.GetDiagnostics().Should().BeEmpty(); // verify the compilation with the added source has no diagnostics

            // Or we can look at the results directly:
            GeneratorDriverRunResult runResult = driver.GetRunResult();

            // The runResult contains the combined results of all generators passed to the driver
            runResult.GeneratedTrees.Length.Should().Be(1);
            runResult.Diagnostics.Should().BeEmpty();

            var generatorResult = runResult.Results[0];
            generatorResult.Diagnostics.Should().BeEmpty();
            generatorResult.GeneratedSources.Length.Should().Be(1);
            generatorResult.Exception.Should().BeNull();

            GeneratedSourceResult outputSource = generatorResult.GeneratedSources[0];
            return outputSource;
        }

        [Fact]
        public async Task Generate_Contracts()
        {
            var inputSource =
                """
                using MetaFac.CG4.Attributes;
                namespace MetaFac.CG4.TestOrg.Models
                {
                    [CG4Generate(BasicGeneratorId.Contracts, "Models.json")]
                    internal static partial class InterfaceModels { }
                }
                """;

            var outputSource = RunSourceGenerator(inputSource);

            // custom generation checks
            outputSource.HintName.Should().Be("MetaFac.CG4.TestOrg.Models.Contracts.g.cs");
            string outputCode = string.Join(Environment.NewLine, outputSource.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }

        [Fact]
        public async Task Generate_MessagePack()
        {
            var inputSource =
                """
                using MetaFac.CG4.Attributes;
                namespace MetaFac.CG4.TestOrg.Models
                {
                    [CG4Generate(BasicGeneratorId.MessagePack, "Models.json")]
                    internal static partial class InterfaceModels { }
                }
                """;

            var outputSource = RunSourceGenerator(inputSource);

            // custom generation checks
            outputSource.HintName.Should().Be("MetaFac.CG4.TestOrg.Models.MessagePack.g.cs");
            string outputCode = string.Join(Environment.NewLine, outputSource.SourceText.Lines.Select(tl => tl.ToString()));
            await Verifier.Verify(outputCode);
        }
    }
}
