namespace Year2024.Solvers;
public class Day6Solver : DefaultAdventOfCodeSolver
{
    public Day6Solver(string[] input) : base(input)
    {
    }

    public override long SolvePart1()
    {
        Map map = new(_input);
        Position position = map.FindPositionOf('^');
        Direction direction = (0, -1);
        HashSet<Position> visited = [position];
        while (true)
        {
            _ = visited.Add(position);
            for (int i = 0; i < 3; i++)
            {
                Position nextPosition = position + direction;
                if (map.IsOutOfBounds(nextPosition))
                {
                    return visited.Count;
                }

                if (map[nextPosition] == '#')
                {
                    direction = direction.TurnClockWise();
                }
                else
                {
                    position = nextPosition;
                    break;
                }
            }
        }

        throw new InvalidOperationException("No solution found");
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}
