﻿using FluentAssertions;
using PublicApiGenerator;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.Schemas.Tests
{
    public class PublicApiRegressionTests
    {
        [Fact]
        public void VersionCheck()
        {
            ThisAssembly.AssemblyVersion.Should().Be("3.2.0.0");
        }

        [Fact]
        public async Task CheckPublicApi()
        {
            // act
            var options = new ApiGeneratorOptions()
            {
                IncludeAssemblyAttributes = false
            };
            string currentApi = typeof(EntityAttribute).Assembly.GeneratePublicApi(options);

            // assert
            await Verifier.Verify(currentApi);
        }

    }
}