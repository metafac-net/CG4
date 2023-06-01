﻿using MetaFac.CG4.ModelReader;
using MetaFac.CG4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.Generators.UnitTests
{
    internal static class GeneratorHelper
    {
        /// <summary>
        /// A helper method to generate source file.
        /// </summary>
        /// <param name="metadata">The model(s).</param>
        /// <param name="outputNamespace">The output namespace for the generated source files.</param>
        /// <param name="usersOptions">The optional users' options.</param>
        /// <param name="generators">The generators to be run in the order given.</param>
        public static IEnumerable<string> GenerateSource(
            Type anchorType,
            string outputNamespace,
            GeneratorOptions? usersOptions,
            GeneratorBase generator)
        {
            if (string.IsNullOrWhiteSpace(outputNamespace)) throw new ArgumentException($"'{nameof(outputNamespace)}' cannot be null or whitespace.", nameof(outputNamespace));

            var sourceAssembly = anchorType.Assembly;
            var sourceNamespace = anchorType.Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(sourceAssembly, sourceNamespace);

            var options = new GeneratorOptions(usersOptions);
            string generatorVersion = FileVersionInfo.GetVersionInfo(generator.GetType().Assembly.Location).FileVersion ?? "unknown";
            metadata = metadata
                .SetToken("Namespace", outputNamespace)
                .SetToken("Generator", $"{generator.ShortName}.{generatorVersion}")
                .SetToken("Metadata", $"{sourceAssembly.GetName().Name}({sourceNamespace})")
                ;
            if (options.CopyrightInfo is not null)
            {
                metadata = metadata.SetToken("CopyrightInfo", options.CopyrightInfo);
            }
            return generator.Generate(metadata).ToList();
        }

    }

    [UsesVerify]
    public class GenerateFromFlattenedModelsTests
    {
        private static string GenerateSourceCode(GeneratorBase generator)
        {
            var anchorType = typeof(FlattenedModels.IBuiltinTypes);
            var options = new GeneratorOptions() { CopyrightInfo = "Copyright (c) 2023 MetaFac" };
            var sourceLines = GeneratorHelper.GenerateSource(anchorType, "Generated", options, generator)
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

        [Fact]
        public async Task Generate_JsonNewtonSoft()
        {
            var generator = new Generator.JsonNewtonSoft.Generator();
            string sourceCode = GenerateSourceCode(generator);
            await Verifier.Verify(sourceCode);
        }

    }
}