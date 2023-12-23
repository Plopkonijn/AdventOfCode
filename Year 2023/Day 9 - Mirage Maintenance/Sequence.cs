using System.Text.RegularExpressions;

namespace Year2023.Day9;

internal class Sequence
{
	private Sequence(long[] values)
	{
		_values = values;
	}

	private readonly long[] _values;
	private bool IsNilSequence() => _values.All(i => i == 0);

	private Sequence CreateDifferenceSequence()
	{
		long[] values = new long[_values.Length - 1];
		for (int i = 0; i < values.Length; i++)
			values[i] = _values[i + 1] - _values[i];

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
		for (Sequence s = this; !s.IsNilSequence(); s = s.CreateDifferenceSequence())
			yield return s;
	}

	public long ExtrapolateLastValue()
	{
		return GenerateSequences()
			.Sum(s => s._values.Last());
	}

	public long ExtrapolateFirstValue()
	{
		return GenerateSequences()
		       .Select(s => s._values.First())
		       .Reverse()
		       .Aggregate(0L, (accumulator, value) => value - accumulator);
	}
}