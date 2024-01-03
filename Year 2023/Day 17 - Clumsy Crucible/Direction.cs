namespace Year2023.Day17;

internal readonly struct Direction(int x, int y)
{
	public int X { get; } = x;
	public int Y { get; } = y;

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y);
	}

	public override bool Equals(object? obj)
	{
		return obj is Direction other && X == other.X && Y == other.Y;
	}
}