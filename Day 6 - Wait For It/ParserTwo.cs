using System.Collections;
using System.Text.RegularExpressions;

static class ParserTwo
{
	public static Record ParseRecord(string text)
	{
		var time = ParseTime(text);
		var distance = ParseDistance(text);
		return new Record(time, distance);
	}
	private static long ParseTime(string text)
	{
		var values = Regex.Match(text, @"(?<=Time:)(\s+(?<times>\d+))+")
		     .Groups["times"]
		     .Captures
		     .Select(capture => capture.Value);
		var value = string.Concat(values);
		return long.Parse(value);
	}
	private static long ParseDistance(string text)
	{
		var values = Regex.Match(text, @"(?<=Distance:)(\s+(?<distances>\d+))+")
		            .Groups["distances"]
		            .Captures
		            .Select(capture => capture.Value);
		var value = string.Concat(values);
		return long.Parse(value);
	}
}