using Application;

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
	
	private int MinimizeHeatLoss<TCrucible>(Position startPosition, Position endPosition, Func<Position, Direction, TCrucible> createCrucible)
		where TCrucible : ICrucible<TCrucible>, new()
	{
		TCrucible right = createCrucible(startPosition, new Direction(1, 0));
		TCrucible down = createCrucible(startPosition, new Direction(0, 1));

		var visited = new HashSet<TCrucible> { right, down };
		var heatLosses = new Dictionary<TCrucible, int>
		{
			{ right, 0 },
			{ down, 0 }
		};
		var queue = new PriorityQueue<TCrucible, int>();
		queue.Enqueue(right, 0);
		queue.Enqueue(down, 0);
		int iterations = 0;
		while (queue.TryDequeue(out TCrucible? crucible, out int heatLoss))
		{
			iterations++;
			if (crucible.ReachedEnd(endPosition))
				return heatLoss;
			foreach (TCrucible neighbour in crucible.GetNeighbours())
			{
				if (!_city.IsInBounds(neighbour.Position) || visited.Contains(neighbour))
					continue;

				int alternateHeatLoss = heatLoss + _city[neighbour.Position];
				if (!heatLosses.TryGetValue(neighbour, out int currentHeatLoss) || alternateHeatLoss < currentHeatLoss)
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