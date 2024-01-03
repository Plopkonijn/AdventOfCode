namespace Year2023.Day17;

internal readonly struct Crucible : ICrucible<Crucible>
{
	public Crucible(Position position, Direction direction, int stepsInCurrentDirection = 1)
	{
		Position = position;
		Direction = direction;
		StepsInCurrentDirection = stepsInCurrentDirection;
	}

	public Position Position { get; }
	public Direction Direction { get; }
	public int StepsInCurrentDirection { get; }

	public override int GetHashCode()
	{
		return HashCode.Combine(Position, Direction, StepsInCurrentDirection);
	}

	public override bool Equals(object? obj)
	{
		return obj is Crucible other &&
		       Position.Equals(other.Position) &&
		       Direction.Equals(other.Direction) &&
		       StepsInCurrentDirection.Equals(other.StepsInCurrentDirection);
	}

	public IEnumerable<Crucible> GetNeighbours()
	{
		Position position;
		if (StepsInCurrentDirection < 3)
		{
			position = Position.Move(Direction);
			yield return new Crucible(position, Direction, StepsInCurrentDirection + 1);
		}

		Direction direction = Direction.TurnLeft();
		position = Position.Move(direction);
		yield return new Crucible(position, direction);

		direction = Direction.TurnRight();
		position = Position.Move(direction);
		yield return new Crucible(position, direction);
	}

	public bool ReachedEnd(Position position)
	{
		return Position.Equals(position);
	}
}