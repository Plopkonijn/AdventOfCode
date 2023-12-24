using Application;

namespace Year2023.Day9;

public sealed class MirageMaintenanceSolver : ISolver
{
	private readonly List<Sequence> _sequences;

	public MirageMaintenanceSolver(string[] args)
	{
		_sequences = args.Select(Sequence.Parse)
		                 .ToList();
	}

	public long PartOne()
	{
		return _sequences.Select(sequence => sequence.ExtrapolateLastValue())
		                 .Sum();
	}

	public long PartTwo()
	{
		return _sequences.Select(sequence => sequence.ExtrapolateFirstValue())
		                 .Sum();
	}
}