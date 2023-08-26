using FluentAssertions;
using MetaFac.CG4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MetaFac.CG4.ModelReader.Tests
{
    public class ModelReaderTests
    {
        [Fact]
        public void RoundtripModelViaJson1()
        {
            // arrange - get model from assembly
            Type anchorType = typeof(GoodModels.BuiltinTypes);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.Should().Be(1);
            metadata.Tokens.Should().ContainKey("Metadata");
            metadata.ModelDefs.Count.Should().Be(1);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.Should().BeEmpty();
            validationResult.Warnings.Should().BeEmpty();

            // act
            string originalJson = metadata.ToJson(true);
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
                new ModelMemberDef("Field1", 1, "Field 1", "int64", false, null, 0, null, false),
                new ModelMemberDef("Field2", 2, "Field 2", "string", true, null, 0, null, false)
            };
            var entityDefs = new List<ModelEntityDef>
            {
                new ModelEntityDef("Entity1", 1, "Entity 1", null, memberDefs)
            };
            var enumItemDefs = new List<ModelEnumItemDef>
            {
                new ModelEnumItemDef("Item1", 1, "Summary of item 1"),
                new ModelEnumItemDef("Item2", 2),
                new ModelEnumItemDef("Item3", 3, null, ModelItemState.Create(true, false, "Not used anymore")),
            };
            var enumTypeDefs = new List<ModelEnumTypeDef>
            {
                new ModelEnumTypeDef("Enum1", enumItemDefs, "Enumeration 1")
            };
            var modelDef = new ModelDefinition("Model1", 1, entityDefs, enumTypeDefs);
            var metadata = new ModelContainer(modelDef);
            metadata.Tokens.Count.Should().Be(0);
            metadata.ModelDefs.Count.Should().Be(1);
            string originalJson = metadata.ToJson(true);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.Should().BeEmpty();
            validationResult.Warnings.Should().BeEmpty();

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
        public void ReadComplexModel()
        {
            Type anchorType = typeof(ComplexModel1.BaseMessage);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.Should().Be(1);
            metadata.Tokens.Should().ContainKey("Metadata");
            metadata.ModelDefs.Count.Should().Be(1);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.Should().BeEmpty();
            validationResult.Warnings.Should().BeEmpty();

            var modelDef = metadata.ModelDefs[0];
            modelDef.AllEntityDefs.Count.Should().Be(28);
            var entityDef = modelDef.AllEntityDefs[0];
            entityDef.Name.Should().Be("BaseMessage");
            entityDef.AllMemberDefs.Count.Should().Be(1);
        }

        [Fact]
        public void ReadComplexModel2()
        {
            Type anchorType = typeof(ComplexModel2.AccountType);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.Should().Be(1);
            metadata.Tokens.Should().ContainKey("Metadata");
            metadata.ModelDefs.Count.Should().Be(1);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.Should().BeEmpty();
            validationResult.Warnings.Should().BeEmpty();

            var modelDef = metadata.ModelDefs[0];
            modelDef.AllEntityDefs.Count.Should().Be(4);
            var entityDef = modelDef.AllEntityDefs[0];
            entityDef.Name.Should().Be("AccountType");
            entityDef.AllMemberDefs.Count.Should().Be(1);
        }

        [Fact]
        public void ReadBuiltinTypes()
        {
            Type anchorType = typeof(GoodModels.BuiltinTypes);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.Should().Be(1);
            metadata.Tokens.Should().ContainKey("Metadata");
            metadata.ModelDefs.Count.Should().Be(1);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.Should().BeEmpty();
            validationResult.Warnings.Should().BeEmpty();

            var modelDef = metadata.ModelDefs[0];
            modelDef.AllEntityDefs.Count.Should().Be(3);
            var entityDef = modelDef.AllEntityDefs[0];
            entityDef.Name.Should().Be("BuiltinTypes");
            entityDef.AllMemberDefs.Count.Should().Be(19);
        }

        [Fact]
        public void ReadExternalTypes()
        {
            Type anchorType = typeof(GoodModels.ExternalTypes);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.Should().Be(1);
            metadata.Tokens.Should().ContainKey("Metadata");
            metadata.ModelDefs.Count.Should().Be(1);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.Should().BeEmpty();
            validationResult.Warnings.Should().BeEmpty();

            var modelDef = metadata.ModelDefs[0];
            var entityDef = modelDef.AllEntityDefs.Where(cd => cd.Name == "ExternalTypes").Single();
            entityDef.AllMemberDefs.Count.Should().Be(1);

            // external type
            var field0 = entityDef.AllMemberDefs[0];
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
            Type anchorType = typeof(GoodModels.ExternalTypes);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.Should().Be(1);
            metadata.Tokens.Should().ContainKey("Metadata");
            metadata.ModelDefs.Count.Should().Be(1);
            var modelDef = metadata.ModelDefs[0];
            var entityDef = modelDef.AllEntityDefs.Where(cd => cd.Name == "EnumeratorTypes").Single();
            entityDef.AllMemberDefs.Count.Should().Be(3);

            // enumeration definitions
            modelDef.AllEnumTypeDefs.Count.Should().Be(1);
            {
                var enumTypeDef = modelDef.AllEnumTypeDefs[0];
                enumTypeDef.Tag.Should().BeNull();
                enumTypeDef.Name.Should().Be("MyCustomEnum");
                enumTypeDef.IsRedacted.Should().BeFalse();
                enumTypeDef.IsInactive.Should().BeFalse();
                enumTypeDef.EnumItemDefs.Count.Should().Be(4);
                enumTypeDef.EnumItemDefs[0].Name.Should().Be("DefaultValue");
                enumTypeDef.EnumItemDefs[0].Value.Should().Be(0);
                enumTypeDef.EnumItemDefs[1].Name.Should().Be("FirstValue");
                enumTypeDef.EnumItemDefs[1].Value.Should().Be(1);
                enumTypeDef.EnumItemDefs[2].Name.Should().Be("SomeValue");
                enumTypeDef.EnumItemDefs[2].Value.Should().Be(2);
                enumTypeDef.EnumItemDefs[3].Name.Should().Be("LastValue");
                enumTypeDef.EnumItemDefs[3].Value.Should().Be(99);
            }
            // enumerator types
            {
                var memberDef = entityDef.AllMemberDefs[0];
                memberDef.Tag.Should().Be(1);
                memberDef.Name.Should().Be("DaysOfWeek");
                memberDef.ProxyDef.Should().BeNull();
                memberDef.ArrayRank.Should().Be(1);
                memberDef.InnerType.Should().Be("System.DayOfWeek");
            }
            {
                var memberDef = entityDef.AllMemberDefs[1];
                memberDef.Tag.Should().Be(2);
                memberDef.Name.Should().Be("MyCustomEnums");
                memberDef.ProxyDef.Should().BeNull();
                memberDef.ArrayRank.Should().Be(1);
                memberDef.InnerType.Should().Be("MyCustomEnum");
            }
            {
                var memberDef = entityDef.AllMemberDefs[2];
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
            Type anchorType = typeof(InvalidModel1.InvalidEntity1);

            var ex = Assert.ThrowsAny<ValidationException>(() =>
            {
                ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            });
            ex.Should().NotBeNull();
            ex.Should().BeOfType<ValidationException>();
            ex.Message.Should().Be("Model1.InvalidEntity1.Grid(): Invalid array rank");
        }

        [Fact]
        public void ReadInvalidTypes2()
        {
            Type anchorType = typeof(InvalidModel2.InvalidEntity2);

            var ex = Assert.ThrowsAny<ValidationException>(() =>
            {
                ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            });
            ex.Should().NotBeNull();
            ex.Should().BeOfType<ValidationException>();
            ex.Message.Should().Be("Model1.InvalidEntity2.MyVersion(): Unknown field type: System.Version");
        }

        [Fact]
        public void ReadMemberLifeCycles()
        {
            Type anchorType = typeof(LifeCycle.Entity1);

            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.Should().Be(1);
            metadata.Tokens.Should().ContainKey("Metadata");
            metadata.ModelDefs.Count.Should().Be(1);
            var modelDef = metadata.ModelDefs[0];
            var entityDef = modelDef.AllEntityDefs.Where(cd => cd.Name == "Entity1").Single();
            entityDef.AllMemberDefs.Count.Should().Be(4);

            // active member
            {
                var member = entityDef.AllMemberDefs[0];
                member.Name.Should().Be("State0_Active");
                member.Tag.Should().Be(1);
                member.State.Should().BeNull();
                member.IsInactive.Should().BeFalse();
                member.IsRedacted.Should().BeFalse();
                //member.State!.Reason.Should().BeNull();
                member.InnerType.Should().Be("bool");
                member.Nullable.Should().BeFalse();
                member.ArrayRank.Should().Be(0);
                member.IsModelType.Should().BeFalse();
                member.IsStringType.Should().BeFalse();
                member.IsBufferType.Should().BeFalse();
                member.ProxyDef.Should().BeNull();
            }

            // reserved member
            {
                var member = entityDef.AllMemberDefs[1];
                member.Name.Should().Be("State1_Reserved");
                member.Tag.Should().Be(2);
                member.State.Should().NotBeNull();
                member.IsInactive.Should().BeFalse();
                member.IsRedacted.Should().BeTrue();
                member.State!.Reason.Should().Be("For future use");
                member.InnerType.Should().Be("bool");
                member.Nullable.Should().BeFalse();
                member.ArrayRank.Should().Be(0);
                member.IsModelType.Should().BeFalse();
                member.IsStringType.Should().BeFalse();
                member.IsBufferType.Should().BeFalse();
                member.ProxyDef.Should().BeNull();
            }

            // deprecated member
            {
                var member = entityDef.AllMemberDefs[2];
                member.Name.Should().Be("State2_Deprecated");
                member.Tag.Should().Be(3);
                member.State.Should().NotBeNull();
                member.IsInactive.Should().BeTrue();
                member.IsRedacted.Should().BeFalse();
                member.State!.Reason.Should().Be("Not used anymore");
                member.InnerType.Should().Be("bool");
                member.Nullable.Should().BeFalse();
                member.ArrayRank.Should().Be(0);
                member.IsModelType.Should().BeFalse();
                member.IsStringType.Should().BeFalse();
                member.IsBufferType.Should().BeFalse();
                member.ProxyDef.Should().BeNull();
            }

            // deleted member
            {
                var member = entityDef.AllMemberDefs[3];
                member.Name.Should().Be("State3_Deleted");
                member.Tag.Should().Be(4);
                member.State.Should().NotBeNull();
                member.IsInactive.Should().BeTrue();
                member.IsRedacted.Should().BeTrue();
                member.State!.Reason.Should().Be("RIP");
                member.InnerType.Should().Be("bool");
                member.Nullable.Should().BeFalse();
                member.ArrayRank.Should().Be(0);
                member.IsModelType.Should().BeFalse();
                member.IsStringType.Should().BeFalse();
                member.IsBufferType.Should().BeFalse();
                member.ProxyDef.Should().BeNull();
            }
        }

    }
}
