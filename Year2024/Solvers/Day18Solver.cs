using System.Diagnostics;

namespace Year2024.Solvers;
public sealed class Day18Solver(string[] input, int stepsToTake, Position endPosition) : AdventOfCodeSolver<long, Position>(input)
{
    public int StepsToTake { get; set; } = stepsToTake;
    public Position EndPosition { get; set; } = endPosition;
    public override long SolvePart1()
    {
        HashSet<Position> corruptedPositions = [];
        foreach (string line in _input.Take(StepsToTake))
        {
            Position corruptedPosition = Position.Parse(line, null);
            _ = corruptedPositions.Add(corruptedPosition);
        }

        Dictionary<Position, (int distance, Position previousPosition)> searchLookup = new()
        {

            { new Position(0, 0), (0, new Position(0,0) )}
        };
        PriorityQueue<Position, int> queue = new();
        queue.Enqueue(new Position(0, 0), 0);
        while (queue.TryDequeue(out Position currentPosition, out int currentDistance))
        {
            if (currentPosition == EndPosition)
            {
                WritePositions(searchLookup, corruptedPositions);
                return currentDistance;
            }

            if (corruptedPositions.Contains(currentPosition) ||
                searchLookup[currentPosition].distance != currentDistance)
            {
                continue;
            }

            foreach (Direction direction in Direction.All)
            {
                Position newPosition = currentPosition + direction;
                if (newPosition.X < 0 ||
                    newPosition.X > EndPosition.X ||
                    newPosition.Y < 0 ||
                    newPosition.Y > EndPosition.Y)
                {
                    continue;
                }

                int newDistance = currentDistance + 1;
                if (!searchLookup.TryGetValue(newPosition, out (int distance, Position previousPosition) existing) || newDistance < existing.distance)
                {
                    searchLookup[newPosition] = (newDistance, currentPosition);
                    queue.Enqueue(newPosition, newDistance);
                }
            }
        }

        return 0;
    }

    private static void WritePositions(Dictionary<Position, (int distance, Position previousPosition)> searchLookup, HashSet<Position> corruptedPositions)
    {
        int width = searchLookup.Keys.Max(p => p.X);
        int height = searchLookup.Keys.Max(p => p.Y);
        for (int y = 0; y <= height; y++)
        {
            for (int x = 0; x <= width; x++)
            {
                Position position = new(x, y);
                if (corruptedPositions.Contains(position))
                {
                    Debug.Write("X");
                }
                else if (searchLookup.TryGetValue(position, out (int distance, Position previousPosition) value))
                {
                    Debug.Write($"O");
                }
                else
                {
                    Debug.Write(".");
                }
            }

            Debug.Write('\n');
        }
    }

    public override Position SolvePart2()
    {
        throw new NotImplementedException();
    }
}

