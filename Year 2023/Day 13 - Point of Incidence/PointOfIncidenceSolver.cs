using Application;
using Common;

public sealed class PointOfIncidenceSolver : ISolver
{
	private readonly List<List<string>> _patterns;

	public PointOfIncidenceSolver(string[] args)
	{
		_patterns = args.Split(string.IsNullOrEmpty)
		                .ToList();
	}

	public long PartOne()
	{
		int verticalTotal = _patterns.Select((pattern, i) => (GetFirstVerticalMirrorIndex(pattern), i))
		                             .ToArray()
		                             .Sum(t => t.Item1);
		int horizontalTotal = _patterns.Select((pattern, i) => (GetFirstHorizontalMirrorIndex(pattern), i))
		                               .ToArray()
		                               .Sum(t => t.Item1);
		int result = horizontalTotal * 100 + verticalTotal;
		return result;
	}

	public long PartTwo()
	{
		int verticalTotal = _patterns.Select((pattern, i) => (GetFirstVerticalMirrorIndex(pattern, 1), i))
		                             .ToArray()
		                             .Sum(t => t.Item1);
		int horizontalTotal = _patterns.Select((pattern, i) => (GetFirstHorizontalMirrorIndex(pattern, 1), i))
		                               .ToArray()
		                               .Sum(t => t.Item1);
		int result = horizontalTotal * 100 + verticalTotal;
		return result;
	}

	private int GetFirstVerticalMirrorIndex(List<string> pattern)
	{
		return Enumerable.Range(1, pattern[0].Length - 1)
		                 .FirstOrDefault(i =>
				                 pattern.All(line =>
					                 line.Take(i)
					                     .Reverse()
					                     .Zip(line.Skip(i))
					                     .All(t => t.First == t.Second)
				                 )
			               , 0);
	}

	private int GetFirstVerticalMirrorIndex(List<string> pattern, int smudges)
	{
		var result = Enumerable.Range(1, pattern[0].Length - 1)
		                 .FirstOrDefault(i =>
		                 {
			                 var differences = 0;
			                 foreach (string line in pattern)
			                 {
				                 if (differences > smudges)
					                 break;
				                 differences += line.Take(i)
				                                    .Reverse()
				                                    .Zip(line.Skip(i))
				                                    .Count(t => t.First != t.Second);
			                 }

			                 return differences <= smudges;
		                 }, 0);
		return result;
	}

	private int GetFirstHorizontalMirrorIndex(List<string> pattern)
	{
		return Enumerable.Range(1, pattern.Count - 1)
		                 .FirstOrDefault(i =>
				                 pattern.Take(i)
				                        .Reverse()
				                        .Zip(pattern.Skip(i))
				                        .All(t =>
					                        t.First.Equals(t.Second)
				                        )
			               , 0);
	}

	private int GetFirstHorizontalMirrorIndex(List<string> pattern, int smudges)
	{
		var result = Enumerable.Range(1, pattern.Count - 1)
		                 .FirstOrDefault(i =>
		                 {
			                 var differences = 0;
			                 var tuples = pattern.Take(i)
			                                     .Reverse()
			                                     .Zip(pattern.Skip(i))
			                                     .SelectMany(t => t.First.Zip(t.Second));
			                 foreach ((char first, char second) in tuples)
			                 {
				                 if (differences > smudges)
					                 break;
				                 if (first != second)
					                 differences++;
			                 }

			                 return differences <= smudges;
		                 }, 0);
		return result;
	}
}