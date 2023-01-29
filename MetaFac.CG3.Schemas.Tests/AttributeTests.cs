using FluentAssertions;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace MetaFac.CG3.Schemas.UnitTests
{
    [Entity(1)] internal class GoodEntity { }

    [Entity(0)] internal class BadTagEntity { }

    public class AttributeTests
    {
        [Fact]
        public void NormalUsageTest()
        {
            Attribute[] customAttributes = typeof(GoodEntity).GetCustomAttributes().ToArray();
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
                Attribute[] customAttributes = typeof(BadTagEntity).GetCustomAttributes().ToArray();
            });
            ex.Message.Should().StartWith("Specified argument was out of the range of valid values.");
        }
    }
}