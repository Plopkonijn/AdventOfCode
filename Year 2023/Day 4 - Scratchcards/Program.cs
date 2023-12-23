// var example = """
//               Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
//               Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
//               Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
//               Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
//               Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
//               Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
//               """;
// var lines = example.Split('\n');

using Year2023.Scratchcards;

var lines = File.ReadAllLines("input.txt");
var scratchCards = lines.Select(ScratchCard.Parse)
                       .ToList();

var totalNumberOfPoints = scratchCards.Sum(scratchCard => scratchCard.GetPoints());
Console.WriteLine($"Part One: {totalNumberOfPoints}");

var totalNumberOfScratchcards = GetTotalNumberOfScratchcards(scratchCards);
Console.WriteLine($"Part Two: {totalNumberOfScratchcards}");


int GetTotalNumberOfScratchcards(List<ScratchCard> list)
{
	var numberOfScratchCards = list.ToDictionary(card => card, _ => 1);
	for (int i = 0; i < list.Count; i++)
	{
		var scratchCard = list[i];
		var copies = numberOfScratchCards[scratchCard];
		var matchingCount = scratchCard.GetMatchingNumberCount();
		
		for (int j = i+1; j <=Math.Min(i+matchingCount,list.Count) ; j++)
		{
			var copy = list[j];
			numberOfScratchCards[copy] += copies;
		}
	}

	return numberOfScratchCards.Values.Sum();
}
