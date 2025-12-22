using System.Globalization;

namespace AdvenOfCode.Solvers.Year2025.Day06;

public sealed class TrashCompactorSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        List<List<long>> problems = [];
        foreach (string line in Input[..^1])
        {
            List<long> values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => long.Parse(s, CultureInfo.InvariantCulture))
                .ToList();
            problems.Add(values);
        }
        long result = 0;
        foreach ((int i, string? c) in Input[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Index())
        {
            IEnumerable<long> row = problems.Select(row => row[i]);
            result += c switch
            {
                "+" => row.Sum(),
                "*" => row.Aggregate((a, b) => a * b),
                _ => throw new InvalidOperationException()
            };
        }
        return result;
    }

    public override long SolvePart2()
    {
        long result = 0;
        Func<long, long, long> currentOperator = null!;
        List<long> problem = [];
        int length = Input.Max(line => line.Length);
        for (int i = 0; i < length; i++)
        {
            if (Input[^1][i] is char c && c is not ' ')
            {
                currentOperator = c switch
                {
                    '+' => (long a, long b) => a + b,
                    '*' => (long a, long b) => a * b,
                    _ => null!
                };
            }
            problem.Clear();
            while (Input.Any(line => i < line.Length && line[i] is not ' '))
            {
                string column = new([.. Input[..^1].Select(s => s[i]).Where(c => c != ' ')]);
                i++;
                if (column.Length == 0)
                {
                    continue;
                }
                long value = long.Parse(column, CultureInfo.InvariantCulture);
                problem.Add(value);
            }
            if (problem.Count > 0)
            {
                long value = problem.Aggregate(currentOperator);
                result += value;
            }
        }

        return result;
    }
}