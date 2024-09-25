using System.Collections.Generic;

namespace Andromeda.Collections.Extensions
{
    public static class IDictionaryExtensions_Struct
    {
        public static TDefault GetValueOrDefault<TKey, TDefault>(
            this IDictionary<TKey, object?> dict,
            TKey key,
            TDefault defaultValue
        )
            where TDefault : struct
            => (
                dict.TryGetValue(key, out var val)
                    ? val as TDefault?
                    : null
            ) ?? defaultValue;

        public static TDefault? GetValueOrDefault<TKey, TDefault>(
            this IDictionary<TKey, object?> dict,
            TKey key,
            TDefault? defaultValue
        )
            where TDefault : struct
            => (
                dict.TryGetValue(key, out var val)
                    ? val as TDefault?
                    : null
            ) ?? defaultValue;
    }
}
