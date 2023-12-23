using System.Text.RegularExpressions;

namespace Year2023.Day2;

internal partial class CubeGroup
{
	public CubeGroup(string group)
	{
		Match match = CubeGroupMatch()
			.Match(group);
		Size = int.Parse(match.Groups["size"].Value);
		Color = match.Groups["color"].Value switch
		{
			"red" => CubeColor.Red,
			"green" => CubeColor.Green,
			"blue" => CubeColor.Blue,
			_ => throw new InvalidOperationException()
		};
	}

	public CubeGroup()
	{
	}

	public int Size { get; init; }
	public CubeColor Color { get; init; }

	[GeneratedRegex(@"(?<size>\d+) (?<color>\w+)")]
	private static partial Regex CubeGroupMatch();
}