namespace Year2023.Day10;

internal class Solver
{
	private readonly Dictionary<(int x, int y), long> _distances;
	private readonly Map _map;
	private readonly Queue<(int x, int y)> _queue;

	public Solver(Map map)
	{
		_map = map;
		var startPosition = map.GetStartPosition();
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
		while (_queue.TryDequeue(out var position))
		{
			(var x, var y) = position;
			var newDistance = _distances[position] + 1;
			var tile = _map.GetTile(position);
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
		{
			_queue.Enqueue(position);
		}
	}

	public ICollection<(int x, int y)> GetNumberOfEnclosedTiles()
	{
		var orderedPositions = _distances.Keys.OrderBy(position => position.x)
		                                 .ThenBy(position => position.y)
		                                 .Take(2)
		                                 .ToArray();

		var startPosition = orderedPositions.First();
		var previousPosition = startPosition;
		var currentPosition = orderedPositions.Last();
		var innerPositions = new HashSet<(int x, int y)>();

		while (currentPosition != startPosition)
		{
			// (int x, int y) innerPosition = GetInnerPosition(previousPosition, currentPosition);
			var foundInnerPositions = GetInnerPositions(previousPosition, currentPosition);
			foreach (var innerPosition in foundInnerPositions)
			{
				if (!_distances.ContainsKey(innerPosition))
				{
					innerPositions.Add(innerPosition);
				}
			}

			var nextPosition = GetNextPosition(previousPosition, currentPosition);
			previousPosition = currentPosition;
			currentPosition = nextPosition;
		}

		var lastInnerPosition = GetInnerPosition(previousPosition, currentPosition);
		if (!_distances.ContainsKey(lastInnerPosition))
		{
			innerPositions.Add(lastInnerPosition);
		}

		var queue = new Queue<(int x, int y)>(innerPositions);
		while (queue.TryDequeue(out var position))
		{
			for (var x = position.x - 1; x <= position.x + 1; x++)
			{
				if (!_map.IsInXRange(x))
				{
					continue;
				}

				for (var y = position.y - 1; y <= position.y + 1; y++)
				{
					if (!_map.IsInYRange(y))
					{
						continue;
					}

					var neighbourPosition = (x, y);
					if (!_distances.ContainsKey(neighbourPosition) && _map.IsInRange(neighbourPosition) && innerPositions.Add(neighbourPosition))
					{
						queue.Enqueue(neighbourPosition);
					}
				}
			}
		}

		return innerPositions;
	}

	private IEnumerable<(int x, int y)> GetInnerPositions((int x, int y) previousPosition, (int x, int y) currentPosition)
	{
		(var x, var y) = GetInnerPosition(previousPosition, currentPosition);
		var tile = _map.GetTile(currentPosition);
		(var dx, var dy) = GetDirection(previousPosition, currentPosition);
		switch (tile, (dx, dy))
		{
			case ('-', _):
			case ('|', _):
				//Moving Straight
				yield return (x + dx, y + dy);
				yield return (x, y);
				yield return (x - dx, y - dy);
				break;
			case ('L', (0, 1)):
			case ('J', (1, 0)):
			case ('7', (0, -1)):
			case ('F', (-1, 0)):
				//Moving Left

				break;
			case ('L', (-1, 0)):
			case ('J', (0, 1)):
			case ('7', (1, 0)):
			case ('F', (0, -1)):
				//Moving Right
				yield return (x, y);
				yield return (x + dx, y + dy);
				yield return (currentPosition.x + dx, currentPosition.y + dy);
				break;
		}
	}

	private (int x, int y) GetInnerPosition((int x, int y) previousPosition, (int x, int y) currentPosition)
	{
		(var dx, var dy) = GetDirection(previousPosition, currentPosition);
		return (currentPosition.x + dy, currentPosition.y - dx);
	}

	private static (int x, int y) GetDirection((int x, int y) previousPosition, (int x, int y) currentPosition)
	{
		var dx = currentPosition.x - previousPosition.x;
		var dy = currentPosition.y - previousPosition.y;
		return (dx, dy);
	}

	private (int x, int y) GetNextPosition((int x, int y) previousPosition, (int x, int y) currentPosition)
	{
		var tile = _map.GetTile(currentPosition);
		var direction = GetDirection(previousPosition, currentPosition);
		switch (tile, direction)
		{
			case ('-', _):
			case ('|', _):
				return MoveStraight(currentPosition, direction);
			case ('L', (0, 1)):
			case ('J', (1, 0)):
			case ('7', (0, -1)):
			case ('F', (-1, 0)):
				return MoveLeft(currentPosition, direction);
			case ('L', (-1, 0)):
			case ('J', (0, 1)):
			case ('7', (1, 0)):
			case ('F', (0, -1)):
				return MoveRight(currentPosition, direction);
			case ('S', _):
				return _distances.First(kvp => kvp.Key != previousPosition && kvp.Value == 1)
				                 .Key;
			default: throw new InvalidOperationException();
		}
	}

	private (int x, int y) MoveStraight((int x, int y) position, (int x, int y) direction)
	{
		(var x, var y) = position;
		(var dx, var dy) = direction;
		return (x + dx, y + dy);
	}

	private (int x, int y) MoveLeft((int x, int y) position, (int x, int y) direction)
	{
		(var x, var y) = position;
		(var dx, var dy) = direction;
		return (x + dy, y - dx);
	}

	private (int x, int y) MoveRight((int x, int y) position, (int x, int y) direction)
	{
		(var x, var y) = position;
		(var dx, var dy) = direction;
		return (x - dy, y + dx);
	}
}