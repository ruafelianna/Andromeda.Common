using System;
using System.Collections.Generic;

namespace Andromeda.Collections.Extensions
{
    public static class ArrayExtensions
    {
        public static IEnumerable<object> Enumerate(this Array array)
        {
            var en = array.GetEnumerator();

            while (en.MoveNext())
            {
                yield return en.Current;
            }
        }
    }
}
