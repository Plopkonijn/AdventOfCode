using System.Text.RegularExpressions;

class ScratchCard
{
	public int Id { get; init; }
	public List<int> WinningNumbers { get; init; } = new();
	public List<int> YourNumbers { get; init; } = new();

	public int GetPoints()
	{
		var count = YourNumbers.Count(WinningNumbers.Contains);
		if (count == 0)
			return 0;
		return (int)Math.Pow(2, count - 1);
	}

	public static ScratchCard Parse(string line)
	{
		var id = ParseId(line);
		var winningNumbers = ParseWinningNumbers(line);
		var yourNumbers = ParseYourNumbers(line);

		return new ScratchCard
		{
			Id = id,
			WinningNumbers = winningNumbers.ToList(),
			YourNumbers = yourNumbers.ToList()
		};
	}

	private static int ParseId(string line)
	{
		var match = Regex.Match(line, @"\d+(?=:)");
		return int.Parse(match.Value);
	}

	private static IEnumerable<int> ParseWinningNumbers(string line)
	{
		return Regex.Matches(line, @"(?<=:.*)\d+(?=.*[|])")
		            .Select(match => int.Parse(match.Value));
	}

	private static IEnumerable<int> ParseYourNumbers(string line)
	{
		return Regex.Matches(line, @"(?<=[|].*)\d+")
		            .Select(match => int.Parse(match.Value));
	}
}