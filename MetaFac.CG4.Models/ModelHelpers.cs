using System.Collections.Generic;
using System;

namespace MetaFac.CG4.Models
{
    internal static class ModelHelpers
    {
        public static IEnumerable<TTarget> NotNullRange<TSource, TTarget>(this IEnumerable<TSource>? source, Func<TSource, TTarget?> converter)
        {
            if (source is not null)
            {
                foreach (var item in source)
                {
                    TTarget? target = converter(item);
                    if (target is not null)
                    {
                        yield return target;
                    }
                }
            }
        }
    }
}