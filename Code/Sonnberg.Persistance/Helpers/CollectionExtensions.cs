using System;
using System.Collections.Generic;

namespace Sonnberg.Persistance.Helpers
{
    public static class CollectionExtensions
    {
        public static void ForEach<TItem>(this IEnumerable<TItem> collection, Action<TItem> action)
        {
            if (collection == null)
                return;
            foreach (TItem obj in collection)
            {
                action(obj);
            }
        }

        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> range)
        {
            foreach (T obj in range)
            {
                collection.Add(obj);
            }
        }
    }
}
