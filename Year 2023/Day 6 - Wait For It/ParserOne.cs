using System.Text.RegularExpressions;

namespace Year2023.Day6;

internal static partial class ParserOne
{
	public static IEnumerable<Record> ParseRecords(string[] text)
	{
		IEnumerable<int> times = ParseTimes(text[0]);
		IEnumerable<int> distances = ParseDistances(text[1]);

		return times.Zip(distances)
		            .Select(tuple =>
		            {
			            (int time, int distance) = tuple;
			            return new Record(time, distance);
		            });
	}

	private static IEnumerable<int> ParseTimes(string text)
	{
		return TimesRegex()
		       .Match(text)
		       .Groups["times"]
		       .Captures
		       .Select(capture => int.Parse(capture.Value));
	}

	private static IEnumerable<int> ParseDistances(string text)
	{
		return DistancesRegex()
		       .Match(text)
		       .Groups["distances"]
		       .Captures
		       .Select(capture => int.Parse(capture.Value));
	}

	[GeneratedRegex(@"(?<=Time:)(\s+(?<times>\d+))+")]
	private static partial Regex TimesRegex();

	[GeneratedRegex(@"(?<=Distance:)(\s+(?<distances>\d+))+")]
	private static partial Regex DistancesRegex();
}