using Shouldly;
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
            metadata.Tokens.Count.ShouldBe(1);
            metadata.Tokens.ShouldContainKey("Metadata");
            metadata.ModelDefs.Count.ShouldBe(1);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.ShouldBeEmpty();
            validationResult.Warnings.ShouldBeEmpty();

            // act
            string originalJson = metadata.ToJson(true);
            var metadata2 = ModelContainer.FromJson(originalJson);

            // assert
            metadata2.ShouldBe(metadata);

            // act again
            string duplicateJson = metadata2.ToJson(true);

            // assert
            duplicateJson.ShouldBe(originalJson);
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
                new ModelEntityDef("Entity1", false, 1, "Entity 1", null, memberDefs)
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
            metadata.Tokens.Count.ShouldBe(0);
            metadata.ModelDefs.Count.ShouldBe(1);
            string originalJson = metadata.ToJson(true);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.ShouldBeEmpty();
            validationResult.Warnings.ShouldBeEmpty();

            // act
            var metadata2 = ModelContainer.FromJson(originalJson);

            // assert
            metadata2.ShouldBe(metadata);

            // act again
            string duplicateJson = metadata2.ToJson(true);

            // assert
            duplicateJson.ShouldBe(originalJson);
        }

        [Fact]
        public void ReadComplexModel()
        {
            Type anchorType = typeof(ComplexModel1.BaseMessage);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.ShouldBe(1);
            metadata.Tokens.ShouldContainKey("Metadata");
            metadata.ModelDefs.Count.ShouldBe(1);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.ShouldBeEmpty();
            validationResult.Warnings.ShouldBeEmpty();

            var modelDef = metadata.ModelDefs[0];
            modelDef.AllEntityDefs.Count.ShouldBe(28);
            var entityDef = modelDef.AllEntityDefs[0];
            entityDef.Name.ShouldBe("BaseMessage");
            entityDef.AllMemberDefs.Count.ShouldBe(1);
        }

        [Fact]
        public void ReadComplexModel2()
        {
            Type anchorType = typeof(ComplexModel2.AccountType);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.ShouldBe(1);
            metadata.Tokens.ShouldContainKey("Metadata");
            metadata.ModelDefs.Count.ShouldBe(1);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.ShouldBeEmpty();
            validationResult.Warnings.ShouldBeEmpty();

            var modelDef = metadata.ModelDefs[0];
            modelDef.AllEntityDefs.Count.ShouldBe(4);
            var entityDef = modelDef.AllEntityDefs[0];
            entityDef.Name.ShouldBe("AccountType");
            entityDef.AllMemberDefs.Count.ShouldBe(1);
        }

        [Fact]
        public void ReadBuiltinTypes()
        {
            Type anchorType = typeof(GoodModels.BuiltinTypes);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.ShouldBe(1);
            metadata.Tokens.ShouldContainKey("Metadata");
            metadata.ModelDefs.Count.ShouldBe(1);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.ShouldBeEmpty();
            validationResult.Warnings.ShouldBeEmpty();

            var modelDef = metadata.ModelDefs[0];
            modelDef.AllEntityDefs.Count.ShouldBe(3);
            var entityDef = modelDef.AllEntityDefs[0];
            entityDef.Name.ShouldBe("BuiltinTypes");
            entityDef.AllMemberDefs.Count.ShouldBe(19);
        }

        [Fact]
        public void ReadExternalTypes()
        {
            Type anchorType = typeof(GoodModels.ExternalTypes);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.ShouldBe(1);
            metadata.Tokens.ShouldContainKey("Metadata");
            metadata.ModelDefs.Count.ShouldBe(1);

            var validator = new ModelValidator();
            var validationResult = validator.Validate(metadata);
            validationResult.Errors.ShouldBeEmpty();
            validationResult.Warnings.ShouldBeEmpty();

            var modelDef = metadata.ModelDefs[0];
            var entityDef = modelDef.AllEntityDefs.Where(cd => cd.Name == "ExternalTypes").Single();
            entityDef.AllMemberDefs.Count.ShouldBe(1);

            // external type
            var field0 = entityDef.AllMemberDefs[0];
            field0.Tag.ShouldBe(1);
            field0.Name.ShouldBe("Quantities");
            field0.ProxyDef.ShouldNotBeNull();
            field0.ProxyDef!.ExternalName.ShouldBe("LabApps.Units.Quantity");
            field0.ProxyDef.ConcreteName.ShouldBe("QuantityValue");
            field0.ArrayRank.ShouldBe(1);
            field0.InnerType.ShouldBe("Quantity");
        }

        [Fact]
        public void ReadEnumeratorTypes()
        {
            Type anchorType = typeof(GoodModels.ExternalTypes);
            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.ShouldBe(1);
            metadata.Tokens.ShouldContainKey("Metadata");
            metadata.ModelDefs.Count.ShouldBe(1);
            var modelDef = metadata.ModelDefs[0];
            var entityDef = modelDef.AllEntityDefs.Where(cd => cd.Name == "EnumeratorTypes").Single();
            entityDef.AllMemberDefs.Count.ShouldBe(3);

            // enumeration definitions
            modelDef.AllEnumTypeDefs.Count.ShouldBe(1);
            {
                var enumTypeDef = modelDef.AllEnumTypeDefs[0];
                enumTypeDef.Tag.ShouldBeNull();
                enumTypeDef.Name.ShouldBe("MyCustomEnum");
                enumTypeDef.IsRedacted.ShouldBeFalse();
                enumTypeDef.IsInactive.ShouldBeFalse();
                enumTypeDef.EnumItemDefs.Count.ShouldBe(4);
                enumTypeDef.EnumItemDefs[0].Name.ShouldBe("DefaultValue");
                enumTypeDef.EnumItemDefs[0].Value.ShouldBe(0);
                enumTypeDef.EnumItemDefs[1].Name.ShouldBe("FirstValue");
                enumTypeDef.EnumItemDefs[1].Value.ShouldBe(1);
                enumTypeDef.EnumItemDefs[2].Name.ShouldBe("SomeValue");
                enumTypeDef.EnumItemDefs[2].Value.ShouldBe(2);
                enumTypeDef.EnumItemDefs[3].Name.ShouldBe("LastValue");
                enumTypeDef.EnumItemDefs[3].Value.ShouldBe(99);
            }
            // enumerator types
            {
                var memberDef = entityDef.AllMemberDefs[0];
                memberDef.Tag.ShouldBe(1);
                memberDef.Name.ShouldBe("DaysOfWeek");
                memberDef.ProxyDef.ShouldBeNull();
                memberDef.ArrayRank.ShouldBe(1);
                memberDef.InnerType.ShouldBe("System.DayOfWeek");
            }
            {
                var memberDef = entityDef.AllMemberDefs[1];
                memberDef.Tag.ShouldBe(2);
                memberDef.Name.ShouldBe("MyCustomEnums");
                memberDef.ProxyDef.ShouldBeNull();
                memberDef.ArrayRank.ShouldBe(1);
                memberDef.InnerType.ShouldBe("MyCustomEnum");
            }
            {
                var memberDef = entityDef.AllMemberDefs[2];
                memberDef.Tag.ShouldBe(3);
                memberDef.Name.ShouldBe("MyDateTimeKinds");
                memberDef.ProxyDef.ShouldNotBeNull();
                memberDef.ProxyDef!.ExternalName.ShouldBe("System.DateTimeKind");
                memberDef.ProxyDef.ConcreteName.ShouldBe("MyDateTimeKindValue");
                memberDef.ArrayRank.ShouldBe(1);
                memberDef.InnerType.ShouldBe("MyDateTimeKind");
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
            ex.ShouldNotBeNull();
            ex.ShouldBeOfType<ValidationException>();
            ex.Message.ShouldBe("Model1.InvalidEntity1.Grid(): Invalid array rank");
            ex.ValidationError.ErrorCode.ShouldBe(ValidationErrorCode.InvalidArrayRank);
        }

        [Fact]
        public void ReadInvalidTypes2()
        {
            Type anchorType = typeof(InvalidModel2.InvalidEntity2);

            var ex = Assert.ThrowsAny<ValidationException>(() =>
            {
                ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            });
            ex.ShouldNotBeNull();
            ex.ShouldBeOfType<ValidationException>();
            ex.Message.ShouldBe("Model1.InvalidEntity2.MyType(): Unknown field type: System.Type");
            ex.ValidationError.ErrorCode.ShouldBe(ValidationErrorCode.UnknownFieldType);
        }

        [Fact]
        public void ReadInvalidTypes3()
        {
            Type anchorType = typeof(InvalidModel3.InvalidEntity3);

            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            var ex = Assert.ThrowsAny<ValidationException>(() =>
            {
                var validator = new ModelValidator();
                var validationResult = validator.Validate(metadata, ValidationErrorHandling.ThrowOnFirst);
            });
            ex.ShouldNotBeNull();
            ex.ShouldBeOfType<ValidationException>();
            ex.Message.ShouldBe("Model1.InvalidEntity3.MyField1: Field tag (1) is same as field: BaseField1");
            ex.ValidationError.ErrorCode.ShouldBe(ValidationErrorCode.DuplicateFieldTag);
        }

        [Fact]
        public void ReadMemberLifeCycles()
        {
            Type anchorType = typeof(LifeCycle.Entity1);

            ModelContainer metadata = ModelParser.ParseAssembly(anchorType);
            metadata.Tokens.Count.ShouldBe(1);
            metadata.Tokens.ShouldContainKey("Metadata");
            metadata.ModelDefs.Count.ShouldBe(1);
            var modelDef = metadata.ModelDefs[0];
            var entityDef = modelDef.AllEntityDefs.Where(cd => cd.Name == "Entity1").Single();
            entityDef.AllMemberDefs.Count.ShouldBe(4);

            // active member
            {
                var member = entityDef.AllMemberDefs[0];
                member.Name.ShouldBe("State0_Active");
                member.Tag.ShouldBe(1);
                member.State.ShouldBeNull();
                member.IsInactive.ShouldBeFalse();
                member.IsRedacted.ShouldBeFalse();
                //member.State!.Reason.ShouldBeNull();
                member.InnerType.ShouldBe("bool");
                member.Nullable.ShouldBeFalse();
                member.ArrayRank.ShouldBe(0);
                member.IsModelType.ShouldBeFalse();
                member.IsStringType.ShouldBeFalse();
                member.IsBufferType.ShouldBeFalse();
                member.ProxyDef.ShouldBeNull();
            }

            // reserved member
            {
                var member = entityDef.AllMemberDefs[1];
                member.Name.ShouldBe("State1_Reserved");
                member.Tag.ShouldBe(2);
                member.State.ShouldNotBeNull();
                member.IsInactive.ShouldBeFalse();
                member.IsRedacted.ShouldBeTrue();
                member.State!.Reason.ShouldBe("For future use");
                member.InnerType.ShouldBe("bool");
                member.Nullable.ShouldBeFalse();
                member.ArrayRank.ShouldBe(0);
                member.IsModelType.ShouldBeFalse();
                member.IsStringType.ShouldBeFalse();
                member.IsBufferType.ShouldBeFalse();
                member.ProxyDef.ShouldBeNull();
            }

            // deprecated member
            {
                var member = entityDef.AllMemberDefs[2];
                member.Name.ShouldBe("State2_Deprecated");
                member.Tag.ShouldBe(3);
                member.State.ShouldNotBeNull();
                member.IsInactive.ShouldBeTrue();
                member.IsRedacted.ShouldBeFalse();
                member.State!.Reason.ShouldBe("Not used anymore");
                member.InnerType.ShouldBe("bool");
                member.Nullable.ShouldBeFalse();
                member.ArrayRank.ShouldBe(0);
                member.IsModelType.ShouldBeFalse();
                member.IsStringType.ShouldBeFalse();
                member.IsBufferType.ShouldBeFalse();
                member.ProxyDef.ShouldBeNull();
            }

            // deleted member
            {
                var member = entityDef.AllMemberDefs[3];
                member.Name.ShouldBe("State3_Deleted");
                member.Tag.ShouldBe(4);
                member.State.ShouldNotBeNull();
                member.IsInactive.ShouldBeTrue();
                member.IsRedacted.ShouldBeTrue();
                member.State!.Reason.ShouldBe("RIP");
                member.InnerType.ShouldBe("bool");
                member.Nullable.ShouldBeFalse();
                member.ArrayRank.ShouldBe(0);
                member.IsModelType.ShouldBeFalse();
                member.IsStringType.ShouldBeFalse();
                member.IsBufferType.ShouldBeFalse();
                member.ProxyDef.ShouldBeNull();
            }
        }

    }
}
