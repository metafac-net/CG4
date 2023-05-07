using MetaFac.CG3.ModelReader;
using MetaFac.CG3.Models;
using MetaFac.Platform;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Reflection;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG3.Generators.UnitTests
{
    [UsesVerify]
    public class GenerateFromFlattenedModelsTests
    {
        private static string GenerateSourceCode(Generator.Interfaces.Generator generator)
        {
            string ns = typeof(FlattenedModels.BuiltinTypes).Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(Assembly.GetExecutingAssembly(), ns);
            var logger = NullLogger.Instance;
            var clock = new TimeOfDayClock();
            var options = new GeneratorOptions() { CopyrightInfo = "Copyright (c) 2023 MetaFac" };
            var sourceLines = GeneratorHelper.GenerateSource(logger, clock, metadata, "Generated", options, generator);
            string sourceCode = string.Join(Environment.NewLine, sourceLines);
            return sourceCode;
        }

        [Fact]
        public async Task Generate_Interfaces()
        {
            var generator = new Generator.Interfaces.Generator();
            string sourceCode = GenerateSourceCode(generator);
            await Verifier.Verify(sourceCode);
        }
    }
}