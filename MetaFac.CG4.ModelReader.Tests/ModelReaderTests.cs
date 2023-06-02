using FluentAssertions;
using MetaFac.CG4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace MetaFac.CG4.ModelReader.Tests
{
    public class ModelReaderTests
    {
        [Fact]
        public void RoundtripModelViaJson1()
        {
            // arrange - get model from assembly
            Type anchorType = typeof(GoodModels.IBuiltinTypes);
            string ns = anchorType.Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType.Assembly, ns);
            metadata.Tokens.Count.Should().Be(1);
            metadata.Tokens.Should().ContainKey("Metadata");
            metadata.ModelDefs.Count.Should().Be(1);
            string originalJson = metadata.ToJson(true);

            // act
            var metadata2 = ModelContainer.FromJson(originalJson);

            // assert
            metadata2.Should().Be(metadata);

            // act again
            string duplicateJson = metadata2.ToJson(true);

            // assert
            duplicateJson.Should().Be(originalJson);
        }

        [Fact]
        public void RoundtripModelViaJson2()
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
                new ModelEnumItemDef("Item1", "Summary of item 1", 1, null),
                new ModelEnumItemDef("Item2", null, 2, null),
                new ModelEnumItemDef("Item3", null, 3, new ModelItemState(true, "Not used anymore")),
            };
            var enumTypeDefs = new List<ModelEnumTypeDef>
            {
                new ModelEnumTypeDef("Enum1", "Enumeration 1", null, enumItemDefs)
            };
            var modelDef = new ModelDefinition("Model1", 1, entityDefs, enumTypeDefs);
            var metadata = new ModelContainer(modelDef);
            metadata.Tokens.Count.Should().Be(0);
            metadata.ModelDefs.Count.Should().Be(1);
            string originalJson = metadata.ToJson(true);

            // act
            var metadata2 = ModelContainer.FromJson(originalJson);

            // assert
            metadata2.Should().Be(metadata);

            // act again
            string duplicateJson = metadata2.ToJson(true);

            // assert
            duplicateJson.Should().Be(originalJson);
        }

        [Fact]
        public void ReadBuiltinTypes()
        {
            Type anchorType = typeof(GoodModels.IBuiltinTypes);
            string ns = anchorType.Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType.Assembly, ns);
            metadata.Tokens.Count.Should().Be(1);
            metadata.Tokens.Should().ContainKey("Metadata");
            metadata.ModelDefs.Count.Should().Be(1);
            var modelDef = metadata.ModelDefs[0];
            modelDef.EntityDefs.Count.Should().Be(3);
            var entityDef = modelDef.EntityDefs[0];
            entityDef.Name.Should().Be("BuiltinTypes");
            entityDef.MemberDefs.Count.Should().Be(19);
        }

        [Fact]
        public void ReadExternalTypes()
        {
            Type anchorType = typeof(GoodModels.IExternalTypes);
            string ns = anchorType.Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType.Assembly, ns);
            metadata.Tokens.Count.Should().Be(1);
            metadata.Tokens.Should().ContainKey("Metadata");
            metadata.ModelDefs.Count.Should().Be(1);
            var modelDef = metadata.ModelDefs[0];
            var entityDef = modelDef.EntityDefs.Where(cd => cd.Name == "ExternalTypes").Single();
            entityDef.MemberDefs.Count.Should().Be(1);

            // external type
            var field0 = entityDef.MemberDefs[0];
            field0.Tag.Should().Be(1);
            field0.Name.Should().Be("Quantities");
            field0.ProxyDef.Should().NotBeNull();
            field0.ProxyDef!.ExternalName.Should().Be("LabApps.Units.Quantity");
            field0.ProxyDef.ConcreteName.Should().Be("QuantityValue");
            field0.ArrayRank.Should().Be(1);
            field0.InnerType.Should().Be("Quantity");
        }

        [Fact]
        public void ReadEnumeratorTypes()
        {
            Type anchorType = typeof(GoodModels.IExternalTypes);
            string ns = anchorType.Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType.Assembly, ns);
            metadata.Tokens.Count.Should().Be(1);
            metadata.Tokens.Should().ContainKey("Metadata");
            metadata.ModelDefs.Count.Should().Be(1);
            var modelDef = metadata.ModelDefs[0];
            var entityDef = modelDef.EntityDefs.Where(cd => cd.Name == "EnumeratorTypes").Single();
            entityDef.MemberDefs.Count.Should().Be(3);

            // enumerator types
            {
                var memberDef = entityDef.MemberDefs[0];
                memberDef.Tag.Should().Be(1);
                memberDef.Name.Should().Be("DaysOfWeek");
                memberDef.ProxyDef.Should().BeNull();
                memberDef.ArrayRank.Should().Be(1);
                memberDef.InnerType.Should().Be("System.DayOfWeek");
            }
            {
                var memberDef = entityDef.MemberDefs[1];
                memberDef.Tag.Should().Be(2);
                memberDef.Name.Should().Be("MyCustomEnums");
                memberDef.ProxyDef.Should().BeNull();
                memberDef.ArrayRank.Should().Be(1);
                memberDef.InnerType.Should().Be("MetaFac.CG4.ModelReader.Tests.GoodModels.MyCustomEnum");
            }
            {
                var memberDef = entityDef.MemberDefs[2];
                memberDef.Tag.Should().Be(3);
                memberDef.Name.Should().Be("MyDateTimeKinds");
                memberDef.ProxyDef.Should().NotBeNull();
                memberDef.ProxyDef!.ExternalName.Should().Be("System.DateTimeKind");
                memberDef.ProxyDef.ConcreteName.Should().Be("MyDateTimeKindValue");
                memberDef.ArrayRank.Should().Be(1);
                memberDef.InnerType.Should().Be("MyDateTimeKind");
            }
        }

        [Fact]
        public void ReadInvalidTypes1()
        {
            Type anchorType = typeof(InvalidModel1.IInvalidEntity1);
            string ns = anchorType.Namespace!;

            var ex = Assert.ThrowsAny<ValidationException>(() =>
            {
                ModelContainer metadata = ModelParser.ParseAssembly(anchorType.Assembly, ns);
            });
            ex.Should().NotBeNull();
            ex.Should().BeOfType<ValidationException>();
            ex.Message.Should().Be("Model1.InvalidEntity1.Grid(): Invalid array rank");
        }

        [Fact]
        public void ReadInvalidTypes2()
        {
            Type anchorType = typeof(InvalidModel2.IInvalidEntity2);
            string ns = anchorType.Namespace!;

            var ex = Assert.ThrowsAny<ValidationException>(() =>
            {
                ModelContainer metadata = ModelParser.ParseAssembly(anchorType.Assembly, ns);
            });
            ex.Should().NotBeNull();
            ex.Should().BeOfType<ValidationException>();
            ex.Message.Should().Be("Model1.InvalidEntity2.MyVersion(): Unknown field type: System.Version");
        }

    }
}