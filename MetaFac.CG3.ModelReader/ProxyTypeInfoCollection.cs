using System.Collections.Immutable;

namespace MetaFac.CG3.ModelReader
{
    internal class ProxyTypeInfoCollection
    {
        private ImmutableDictionary<string, ProxyTypeInfo> _coll = ImmutableDictionary<string, ProxyTypeInfo>.Empty;

        public bool TryGetValue(string typeName, out ProxyTypeInfo? info)
        {
            return _coll.TryGetValue(typeName, out info);
        }
        public void Add(string typeName, ProxyTypeInfo info)
        {
            _coll = _coll.Add(typeName, info);
        }
    }
}