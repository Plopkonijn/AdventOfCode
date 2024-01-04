using System.Drawing;
using System.Text.RegularExpressions;

namespace Year2023.Day18;

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

	public IEnumerable<(int x, int y)> DigTrenches(int x, int y)
	{
		(int dx, int dy) = GetDirectionTuple();
		for (int i = 0; i < Distance; i++)
		{
			x += dx;
			y += dy;
			yield return (x, y);
		}
	}

	private (int x, int y) GetDirectionTuple()
	{
		return Direction switch
		{
			DigDirection.Up => (0, +1),
			DigDirection.Down => (0, -1),
			DigDirection.Left => (-1, 0),
			DigDirection.Right => (+1, 0),
			_ => throw new ArgumentOutOfRangeException()
		};
	}
}