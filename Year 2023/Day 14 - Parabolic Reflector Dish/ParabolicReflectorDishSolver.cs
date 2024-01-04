using Application;
using CharGrid = Common.Grid<char>;

namespace Year2023.Day14;

public sealed class ParabolicReflectorDishSolver : ISolver
{
	private readonly CharGrid _platform;

	public ParabolicReflectorDishSolver(string[] args)
	{
		_platform = CharGrid.Parse(args);
	}

	public long PartOne()
	{
		RollNorth();
		return GetLoadNorthBeams();
	}

	public long PartTwo()
	{
		Console.WriteLine("initial state:");
		Console.Write(_platform);
		Console.WriteLine();
		RollDirections(1000000000);
		return GetLoadNorthBeams();
	}

	private void RollDirections(int cycles)
	{
		var visitedAtCycle = new Dictionary<string, int>
		{
			{ _platform.ToString(), 0 }
		};
		for (var cycle = 1; cycle <= cycles; cycle++)
		{
			RollCycle();
			if (!visitedAtCycle.TryAdd(_platform.ToString(), cycle))
			{
				break;
			}
		}

		var cycleStartsFrom = visitedAtCycle[_platform.ToString()];
		var remainingCycles = cycles - visitedAtCycle.Count % visitedAtCycle.Count - cycleStartsFrom;

		for (var cycle = 1; cycle <= remainingCycles; cycle++)
		{
			RollCycle();
		}
	}

	private void RollCycle()
	{
		RollNorth();
		RollWest();
		RollSouth();
		RollEast();
	}

	private void RollNorth()
	{
		for (var x = 0; x < _platform.Width; x++)
		for (var y = 1; y < _platform.Height; y++)
		{
			if (_platform[x, y] != 'O')
			{
				continue;
			}

			for (var yNeighbour = y - 1; yNeighbour >= 0; yNeighbour--)
			{
				if (_platform[x, yNeighbour] != '.')
				{
					break;
				}

				_platform[x, yNeighbour] = 'O';
				_platform[x, yNeighbour + 1] = '.';
			}
		}
	}

	private void RollWest()
	{
		for (var y = 0; y < _platform.Height; y++)
		for (var x = 1; x < _platform.Width; x++)
		{
			if (_platform[x, y] != 'O')
			{
				continue;
			}

			for (var xNeighbour = x - 1; xNeighbour >= 0; xNeighbour--)
			{
				if (_platform[xNeighbour, y] != '.')
				{
					break;
				}

				_platform[xNeighbour, y] = 'O';
				_platform[xNeighbour + 1, y] = '.';
			}
		}
	}

	private void RollSouth()
	{
		for (var x = 0; x < _platform.Width; x++)
		for (var y = _platform.Height - 2; y >= 0; y--)
		{
			if (_platform[x, y] != 'O')
			{
				continue;
			}

			for (var yNeighbour = y + 1; yNeighbour < _platform.Height; yNeighbour++)
			{
				if (_platform[x, yNeighbour] != '.')
				{
					break;
				}

				_platform[x, yNeighbour] = 'O';
				_platform[x, yNeighbour - 1] = '.';
			}
		}
	}

	private void RollEast()
	{
		for (var y = 0; y < _platform.Height; y++)
		for (var x = _platform.Width - 2; x >= 0; x--)
		{
			if (_platform[x, y] != 'O')
			{
				continue;
			}

			for (var xNeighbour = x + 1; xNeighbour < _platform.Width; xNeighbour++)
			{
				if (_platform[xNeighbour, y] != '.')
				{
					break;
				}

				_platform[xNeighbour, y] = 'O';
				_platform[xNeighbour - 1, y] = '.';
			}
		}
	}

	private long GetLoadNorthBeams()
	{
		var loadNorthBeams = 0L;
		for (var x = 0; x < _platform.Width; x++)
		for (var y = 0; y < _platform.Height; y++)
		{
			if (_platform[x, y] == 'O')
			{
				loadNorthBeams += _platform.Height - y;
			}
		}

		return loadNorthBeams;
	}
}