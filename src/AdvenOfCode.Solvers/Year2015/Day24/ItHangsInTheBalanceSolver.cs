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
        long bestQuantumEntanglement = long.MaxValue;
        long bestSize = long.MaxValue;
        foreach (IEnumerable<long> firstGroup in GenerateGroups(groupWeight, weights))
        {
            long[] firstGroupArray = firstGroup.ToArray();
            if (firstGroupArray.Length > bestSize)
            {
                continue;
            }
            long[] remainingWeights = weights.Except(firstGroupArray).ToArray();
            bool hasSecondGroup = GenerateGroups(groupWeight, remainingWeights).Any();
            if (!hasSecondGroup)
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
        return bestQuantumEntanglement;
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
        throw new NotImplementedException();
    }
}