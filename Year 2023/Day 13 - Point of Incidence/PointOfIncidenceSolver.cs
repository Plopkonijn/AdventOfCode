using Application;
using Common;

namespace Year2023.Day13;

public sealed class PointOfIncidenceSolver : ISolver
{
	private readonly List<Grid> _patterns;

	public PointOfIncidenceSolver(string[] args)
	{
		_patterns = args.Split(string.IsNullOrEmpty)
		                .Select(pattern => new Grid(pattern.ToArray()))
		                .ToList();
	}

	public long PartOne()
	{
		long verticalTotal = 0L;
		long horizontalTotal = 0L;
		foreach (Grid pattern in _patterns)
		{
			Grid transpose = pattern.Transpose();
			int vertical = GetFirstVerticalMirrorIndex(pattern);
			int horizontal = GetFirstVerticalMirrorIndex(transpose);

			verticalTotal += vertical;
			horizontalTotal += horizontal;
		}

		long result = horizontalTotal * 100L + verticalTotal;
		return result;
	}

	public long PartTwo()
	{
		long newVerticalTotal = 0L;
		long newHorizontalTotal = 0L;
		foreach (Grid pattern in _patterns)
		{
			Grid transpose = pattern.Transpose();
			int vertical = GetFirstVerticalMirrorIndex(pattern);
			int newVertical = GetFirstVerticalMirrorIndex(pattern, vertical);

			int horizontal = GetFirstVerticalMirrorIndex(transpose);
			int newHorizontal = GetFirstVerticalMirrorIndex(transpose, horizontal);

			newVerticalTotal += newVertical;

			newHorizontalTotal += newHorizontal;
		}

		long result = newHorizontalTotal * 100L + newVerticalTotal;
		return result;
	}

	private int GetFirstVerticalMirrorIndex(Grid pattern, int match = -1)
	{
		bool cleanSmudge = match != -1;
		for (int column = 0; column < pattern.Width - 1; column++)
		{
			if (column + 1 == match)
				continue;

			if (IsVerticalMirror(pattern, column, cleanSmudge))
				return column + 1;
		}

		return 0;
	}

	private bool IsVerticalMirror(Grid pattern, int leftMirrorColumn, bool cleanSmudge)
	{
		int columnsToCheck = Math.Min(leftMirrorColumn + 1, pattern.Width - leftMirrorColumn - 1);
		for (int i = 0; i < columnsToCheck; i++)
		{
			if (IsMatch(pattern, leftMirrorColumn - i, leftMirrorColumn + i + 1, ref cleanSmudge))
				continue;

			return false;
		}

		return true;
	}

	private bool IsMatch(Grid pattern, int leftColumn, int rightColumn, ref bool cleanSmudge)
	{
		for (int row = 0; row < pattern.Height; row++)
		{
			if (pattern[leftColumn, row] == pattern[rightColumn, row])
				continue;
			if (cleanSmudge)
				cleanSmudge = false;
			else
				return false;
		}

		return true;
	}
}