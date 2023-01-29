using System;
using System.Collections;
using System.Collections.Generic;

namespace MetaCode.Runtime
{
    public class ListFacade<TExternal, TInternal> : IReadOnlyList<TExternal?>
    {
        private readonly IReadOnlyList<TInternal?> _list;
        private readonly Func<TInternal?, TExternal?> _map;

        public ListFacade(IReadOnlyList<TInternal?> list, Func<TInternal?, TExternal?> map)
        {
            _list = list;
            _map = map;
        }

        public TExternal? this[int index] => _map(_list[index]);
        public int Count => _list.Count;
        public IEnumerator<TExternal?> GetEnumerator() => new ListEnumerator(_list, _map);
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private class ListEnumerator : IEnumerator<TExternal?>
        {
            private readonly IEnumerator<TInternal?> _enumerator;
            private readonly Func<TInternal?, TExternal?> _map;

            public ListEnumerator(IReadOnlyList<TInternal?> list, Func<TInternal?, TExternal?> map)
            {
                _enumerator = list.GetEnumerator();
                _map = map;
            }

            public TExternal? Current => _map(_enumerator.Current);
            object? IEnumerator.Current => this.Current;
            public void Dispose() => _enumerator.Dispose();
            public bool MoveNext() => _enumerator.MoveNext();
            public void Reset() => _enumerator.Reset();
        }
    }
}
