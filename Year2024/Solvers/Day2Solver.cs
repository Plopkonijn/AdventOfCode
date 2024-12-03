using System.Data;
using System.Text.RegularExpressions;

namespace Year2024.Solvers;

public sealed partial class Day2Solver(string[] input) : AdventOfCodeSolver(input)
{
    public override long SolvePart1(string[] input)
    {
        long safeReports = 0;
        foreach (string line in input)
        {
            long[] values = NumberRegex().Matches(line)
                              .Select(m => long.Parse(m.Value))
                              .ToArray();
            if (IsSafeReport(values))
            {
                safeReports++;
            }
        }

        return safeReports;
    }

    private static bool IsSafeReport(long[] values, int omitIndex = -1)
    {
        bool isIncreasing = IsIncreasingReport(values, omitIndex);

        for (int i = 0; i < values.Length - 1; i++)
        {
            long currentValue = values[i];
            if (i == omitIndex)
            {
                if (i == 0)
                {
                    continue;
                }

                currentValue = values[i - 1];
            }

            long nextValue = values[i + 1];

            if (i + 1 == omitIndex)
            {
                if (i + 1 >= values.Length - 1)
                {
                    continue;
                }

                nextValue = values[i + 2];
            }

            if (isIncreasing)
            {
                if (currentValue > nextValue)
                {
                    return false;
                }

                long difference = nextValue - currentValue;
                if (difference is < 1 or > 3)
                {
                    return false;
                }
            }
            else
            {
                if (currentValue < nextValue)
                {
                    return false;
                }

                long difference = currentValue - nextValue;
                if (difference is < 1 or > 3)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static bool IsIncreasingReport(long[] values, int omitIndex)
    {
        return omitIndex switch
        {
            -1 => values[0] <= values[1],
            0 => values[1] <= values[2],
            1 => values[0] <= values[2],
            _ => values[0] <= values[1]
        };
    }

    public override long SolvePart2(string[] input)
    {
        long safeReports = 0;
        foreach (string line in input)
        {
            long[] values = NumberRegex().Matches(line)
                              .Select(m => long.Parse(m.Value))
                              .ToArray();
            for (int omitIndex = -1; omitIndex < values.Length; omitIndex++)
            {
                if (IsSafeReport(values, omitIndex))
                {
                    safeReports++;
                    break;
                }
            }
        }

        return safeReports;
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();
}