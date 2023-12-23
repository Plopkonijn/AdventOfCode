namespace Year2023.TheFloorWillBeLava;

internal record Beam(int PositionX, int PositionY, int DirectionX, int DirectionY)
{
	public Guid Id { get; init; } = Guid.NewGuid();

	public int PositionX { get; private set; } = PositionX;
	public int PositionY { get; private set; } = PositionY;
	public int DirectionX { get; private set; } = DirectionX;
	public int DirectionY { get; private set; } = DirectionY;

	public void Move()
	{
		PositionX += DirectionX;
		PositionY += DirectionY;
	}

	public void ChangeDirection(int directionX, int directionY)
	{
		DirectionX = directionX;
		DirectionY = directionY;
	}

	public override int GetHashCode()
	{
		return Id.GetHashCode();
	}

	public virtual bool Equals(Beam? other)
	{
		return other?.Id == Id;
	}
}