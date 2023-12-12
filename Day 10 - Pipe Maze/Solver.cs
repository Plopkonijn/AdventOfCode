internal class Solver
{
	private readonly Dictionary<(int x, int y), long> _distances;
	private readonly Map _map;
	private readonly Queue<(int x, int y)> _queue;

	public Solver(Map map)
	{
		_map = map;
		(int x, int y) startPosition = map.GetStartPosition();
		_queue = new Queue<(int x, int y)>();
		_distances = new Dictionary<(int x, int y), long>
		{
			{ startPosition, 0 }
		};
		(int x, int y) leftPosition = (startPosition.x - 1, startPosition.y);
		if (leftPosition.x >= _map.MinX && _map.GetTile(leftPosition) is '-' or 'F' or 'L')
		{
			_queue.Enqueue(leftPosition);
			_distances.Add(leftPosition, 1);
		}

		(int x, int y) rightPosition = (startPosition.x + 1, startPosition.y);
		if (rightPosition.x < _map.MaxX && _map.GetTile(rightPosition) is '-' or '7' or 'J')
		{
			_queue.Enqueue(rightPosition);
			_distances.Add(rightPosition, 1);
		}

		(int x, int y) topPosition = (startPosition.x, startPosition.y - 1);
		if (topPosition.y >= _map.MinY && _map.GetTile(topPosition) is '|' or 'F' or '7')
		{
			_queue.Enqueue(topPosition);
			_distances.Add(topPosition, 1);
		}

		(int x, int y) bottomPosition = (startPosition.x, startPosition.y + 1);
		if (bottomPosition.y <= _map.MaxY && _map.GetTile(bottomPosition) is '|' or 'L' or 'J')
		{
			_queue.Enqueue(bottomPosition);
			_distances.Add(bottomPosition, 1);
		}
	}

	public long GertFurthestDistance()
	{
		while (_queue.TryDequeue(out (int x, int y) position))
		{
			(int x, int y) = position;
			long newDistance = _distances[position] + 1;
			char tile = _map.GetTile(position);
			DiscoverNeighbourPositions(tile, x, y, newDistance);
		}

		return _distances.Values.Max();
	}

	private void DiscoverNeighbourPositions(char tile, int x, int y, long newDistance)
	{
		switch (tile)
		{
			case '|':
				DiscoverPosition((x, y - 1), newDistance);
				DiscoverPosition((x, y + 1), newDistance);
				break;
			case '-':
				DiscoverPosition((x - 1, y), newDistance);
				DiscoverPosition((x + 1, y), newDistance);
				break;
			case 'L':
				DiscoverPosition((x, y - 1), newDistance);
				DiscoverPosition((x + 1, y), newDistance);
				break;
			case 'J':
				DiscoverPosition((x - 1, y), newDistance);
				DiscoverPosition((x, y - 1), newDistance);
				break;
			case '7':
				DiscoverPosition((x - 1, y), newDistance);
				DiscoverPosition((x, y + 1), newDistance);
				break;
			case 'F':
				DiscoverPosition((x, y + 1), newDistance);
				DiscoverPosition((x + 1, y), newDistance);
				break;
			default:
				throw new InvalidOperationException();
		}
	}

	private void DiscoverPosition((int x, int) position, long newDistance)
	{
		if (_distances.TryAdd(position, newDistance))
			_queue.Enqueue(position);
	}
}