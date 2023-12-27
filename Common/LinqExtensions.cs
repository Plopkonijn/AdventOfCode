namespace Common;

public static class LinqExtensions
{
	public static IEnumerable<IEnumerable<string>> Split(this string[] args, Predicate<string> predicate)
	{
		var split = new List<string>();
		foreach (string line in args)
		{
			if (predicate(line))
			{
				yield return split;
				split = new List<string>();
				continue;
			}

			split.Add(line);
		}

		yield return split;
	}
}