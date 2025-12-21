using System.Globalization;
using Tile = (long X, long Y);

namespace AdvenOfCode.Solvers.Year2025.Day09;

public sealed class MovieTheaterSolver(string[] input) : Solver(input)
{

    public override long SolvePart1()
    {
        long result = 0;
        Tile[] tiles = Input.Select(line => line.Split(',').Select(s => long.Parse(s, CultureInfo.InvariantCulture)).ToArray())
            .Select(s => new Tile(s[0], s[1]))
            .ToArray();
        for (int i = 0; i < tiles.Length; i++)
        {
            (long X, long Y) tileI = tiles[i];
            for (int j = i + 1; j < tiles.Length; j++)
            {
                (long X, long Y) tileJ = tiles[j];
                long area = CalculateArea(tileI, tileJ);
                if (area > result)
                {
                    result = area;
                }
            }
        }


        return result;
    }

    private static long CalculateArea(Tile a, Tile b)
    {
        long width = a.X - b.X;
        width = width < 0 ? -width : width;
        width++;

        long height = a.Y - b.Y;
        height = height < 0 ? -height : height;
        height++;
        return width * height;
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}