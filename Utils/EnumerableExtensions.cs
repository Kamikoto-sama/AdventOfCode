namespace Utils;

public static class EnumerableExtensions
{
    public static IEnumerable<List<T>> Split<T>(this IEnumerable<T> source, Func<T, bool> split)
    {
        var batch = new List<T>();
        foreach (var item in source)
            if (split(item))
            {
                yield return batch;
                batch.Clear();
            }
            else
                batch.Add(item);
    }

    public static void RemoveRange<T>(this HashSet<T> source, IEnumerable<T> items)
    {
        foreach (var item in items)
            source.Remove(item);
    }

    public static IOrderedEnumerable<T> OrderDesc<T>(this IEnumerable<T> source) => source.OrderByDescending(x => x);

    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source) where TKey : notnull
    {
        return source.ToDictionary(x => x.Key, x => x.Value);
    }

    public static void Deconstruct<T>(this IEnumerable<T> source, out T item1, out T item2)
    {
        using var enumerator = source.GetEnumerator();
        item1 = GetNextItem(enumerator, 2);
        item2 = GetNextItem(enumerator, 2);
    }

    private static T GetNextItem<T>(IEnumerator<T> enumerator, int desiredItemsCount)
    {
        if (!enumerator.MoveNext())
            throw new InvalidOperationException($"Collection contains less than {desiredItemsCount} items");

        return enumerator.Current;
    }
}