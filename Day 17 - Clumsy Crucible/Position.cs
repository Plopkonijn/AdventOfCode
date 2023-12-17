namespace ClumsyCrucible;

internal readonly struct Position
{
	public Position(int x, int y)
	{
		X = x;
		Y = y;
	}

	public int X { get; }
	public int Y { get; }

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y);
	}

	public override bool Equals(object? obj)
	{
		return obj is Position other && X == other.X && Y == other.Y;
	}
}