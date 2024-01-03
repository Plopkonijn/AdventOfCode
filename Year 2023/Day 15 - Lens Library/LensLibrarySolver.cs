using Application;

namespace Year2023.Day15;

public class LensLibrarySolver : ISolver
{
	private readonly List<string> _initializationSequence;

	public LensLibrarySolver(string[] args)
	{
		_initializationSequence = args.SelectMany(s =>
			                              s.Split(','))
		                              .ToList();
	}

	public long PartOne()
	{
		return _initializationSequence.Sum(Hash);
	}

	public long PartTwo()
	{
		throw new NotImplementedException();
	}

	private long Hash(string initializationStep)
	{
		long hash = 0L;

		foreach (char c in initializationStep)
		{
			hash += c;
			hash *= 17;
			hash %= 256;
		}

		return hash;
	}
}