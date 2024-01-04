using Application;

namespace Year2023.Day3;

public sealed class GearRatiosSolver : ISolver
{
	private readonly EngineSchematic _engineSchematic;

	public GearRatiosSolver(string[] args)
	{
		_engineSchematic = new EngineSchematic(args);
	}

	public long PartOne()
	{
		return _engineSchematic.GetPartNumbers()
		                       .Sum();
	}

	public long PartTwo()
	{
		return _engineSchematic.GetGearRatios()
		                       .Sum();
	}
}