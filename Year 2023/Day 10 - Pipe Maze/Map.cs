namespace Year2023.PipeMaze;

internal class Map
{
	private readonly string[] _map;

	public Map(string[] map)
	{
		_map = map;
	}

	public int MinX => 0;
	public int MaxX => _map[0].Length;
	public int MinY => 0;
	public int MaxY => _map.Length;

	public (int x, int y) GetStartPosition()
	{
		for (int y = 0; y < _map.Length; y++)
		{
			int x = _map[y].IndexOf('S');
			if (x != -1)
				return (x, y);
		}

		throw new InvalidOperationException();
	}

	public bool IsInRange((int x, int y) tuple)
	{
		return IsInRange(tuple.x, tuple.y);
	}

	public bool IsInRange(int x, int y)
	{
		return IsInXRange(x) && IsInYRange(y);
	}

	public bool IsInXRange(int x)
	{
		return MinX <= x && x < MaxX;
	}
	
	public bool IsInYRange(int y)
	{
		return MinY <= y && y < MaxY;
	}

	public char GetTile(int x, int y)
	{
		return _map[y][x];
	}

	public char GetTile((int x, int y) tuple)
	{
		return GetTile(tuple.x, tuple.y);
	}
}