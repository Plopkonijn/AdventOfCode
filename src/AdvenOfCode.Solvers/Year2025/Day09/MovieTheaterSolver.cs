using System.Globalization;

namespace AdvenOfCode.Solvers.Year2025.Day09;

public sealed class MovieTheaterSolver(string[] input) : Solver(input)
{

    public override long SolvePart1()
    {
        long result = 0;
        Tile[] tiles = ReadTiles();
        for (int i = 0; i < tiles.Length; i++)
        {
            Tile tileI = tiles[i];
            for (int j = i + 1; j < tiles.Length; j++)
            {
                Tile tileJ = tiles[j];
                long area = CalculateArea(tileI, tileJ);
                if (area > result)
                {
                    result = area;
                }
            }
        }


        return result;
    }

    private Tile[] ReadTiles()
    {
        return Input.Select(line => line.Split(',').Select(s => long.Parse(s, CultureInfo.InvariantCulture)).ToArray())
                    .Select(s => new Tile(s[0], s[1]))
                    .ToArray();
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
        long result = 0;
        Tile[] redTiles = ReadTiles();
        Edge[] edges = redTiles.Zip(redTiles[1..].Append(redTiles[0]))
            .Select(t => new Edge(t.First, t.Second))
            .ToArray();

        for (int i = 0; i < redTiles.Length; i++)
        {
            Tile tileI = redTiles[i];
            for (int j = i + 1; j < redTiles.Length; j++)
            {
                Tile tileJ = redTiles[j];
                Rectangle rectangle = new(tileI, tileJ);
                long area = rectangle.CalculateArea();
                if (area <= result || edges.Any(e => Intersects(rectangle, e)))
                {
                    continue;
                }
                result = area;
            }
        }

        return result;
    }

    private static bool Intersects(Rectangle rectangle, Edge edge)
    {
        return rectangle.MinX < edge.MaxX &&
               rectangle.MaxX > edge.MinX &&
               rectangle.MinY < edge.MaxY &&
               rectangle.MaxY > edge.MinY;
    }
}
