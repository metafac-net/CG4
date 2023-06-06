using FluentAssertions;
using MetaFac.CG4.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.CG4.ModelReader.Tests
{
    [UsesVerify]
    public class JsonModelRegressionTests
    {
        [Fact]
        public async Task SaveModelFromAssembly()
        {
            // arrange - get model from assembly
            Type anchorType = typeof(GoodModels.IBuiltinTypes);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);

            // act
            string json = metadata.ToJson(true);

            // assert
            await Verifier.Verify(json);
        }

        [Fact]
        public async Task SaveModelFromInlineCode()
        {
            // arrange - construct model
            var memberDefs = new List<ModelMemberDef>
            {
                new ModelMemberDef("Field1", 1, "Field 1", "long", false, null, 0, null, false),
                new ModelMemberDef("Field2", 2, "Field 2", "string", true, null, 0, null, false)
            };
            var entityDefs = new List<ModelEntityDef>
            {
                new ModelEntityDef("Entity1", 1, "Entity 1", false, null, memberDefs)
            };
            var enumItemDefs = new List<ModelEnumItemDef>
            {
                new ModelEnumItemDef("Item1", "Summary of item 1", 1),
                new ModelEnumItemDef("Item2", null, 2),
                new ModelEnumItemDef("Item3", null, 3, ModelItemState.Create(true, false, "Not used anymore")),
            };
            var enumTypeDefs = new List<ModelEnumTypeDef>
            {
                new ModelEnumTypeDef("Enum1", "Enumeration 1", null, enumItemDefs)
            };
            var modelDef = new ModelDefinition("Model1", 1, entityDefs, enumTypeDefs);
            var tokens = new Dictionary<string, string>
            {
                ["Token1"] = "Value1",
            };
            var metadata = new ModelContainer(modelDef, tokens);

            // act
            string json = metadata.ToJson(true);

            // assert
            await Verifier.Verify(json);
        }

    }
}