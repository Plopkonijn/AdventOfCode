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
        for (int firstGroupSize = 1; firstGroupSize < weights.Length; firstGroupSize++)
        {
            long[] quantumEntanglements = Combinatorics.Combinations(weights, firstGroupSize)
                                                                  .Where(g => g.Sum() == groupWeight)
                                                                  .Select(g => g.Aggregate((a, b) => a * b))
                                                                  .ToArray();
            if (quantumEntanglements.Length == 0)
            {
                continue;
            }
            return quantumEntanglements.Min();
        }
        throw new InvalidOperationException();
    }

    public override long SolvePart2()
    {
        long[] weights = Input.Select(line => long.Parse(line, CultureInfo.InvariantCulture))
            .OrderDescending()
            .ToArray();
        long totalWeight = weights.Sum();
        if (totalWeight % 4 != 0)
        {
            throw new InvalidOperationException();
        }
        long groupWeight = totalWeight / 4;
        for (int firstGroupSize = 1; firstGroupSize < weights.Length; firstGroupSize++)
        {
            long[] quantumEntanglements = Combinatorics.Combinations(weights, firstGroupSize)
                                                                  .Where(g => g.Sum() == groupWeight)
                                                                  .Select(g => g.Aggregate((a, b) => a * b))
                                                                  .ToArray();
            if (quantumEntanglements.Length == 0)
            {
                continue;
            }
            return quantumEntanglements.Min();
        }
        throw new InvalidOperationException();
    }
}