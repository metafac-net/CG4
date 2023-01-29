using FluentAssertions;
using System;
using System.Text.Json;
using Xunit;

namespace MetaCode.Runtime.JsonPoco.Tests
{
    public class RoundtripTests
    {
        [Theory]
        [InlineData(0L, "\"00:00:00\"")]
        [InlineData(10000000L, "\"00:00:01\"")]
        [InlineData(-10000000L, "\"-00:00:01\"")]
        [InlineData(long.MaxValue, "\"10675199.02:48:05.4775807\"")]
        [InlineData(long.MinValue, "\"-10675199.02:48:05.4775808\"")]
        public void Roundtrip_TimeSpan(long ticks, string expectedJson)
        {
            TimeSpan original = new TimeSpan(ticks);
            TimeSpanData outgoing = original;
            string json = JsonSerializer.Serialize<TimeSpanData>(outgoing);
            json.Should().Be(expectedJson);
            TimeSpanData incoming = JsonSerializer.Deserialize<TimeSpanData>(json);
            TimeSpan duplicate = incoming;
            duplicate.Should().Be(original);
        }

        [Theory]
        [InlineData(0L)]
        [InlineData(10000000L)]
        [InlineData(-10000000L)]
        [InlineData(long.MaxValue)]
        [InlineData(long.MinValue)]
        public void Roundtrip_PocoWithTimeSpan(long ticks)
        {
            TestPoco original = new TestPoco() { Field1 = "abc", Field2 = new TimeSpan(ticks) };
            string json = JsonSerializer.Serialize<TestPoco>(original);
            TestPoco? duplicate = JsonSerializer.Deserialize<TestPoco>(json);
            duplicate.Should().NotBeNull();
            duplicate.Should().Be(original);
        }
    }
}