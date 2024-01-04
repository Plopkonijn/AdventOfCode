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
		var numberOfScratchCards = _scratchCards.ToDictionary(card => card, _ => 1);
		for (var i = 0; i < _scratchCards.Count; i++)
		{
			var scratchCard = _scratchCards[i];
			var copies = numberOfScratchCards[scratchCard];
			var matchingCount = scratchCard.GetMatchingNumberCount();

			for (var j = i + 1; j <= Math.Min(i + matchingCount, _scratchCards.Count); j++)
			{
				var copy = _scratchCards[j];
				numberOfScratchCards[copy] += copies;
			}
		}

		return numberOfScratchCards.Values.Sum();
	}
}