using System.Collections.Generic;

namespace Andromeda.Collections.Extensions
{
    public static class IDictionaryExtensions_Class
    {
        public static TDefault GetValueOrDefault<TKey, TDefault>(
            this IDictionary<TKey, object?> dict,
            TKey key,
            TDefault defaultValue
        )
            where TDefault : class
            => (
                dict.TryGetValue(key, out var val)
                    ? val as TDefault
                    : null
            ) ?? defaultValue;

        public static TObject? GetValueOrDefault<TKey, TObject>(
            this IDictionary<TKey, TObject?> dict,
            TKey key,
            TObject? defaultValue = null
        )
            where TObject : class
            => dict.TryGetValue(key, out var val)
                ? val
                : defaultValue;
    }
}
