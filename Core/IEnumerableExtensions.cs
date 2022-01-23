using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public static class EnumerableExtensions
    {
        private static readonly Random Rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        public static IEnumerable<T> Replace<T>(this IEnumerable<T> enumerable, int index, T value)
        {
            return enumerable.Select((x, i) => index == i ? value : x);
        }

    }
}