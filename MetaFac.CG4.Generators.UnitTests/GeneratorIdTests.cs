using FluentAssertions;
using MetaFac.CG4.SrcGenAttributes;
using Xunit;

namespace MetaFac.CG4.Generators.UnitTests
{
    public class GeneratorIdTests
    {
        [Fact]
        public void CheckGeneratorIdAbsoluteValues()
        {
            ((int)InternalGeneratorId.None).Should().Be(0);
            ((int)InternalGeneratorId.Contracts).Should().Be(1);
            ((int)InternalGeneratorId.MessagePack).Should().Be(2);
        }

        [Fact]
        public void CheckGeneratorIdsMatchExternal()
        {
            ((int)InternalGeneratorId.None).Should().Be((int)CG4GeneratorId.None);
            ((int)InternalGeneratorId.Contracts).Should().Be((int)CG4GeneratorId.Contracts);
            ((int)InternalGeneratorId.MessagePack).Should().Be((int)CG4GeneratorId.MessagePack);
        }

        [Fact]
        public void CheckGeneratorAttributeName()
        {
            nameof(CG4GenerateAttribute).Should().Be("CG4GenerateAttribute");
        }
    }
}