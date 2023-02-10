using FluentAssertions;
using Xunit;

namespace MetaFac.CG3.Runtime.GProto3.Tests
{
    public class ShortCodecTests
    {
        [Theory]
        [InlineData(short.MaxValue, short.MaxValue, short.MaxValue)]
        [InlineData(1, 1, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1, -1)]
        [InlineData(short.MinValue, short.MinValue, short.MinValue)]
        public void Short(short outgoing, int expectedTransit, short expectedIncoming)
        {
            int transit = outgoing.Encode_Int16_To_Int32();
            transit.Should().Be(expectedTransit);

            short incoming = transit.Decode_Int16_From_Int32();
            incoming.Should().Be(expectedIncoming);
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData(short.MaxValue, (int)short.MaxValue, short.MaxValue)]
        [InlineData((short)1, 1, (short)1)]
        [InlineData((short)0, 0, (short)0)]
        [InlineData((short)-1, -1, (short)-1)]
        [InlineData(short.MinValue, (int)short.MinValue, short.MinValue)]
        public void Short_Nullable(short? outgoing, int? expectedTransit, short? expectedIncoming)
        {
            int? transit = outgoing.Encode_Int16_To_Int32();
            transit.Should().Be(expectedTransit);

            short? incoming = transit.Decode_Int16_From_Int32(0);
            incoming.Should().Be(expectedIncoming);
        }

        [Theory]
        [InlineData(ushort.MaxValue, ushort.MaxValue, ushort.MaxValue)]
        [InlineData(1, 1, 1)]
        [InlineData(ushort.MinValue, ushort.MinValue, ushort.MinValue)]
        public void UShort(ushort outgoing, uint expectedTransit, ushort expectedIncoming)
        {
            uint transit = outgoing.Encode_UInt16_To_UInt32();
            transit.Should().Be(expectedTransit);

            ushort incoming = transit.Decode_UInt16_From_UInt32();
            incoming.Should().Be(expectedIncoming);
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData(ushort.MaxValue, (uint)ushort.MaxValue, ushort.MaxValue)]
        [InlineData((ushort)1, (uint)1, (ushort)1)]
        [InlineData(ushort.MinValue, (uint)ushort.MinValue, ushort.MinValue)]
        public void UShort_Nullable(ushort? outgoing, uint? expectedTransit, ushort? expectedIncoming)
        {
            uint? transit = outgoing.Encode_UInt16_To_UInt32();
            transit.Should().Be(expectedTransit);

            ushort? incoming = transit.Decode_UInt16_From_UInt32(0);
            incoming.Should().Be(expectedIncoming);
        }
    }
}