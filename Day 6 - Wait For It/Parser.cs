using System.Text.RegularExpressions;

static class Parser
{
	public static List<Record> ParseRecords(string text)
	{
		var times = ParseTimes(text);

		var distances = ParseDistances(text);
		return times.Zip(distances)
		            .Select(tuple =>
		            {
			            (int time, int distance) = tuple;
			            return new Record(time, distance);
		            })
		            .ToList();
	}

	private static IEnumerable<int> ParseTimes(string text)
	{
		return Regex.Match(text, @"(?<=Time:)(\s+(?<times>\d+))+")
		            .Groups["times"]
		            .Captures
		            .Select(capture => int.Parse(capture.Value));
	}

	private static IEnumerable<int> ParseDistances(string text)
	{
		return Regex.Match(text, @"(?<=Distance:)(\s+(?<distances>\d+))+")
		            .Groups["distances"]
		            .Captures
		            .Select(capture => int.Parse(capture.Value));
	}

	
}