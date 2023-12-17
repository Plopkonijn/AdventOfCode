namespace ClumsyCrucible;

internal static class Utilities
{
	public static Position Move(this Position position, Direction direction)
	{
		return new Position(position.X + direction.X, position.Y + direction.Y);
	}

	public static int Distance(this Position position1, Position position2)
	{
		return Math.Abs(position2.X - position1.X) + Math.Abs(position2.Y - position1.Y);
	}

	public static Direction TurnLeft(this Direction direction)
	{
		return new Direction(direction.Y, -direction.X);
	}

	public static Direction TurnRight(this Direction direction)
	{
		return new Direction(-direction.Y, direction.X);
	}
}