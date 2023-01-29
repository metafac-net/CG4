using FluentAssertions;
using System;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace MetaFac.CG3.TextProcessing.UnitTests
{
    public class EncryptedTextTests
    {
        private const string testId = "479C6DD3-D48E-441C-8455-9E8ABAF7B570";
        private const string testKey = "249-89-170-209-79-22-102-62-1-241-208-236-14-48-49-54-163-218-164-31-2-231-152-81-122-184-12-26-227-66-246-133";
        private const string testIV = "166-201-233-92-74-249-175-92-244-17-179-104-87-128-161-99";

        [Theory]
        [InlineData("{", "3a67628e-2e64-ad01-6d34-95f32f5fc4eb")]
        [InlineData("}", "c69962ef-cc8c-d2c1-0ecc-b8de2b14d2f4")]
        public void MD5HashRegressionCheck(string text, string hashAsGuid)
        {
            using (HashAlgorithm hasher = MD5.Create())
            {
                var hash = hasher.ComputeHash(Encoding.Unicode.GetBytes(text));
                hash.Length.Should().Be(16);
                Guid fromHash = new Guid(hash);
                fromHash.ToString("D").Should().Be(hashAsGuid);
            }
        }

    }
}