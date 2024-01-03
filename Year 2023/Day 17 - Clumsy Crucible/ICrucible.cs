namespace Year2023.Day17;

internal interface ICrucible<out TCrucible>
{
	public Position Position { get; }
	public Direction Direction { get; }
	public int StepsInCurrentDirection { get; }
	public IEnumerable<TCrucible> GetNeighbours();

	public bool ReachedEnd(Position position);
}