namespace AdvenOfCode.Solvers.Year2025.Day4;

public sealed class PrintingDepartmentSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long result = 0;
        for (int y = 0; y < Input.Length; y++)
        {
            string line = Input[y];
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] is not '@')
                {
                    continue;
                }

                if (IsLiftable(x, y))
                {
                    result++;
                }
            }
        }

        return result;
    }

    private bool IsLiftable(int xPosition, int yPosition)
    {
        int total = 0;
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                int y = yPosition + dy;
                if (y < 0 || y >= Input.Length)
                {
                    continue;
                }
                int x = xPosition + dx;
                if (x < 0 || x >= Input[y].Length)
                {
                    continue;
                }
                if (Input[y][x] is '@')
                {
                    total++;
                }
            }
        }
        return total < 5;
    }

    public override long SolvePart2()
    {
        return SolvePart2(Input.Select(line => line.ToArray()).ToArray());
    }

    private static long SolvePart2(char[][] input)
    {
        char[][] newInput = new char[input.Length][];
        for (int i = 0; i < newInput.Length; i++)
        {
            newInput[i] = new char[input[i].Length];
            Array.Copy(input[i], newInput[i], input[i].Length);
        }

        long result = 0;
        for (int y = 0; y < input.Length; y++)
        {
            char[] line = input[y];
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] is not '@')
                {
                    continue;
                }

                if (IsLiftable(input, x, y))
                {
                    result++;
                    char[] newLline = newInput[y];
                    newLline[x] = '.';
                }
            }
        }

        return result == 0 ? result : result + SolvePart2(newInput);
    }

    private static bool IsLiftable(char[][] input, int xPosition, int yPosition)
    {
        int total = 0;
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                int y = yPosition + dy;
                if (y < 0 || y >= input.Length)
                {
                    continue;
                }
                int x = xPosition + dx;
                if (x < 0 || x >= input[y].Length)
                {
                    continue;
                }
                if (input[y][x] is '@')
                {
                    total++;
                }
            }
        }
        return total < 5;
    }
}