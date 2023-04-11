using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace MetaFac.CG3.ModelReader
{
    internal class ProxyTypeInfoCollection
    {
        private ImmutableDictionary<string, ProxyTypeInfo> _coll = ImmutableDictionary<string, ProxyTypeInfo>.Empty;

#if NET5_0_OR_GREATER
        public bool TryGetValue(string typeName, [MaybeNullWhen(false)] out ProxyTypeInfo info)
#else
        public bool TryGetValue(string typeName, out ProxyTypeInfo? info)
#endif
        {
            return _coll.TryGetValue(typeName, out info);
        }
        public void Add(string typeName, ProxyTypeInfo info)
        {
            _coll = _coll.Add(typeName, info);
        }
    }
}