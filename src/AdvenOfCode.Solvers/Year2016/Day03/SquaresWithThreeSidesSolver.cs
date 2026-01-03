using System.Globalization;

namespace AdvenOfCode.Solvers.Year2016.Day03;

public sealed class SquaresWithThreeSidesSolver(string[] Input) : Solver(Input)
{
    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            long[] sides = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => long.Parse(s, CultureInfo.InvariantCulture))
                .ToArray();
            if (sides.Length != 3)
            {
                throw new InvalidOperationException();
            }
            if (IsValidTriangle(sides[0], sides[1], sides[2]))
            {
                result++;
            }
        }
        return result;
    }

    private static bool IsValidTriangle(long a, long b, long c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    public override long SolvePart2()
    {
        long result = 0;

        foreach (string[] lines in Input.Chunk(3))
        {
            long[][] multiSides = lines.Select(line =>
            {

                return line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => long.Parse(s, CultureInfo.InvariantCulture))
                    .ToArray();
            }).ToArray();
            for (int i = 0; i < 3; i++)
            {
                if (IsValidTriangle(multiSides[0][i], multiSides[1][i], multiSides[2][i]))
                {
                    result++;
                }
            }
        }
        return result;
    }
}