using System.Text.RegularExpressions;

namespace Year2023.Day19;

internal record PartRating(int X, int M, int A, int S)
{
	public long Total => X + M + A + S;

	public static PartRating Parse(string text)
	{
		var match = Regex.Match(text, @"{x=(?<x>\d+),m=(?<m>\d+),a=(?<a>\d+),s=(?<s>\d+)}");
		var x = int.Parse(match.Groups["x"].Value);
		var m = int.Parse(match.Groups["m"].Value);
		var a = int.Parse(match.Groups["a"].Value);
		var s = int.Parse(match.Groups["s"].Value);
		return new PartRating(x, m, a, s);
	}
}