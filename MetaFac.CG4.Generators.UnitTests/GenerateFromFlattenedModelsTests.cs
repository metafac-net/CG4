using MetaFac.CG4.ModelReader;
using MetaFac.CG4.Models;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.Generators.UnitTests
{
    [UsesVerify]
    public class GenerateFromFlattenedModelsTests
    {
        private static string GenerateSourceCode(GeneratorBase generator)
        {
            string ns = typeof(FlattenedModels.BuiltinTypes).Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(Assembly.GetExecutingAssembly(), ns);
            var logger = NullLogger.Instance;
            var options = new GeneratorOptions() { CopyrightInfo = "Copyright (c) 2023 MetaFac" };
            var sourceLines = GeneratorHelper.GenerateSource(logger, metadata, "Generated", options, generator)
                .ToArray();
            string sourceCode = string.Join(Environment.NewLine, sourceLines);
            return sourceCode;
        }

        [Fact]
        public async Task Generate_Contracts()
        {
            var generator = new Generator.Contracts.Generator();
            string sourceCode = GenerateSourceCode(generator);
            await Verifier.Verify(sourceCode);
        }

        [Fact]
        public async Task Generate_ClassesV2()
        {
            var generator = new Generator.ClassesV2.Generator();
            string sourceCode = GenerateSourceCode(generator);
            await Verifier.Verify(sourceCode);
        }

        [Fact]
        public async Task Generate_RecordsV2()
        {
            var generator = new Generator.RecordsV2.Generator();
            string sourceCode = GenerateSourceCode(generator);
            await Verifier.Verify(sourceCode);
        }

        [Fact]
        public async Task Generate_MessagePack()
        {
            var generator = new Generator.MessagePack.Generator();
            string sourceCode = GenerateSourceCode(generator);
            await Verifier.Verify(sourceCode);
        }

    }
}