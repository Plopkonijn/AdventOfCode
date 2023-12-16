namespace TheFloorWillBeLava;

internal record Beam
{
	private readonly int _hashCode;

	public Beam(int positionX, int positionY, int directionX, int directionY)
	{
		_hashCode = HashCode.Combine(positionX, positionY, directionX, directionY);
		PositionX = positionX;
		PositionY = positionY;
		DirectionX = directionX;
		DirectionY = directionY;
	}

	public int PositionX { get; private set; }
	public int PositionY { get; private set; }
	public int DirectionX { get; private set; }
	public int DirectionY { get; private set; }

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
		return _hashCode;
	}
}