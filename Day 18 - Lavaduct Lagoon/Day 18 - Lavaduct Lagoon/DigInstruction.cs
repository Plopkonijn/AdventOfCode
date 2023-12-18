using System.Drawing;
using System.Text.RegularExpressions;

namespace LavaductLagoon;

internal record DigInstruction(DigDirection Direction, int Distance, Color Color)
{
	public static DigInstruction Parse(string text)
	{
		Match match = Regex.Match(text, @"(?<direction>[UDLR]) (?<distance>\d+) \((?<color>\#\w+)\)");
		DigDirection direction = match.Groups["direction"].Value switch
		{
			"U" => DigDirection.Up,
			"D" => DigDirection.Down,
			"L" => DigDirection.Left,
			"R" => DigDirection.Right,
			_ => throw new ArgumentOutOfRangeException()
		};
		int distance = int.Parse(match.Groups["distance"].Value);
		Color color = ColorTranslator.FromHtml(match.Groups["color"].Value);
		return new DigInstruction(direction, distance, color);
	}
}