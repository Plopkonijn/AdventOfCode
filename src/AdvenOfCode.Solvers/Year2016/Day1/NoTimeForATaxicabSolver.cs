using System.Globalization;

namespace AdvenOfCode.Solvers.Year2016.Day1;

public sealed class NoTimeForATaxicabSolver(string[] Input) : Solver(Input)
{
    public override long SolvePart1()
    {
        LongVector2 start = new(0, 0);
        LongVector2 location = start;
        LongVector2 direction = new(0, 1);

        foreach (string line in Input[0].Split(", "))
        {
            direction = line[0] switch
            {
                'R' => new(direction.Y, -direction.X),
                'L' => new(-direction.Y, direction.X),
                _ => throw new InvalidOperationException()
            };
            long length = long.Parse(line[1..], CultureInfo.InvariantCulture);
            location += direction * length;
        }
        return Math.Abs(location.X) + Math.Abs(location.Y);
    }



    public override long SolvePart2()
    {
        LongVector2 start = new(0, 0);
        LongVector2 location = start;
        LongVector2 direction = new(0, 1);
        HashSet<LongVector2> visited = [start];

        foreach (string line in Input[0].Split(", "))
        {
            direction = line[0] switch
            {
                'R' => new(direction.Y, -direction.X),
                'L' => new(-direction.Y, direction.X),
                _ => throw new InvalidOperationException()
            };
            long length = long.Parse(line[1..], CultureInfo.InvariantCulture);
            for (int i = 1; i <= length; i++)
            {
                location += direction;
                if (!visited.Add(location))
                {
                    return Math.Abs(location.X) + Math.Abs(location.Y);
                }
            }
        }
        throw new InvalidOperationException();
    }
}



