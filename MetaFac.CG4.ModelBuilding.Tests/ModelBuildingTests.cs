using MetaFac.CG4.Models;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.ModelBuilding.Tests
{
    [UsesVerify]
    public class ModelBuildingTests
    {
        [Fact]
        public async Task BuildEmptyContainer()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .Build();

            string jsonMetaData = metadata.ToJson(true);
            await Verifier.Verify(jsonMetaData);
        }

        [Fact]
        public async Task BuildEmptyModel()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .AddModelDef("Model1", null)
                .Build();

            string jsonMetaData = metadata.ToJson(true);
            await Verifier.Verify(jsonMetaData);
        }

        [Fact]
        public async Task BuildMultiModel()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .AddModelDef("Model1", null)
                .AddModelDef("Model2", null)
                .Build();

            string jsonMetaData = metadata.ToJson(true);
            await Verifier.Verify(jsonMetaData);
        }

        [Fact]
        public async Task BuildSingleEntityModel()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .AddModelDef("Model1", null)
                    .AddEntityDef("Entity1", null)
                .Build();

            string jsonMetaData = metadata.ToJson(true);
            await Verifier.Verify(jsonMetaData);
        }

        [Fact]
        public async Task BuildMultiEntityModel()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .AddModelDef("Model1", null)
                    .AddEntityDef("Entity1", null)
                    .AddEntityDef("Entity2", null)
                .Build();

            string jsonMetaData = metadata.ToJson(true);
            await Verifier.Verify(jsonMetaData);
        }
    }
}