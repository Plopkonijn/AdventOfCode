namespace AdvenOfCode.Solvers.Year2015.Day01;

public sealed class NotQuiteLispSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            result += line.Aggregate(0, (a, c) => c switch
            {
                '(' => a + 1,
                ')' => a - 1,
                _ => throw new InvalidOperationException()
            });
        }
        return result;
    }

    public override long SolvePart2()
    {
        long result = 0;
        foreach (string line in Input)
        {
            int floor = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                floor = c switch
                {
                    '(' => floor + 1,
                    ')' => floor - 1,
                    _ => throw new InvalidOperationException()
                };
                if (floor is -1)
                {
                    result += i + 1;
                    break;
                }
            }
        }
        return result;
    }
}