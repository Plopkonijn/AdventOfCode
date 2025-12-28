using System.Globalization;

namespace AdvenOfCode.Solvers.Year2015.Day17;

public sealed class ScienceForHungryPeopleSolver(string[] Input)
{
    public long SolvePart1(long totalVolume)
    {
        long[] containerVolumes = Input.Select(line => long.Parse(line, CultureInfo.InvariantCulture))
            .ToArray();
        return Calculate1(totalVolume, containerVolumes, []);
    }

    private static long Calculate1(long totalVolume, ReadOnlySpan<long> containerVolume, Dictionary<(long, int), long> cache)
    {
        if (cache.TryGetValue((totalVolume, containerVolume.Length), out long result))
        {
            return result;
        }
        result = containerVolume.Length == 0
            ? totalVolume == 0 ? 1 : 0
            : totalVolume < 0
                ? 0
                : totalVolume == 0
                ? 1
                : Calculate1(totalVolume, containerVolume[1..], cache) + Calculate1(totalVolume - containerVolume[0], containerVolume[1..], cache);
        cache.Add((totalVolume, containerVolume.Length), result);
        return result;
    }

    public long SolvePart2(long totalVolume)
    {
        long[] containerVolumes = Input.Select(line => long.Parse(line, CultureInfo.InvariantCulture))
            .ToArray();
        Dictionary<(long, int), (long Amount, long Length)?> cache = [];
        (long Amount, long Length) = Calculate2(totalVolume, containerVolumes, cache) ?? throw new InvalidOperationException();
        return Amount;
    }

    private static (long Amount, long Length)? Calculate2(long totalVolume, ReadOnlySpan<long> containerVolume, Dictionary<(long, int), (long Amount, long Lengt)?> cache)
    {
        if (cache.TryGetValue((totalVolume, containerVolume.Length), out (long Amount, long Lengt)? result))
        {
            return result;
        }
        if (containerVolume.Length == 0)
        {
            if (totalVolume == 0)
            {
                result = (1, 0);
            }
            else
            {
                result = null;
            }
        }
        else if (totalVolume < 0)
        {
            result = null;
        }
        else if (totalVolume == 0)
        {
            result = (1, 0);
        }
        else
        {
            (long Amount, long Length)? excluding = Calculate2(totalVolume, containerVolume[1..], cache);
            (long Amount, long Length)? including = Calculate2(totalVolume - containerVolume[0], containerVolume[1..], cache);
            result = (excluding, including) switch
            {
                (null, null) => null,
                (null, (long, long) i) => (i.Amount, i.Length + 1),
                ((long, long) e, null) => e,
                ((long ea, long el), (long ia, long il)) when el == il + 1 => (ea + ia, el),
                ((long ea, long el), (long, long il)) when el < il + 1 => (ea, el),
                ((long, long el), (long ia, long il)) when el > il + 1 => (ia, il + 1),
                _ => throw new InvalidOperationException()
            };
        }
        cache.Add((totalVolume, containerVolume.Length), result);
        return result;
    }
}