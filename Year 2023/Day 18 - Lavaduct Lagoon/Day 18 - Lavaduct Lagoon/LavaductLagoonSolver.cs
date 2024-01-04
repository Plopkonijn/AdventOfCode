using Application;

namespace Year2023.Day18;

public sealed class LavaductLagoonSolver : ISolver
{
	private readonly DigPlan _digPlan;

	public LavaductLagoonSolver(string[] args)
	{
		_digPlan = DigPlan.Parse(args);
	}
	public long PartOne()
	{
		var trenches = _digPlan.Execute();
		return trenches.Count;
	}

	public long PartTwo()
	{
		throw new NotImplementedException();
	}
}