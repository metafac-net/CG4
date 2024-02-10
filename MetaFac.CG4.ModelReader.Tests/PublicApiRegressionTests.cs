using MetaFac.CG4.Models;
using PublicApiGenerator;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.ModelReader.Tests
{
    public class PublicApiRegressionTests
    {
        [Fact]
        public async Task CheckParserApi()
        {
            // act
            var options = new ApiGeneratorOptions()
            {
                IncludeAssemblyAttributes = false
            };
            string currentApi = ApiGenerator.GeneratePublicApi(typeof(ModelParser).Assembly, options);

            // assert
            await Verifier.Verify(currentApi);
        }

        [Fact]
        public async Task CheckModelsApi()
        {
            // act
            var options = new ApiGeneratorOptions()
            {
                IncludeAssemblyAttributes = false
            };
            string currentApi = ApiGenerator.GeneratePublicApi(typeof(ModelEntityDef).Assembly, options);

            // assert
            await Verifier.Verify(currentApi);
        }
    }
}
