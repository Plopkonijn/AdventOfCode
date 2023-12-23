using System.Text;

class Platform
{
	private HashSet<Location> _cubeRocks = new();
	private HashSet<Location> _roundRocks = new();
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

	public void RollNorth()
	{
		var _rollingRocks = new PriorityQueue<Location, int>(_roundRocks.Select(location => (location, location.Y)));
		while (_rollingRocks.TryDequeue(out var currentLocation, out int y))
		{
			Location? nextLocation = null;
			var location = currentLocation with { Y = y - 1 };
			while (location.Y >= 0 && !_cubeRocks.Contains(location) && !_roundRocks.Contains(location))
			{
				nextLocation = location;
				location = location with { Y = location.Y-1 };
			}

			if (nextLocation is {} updatedLocation)
			{
				_roundRocks.Remove(currentLocation);
				_roundRocks.Add(updatedLocation);
			}
		}
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