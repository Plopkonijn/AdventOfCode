using System.Collections;
using System.Text;

class Platform
{
	private HashSet<Location> _cubeRocks = new();
	private List<Location> _roundRocks = new();
	private int _width;
	private int _height;

	public Platform(string[] text)
	{
		_width = text[0].Length;
		_height = text.Length;
		var locations = text.SelectMany((line, y) => line.Select((c, x) => (c, new Location(x,y))));
		foreach ((char c, Location location) in locations)
		{
			switch (c)
			{
				case 'O': _roundRocks.Add(location);
					break;
				case '#': _cubeRocks.Add(location);
					break;
			}
		}
	}

	private int HashRoundRocks()
	{
		return _roundRocks.Select(location => location.GetHashCode())
		                  .Aggregate(HashCode.Combine);
	}
	
	
	public (int remainingCycles, int cycleLength) RollDirections(Direction[] directions, int cycles)
	{
		var remainingCycles = cycles;
		var cycleLength = 0;
		var cyclesDone = 0;
		var hashes = new HashSet<string>();
		var locationComparers = CreateLocationComparers(directions);
		while (remainingCycles-- > 0)
		{
			cyclesDone++;
			if (!hashes.Add(ToString()))
			{
				break;
			}
			RollCycle(directions,locationComparers);
		}

		cycleLength = cyclesDone;
		remainingCycles = cycles % cycleLength;
		while (remainingCycles-- > 0)
		{
			cyclesDone++;
			RollCycle(directions,locationComparers);
		}

		return (cyclesDone, cycleLength);
	}

	private Comparison<Location>[] CreateLocationComparers(Direction[] directions)
	{
		return directions.Select(direction => direction switch
		{
			(< 0, _) => new Comparison<Location>((a, b) => a.X.CompareTo(b.X)),
			(> 0, _) => new Comparison<Location>((a, b) => (_width - a.X).CompareTo(_width - b.X)),
			(_, < 0) => new Comparison<Location>((a, b) => a.Y.CompareTo(b.Y)),
			(_, > 0) => new Comparison<Location>((a, b) => (_height - a.Y).CompareTo(_height - b.Y)),
			_ => throw new InvalidOperationException()
		})
		.ToArray();
	}

	private void RollCycle(Direction[] directions, Comparison<Location>[] locationComparers)
	{
		for (int index = 0; index < directions.Length; index++)
		{
			Direction direction = directions[index];
			var locationComparer = locationComparers[index];
			RollDirection(direction,locationComparer);
		}
	}

	private void RollDirection(Direction direction, Comparison<Location> locationComparer)
	{
		_roundRocks.Sort(locationComparer);
		for (int i = 0; i < _roundRocks.Count; i++)
		{
			var currentLocation = _roundRocks[i];
			if (FindNextLocation(direction, currentLocation) is { } nextLocation)
			{
				_roundRocks[i] = nextLocation;
			};
		}
	}

	private Location? FindNextLocation(Direction direction, Location currentLocation)
	{
		Location? nextLocation = null;
		var location = currentLocation.Move(direction);
		while (IsInBounds(location) && !_cubeRocks.Contains(location) && !_roundRocks.Contains(location))
		{
			nextLocation = location;
			location = location.Move(direction);
		}

		return nextLocation;
	}

	private bool IsInBounds(Location location)
	{
		return location.X >= 0
		    && location.X < _width
		    && location.Y >= 0
		    && location.Y < _height;
	}

	public override string ToString()
	{
		var stringBuilder = new StringBuilder();
		for (int y = 0; y < _height; y++)
		{
			for (int x = 0; x < _width; x++)
			{
				var location = new Location(x, y);
				if (_roundRocks.Contains(location))
				{
					stringBuilder.Append('O');
				}
				else if (_cubeRocks.Contains(location))
				{
					stringBuilder.Append('#');
				}
				else
				{
					stringBuilder.Append('.');
				}
			}

			stringBuilder.Append('\n');
		}

		return stringBuilder.ToString();
	}

	public int GetLoadNorthBeams()
	{
		return _roundRocks.Sum(location => _height - location.Y);
	}
}