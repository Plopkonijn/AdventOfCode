using System.ComponentModel.Design;
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
		var trenches = _digPlan.DigTrenches();
		var trenchLength = trenches.Sum(trench => trench.Length);
		var interiorArea = CalculateInteriorArea(trenches);
		var area = interiorArea + trenchLength / 2 + 1;
		return area;
	}

	private static long CalculateInteriorArea(IEnumerable<Trench> trenches)
	{
		return Math.Abs(trenches.Sum(trench => trench.Start.X * trench.End.Y - trench.End.X * trench.Start.Y)) / 2;
	}

	public long PartTwo()
	{
		throw new NotImplementedException();
	}
}