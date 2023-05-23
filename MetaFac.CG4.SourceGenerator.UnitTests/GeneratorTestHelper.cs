using FluentAssertions;
using MetaFac.CG4.Attributes;
using MetaFac.CG4.Runtime;
using MetaFac.Memory;
using MetaFac.Mutability;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Linq;
using System.Reflection;

namespace MetaFac.CG4.SourceGenerator.UnitTests
{
    internal static class GeneratorTestHelper
    {
        private static Compilation CreateCompilation(string source, params PortableExecutableReference[] additionalReferences)
        {
            Assembly standardAssm = Assembly.Load("netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51");
            Assembly runtimeAssm = Assembly.Load("System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");

            PortableExecutableReference[] commonReferences = new[]
                        {
                            MetadataReference.CreateFromFile(standardAssm.Location),
                            MetadataReference.CreateFromFile(runtimeAssm.Location),
                            MetadataReference.CreateFromFile(typeof(Enum).GetTypeInfo().Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(Attribute).GetTypeInfo().Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(EntityAttribute).GetTypeInfo().Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(Octets).GetTypeInfo().Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(IFreezable).GetTypeInfo().Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(IEntityBase).GetTypeInfo().Assembly.Location),
                        };

            PortableExecutableReference[] metadataReferences = commonReferences.Concat(additionalReferences).ToArray();

            return CSharpCompilation.Create("compilation",
                        new[] { CSharpSyntaxTree.ParseText(source) },
                        metadataReferences,
                        new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }

        public static GeneratorRunResult RunSourceGenerator(string source, int expectedNewTrees, 
            params PortableExecutableReference[] additionalReferences)
        {
            // Create the 'input' compilation that the generator will act on
            Compilation inputCompilation = CreateCompilation(source, additionalReferences);

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
            outputCompilation.SyntaxTrees.Should().HaveCount(1 + expectedNewTrees); // we have two syntax trees, the original 'user' provided one, and the one added by the generator
            outputCompilation.GetDiagnostics().Should().BeEmpty(); // verify the compilation with the added source has no diagnostics

            // Or we can look at the results directly:
            GeneratorDriverRunResult runResult = driver.GetRunResult();

            // The runResult contains the combined results of all generators passed to the driver
            runResult.GeneratedTrees.Length.Should().Be(expectedNewTrees);
            runResult.Diagnostics.Should().BeEmpty();

            var generatorResult = runResult.Results[0];
            generatorResult.Diagnostics.Should().BeEmpty();
            generatorResult.GeneratedSources.Length.Should().Be(expectedNewTrees);
            generatorResult.Exception.Should().BeNull();

            return generatorResult;
        }
    }
}
