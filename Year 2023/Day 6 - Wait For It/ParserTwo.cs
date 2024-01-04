using System.Text.RegularExpressions;

namespace Year2023.Day6;

internal static partial class ParserTwo
{
	public static Record ParseRecord(string[] text)
	{
		var time = ParseTime(text[0]);
		var distance = ParseDistance(text[1]);
		return new Record(time, distance);
	}

	private static long ParseTime(string text)
	{
		var values = TimesRegex()
		             .Match(text)
		             .Groups["times"]
		             .Captures
		             .Select(capture => capture.Value);
		var value = string.Concat(values);
		return long.Parse(value);
	}

	private static long ParseDistance(string text)
	{
		var values = DistancesRegex()
		             .Match(text)
		             .Groups["distances"]
		             .Captures
		             .Select(capture => capture.Value);
		var value = string.Concat(values);
		return long.Parse(value);
	}

	[GeneratedRegex(@"(?<=Time:)(\s+(?<times>\d+))+")]
	private static partial Regex TimesRegex();

	[GeneratedRegex(@"(?<=Distance:)(\s+(?<distances>\d+))+")]
	private static partial Regex DistancesRegex();
}