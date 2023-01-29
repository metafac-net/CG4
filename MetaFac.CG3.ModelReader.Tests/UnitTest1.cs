using FluentAssertions;
using MetaCode.Models;
using System.Reflection;
using Xunit;

namespace MetaCode.ModelReader.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string ns = typeof(TestModel.BuiltinTypes).Namespace!;
            ModelContainer metadata = ModelParser.ParseAssembly(Assembly.GetExecutingAssembly(), ns);
            metadata.Tokens.Count.Should().Be(0);
            metadata.ModelDefs.Count.Should().Be(1);
            var modelDef = metadata.ModelDefs[0];
            modelDef.Tokens.Count.Should().Be(0);
            modelDef.ClassDefs.Count.Should().Be(1);
            var classDef = modelDef.ClassDefs[0];
            classDef.Tokens.Count.Should().Be(0);
            classDef.FieldDefs.Count.Should().Be(20);

            // external type
            var field20 = classDef.FieldDefs[19];
            field20.Tag.Should().Be(20);
            field20.Name.Should().Be("Quantities");
            field20.ProxyDef.Should().NotBeNull();
            field20.ProxyDef!.HasNames.Should().BeTrue();
            field20.ProxyDef.ExternalName.Should().Be("LabApps.Units.Quantity");
            field20.ProxyDef.ConcreteName.Should().Be("QuantityValue");
            field20.ArrayRank.Should().Be(1);
            field20.InnerType.Should().Be("Quantity");
        }
    }
}