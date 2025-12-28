using System.Globalization;

namespace AdvenOfCode.Solvers.Year2015.Day17;

public sealed class ScienceForHungryPeopleSolver(string[] Input)
{
    public long SolvePart1(long totalVolume)
    {
        long[] containerVolumes = Input.Select(line => long.Parse(line, CultureInfo.InvariantCulture))
            .ToArray();
        return Calculate(totalVolume, containerVolumes, []);
    }

    private static long Calculate(long totalVolume, ReadOnlySpan<long> containerVolume, Dictionary<(long, int), long> cache)
    {
        if (cache.TryGetValue((totalVolume, containerVolume.Length), out long result))
        {
            return result;
        }
        if (containerVolume.Length == 0)
        {
            result = totalVolume == 0 ? 1 : 0;
        }
        else if (totalVolume < 0)
        {
            result = 0;
        }
        else
        {
            result = totalVolume == 0
                ? 1
                : Calculate(totalVolume, containerVolume[1..], cache) + Calculate(totalVolume - containerVolume[0], containerVolume[1..], cache);
        }
        cache.Add((totalVolume, containerVolume.Length), result);
        return result;
    }

    public long SolvePart2()
    {
        throw new NotImplementedException();
    }
}