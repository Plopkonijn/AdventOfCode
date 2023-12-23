using System.Text.RegularExpressions;

namespace Year2023.Day2;

internal class CubeGame
{
	public CubeGame(string arg)
	{
		Match match = Regex.Match(arg, @"(?<id>(?=Game )\d+):(?<cubesets>.*(?=;?))");
		Id = int.Parse(match.Groups["id"].Value);
		CubeSets = match.Groups["cubeset"]
		                .Captures.Select(capture => new CubeSet(capture.Value))
		                .ToList();
	}

	public int Id { get; init; }
	public List<CubeSet> CubeSets { get; init; }

	public bool IsPossible(CubeSet cubeSet)
	{
		return CubeSets.All(cubeSet.ContainsSubSet);
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
		return CubeSets.Max(set => set.GetSizeForColor(cubeColor));
	}
}