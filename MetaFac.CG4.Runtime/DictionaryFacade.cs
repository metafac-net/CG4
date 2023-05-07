using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.Runtime
{
    public class DictionaryFacade<TKey, TExternal, TInternal> : IReadOnlyDictionary<TKey, TExternal?> where TKey : notnull
    {
        private readonly IReadOnlyDictionary<TKey, TInternal?> _dict;
        private readonly Func<TInternal?, TExternal?> _map;

        public DictionaryFacade(IReadOnlyDictionary<TKey, TInternal?> dict, Func<TInternal?, TExternal?> map)
        {
            _dict = dict;
            _map = map;
        }

        public TExternal? this[TKey key] => _map(_dict[key]);
        public IEnumerable<TKey> Keys => _dict.Keys;
        public IEnumerable<TExternal?> Values => _dict.Values.Select(_map);
        public int Count => _dict.Count;
        public bool ContainsKey(TKey key) => _dict.ContainsKey(key);
        public bool TryGetValue(TKey key, out TExternal? value)
        {
            bool result = _dict.TryGetValue(key, out var local);
            value = _map(local);
            return result;
        }
        public IEnumerator<KeyValuePair<TKey, TExternal?>> GetEnumerator() => new InternalEnumerator(_dict, _map);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class InternalEnumerator : IEnumerator<KeyValuePair<TKey, TExternal?>>
        {
            private readonly IEnumerator<KeyValuePair<TKey, TInternal?>> _enumerator;
            private readonly Func<TInternal?, TExternal?> _map;

            public InternalEnumerator(IReadOnlyDictionary<TKey, TInternal?> dict, Func<TInternal?, TExternal?> map)
            {
                _enumerator = dict.GetEnumerator();
                _map = map;
            }
            public KeyValuePair<TKey, TExternal?> Current
            {
                get
                {
                    KeyValuePair<TKey, TInternal?> kvp = _enumerator.Current;
                    return new KeyValuePair<TKey, TExternal?>(kvp.Key, _map(kvp.Value));
                }
            }

            object IEnumerator.Current => Current;
            public void Dispose() => _enumerator.Dispose();
            public bool MoveNext() => _enumerator.MoveNext();
            public void Reset() => _enumerator.Reset();
        }
    }
}
