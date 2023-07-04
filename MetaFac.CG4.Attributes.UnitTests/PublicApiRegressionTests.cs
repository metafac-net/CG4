using PublicApiGenerator;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.Attributes.UnitTests
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
            string currentApi = ApiGenerator.GeneratePublicApi(typeof(EntityAttribute).Assembly, options);

            // assert
            await Verifier.Verify(currentApi);
        }
    }
}
