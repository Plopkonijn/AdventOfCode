using Application;

namespace Year2023.Day2;

public sealed class CubeConundrumSolver : ISolver
{
	private readonly CubeSet _bag = new()
	{
		CubeGroups =
		{
			new CubeGroup
			{
				Color = CubeColor.Red,
				Size = 12
			},
			new CubeGroup
			{
				Color = CubeColor.Green,
				Size = 13
			},
			new CubeGroup
			{
				Color = CubeColor.Blue,
				Size = 14
			}
		}
	};

	private readonly List<CubeGame> _cubeGames;

	public CubeConundrumSolver(string[] args)
	{
		_cubeGames = args.Select(arg => new CubeGame(arg))
		                 .ToList();
	}

	public long PartOne()
	{
		return _cubeGames
		       .Where(game => game.IsPossible(_bag))
		       .Sum(game => game.Id);
	}

	public long PartTwo()
	{
		return _cubeGames
		       .Select(game => game.GetPower())
		       .Sum();
	}
}