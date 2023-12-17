using ClumsyCrucible;

internal class Solver
{
	private readonly City _city;

	public Solver(City city)
	{
		_city = city;
	}

	public int MinimizeHeatLoss<TCrucible>(Position startPosition, Position endPosition, Func<Position, Direction, TCrucible> createCrucible)
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