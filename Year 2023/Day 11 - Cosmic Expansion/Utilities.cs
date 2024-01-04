namespace Year2023.Day11;

internal static class Utilities
{
	private static IEnumerable<(int, int)> GetGalaxies(this Cosmos cosmos)
	{
		for (var x = 0; x < cosmos.Width; x++)
		for (var y = 0; y < cosmos.Height; y++)
		{
			var tile = cosmos[x, y];
			if (IsGalaxy(tile))
			{
				yield return (x, y);
			}
		}
	}

	public static long SumOfGalaxyDistances(this Cosmos cosmos, int expansion)
	{
		var emptyRows = cosmos.GetEmptyRowIndices();
		var emptyColumns = cosmos.GetEmptyColumnIndices();
		var galaxyPositions = cosmos.GetSortedGalaxyPositions();
		long total = 0;
		foreach ((int x, int y) position1 in galaxyPositions)
		foreach ((int x, int y) position2 in galaxyPositions.TakeWhile(p => p != position1))
		{
			var columnOffset = GetOffset(emptyColumns, position1.x, position2.x);
			var rowOffset = GetOffset(emptyRows, position1.y, position2.y);
			long dx = Math.Abs(position2.x - position1.x);
			long dy = Math.Abs(position2.y - position1.y);
			var distance = dx + dy;
			var expansionDistance = (columnOffset + rowOffset) * (expansion - 1);
			total += distance + expansionDistance;
		}

		return total;
	}

	private static long GetOffset(int[] indices, int i1, int i2)
	{
		var iMin = Math.Min(i1, i2);
		var iMax = Math.Max(i1, i2);

		return indices.LongCount(i => iMin < i && i < iMax);
	}

	private static List<(int, int)> GetSortedGalaxyPositions(this Cosmos cosmos)
	{
		return cosmos.GetGalaxies()
		             .OrderBy(t => t.Item2)
		             .ThenBy(t => t.Item1)
		             .ToList();
	}

	public static bool IsEmptySpace(char c)
	{
		return c == '.';
	}

	public static bool IsGalaxy(char c)
	{
		return c == '#';
	}
}