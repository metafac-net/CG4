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
            string ns = anchorType.Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType.Assembly, ns);

            // act
            string json = metadata.ToJson(true);

            // assert
            await Verifier.Verify(json);
        }

        [Fact]
        public async Task SaveModelFromInlineCode()
        {
            // arrange - construct model
            List<ModelFieldDef> memberDefs = new List<ModelFieldDef>
            {
                new ModelFieldDef("Field1", 1, "long", false, null, 0, null, false),
                new ModelFieldDef("Field2", 2, "string", true, null, 0, null, false)
            };
            List<ModelEntityDef> entityDefs = new List<ModelEntityDef>
            {
                new ModelEntityDef("Entity1", 1, false, null, memberDefs)
            };
            var enumItemDefs = new List<ModelEnumItemDef>
            {
                new ModelEnumItemDef("Item1", 1),
                new ModelEnumItemDef("Item2", 3),
                new ModelEnumItemDef("Item3", 3)
            };
            var enumTypeDefs = new List<ModelEnumTypeDef>
            {
                new ModelEnumTypeDef("Enum1", enumItemDefs)
            };
            var modelDef = new ModelDefinition("Model1", 1, entityDefs, enumTypeDefs);
            var tokens = new Dictionary<string, string>
            {
                ["Token1"] = "Value1",
            };
            ModelContainer metadata = new ModelContainer(modelDef, tokens);

            // act
            string json = metadata.ToJson(true);

            // assert
            await Verifier.Verify(json);
        }

    }
}