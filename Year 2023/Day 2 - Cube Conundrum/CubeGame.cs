using System.Text.RegularExpressions;

namespace Year2023.Day2;

internal partial class CubeGame
{
	private readonly List<CubeSet> _cubeSets;

	public CubeGame(string arg)
	{
		Match match = GameRegex()
			.Match(arg);
		Id = int.Parse(match.Groups["id"].Value);
		_cubeSets = match.Groups["sets"]
		                 .Captures.Select(capture => new CubeSet(capture.Value))
		                 .ToList();
	}

	public int Id { get; }

	public bool IsPossible(CubeSet cubeSet)
	{
		return _cubeSets.All(cubeSet.ContainsSubSet);
	}

	public int GetPower()
	{
		int minimumRed = GetMinimumForColor(CubeColor.Red);
		int minimumGreen = GetMinimumForColor(CubeColor.Green);
		int minimumBlue = GetMinimumForColor(CubeColor.Blue);
		return minimumRed * minimumGreen * minimumBlue;
	}

	private int GetMinimumForColor(CubeColor cubeColor)
	{
		return _cubeSets.Max(set => set.GetSizeForColor(cubeColor));
	}

	[GeneratedRegex(@"(?<id>(?=Game )\d+):(?<sets>.*(?=;?))")]
	private static partial Regex GameRegex();
}