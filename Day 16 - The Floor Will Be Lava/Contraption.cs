internal class Contraption
{
	private readonly string[] _tiles;

	public Contraption(string[] tiles)
	{
		if (tiles.Select(row => row.Length).Count() > 1)
			throw new ArgumentException();
		_tiles = tiles;
	}

	public int Width => _tiles.FirstOrDefault(string.Empty).Length;
	public int Height => _tiles.Length;
}