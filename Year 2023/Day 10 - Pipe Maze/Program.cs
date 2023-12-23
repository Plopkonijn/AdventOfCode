using Application;
using Year2023.Day10;

public sealed class PipeMazeSolver : ISolver
{
	private readonly Solver _solver;

	public PipeMazeSolver(string[] args)
	{
		var map = new Map(args);
		_solver = new Solver(map);
	}

	public long PartOne()
	{
		return _solver.GertFurthestDistance();
	}

	public long PartTwo()
	{
		return _solver.GetNumberOfEnclosedTiles()
		              .Count;
	}
}