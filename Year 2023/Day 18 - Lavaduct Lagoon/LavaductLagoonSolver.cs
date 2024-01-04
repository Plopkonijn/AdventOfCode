using Application;

namespace Year2023.Day18;

public sealed class LavaductLagoonSolver : ISolver
{
	private readonly DigPlan _digPlanOne;
	private readonly DigPlan _digPlanTwo;

	public LavaductLagoonSolver(string[] args)
	{
		_digPlanOne = DigPlan.ParseOne(args);
		_digPlanTwo = DigPlan.ParseTwo(args);
	}

	public long PartOne()
	{
		var trenches = _digPlanOne.DigTrenches();
		var trenchLength = trenches.Sum(trench => trench.Length);
		var interiorArea = CalculateInteriorArea(trenches);
		var area = interiorArea + trenchLength / 2 + 1;
		return area;
	}

	public long PartTwo()
	{
		var trenches = _digPlanTwo.DigTrenches();
		var trenchLength = trenches.Sum(trench => trench.Length);
		var interiorArea = CalculateInteriorArea(trenches);
		var area = interiorArea + trenchLength / 2 + 1;
		return area;
	}

	private static long CalculateInteriorArea(IEnumerable<Trench> trenches)
	{
		return Math.Abs(trenches.Sum(trench => trench.Start.X * (long)trench.End.Y - trench.End.X * (long)trench.Start.Y)) / 2L;
	}
}