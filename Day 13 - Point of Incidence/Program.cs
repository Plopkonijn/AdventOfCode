IEnumerable<string> text = File.ReadLines("input.txt");
List<List<string>> patterns = ParsePatterns(text);

var verticalMirrorIndices = patterns.Select((pattern, i) => (GetVerticalMirrorIndices(pattern).ToArray(), i)).ToArray();
var horizontalMirrorIndices = patterns.Select((pattern, i) => (GetHorizontalMirrorIndices(pattern).ToArray(), i)).ToArray();

var verticalTotal = verticalMirrorIndices.Sum(t => t.Item1.Sum());
var horizontalTotal = horizontalMirrorIndices.Sum(t => t.Item1.Sum());
var answerPartOne = horizontalTotal * 100 + verticalTotal;
Console.WriteLine($"Answer to part one: {answerPartOne}");

List<List<string>> ParsePatterns(IEnumerable<string> enumerable)
{
	var patterns = new List<List<string>>();
	var currentPattern = new List<string>();
	foreach (string line in enumerable)
	{
		if (string.IsNullOrWhiteSpace(line))
		{
			patterns.Add(currentPattern);
			currentPattern = new List<string>();
			continue;
		}

		currentPattern.Add(line);
	}

	if (currentPattern.Any())
		patterns.Add(currentPattern);

	return patterns;
}

IEnumerable<int> GetVerticalMirrorIndices(List<string> pattern)
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

IEnumerable<int> GetHorizontalMirrorIndices(List<string> pattern)
{
	return Enumerable.Range(1, pattern.Count - 1)
	                 .Where(i =>
		                 pattern.Take(i)
		                        .Reverse()
		                        .Zip(pattern.Skip(i))
		                        .All(t =>
			                        t.First.Equals(t.Second)
		                        )
	                 );
}