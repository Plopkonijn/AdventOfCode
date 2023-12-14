using System.Text.RegularExpressions;

public record Entry(Hand Hand, int Bid) : IComparable<Entry>
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
		                                 .Select(text => Hand.ParseHands(text));
		IEnumerable<int> bids = matches.Select(match => match.Groups["bid"].Value)
		                               .Select(int.Parse);
		IEnumerable<Entry> entries = hands.Zip(bids)
		                                  .Select(t => new Entry(t.First, t.Second));
		return entries;
	}
}