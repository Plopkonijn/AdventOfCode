namespace AdvenOfCode.Solvers;

internal static class Combinatorics
{
    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> items, int length)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(length);
        if (length == 0)
        {
            return Singleton(Enumerable.Empty<T>());
        }
#pragma warning disable CA1851 // Possible multiple enumerations of 'IEnumerable' collection
        if (!items.Any())
        {
            return Enumerable.Empty<IEnumerable<T>>();
        }
        T first = items.First();
#pragma warning restore CA1851 // Possible multiple enumerations of 'IEnumerable' collection
        IEnumerable<T> skip = items.Skip(1);
        return Combinations(skip, length - 1).Select(c => c.Prepend(first))
            .Concat(Combinations(skip, length)); ;
    }

    public static IEnumerable<T> Singleton<T>(T item)
    {
        yield return item;
    }
}
