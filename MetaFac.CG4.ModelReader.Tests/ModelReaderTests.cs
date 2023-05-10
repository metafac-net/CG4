using FluentAssertions;
using MetaFac.CG4.Models;
using System.Linq;
using System.Reflection;
using Xunit;

namespace MetaFac.CG4.ModelReader.Tests
{
    public class ModelReaderTests
    {
        [Fact]
        public void RoundtripModelViaJson()
        {
            // arrange
            string ns = typeof(TestModel.BuiltinTypes).Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(Assembly.GetExecutingAssembly(), ns);
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
            string ns = typeof(TestModel.BuiltinTypes).Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(Assembly.GetExecutingAssembly(), ns);
            metadata.Tokens.Count.Should().Be(0);
            metadata.ModelDefs.Count.Should().Be(1);
            var modelDef = metadata.ModelDefs[0];
            modelDef.EntityDefs.Count.Should().Be(3);
            var entityDef = modelDef.EntityDefs[0];
            entityDef.Name.Should().Be("BuiltinTypes");
            entityDef.FieldDefs.Count.Should().Be(19);
        }

        [Fact]
        public void ReadExternalTypes()
        {
            string ns = typeof(TestModel.ExternalTypes).Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(Assembly.GetExecutingAssembly(), ns);
            metadata.Tokens.Count.Should().Be(0);
            metadata.ModelDefs.Count.Should().Be(1);
            var modelDef = metadata.ModelDefs[0];
            var entityDef = modelDef.EntityDefs.Where(cd => cd.Name == "ExternalTypes").Single();
            entityDef.FieldDefs.Count.Should().Be(1);

            // external type
            var field0 = entityDef.FieldDefs[0];
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
            string ns = typeof(TestModel.ExternalTypes).Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(Assembly.GetExecutingAssembly(), ns);
            metadata.Tokens.Count.Should().Be(0);
            metadata.ModelDefs.Count.Should().Be(1);
            var modelDef = metadata.ModelDefs[0];
            var entityDef = modelDef.EntityDefs.Where(cd => cd.Name == "EnumeratorTypes").Single();
            entityDef.FieldDefs.Count.Should().Be(3);

            // enumerator types
            {
                var fieldDef = entityDef.FieldDefs[0];
                fieldDef.Tag.Should().Be(1);
                fieldDef.Name.Should().Be("DaysOfWeek");
                fieldDef.ProxyDef.Should().BeNull();
                fieldDef.ArrayRank.Should().Be(1);
                fieldDef.InnerType.Should().Be("System.DayOfWeek");
            }
            {
                var fieldDef = entityDef.FieldDefs[1];
                fieldDef.Tag.Should().Be(2);
                fieldDef.Name.Should().Be("MyCustomEnums");
                fieldDef.ProxyDef.Should().BeNull();
                fieldDef.ArrayRank.Should().Be(1);
                fieldDef.InnerType.Should().Be("MetaFac.CG4.ModelReader.Tests.TestModel.MyCustomEnum");
            }
            {
                var fieldDef = entityDef.FieldDefs[2];
                fieldDef.Tag.Should().Be(3);
                fieldDef.Name.Should().Be("MyDateTimeKinds");
                fieldDef.ProxyDef.Should().NotBeNull();
                fieldDef.ProxyDef!.ExternalName.Should().Be("System.DateTimeKind");
                fieldDef.ProxyDef.ConcreteName.Should().Be("MyDateTimeKindValue");
                fieldDef.ArrayRank.Should().Be(1);
                fieldDef.InnerType.Should().Be("MyDateTimeKind");
            }
        }

    }
}