using Application;
using Common;
using CharGrid = Common.Grid<char>;

namespace Year2023.Day13;

public sealed class PointOfIncidenceSolver : ISolver
{
	private readonly List<CharGrid> _patterns;

	public PointOfIncidenceSolver(string[] args)
	{
		_patterns = args.Split(string.IsNullOrEmpty)
		                .Select(pattern => CharGrid.Parse(pattern.ToArray()))
		                .ToList();
	}

	public long PartOne()
	{
		var verticalTotal = 0L;
		var horizontalTotal = 0L;
		foreach (var pattern in _patterns)
		{
			var transpose = pattern.Transpose();
			var vertical = GetFirstVerticalMirrorIndex(pattern);
			var horizontal = GetFirstVerticalMirrorIndex(transpose);

			verticalTotal += vertical;
			horizontalTotal += horizontal;
		}

		var result = horizontalTotal * 100L + verticalTotal;
		return result;
	}

	public long PartTwo()
	{
		var newVerticalTotal = 0L;
		var newHorizontalTotal = 0L;
		foreach (var pattern in _patterns)
		{
			var transpose = pattern.Transpose();
			var vertical = GetFirstVerticalMirrorIndex(pattern);
			var newVertical = GetFirstVerticalMirrorIndex(pattern, vertical);

			var horizontal = GetFirstVerticalMirrorIndex(transpose);
			var newHorizontal = GetFirstVerticalMirrorIndex(transpose, horizontal);

			newVerticalTotal += newVertical;

			newHorizontalTotal += newHorizontal;
		}

		var result = newHorizontalTotal * 100L + newVerticalTotal;
		return result;
	}

	private int GetFirstVerticalMirrorIndex(CharGrid pattern, int match = -1)
	{
		var cleanSmudge = match != -1;
		for (var column = 0; column < pattern.Width - 1; column++)
		{
			if (column + 1 == match)
			{
				continue;
			}

			if (IsVerticalMirror(pattern, column, cleanSmudge))
			{
				return column + 1;
			}
		}

		return 0;
	}

	private bool IsVerticalMirror(CharGrid pattern, int leftMirrorColumn, bool cleanSmudge)
	{
		var columnsToCheck = Math.Min(leftMirrorColumn + 1, pattern.Width - leftMirrorColumn - 1);
		for (var i = 0; i < columnsToCheck; i++)
		{
			if (IsMatch(pattern, leftMirrorColumn - i, leftMirrorColumn + i + 1, ref cleanSmudge))
			{
				continue;
			}

			return false;
		}

		return true;
	}

	private bool IsMatch(CharGrid pattern, int leftColumn, int rightColumn, ref bool cleanSmudge)
	{
		for (var row = 0; row < pattern.Height; row++)
		{
			if (pattern[leftColumn, row] == pattern[rightColumn, row])
			{
				continue;
			}

			if (cleanSmudge)
			{
				cleanSmudge = false;
			}
			else
			{
				return false;
			}
		}

		return true;
	}
}