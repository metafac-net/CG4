using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Security.Cryptography;
using System.Text;

namespace MetaCode.TextProcessing
{
    public class NotEncryptedTextCache : IEncryptedTextCache
    {
        public bool IsNonEncrypting => true;

        private ImmutableDictionary<Guid, ImmutableArray<byte>> _cache = ImmutableDictionary<Guid, ImmutableArray<byte>>.Empty;
        public ImmutableDictionary<Guid, ImmutableArray<byte>> Cache => _cache;

        public Guid KeyId => Guid.Empty;

        public void Dispose()
        {
        }

        public Guid AddText(string text)
        {
            if (text is null) throw new ArgumentNullException(nameof(text));

            using (var hasher = MD5.Create())
            {
                var inputBuffer = Encoding.Unicode.GetBytes(text);
                Guid hash = new Guid(hasher.ComputeHash(inputBuffer));
                if (_cache.TryGetValue(hash, out var _)) return hash;
                ImmutableInterlocked.TryAdd(ref _cache, hash, inputBuffer.ToImmutableArray<byte>());
                return hash;
            }
        }

        public string GetText(Guid hash)
        {
            if (_cache.TryGetValue(hash, out var encrypted))
            {
                byte[] inputBuffer = encrypted.AsSpan().ToArray(); // todo alloc!
                return Encoding.Unicode.GetString(inputBuffer);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}