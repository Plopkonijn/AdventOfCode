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

	public static int SumOfGalaxyDistances(this Cosmos cosmos)
	{
		int total = 0;
		List<(int, int)> galaxyPositions = cosmos.GetGalaxies()
		                                         .OrderBy(t=>t.Item2)
		                                         .ThenBy(t=>t.Item1)
		                                         .ToList();
		foreach ((int x, int y) position1 in galaxyPositions)
		foreach ((int x, int y) position2 in galaxyPositions.TakeWhile(p=>p!=position1))
		{
			var galaxy1 = galaxyPositions.IndexOf(position1)+1;
			var galaxy2 = galaxyPositions.IndexOf(position2)+1;
			int dx = Math.Abs(position2.x - position1.x);
			int dy = Math.Abs(position2.y - position1.y);
			int distance = dx + dy;
			total += distance;
		}
		return total;
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