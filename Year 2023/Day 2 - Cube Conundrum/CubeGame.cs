namespace Year2023.Day2;

internal class CubeGame
{
	public required int Id { get; init; }
	public List<CubeSet> CubeSets { get; init; } = new();
}