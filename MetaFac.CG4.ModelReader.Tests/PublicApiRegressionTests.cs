using PublicApiGenerator;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.ModelReader.Tests
{
    [UsesVerify]
    public class PublicApiRegressionTests
    {
        [Fact]
        public async Task CheckPublicApi()
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
    }
}
