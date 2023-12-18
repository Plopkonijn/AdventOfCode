namespace LavaductLagoon;

internal record DigPlan(List<DigInstruction> DigInstructions)
{
	public static DigPlan Parse(IEnumerable<string> text)
	{
		List<DigInstruction> digInstructions = text.Select(DigInstruction.Parse)
		                                           .ToList();
		return new DigPlan(digInstructions);
	}

	public ICollection<(int x, int y)> Execute()
	{
		SortedSet<(int x, int y)> trenches = DigTrenches();
		HashSet<(int x, int y)> interior = DigInterior(trenches);
		return interior;
	}

	private SortedSet<(int x, int y)> DigTrenches()
	{
		int x = 0;
		int y = 0;
		var allTrenches = new SortedSet<(int x, int y)>(Comparer<(int x, int y)>.Create((a, b) =>
		{
			int comparison = a.x.CompareTo(b.x);
			if (comparison != 0)
				return comparison;
			return a.y.CompareTo(b.y);
		})) { (x, y) };
		foreach (DigInstruction digInstruction in DigInstructions)
		{
			IEnumerable<(int x, int y)> trenches = digInstruction.DigTrenches(x, y).ToArray();
			(x, y) = trenches.LastOrDefault((x, y));
			allTrenches.UnionWith(trenches);
		}

		return allTrenches;
	}

	private HashSet<(int x, int y)> DigInterior(SortedSet<(int x, int y)> trenches)
	{
		var interior = new HashSet<(int x, int y)>(trenches);
		(int x, int y) = trenches.Min;
		var unDiscovered = new HashSet<(int x, int y)> { (x + 1, y + 1) };
		while (unDiscovered.Count > 0)
		{
			(int x, int y) position = unDiscovered.First();
			unDiscovered.Remove(position);
			interior.Add(position);
			(x, y) = position;
			if (!interior.Contains((x - 1, y)))
				unDiscovered.Add((x - 1, y));
			if (!interior.Contains((x + 1, y)))
				unDiscovered.Add((x + 1, y));
			if (!interior.Contains((x, y - 1)))
				unDiscovered.Add((x, y - 1));
			if (!interior.Contains((x, y + 1)))
				unDiscovered.Add((x, y + 1));
		}

		return interior;
	}
}

/*		#######
 *		#.....#
 *		###...#
 *		..#...#
 *		..#...#
 *		###.###
 *		#...#..
 *		##..###
 *		.#....#
 *		.######
 *
 *
 */