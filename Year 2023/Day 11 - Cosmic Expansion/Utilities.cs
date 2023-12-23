internal static class Utilities
{
	private static IEnumerable<(int, int)> GetGalaxies(this Cosmos cosmos)
	{
		for (int x = 0; x < cosmos.Width; x++)
		for (int y = 0; y < cosmos.Height; y++)
		{
			char tile = cosmos[x, y];
			if (IsGalaxy(tile))
				yield return (x, y);
		}
	}

	public static long SumOfGalaxyDistances(this Cosmos cosmos, int expansion)
	{
		int[] emptyRows = cosmos.GetEmptyRowIndices();
		int[] emptyColumns = cosmos.GetEmptyColumnIndices();
		List<(int, int)> galaxyPositions = cosmos.GetSortedGalaxyPositions();
		long total = 0;
		foreach ((int x, int y) position1 in galaxyPositions)
		foreach ((int x, int y) position2 in galaxyPositions.TakeWhile(p => p != position1))
		{
			long columnOffset = GetOffset(emptyColumns, position1.x, position2.x);
			long rowOffset = GetOffset(emptyRows, position1.y, position2.y);
			int galaxy1 = galaxyPositions.IndexOf(position1) + 1;
			int galaxy2 = galaxyPositions.IndexOf(position2) + 1;
			long dx = Math.Abs(position2.x - position1.x);
			long dy = Math.Abs(position2.y - position1.y);
			long distance = dx + dy ;
			long expansionDistance = (columnOffset + rowOffset) * (expansion-1);
			total += distance + expansionDistance;
		}

		return total;
	}

	private static long GetOffset(int[] indices, int i1, int i2)
	{
		int iMin = Math.Min(i1, i2);
		int iMax = Math.Max(i1, i2);
		
		
		return indices.LongCount(i => iMin<i && i<iMax);
	}

	public static int SumOfGalaxyDistances(this Cosmos cosmos)
	{
		int total = 0;
		List<(int, int)> galaxyPositions = cosmos.GetSortedGalaxyPositions();
		foreach ((int x, int y) position1 in galaxyPositions)
		foreach ((int x, int y) position2 in galaxyPositions.TakeWhile(p => p != position1))
		{
			int galaxy1 = galaxyPositions.IndexOf(position1) + 1;
			int galaxy2 = galaxyPositions.IndexOf(position2) + 1;
			int dx = Math.Abs(position2.x - position1.x);
			int dy = Math.Abs(position2.y - position1.y);
			int distance = dx + dy;
			total += distance;
		}

		return total;
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