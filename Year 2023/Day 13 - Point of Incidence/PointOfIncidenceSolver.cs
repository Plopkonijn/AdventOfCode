using Application;
using Common;

public sealed class PointOfIncidenceSolver : ISolver
{
	private readonly IEnumerable<string[]> _patterns;

	public PointOfIncidenceSolver(string[] args)
	{
		_patterns = args.Split(string.IsNullOrWhiteSpace);
	}

	public long PartOne()
	{
		int verticalTotal = _patterns.Select((pattern, i) => (GetVerticalMirrorIndices(pattern)
			                             .ToArray(), i))
		                             .ToArray()
		                             .Sum(t => t.Item1.Sum());
		int horizontalTotal = _patterns.Select((pattern, i) => (GetHorizontalMirrorIndices(pattern)
			                               .ToArray(), i))
		                               .ToArray()
		                               .Sum(t => t.Item1.Sum());
		int result = horizontalTotal * 100 + verticalTotal;
		return result;
	}

	public long PartTwo()
	{
		throw new NotImplementedException();
	}

	private IEnumerable<int> GetVerticalMirrorIndices(string[] pattern)
	{
		return Enumerable.Range(1, pattern[0].Length - 1)
		                 .Where(i =>
			                 pattern.All(line =>
				                 line.Take(i)
				                     .Reverse()
				                     .Zip(line.Skip(i))
				                     .All(t => t.First == t.Second)
			                 )
		                 );
	}

	private IEnumerable<int> GetHorizontalMirrorIndices(string[] pattern)
	{
		return Enumerable.Range(1, pattern.Length - 1)
		                 .Where(i =>
			                 pattern.Take(i)
			                        .Reverse()
			                        .Zip(pattern.Skip(i))
			                        .All(t =>
				                        t.First.Equals(t.Second)
			                        )
		                 );
	}
}

public class Grid
{
	public Grid(IEnumerable<string> args)
	{
	}
}