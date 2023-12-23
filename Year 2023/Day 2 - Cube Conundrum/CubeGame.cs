namespace Year2023.CubeConundrum;

internal class CubeGame
{
	public required int Id { get; init; }
	public List<CubeSet> CubeSets { get; init; } = new();
}