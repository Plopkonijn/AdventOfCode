using Application;

namespace Year2023.Day4;

public sealed class ScratchCardsSolver : ISolver
{
	private readonly List<ScratchCard> _scratchCards;

	public ScratchCardsSolver(string[] args)
	{
		_scratchCards = args.Select(ScratchCard.Parse)
		                    .ToList();
	}

	public long PartOne()
	{
		return _scratchCards.Sum(scratchCard => scratchCard.GetPoints());
	}

	public long PartTwo()
	{
		Dictionary<ScratchCard, int> numberOfScratchCards = _scratchCards.ToDictionary(card => card, _ => 1);
		for (int i = 0; i < _scratchCards.Count; i++)
		{
			ScratchCard scratchCard = _scratchCards[i];
			int copies = numberOfScratchCards[scratchCard];
			int matchingCount = scratchCard.GetMatchingNumberCount();

			for (int j = i + 1; j <= Math.Min(i + matchingCount, _scratchCards.Count); j++)
			{
				ScratchCard copy = _scratchCards[j];
				numberOfScratchCards[copy] += copies;
			}
		}

		return numberOfScratchCards.Values.Sum();
	}
}