namespace Common;

public readonly record struct Direction(int X, int Y)
{
	public Direction TurnLeft()
	{
		return new Direction(Y, -X);
	}

	public Direction TurnRight()
	{
		return new Direction(-Y, X);
	}
}