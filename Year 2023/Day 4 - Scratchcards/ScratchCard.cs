using System.Text.RegularExpressions;

namespace Year2023.Day4;

internal partial class ScratchCard
{
	public int Id { get; init; }
	public List<int> WinningNumbers { get; init; } = new();
	public List<int> YourNumbers { get; init; } = new();

	public int GetMatchingNumberCount()
	{
		return YourNumbers.Count(WinningNumbers.Contains);
	}

	public int GetPoints()
	{
		int count = GetMatchingNumberCount();
		if (count == 0)
			return 0;
		return (int)Math.Pow(2, count - 1);
	}

	public static ScratchCard Parse(string line)
	{
		return new ScratchCard
		{
			Id = ParseId(line),
			WinningNumbers = ParseWinningNumbers(line)
				.ToList(),
			YourNumbers = ParseYourNumbers(line)
				.ToList()
		};
	}

	private static int ParseId(string line)
	{
		Match match = Regex.Match(line, @"\d+(?=:)");
		return int.Parse(match.Value);
	}

	private static IEnumerable<int> ParseWinningNumbers(string line)
	{
		return MatchWinningNumbers()
		       .Matches(line)
		       .Select(match => int.Parse(match.Value));
	}

	private static IEnumerable<int> ParseYourNumbers(string line)
	{
		return MatchYourNumbers()
		       .Matches(line)
		       .Select(match => int.Parse(match.Value));
	}

	[GeneratedRegex(@"(?<=:.*)\d+(?=.*[|])")]
	private static partial Regex MatchWinningNumbers();

	[GeneratedRegex(@"(?<=[|].*)\d+")]
	private static partial Regex MatchYourNumbers();
}