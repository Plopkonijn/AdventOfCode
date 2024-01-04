using System.Drawing;
using System.Text.RegularExpressions;
using Common;

namespace Year2023.Day18;

internal record DigInstruction(DigDirection Direction, int Distance, Color Color)
{
	public static DigInstruction Parse(string text)
	{
		var match = Regex.Match(text, @"(?<direction>[UDLR]) (?<distance>\d+) \((?<color>\#\w+)\)");
		var direction = match.Groups["direction"].Value switch
		{
			"U" => DigDirection.Up,
			"D" => DigDirection.Down,
			"L" => DigDirection.Left,
			"R" => DigDirection.Right,
			_ => throw new ArgumentOutOfRangeException()
		};
		var distance = int.Parse(match.Groups["distance"].Value);
		var color = ColorTranslator.FromHtml(match.Groups["color"].Value);
		return new DigInstruction(direction, distance, color);
	}

	public Trench DigTrenches(Position start)
	{
		var direction = GetDirection();
		var end = start.Move(direction);
		return new Trench(start, end);
	}

	private Direction GetDirection()
	{
		return Direction switch
		{
			DigDirection.Up => new Direction(0, +Distance),
			DigDirection.Down => new Direction(0, -Distance),
			DigDirection.Left => new Direction(-Distance, 0),
			DigDirection.Right => new Direction(+Distance, 0),
			_ => throw new ArgumentOutOfRangeException()
		};
	}
}