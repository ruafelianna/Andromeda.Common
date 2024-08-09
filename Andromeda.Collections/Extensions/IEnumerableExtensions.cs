using System.Collections.Generic;
using System.Linq;

namespace Andromeda.Collections.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> BreakIntoGroups<T>(
            this IEnumerable<T> source,
            int groupSize
        ) => source
            .Select((x, i) => new { Key = i / groupSize, Value = x })
            .GroupBy(x => x.Key, x => x.Value);
    }
}
