using ClumsyCrucible;

internal class Solver
{
	private readonly City _city;

	public Solver(City city)
	{
		_city = city;
	}

	public int MinimizeHeatLoss(Position startPosition, Position endPosition)
	{
		var right = new Crucible(startPosition, new Direction(1, 0));
		var down = new Crucible(startPosition, new Direction(0, 1));

		var visited = new HashSet<Crucible> { right, down };
		var heatLosses = new Dictionary<Crucible, int>
		{
			{ right, 0 },
			{ down, 0 }
		};
		var queue = new PriorityQueue<Crucible, int>();
		queue.Enqueue(right, 0);
		queue.Enqueue(down, 0);
		int iterations = 0;
		while (queue.TryDequeue(out Crucible crucible, out int heatLoss))
		{
			iterations++;
			if (crucible.Position.Equals(endPosition))
				return heatLoss;
			foreach (Crucible neighbour in crucible.GetNeighbours())
			{
				if (!_city.IsInBounds(neighbour.Position) || visited.Contains(neighbour))
					continue;

				int alternateHeatLoss = heatLoss + _city[neighbour.Position];
				if (!heatLosses.TryGetValue(neighbour, out int currentHeatLoss) || alternateHeatLoss < currentHeatLoss)
				{
					heatLosses[neighbour] = alternateHeatLoss;
					queue.Enqueue(neighbour,alternateHeatLoss);
				}
			}
			visited.Add(crucible);

		}

		throw new InvalidOperationException();
	}
}