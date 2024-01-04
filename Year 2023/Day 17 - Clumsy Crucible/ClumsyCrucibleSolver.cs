using Application;
using Common;

namespace Year2023.Day17;

public sealed class ClumsyCrucibleSolver : ISolver
{
	private readonly City _city;

	public ClumsyCrucibleSolver(string[] args)
	{
		_city = City.Parse(args);
	}

	public long PartOne()
	{
		var startPosition = new Position(0, 0);
		var endPosition = new Position(_city.Width - 1, _city.Height - 1);
		return MinimizeHeatLoss(startPosition, endPosition, (p, d) => new Crucible(p, d));
	}

	public long PartTwo()
	{
		var startPosition = new Position(0, 0);
		var endPosition = new Position(_city.Width - 1, _city.Height - 1);
		return MinimizeHeatLoss(startPosition, endPosition, (p, d) => new UltraCrucible(p, d));
	}

	private int MinimizeHeatLoss(Position startPosition, Position endPosition, int minimumSteps, int maximumSteps)
	{
		var heatLosses = new Dictionary<(Position position, Direction direction), int>
		{
			{ (startPosition, new Direction(1, 0)), 0 },
			{ (startPosition, new Direction(0, 1)), 0 }
		};
		var queue = new PriorityQueue<(Position position, Direction direction), int>();
		queue.Enqueue((startPosition, new Direction(1, 0)), 0);
		queue.Enqueue((startPosition, new Direction(0, 1)), 0);

		while (queue.TryDequeue(out var crucible, out var heatLoss))
		{
			if (crucible.position.Equals(endPosition))
			{
				return heatLoss;
			}

			var leftDirection = TurnLeft(crucible.direction);
			foreach (var (newPosition, newHeatLoss) in GetNewPositions(crucible.position, leftDirection, minimumSteps, maximumSteps))
			{
				var alternativeHeatLoss = heatLoss + newHeatLoss;
				if (heatLosses.TryGetValue((newPosition, leftDirection), out var existingHeatLoss) && existingHeatLoss <= alternativeHeatLoss)
				{
					continue;
				}

				heatLosses[(newPosition, leftDirection)] = alternativeHeatLoss;
				queue.Enqueue((newPosition, leftDirection), alternativeHeatLoss);
			}

			var rightDirection = TurnRight(crucible.direction);
			foreach (var (newPosition, newHeatLoss) in GetNewPositions(crucible.position, rightDirection, minimumSteps, maximumSteps))
			{
				var alternativeHeatLoss = heatLoss + newHeatLoss;
				if (heatLosses.TryGetValue((newPosition, rightDirection), out var existingHeatLoss) && existingHeatLoss <= alternativeHeatLoss)
				{
					continue;
				}

				heatLosses[(newPosition, rightDirection)] = alternativeHeatLoss;
				queue.Enqueue((newPosition, rightDirection), alternativeHeatLoss);
			}
		}

		throw new InvalidOperationException();
	}

	private IEnumerable<(Position position, int heatLoss)> GetNewPositions(Position position, Direction direction, int minimumSteps, int maximumSteps)
	{
		var heatLoss = 0;
		for (var steps = 1; steps <= maximumSteps; steps++)
		{
			position = new Position(position.X + direction.X, position.Y + direction.Y);
			if (position.X < 0 || position.X >= _city.Width || position.Y < 0 || position.Y >= _city.Height)
			{
				yield break;
			}

			heatLoss += _city[position];
			if (steps >= minimumSteps)
			{
				yield return (position, heatLoss);
			}
		}
	}

	private Direction TurnLeft(Direction direction)
	{
		return new Direction(direction.Y, direction.X);
	}

	private Direction TurnRight(Direction direction)
	{
		return new Direction(-direction.Y, -direction.X);
	}

	private int MinimizeHeatLoss<TCrucible>(Position startPosition, Position endPosition, Func<Position, Direction, TCrucible> createCrucible)
		where TCrucible : ICrucible<TCrucible>, new()
	{
		var right = createCrucible(startPosition, new Direction(1, 0));
		var down = createCrucible(startPosition, new Direction(0, 1));

		var visited = new HashSet<TCrucible> { right, down };
		var heatLosses = new Dictionary<TCrucible, int>
		{
			{ right, 0 },
			{ down, 0 }
		};
		var queue = new PriorityQueue<TCrucible, int>();
		queue.Enqueue(right, 0);
		queue.Enqueue(down, 0);
		var iterations = 0;
		while (queue.TryDequeue(out var crucible, out var heatLoss))
		{
			iterations++;
			if (crucible.ReachedEnd(endPosition))
			{
				return heatLoss;
			}

			foreach (var neighbour in crucible.GetNeighbours())
			{
				if (!_city.IsInBounds(neighbour.Position) || visited.Contains(neighbour))
				{
					continue;
				}

				var alternateHeatLoss = heatLoss + _city[neighbour.Position];
				if (!heatLosses.TryGetValue(neighbour, out var currentHeatLoss) || alternateHeatLoss < currentHeatLoss)
				{
					heatLosses[neighbour] = alternateHeatLoss;
					queue.Enqueue(neighbour, alternateHeatLoss);
				}
			}

			visited.Add(crucible);
		}

		throw new InvalidOperationException();
	}
}