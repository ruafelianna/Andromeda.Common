using System.Collections.Generic;
using System.Linq;

namespace Andromeda.Collections.Extensions
{
    public static class IReadOnlyCollectionExtensions
    {
        public static T? ElementAtOrDefault<T>(
            this IReadOnlyCollection<T> collection,
            int index,
            T? defaultValue = null
        ) where T : struct
            => index >= 0 && index < collection.Count
                ? collection.ElementAt(index)
                : defaultValue;
    }
}
