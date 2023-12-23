using Application;
using Year2023.Day7;

public sealed class CamelCardsSolver : ISolver
{
	private readonly List<Entry> _entries;

	public CamelCardsSolver(string[] text)
	{
		_entries = text.Select(Entry.Parse)
		               .ToList();
	}

	public long PartOne()
	{
		return _entries.Order()
		               .Select((entry, index) => (index + 1) * entry.Bid)
		               .Sum();
	}

	public long PartTwo()
	{
		return _entries.Select(entry => entry with { Hand = Hand.ConvertToJokerHandType(entry.Hand) })
		               .Order()
		               .Select((entry, index) => (index + 1) * entry.Bid)
		               .Sum();
	}
}