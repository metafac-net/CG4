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
        public async Task BuildContainerWithTokens()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .AddOuterToken("Copyright", "2023 MetaFac")
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
                    .AddEntity("Entity1", null, null, "Description for Entity1")
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
                    .AddEntity("Entity1", null, null, "Description for Entity1")
                    .AddEntity("Entity2", null, "Entity1", "Description for Entity2", ItemState.Retired, "Will be deleted soon")
                .Build();

            string jsonMetaData = metadata.ToJson(true);
            await Verifier.Verify(jsonMetaData);
        }

        [Fact]
        public async Task BuildEntityWithMembers()
        {
            ModelContainer metadata
                = ModelBuilder.Create()
                .AddModelDef("Model1", null)
                    .AddEntity("Entity1", null, null, "Description for Entity1")
                        .AddMember("Member1", null, "in64", false, 0, null, false, "Description of Member1")
                            .SetProxyTypes("ExternalType", "ConcreteType")
                        .AddMember("Member2", null, "in64", false, 0, null, false, "Description of Member2", ItemState.Reserved)
                        .AddMember("Member3", null, "in64", false, 0, null, false, "Description of Member3", ItemState.Retired, "Deprecated")
                        .AddMember("Member4", null, "in64", false, 0, null, false, "Description of Member4", ItemState.Deleted)
                .Build();

            string jsonMetaData = metadata.ToJson(true);
            await Verifier.Verify(jsonMetaData);
        }

    }
}