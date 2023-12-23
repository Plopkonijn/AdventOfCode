using System.Text.RegularExpressions;

namespace Year2023.Day6;

internal static class ParserTwo
{
	public static Record ParseRecord(string[] text)
	{
		long time = ParseTime(text[0]);
		long distance = ParseDistance(text[1]);
		return new Record(time, distance);
	}

	private static long ParseTime(string text)
	{
		IEnumerable<string> values = Regex.Match(text, @"(?<=Time:)(\s+(?<times>\d+))+")
		                                  .Groups["times"]
		                                  .Captures
		                                  .Select(capture => capture.Value);
		string value = string.Concat(values);
		return long.Parse(value);
	}

	private static long ParseDistance(string text)
	{
		IEnumerable<string> values = Regex.Match(text, @"(?<=Distance:)(\s+(?<distances>\d+))+")
		                                  .Groups["distances"]
		                                  .Captures
		                                  .Select(capture => capture.Value);
		string value = string.Concat(values);
		return long.Parse(value);
	}
}