using System;
using System.Collections.Immutable;

namespace MetaCode.TextProcessing
{
    public interface IEncryptedTextCache : IDisposable
    {
        bool IsNonEncrypting { get; }
        Guid AddText(string text);
        string GetText(Guid hash);
        ImmutableDictionary<Guid, ImmutableArray<byte>> Cache { get; }
        Guid KeyId { get; }
    }
}