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
		return MinimizeHeatLoss(startPosition, endPosition, 0, 3);
	}

	public long PartTwo()
	{
		var startPosition = new Position(0, 0);
		var endPosition = new Position(_city.Width - 1, _city.Height - 1);
		return MinimizeHeatLoss(startPosition, endPosition, 4, 10);
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
			if (heatLosses.TryGetValue(crucible, out var currentHeatLoss) && currentHeatLoss < heatLoss)
			{
				continue;
			}

			if (crucible.position.Equals(endPosition))
			{
				return heatLoss;
			}

			var leftDirection = crucible.direction.TurnLeft();
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

			var rightDirection = crucible.direction.TurnRight();
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
			position = position.Move(direction);
			if (!_city.IsInBounds(position))
				yield break;
			heatLoss += _city[position];
			if (steps >= minimumSteps)
			{
				yield return (position, heatLoss);
			}
		}
	}
}