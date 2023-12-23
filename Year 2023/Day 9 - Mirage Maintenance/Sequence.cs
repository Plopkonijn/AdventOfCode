using System.Text.RegularExpressions;

internal class Sequence
{
	private Sequence(long[] values)
	{
		Values = values;
	}

	public long[] Values { get; }
	public bool IsNilSequence => Values.All(i => i == 0);

	public static IEnumerable<Sequence> ParseSequences(string text)
	{
		return Regex.Matches(text, @"((?<values>-?\d+)[ ]*)+")
		            .Select(match => match.Groups["values"]
		                                  .Captures
		                                  .Select(capture => long.Parse(capture.Value))
		                                  .ToArray())
		            .Select(values => new Sequence(values));
	}

	public Sequence CreateDifferenceSequence()
	{
		long[] values = new long[Values.Length - 1];
		for (int i = 0; i < values.Length; i++)
			values[i] = Values[i + 1] - Values[i];

		return new Sequence(values);
	}
}