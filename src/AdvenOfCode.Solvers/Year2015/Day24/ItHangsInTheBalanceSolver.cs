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
        return Calculate(groupWeight, weights, new GroupTriplet())?.Value ?? throw new InvalidOperationException();
    }
    internal static QuantumEntanglement? Calculate<TTuple>(long groupWeight, ReadOnlySpan<long> weights, TTuple groups)
        where TTuple : IGroupTuple<TTuple>
    {
        Group firstGroup = groups[0];
        if (groups.Any(g => g.Weight > groupWeight || g.Size < firstGroup.Size))
        {
            return null;
        }
        TTuple groupsFirst = groups.AddWeight(0, weights[0]);
        QuantumEntanglement? bestResult = Calculate(groupWeight, weights[1..], groupsFirst)?.AddWeight(weights[0]);
        for (int i = 1; i < TTuple.Length; i++)
        {
            TTuple newGroup = groups.AddWeight(i, weights[0]);
            if (Calculate(groupWeight, weights[1..], newGroup) is not { } result)
            {
                continue;
            }
            if (!bestResult.HasValue || bestResult.Value.Size > result.Size || bestResult.Value.Value > result.Value)
            {
                bestResult = result;
            }
        }
        return bestResult;
    }


    private static IEnumerable<IEnumerable<long>> GenerateGroups(long totalWeight, ReadOnlySpan<long> weights)
    {
        if (totalWeight == 0)
        {
            return Enumerable.Repeat(Enumerable.Empty<long>(), 1);
        }
        if (totalWeight < 0 || weights.Length == 0)
        {
            return Enumerable.Empty<IEnumerable<long>>();
        }
        long weight = weights[0];
        IEnumerable<IEnumerable<long>> including = GenerateGroups(totalWeight - weight, weights[1..]).Select(g => g.Prepend(weight));
        IEnumerable<IEnumerable<long>> excluding = GenerateGroups(totalWeight, weights[1..]);
        return including.Concat(excluding);
    }




    public override long SolvePart2()
    {
        long[] weights = Input.Select(line => long.Parse(line, CultureInfo.InvariantCulture))
           .OrderDescending()
           .ToArray();
        long totalWeight = weights.Sum();
        if (totalWeight % 3 != 0)
        {
            throw new InvalidOperationException();
        }
        long groupWeight = totalWeight / 4;
        long bestQuantumEntanglement = long.MaxValue;
        long bestSize = long.MaxValue;
        foreach (IEnumerable<long> firstGroup in GenerateGroups(groupWeight, weights))
        {
            long[] firstGroupArray = firstGroup.ToArray();
            if (firstGroupArray.Length > bestSize)
            {
                continue;
            }
            long[] remainingWeightsSecondGroup = weights.Except(firstGroupArray).ToArray();
            foreach (IEnumerable<long> secondGroup in GenerateGroups(groupWeight, remainingWeightsSecondGroup))
            {
                long[] secondGroupArray = secondGroup.ToArray();
                long[] remainingWeights = remainingWeightsSecondGroup.Except(secondGroup).ToArray();
                bool hasThirdGroup = GenerateGroups(groupWeight, remainingWeights).Any();
                if (!hasThirdGroup)
                {
                    continue;
                }


                long quantumEntanglement = firstGroupArray.Aggregate((a, b) => a * b);
                if (firstGroupArray.Length < bestSize)
                {
                    bestSize = firstGroupArray.Length;
                    bestQuantumEntanglement = quantumEntanglement;
                }
                else if (quantumEntanglement < bestQuantumEntanglement)
                {
                    bestQuantumEntanglement = quantumEntanglement;
                }
            }
        }
        return bestQuantumEntanglement;
    }
}