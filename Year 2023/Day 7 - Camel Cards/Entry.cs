using System.Text.RegularExpressions;

namespace Year2023.Day7;

public partial record Entry(Hand Hand, int Bid) : IComparable<Entry>
{
	public int CompareTo(Entry? other)
	{
		if (other is null)
			return Comparer<object>.Default.Compare(this, other);
		return Hand.CompareTo(other.Hand);
	}

	public static IEnumerable<Entry> ParseEntries(string text)
	{
		MatchCollection matches = Regex.Matches(text, @"(?<hand>.{5}) (?<bid>\d+)");
		IEnumerable<Hand> hands = matches.Select(match => match.Groups["hand"].Value)
		                                 .Select(text => Hand.Parse(text));
		IEnumerable<int> bids = matches.Select(match => match.Groups["bid"].Value)
		                               .Select(int.Parse);
		IEnumerable<Entry> entries = hands.Zip(bids)
		                                  .Select(t => new Entry(t.First, t.Second));
		return entries;
	}

	public static Entry Parse(string text)
	{
		Match match = EntryRegex()
			.Match(text);
		Hand hand = Hand.Parse(match.Groups["hand"].Value);
		int bid = int.Parse(match.Groups["bid"].Value);
		return new Entry(hand, bid);
	}

	[GeneratedRegex(@"(?<hand>.{5}) (?<bid>\d+)")]
	private static partial Regex EntryRegex();
}