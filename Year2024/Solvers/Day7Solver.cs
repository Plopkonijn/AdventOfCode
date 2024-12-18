using System.Text.RegularExpressions;

namespace Year2024.Solvers;

public sealed class Day7Solver(string[] input) : DefaultAdventOfCodeSolver(input)
{
    public override long SolvePart1()
    {
        return CalculateTotalPossibleEquations(AddOperation, MultiplyOperation);
    }

    public override long SolvePart2()
    {
        return CalculateTotalPossibleEquations(AddOperation, MultiplyOperation, ConcatOperation);
    }

    private long CalculateTotalPossibleEquations(params Operation[] operations)
    {
        long total = 0;
        foreach (string line in _input)
        {
            Match resultMatch = Regex.Match(line, @"\d+(?=:)");
            long result = long.Parse(resultMatch.Value);

            MatchCollection operandsMatch = Regex.Matches(line, @"\d+(?![\d:])");
            List<long> operands = operandsMatch.Select(m => long.Parse(m.Value))
                                               .ToList();
            if (!IsPossibleEquation(result, operands[0], operands, 1, operations))
            {
                continue;
            }

            total += result;
        }

        return total;
    }

    private bool IsPossibleEquation(long expectedResult, long actualResult, List<long> operands, int index, Operation[] operations)
    {
        if (index == operands.Count)
        {
            return expectedResult == actualResult;
        }

        long operand = operands[index];
        foreach (Operation operation in operations)
        {
            long newResult = operation(actualResult, operand);
            if (newResult <= expectedResult && IsPossibleEquation(expectedResult, newResult, operands, index + 1, operations))
            {
                return true;
            }
        }

        return false;
    }

    private delegate long Operation(long left, long right);

    private long AddOperation(long left, long right)
    {
        return left + right;
    }

    private long MultiplyOperation(long left, long right)
    {
        return left * right;
    }

    private long ConcatOperation(long left, long right)
    {
        return long.Parse($"{left}{right}");
    }
}