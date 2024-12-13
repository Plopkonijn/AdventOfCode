using System.Text.RegularExpressions;

namespace Year2024.Solvers;

public sealed class Day7Solver(string[] input) : AdventOfCodeSolver(input)
{
    public override long SolvePart1()
    {
        long total = 0;
        foreach (string line in _input)
        {
            Match resultMatch = Regex.Match(line, @"\d+(?=:)");
            long result = long.Parse(resultMatch.Value);

            MatchCollection operandsMatch = Regex.Matches(line, @"\d+(?![\d:])");
            List<long> operands = operandsMatch.Select(m => long.Parse(m.Value))
                                               .ToList();
            if (!IsPossibleEquation(result, operands[0], operands, 1))
            {
                continue;
            }

            total += result;
        }

        return total;
    }

    private bool IsPossibleEquation(long expectedResult, long actualResult, List<long> operands, int index)
    {
        if (index == operands.Count)
        {
            return expectedResult == actualResult;
        }

        long operand = operands[index];

        if (actualResult + operand <= expectedResult && IsPossibleEquation(expectedResult, actualResult + operand, operands, index + 1))
        {
            return true;
        }

        if (actualResult * operand <= expectedResult && IsPossibleEquation(expectedResult, actualResult * operand, operands, index + 1))
        {
            return true;
        }

        return false;
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}