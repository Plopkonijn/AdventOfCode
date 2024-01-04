using Application;

namespace Year2023.Day16;

public sealed class TheFloorWilBeLavaSolver : ISolver
{
	private readonly Contraption _contraption;

	public TheFloorWilBeLavaSolver(string[] args)
	{
		_contraption = new Contraption(args);
	}

	public long PartOne()
	{
		var beam = new Beam(0, 0, 1, 0);
		return _contraption.CountEnergizedTiles(beam);
	}

	public long PartTwo()
	{
		return _contraption.CountMaximumEnergizedTiles();
	}
}