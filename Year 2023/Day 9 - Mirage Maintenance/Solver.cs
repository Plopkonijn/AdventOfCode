namespace Year2023.MirageMaintenance;

internal static class Solver
{
	private static IEnumerable<Sequence> GenerateSequences(Sequence sequence)
	{
		for (Sequence s = sequence; !s.IsNilSequence; s = s.CreateDifferenceSequence())
			yield return s;
	}

	public static long ExtrapolateLastValue(Sequence sequence)
	{
		return GenerateSequences(sequence).Sum(s => s.Values.Last());
	}

	public static long ExtrapolateFirstValue(Sequence sequence)
	{
		return GenerateSequences(sequence).Select(s => s.Values.First())
		                                  .Reverse()
		                                  .Aggregate(0L, (accumulator, value) => value - accumulator);
	}
}