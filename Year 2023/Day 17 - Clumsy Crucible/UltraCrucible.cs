using Common;

namespace Year2023.Day17;

internal readonly struct UltraCrucible : ICrucible<UltraCrucible>
{
	public UltraCrucible(Position position, Direction direction, int stepsInCurrentDirection = 1)
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
		return obj is UltraCrucible other &&
		       Position.Equals(other.Position) &&
		       Direction.Equals(other.Direction) &&
		       StepsInCurrentDirection.Equals(other.StepsInCurrentDirection);
	}

	public IEnumerable<UltraCrucible> GetNeighbours()
	{
		Position position;
		if (StepsInCurrentDirection < 10)
		{
			position = Position.Move(Direction);
			yield return new UltraCrucible(position, Direction, StepsInCurrentDirection + 1);
		}

		if (StepsInCurrentDirection < 4)
		{
			yield break;
		}

		var direction = Direction.TurnLeft();
		position = Position.Move(direction);
		yield return new UltraCrucible(position, direction);

		direction = Direction.TurnRight();
		position = Position.Move(direction);
		yield return new UltraCrucible(position, direction);
	}

	public bool ReachedEnd(Position position)
	{
		return Position.Equals(position) && StepsInCurrentDirection >= 4;
	}
}