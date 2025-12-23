namespace AdvenOfCode.Solvers.Year2015.Day03;

public sealed class PerfectlySphericalHousesinaVacuumSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            result += CountHouses(line);
        }


        return result;
    }

    private static long CountHouses(string line)
    {
        (long X, long Y) currentLocation = (0, 0);
        HashSet<(long, long)> visited = [currentLocation];

        foreach (char c in line)
        {
            currentLocation = c switch
            {
                '^' => (currentLocation.X, currentLocation.Y + 1),
                'v' => (currentLocation.X, currentLocation.Y - 1),
                '>' => (currentLocation.X + 1, currentLocation.Y),
                '<' => (currentLocation.X - 1, currentLocation.Y),
                _ => throw new InvalidOperationException()
            };
            _ = visited.Add(currentLocation);
        }
        return visited.Count;
    }

    public override long SolvePart2()
    {
        long result = 0;
        foreach (string line in Input)
        {
            result += CountHousesWithRobot(line);
        }


        return result;
    }

    private static long CountHousesWithRobot(string line)
    {
        (long X, long Y) santaLocation = (0, 0);
        (long X, long Y) robotLocation = (0, 0);

        HashSet<(long, long)> visited = [santaLocation];
        foreach ((int i, char c) in line.Index())
        {
            ref (long X, long Y) currentLocation = ref i % 2 == 0 ? ref santaLocation : ref robotLocation;
            currentLocation = c switch
            {
                '^' => (currentLocation.X, currentLocation.Y + 1),
                'v' => (currentLocation.X, currentLocation.Y - 1),
                '>' => (currentLocation.X + 1, currentLocation.Y),
                '<' => (currentLocation.X - 1, currentLocation.Y),
                _ => throw new InvalidOperationException()
            };
            _ = visited.Add(currentLocation);

        }
        return visited.Count;
    }
}