using Year2023.CamelCards;

string text = """
              32T3K 765
              T55J5 684
              KK677 28
              KTJJT 220
              QQQJA 483
              """;

text = File.ReadAllText("input.txt");
List<Entry> entriesPartOne = Entry.ParseEntries(text).ToList();
entriesPartOne.Sort();
int totalWinningsPartOne = entriesPartOne.Select((entry, index) => (entry, index))
                           .Sum(t => (t.index + 1) * t.entry.Bid);
Console.WriteLine(totalWinningsPartOne);

var entriesPartTwo = entriesPartOne.Select(entry => entry with { Hand = Hand.ConvertToJokerHandType(entry.Hand) })
       .ToList();
entriesPartTwo.Sort();

int totalWinningsPartTwo = entriesPartTwo.Select((entry, index) => (entry, index))
                                         .Sum(t => (t.index + 1) * t.entry.Bid);
var jokerkEntries = entriesPartTwo.Where(entry => entry.Hand.Text.Contains('J'))
                                  .ToList();
Console.WriteLine(totalWinningsPartTwo);
Console.WriteLine();