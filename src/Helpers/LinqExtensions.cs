using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piksel.Dearchiver.Helpers
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (TSource item in source)
            {
                action(item);
            }

            return source;
        }

        public static IEnumerable<(TKey, TValue)> ForEach<TKey, TValue>(this IEnumerable<(TKey, TValue)> source, Action<TKey, TValue> action)
        {
            foreach (var tuple in source)
            {
                action(tuple.Item1, tuple.Item2);
            }

            return source;
        }

        public static IEnumerable<TSource> ChainedForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (TSource item in source)
            {
                action(item);
                yield return item;
            }
        }

        public static IEnumerable<(TKey, TValue)> ChainedForEach<TKey, TValue>(this IEnumerable<(TKey, TValue)> source, Action<TKey, TValue> action)
        {
            foreach (var tuple in source)
            {
                action(tuple.Item1, tuple.Item2);
                yield return tuple;
            }
        }

        public static void ExecuteChain<TSource>(this IEnumerable<TSource> source)
            => source.LastOrDefault();
    }
}
