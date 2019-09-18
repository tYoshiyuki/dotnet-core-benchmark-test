using System;
using System.Collections.Generic;

namespace DotNetCoreBenchmarkTest.Extensions
{
    public static class EnumerableExtension
    {
        public static T FirstOrDefault<T, TState>(this IEnumerable<T> source,
            Func<T, TState, bool> predicate, TState state)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            foreach (var x in source)
            {
                if (predicate(x, state)) return x;
            }

            return default;
        }
    }
}
