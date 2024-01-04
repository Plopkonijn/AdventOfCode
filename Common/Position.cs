namespace Common;

public readonly record struct Position(int X, int Y)
{
	public Position Move(Direction direction)
	{
		return new Position(X + direction.X, Y + direction.Y);
	}

	public int ManhattanDistance(Position other)
	{
		int dx = Math.Abs(this.X-other.X);
		int dy = Math.Abs(this.Y - other.Y);
		return dx + dy;
	}
}