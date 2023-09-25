using MetaFac.Memory;
using System;
using System.Runtime.CompilerServices;

namespace MetaFac.CG4.Runtime
{
    public static class ConversionHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ToExternal<T>(this T value)
        {
            return value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? ToExternal<T>(this T? value) where T : struct
        {
            return value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ToInternal<T>(this T value)
        {
            return value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? ToInternal<T>(this T? value) where T : struct
        {
            return value;
        }
    }
}