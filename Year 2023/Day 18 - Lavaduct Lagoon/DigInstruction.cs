using System.Text.RegularExpressions;
using Common;

namespace Year2023.Day18;

internal record DigInstruction(DigDirection Direction, int Distance)
{
	public static DigInstruction ParseOne(string text)
	{
		var match = Regex.Match(text, @"(?<direction>[UDLR]) (?<distance>\d+)");
		var direction = match.Groups["direction"].Value switch
		{
			"U" => DigDirection.Up,
			"D" => DigDirection.Down,
			"L" => DigDirection.Left,
			"R" => DigDirection.Right,
			_ => throw new ArgumentOutOfRangeException()
		};
		var distance = int.Parse(match.Groups["distance"].Value);
		return new DigInstruction(direction, distance);
	}

	public static DigInstruction ParseTwo(string text)
	{
		var match = Regex.Match(text, @"#(?<distance>\w{5})(?<direction>\w)");
		var direction = match.Groups["direction"].Value switch
		{
			"0" => DigDirection.Right,
			"1" => DigDirection.Down,
			"2" => DigDirection.Left,
			"3" => DigDirection.Up,
			_ => throw new ArgumentOutOfRangeException()
		};
		var distance = Convert.ToInt32($"0x{match.Groups["distance"].Value}", 16);
		return new DigInstruction(direction, distance);
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