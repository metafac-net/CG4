using FluentAssertions;
using Xunit;

namespace MetaCode.Runtime.GProto3.Tests
{
    public class SByteCodecTests
    {
        [Theory]
        [InlineData(sbyte.MaxValue, sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData(1, 1, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1, -1)]
        [InlineData(sbyte.MinValue, sbyte.MinValue, sbyte.MinValue)]
        public void SByte(sbyte outgoing, int expectedTransit, sbyte expectedIncoming)
        {
            int transit = outgoing.Encode_SByte_To_Int32();
            transit.Should().Be(expectedTransit);

            sbyte incoming = transit.Decode_SByte_From_Int32();
            incoming.Should().Be(expectedIncoming);
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData(sbyte.MaxValue, (int)sbyte.MaxValue, sbyte.MaxValue)]
        [InlineData((sbyte)1, 1, (sbyte)1)]
        [InlineData((sbyte)0, 0, (sbyte)0)]
        [InlineData((sbyte)(-1), -1, (sbyte)(-1))]
        [InlineData(sbyte.MinValue, (int)sbyte.MinValue, sbyte.MinValue)]
        public void SByte_Nullable(sbyte? outgoing, int? expectedTransit, sbyte? expectedIncoming)
        {
            int? transit = outgoing.Encode_SByte_To_Int32();
            transit.Should().Be(expectedTransit);

            sbyte? incoming = transit.Decode_SByte_From_Int32(0);
            incoming.Should().Be(expectedIncoming);
        }

        [Theory]
        [InlineData(byte.MaxValue, byte.MaxValue, byte.MaxValue)]
        [InlineData(1, 1, 1)]
        [InlineData(byte.MinValue, byte.MinValue, byte.MinValue)]
        public void Byte(byte outgoing, uint expectedTransit, byte expectedIncoming)
        {
            uint transit = outgoing.Encode_Byte_To_UInt32();
            transit.Should().Be(expectedTransit);

            byte incoming = transit.Decode_Byte_From_UInt32();
            incoming.Should().Be(expectedIncoming);
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData(byte.MaxValue, (uint)byte.MaxValue, byte.MaxValue)]
        [InlineData((byte)1, (uint)(byte)1, (byte)1)]
        [InlineData(byte.MinValue, (uint)byte.MinValue, byte.MinValue)]
        public void Byte_Nullable(byte? outgoing, uint? expectedTransit, byte? expectedIncoming)
        {
            uint? transit = outgoing.Encode_Byte_To_UInt32();
            transit.Should().Be(expectedTransit);

            byte? incoming = transit.Decode_Byte_From_UInt32(0);
            incoming.Should().Be(expectedIncoming);
        }
    }
}