using System.Collections.Specialized;
using System.Globalization;

namespace AdvenOfCode.Solvers.Year2015.Day24;

public sealed partial class ItHangsInTheBalanceSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long[] weights = Input.Select(line => long.Parse(line, CultureInfo.InvariantCulture))
            .OrderDescending()
            .ToArray();
        long totalWeight = weights.Sum();
        if (totalWeight % 3 != 0)
        {
            throw new InvalidOperationException();
        }
        long groupWeight = totalWeight / 3;
        return GetMinimumEntanglement(groupWeight, new Distribution(), weights, []) ?? throw new InvalidOperationException();
    }

    private static long? GetMinimumEntanglement(long maxWeight, Distribution distribution, ReadOnlySpan<long> weights, Dictionary<Distribution, long?> cache)
    {
        if (cache.TryGetValue(distribution, out long? result))
        {
            return result;
        }
        if (weights.Length == 0)
        {
            if (distribution.IsValid())
            {
                return 1;
            }
            else
            {
                return null;
            }
        }
        if (distribution.FirstWeight > maxWeight || distribution.SecondWeight > maxWeight || distribution.ThirdWeight > maxWeight)
        {
            return null;
        }

        int mask = 1 << (weights.Length - 1);
        result = null;
        Distribution first = distribution with
        {
            FirstWeight = distribution.FirstWeight + weights[0],
            FirstIndices = new BitVector32(distribution.FirstIndices.Data | mask)
        };
        if (GetMinimumEntanglement(maxWeight, first, weights[1..], cache) is { } firstEntanglement && firstEntanglement * weights[0] < result)
        {
            result = firstEntanglement * weights[0];
        }
        Distribution second = distribution with
        {
            SecondWeight = distribution.SecondWeight + weights[0],
            SecondIndices = new BitVector32(distribution.SecondIndices.Data | mask)
        };
        if (GetMinimumEntanglement(maxWeight, second, weights[1..], cache) is { } secondEntanglement && secondEntanglement < result)
        {
            result = secondEntanglement;
        }
        Distribution third = distribution with
        {
            ThirdWeight = distribution.ThirdWeight + weights[0],
            ThirdIndices = new BitVector32(distribution.ThirdIndices.Data | mask)
        };
        if (GetMinimumEntanglement(maxWeight, third, weights[1..], cache) is { } thirdEntanglement && thirdEntanglement < result)
        {
            result = thirdEntanglement;
        }
        cache.Add(distribution, result);
        return result;
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}