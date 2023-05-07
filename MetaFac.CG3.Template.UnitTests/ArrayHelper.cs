using System;
using System.Collections.Immutable;

namespace MetaFac.CG3.Template.UnitTests
{
    internal static class ArrayHelper
    {
        public static ImmutableArray<T> ToImmutableArray<T>(this ReadOnlyMemory<T> source)
        {
            if (source.IsEmpty) return default;
            var span = source.Span;
            var builder = ImmutableArray<T>.Empty.ToBuilder();
            builder.Count = span.Length;
            for (int i = 0; i < span.Length; i++)
            {
                builder[i] = span[i];
            }
            return builder.ToImmutable();
        }
    }
}