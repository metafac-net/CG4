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
            ((int)GeneratorId.None).Should().Be(0);
            ((int)GeneratorId.Contracts).Should().Be(1);
            ((int)GeneratorId.MessagePack).Should().Be(2);
            ((int)GeneratorId.ClassesV2).Should().Be(3);
            ((int)GeneratorId.RecordsV2).Should().Be(4);
        }

        [Fact]
        public void CheckGeneratorIdsMatchExternal()
        {
            ((int)GeneratorId.None).Should().Be((int)CG4GeneratorId.None);
            ((int)GeneratorId.Contracts).Should().Be((int)CG4GeneratorId.Contracts);
            ((int)GeneratorId.MessagePack).Should().Be((int)CG4GeneratorId.MessagePack);
            //((int)GeneratorId.ClassesV2).Should().Be((int)CG4GeneratorId.ClassesV2);
            //((int)GeneratorId.RecordsV2).Should().Be((int)CG4GeneratorId.RecordsV2);
        }

        [Fact]
        public void CheckGeneratorAttributeName()
        {
            nameof(CG4GenerateAttribute).Should().Be("CG4GenerateAttribute");
        }
    }
}