using FluentAssertions;
using MetaFac.CG4.Schemas;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace MetaFac.CG4.Schemas.UnitTests
{
    [Entity(1)] internal interface IGoodEntity { }

    [Entity(0)] internal interface IBadTagEntity { }

    public class AttributeTests
    {
        [Fact]
        public void NormalUsageTest()
        {
            Attribute[] customAttributes = typeof(IGoodEntity).GetCustomAttributes().ToArray();
            customAttributes.Length.Should().Be(1);

            Attribute customAttribute = customAttributes[0];
            customAttribute.Should().BeOfType<EntityAttribute>();

            EntityAttribute entityAttribute = (EntityAttribute)customAttribute;
            entityAttribute.Tag.Should().Be(1);
        }

        [Fact]
        public void BadTagTest()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Attribute[] customAttributes = typeof(IBadTagEntity).GetCustomAttributes().ToArray();
            });
            ex.Message.Should().StartWith("Must be > 0");
        }
    }
}