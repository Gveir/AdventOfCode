using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode07
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> values, int length)
        {
            if (length == 1) return values.Select(t => new T[] { t });

            return GetPermutations(values, length - 1)
                .SelectMany(t => values.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
