namespace Common;

public static class LinqExtensions
{
	public static IEnumerable<string[]> Split(this string[] args, Predicate<string> predicate)
	{
		IEnumerable<int> indices = args.Where((s, i) => predicate(s))
		                               .Select((_, i) => i);
		int startIndex = 0;
		foreach (int endIndex in indices)
		{
			string[] grid = args[startIndex..endIndex];
			yield return grid;
			startIndex = endIndex + 1;
		}
	}
}