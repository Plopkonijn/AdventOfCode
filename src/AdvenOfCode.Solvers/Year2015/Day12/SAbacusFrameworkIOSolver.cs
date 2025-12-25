using System.Globalization;

namespace AdvenOfCode.Solvers.Year2015.Day12;

public sealed class SAbacusFrameworkIOSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            result += SumNumbers(line);
        }
        return result;
    }

    private static long SumNumbers(ReadOnlySpan<char> line)
    {
        long result = 0;
        while (line.Length > 0)
        {
            if (line[0] != '-' && !char.IsDigit(line[0]))
            {
                line = line[1..];
                continue;
            }
            int nonDigitIndex = 1;
            while (line.Length > 0 && char.IsDigit(line[nonDigitIndex]))
            {
                nonDigitIndex++;
            }
            ReadOnlySpan<char> digit = line[0..nonDigitIndex];
            result += long.Parse(digit, CultureInfo.InvariantCulture);
            line = line[nonDigitIndex..];
        }
        return result;
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}