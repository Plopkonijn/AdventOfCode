namespace Common;

public readonly record struct Position(int X, int Y)
{
	public Position Move(Direction direction)
	{
		return new Position(X + direction.X, Y + direction.Y);
	}
}