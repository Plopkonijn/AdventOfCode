using System.Text.RegularExpressions;

public sealed class Day2Solver : AdventOfCodeSolver
{
    public Day2Solver(string[] input) : base(input)
    {
    }

    public override long SolvePart1(string[] input)
    {
        long safeReports = 0;
        foreach (string line in input)
        {
            long[] values = Regex.Matches(line, @"\d+")
                              .Select(m => long.Parse(m.Value))
                              .ToArray();
            if (IsSafeReport(values))
            {
                safeReports++;
            }
        }

        return safeReports;
    }

    private bool IsSafeReport(long[] values)
    {
        bool isIncreasing = values[0] <= values[1];
        for (int i = 0; i < values.Length - 1; i++)
        {
            if (isIncreasing)
            {
                if (values[i] > values[i + 1])
                {
                    return false;
                }

                long difference = values[i + 1] - values[i];
                if (difference is < 1 or > 3)
                {
                    return false;
                }
            }
            else
            {
                if (values[i] < values[i + 1])
                {
                    return false;
                }

                long difference = values[i] - values[i + 1];
                if (difference is < 1 or > 3)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override long SolvePart2(string[] input)
    {
        throw new NotImplementedException();
    }
}