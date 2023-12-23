using System.Text.RegularExpressions;

namespace Year2023.Day9;

internal class Sequence
{
	private Sequence(long[] values)
	{
		Values = values;
	}

	public long[] Values { get; }
	public bool IsNilSequence => Values.All(i => i == 0);

	public Sequence CreateDifferenceSequence()
	{
		long[] values = new long[Values.Length - 1];
		for (int i = 0; i < values.Length; i++)
			values[i] = Values[i + 1] - Values[i];

		return new Sequence(values);
	}

	public static Sequence Parse(string arg)
	{
		long[] values = Regex.Match(arg, @"((?<values>-?\d+)\s*)+")
		                     .Groups["values"]
		                     .Captures
		                     .Select(capture => long.Parse(capture.Value))
		                     .ToArray();
		return new Sequence(values);
	}

	private IEnumerable<Sequence> GenerateSequences()
	{
		for (Sequence s = this; !s.IsNilSequence; s = s.CreateDifferenceSequence())
			yield return s;
	}

	public long ExtrapolateLastValue()
	{
		return GenerateSequences()
			.Sum(s => s.Values.Last());
	}

	public long ExtrapolateFirstValue()
	{
		return GenerateSequences()
		       .Select(s => s.Values.First())
		       .Reverse()
		       .Aggregate(0L, (accumulator, value) => value - accumulator);
	}
}