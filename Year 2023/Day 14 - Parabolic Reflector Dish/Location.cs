record struct Location(int X, int Y)
{
	public Location Move(Direction direction)
	{
		return new Location(X + direction.X, Y + direction.Y);
	}
}

record struct Direction(int X, int Y);