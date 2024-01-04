using Common;

namespace Year2023.Day18;

internal readonly record struct Trench(Position Start, Position End)
{
	public int Length => Start.ManhattanDistance(End);
}