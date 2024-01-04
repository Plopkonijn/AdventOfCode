using System.Text.RegularExpressions;

namespace Year2023.Day7;

internal partial record Entry(Hand Hand, int Bid) : IComparable<Entry>
{
	public int CompareTo(Entry? other)
	{
		return other is null ? Comparer<object>.Default.Compare(this, other) : Hand.CompareTo(other.Hand);
	}

	public static Entry Parse(string text)
	{
		var match = EntryRegex()
			.Match(text);
		var hand = Hand.Parse(match.Groups["hand"].Value);
		var bid = int.Parse(match.Groups["bid"].Value);
		return new Entry(hand, bid);
	}

	[GeneratedRegex(@"(?<hand>.{5}) (?<bid>\d+)")]
	private static partial Regex EntryRegex();
}