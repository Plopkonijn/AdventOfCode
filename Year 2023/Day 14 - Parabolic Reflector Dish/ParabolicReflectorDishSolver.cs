using Application;
using Common;

namespace Year2023.Day14;

public sealed class ParabolicReflectorDishSolver : ISolver
{
	private readonly Grid _platform;

	public ParabolicReflectorDishSolver(string[] args)
	{
		_platform = new Grid(args);
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
		for (int cycle = 1; cycle <= cycles; cycle++)
		{
			RollCycle();
			if (!visitedAtCycle.TryAdd(_platform.ToString(), cycle))
				break;
		}

		int cycleStartsFrom = visitedAtCycle[_platform.ToString()];
		int remainingCycles = cycles - visitedAtCycle.Count % visitedAtCycle.Count - cycleStartsFrom;

		for (int cycle = 1; cycle <= remainingCycles; cycle++)
			RollCycle();
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
		for (int x = 0; x < _platform.Width; x++)
		for (int y = 1; y < _platform.Height; y++)
		{
			if (_platform[x, y] != 'O')
				continue;
			for (int yNeighbour = y - 1; yNeighbour >= 0; yNeighbour--)
			{
				if (_platform[x, yNeighbour] != '.')
					break;

				_platform[x, yNeighbour] = 'O';
				_platform[x, yNeighbour + 1] = '.';
			}
		}
	}

	private void RollWest()
	{
		for (int y = 0; y < _platform.Height; y++)
		for (int x = 1; x < _platform.Width; x++)
		{
			if (_platform[x, y] != 'O')
				continue;
			for (int xNeighbour = x - 1; xNeighbour >= 0; xNeighbour--)
			{
				if (_platform[xNeighbour, y] != '.')
					break;
				_platform[xNeighbour, y] = 'O';
				_platform[xNeighbour + 1, y] = '.';
			}
		}
	}

	private void RollSouth()
	{
		for (int x = 0; x < _platform.Width; x++)
		for (int y = _platform.Height - 2; y >= 0; y--)
		{
			if (_platform[x, y] != 'O')
				continue;
			for (int yNeighbour = y + 1; yNeighbour < _platform.Height; yNeighbour++)
			{
				if (_platform[x, yNeighbour] != '.')
					break;
				_platform[x, yNeighbour] = 'O';
				_platform[x, yNeighbour - 1] = '.';
			}
		}
	}

	private void RollEast()
	{
		for (int y = 0; y < _platform.Height; y++)
		for (int x = _platform.Width - 2; x >= 0; x--)
		{
			if (_platform[x, y] != 'O')
				continue;
			for (int xNeighbour = x + 1; xNeighbour < _platform.Width; xNeighbour++)
			{
				if (_platform[xNeighbour, y] != '.')
					break;
				_platform[xNeighbour, y] = 'O';
				_platform[xNeighbour - 1, y] = '.';
			}
		}
	}

	private long GetLoadNorthBeams()
	{
		long loadNorthBeams = 0L;
		for (int x = 0; x < _platform.Width; x++)
		for (int y = 0; y < _platform.Height; y++)
			if (_platform[x, y] == 'O')
				loadNorthBeams += _platform.Height - y;

		return loadNorthBeams;
	}
}