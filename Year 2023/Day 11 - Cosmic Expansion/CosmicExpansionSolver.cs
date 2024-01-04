using Application;

namespace Year2023.Day11;

public sealed class CosmicExpansionSolver : ISolver
{
	private readonly Cosmos _cosmos;

	public CosmicExpansionSolver(string[] args)
	{
		_cosmos = new Cosmos(args);
	}

	public long PartOne()
	{
		return _cosmos.Expand()
		              .SumOfGalaxyDistances(2);
	}

	public long PartTwo()
	{
		return _cosmos.SumOfGalaxyDistances(1_000_000);
	}
}