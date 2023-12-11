public record class Hand(HandType HandType, CardValue[] CardValues, string Text) : IComparable<Hand>
{
	public int CompareTo(Hand? other)
	{
		if (other is null)
			return Comparer<object>.Default.Compare(this, other);

		int typeComparison = HandType.CompareTo(other.HandType);
		if (typeComparison != 0)
			return typeComparison;

		return CardValues.Zip(other.CardValues)
		                 .Select(t => t.First.CompareTo(t.Second))
		                 .FirstOrDefault(c => c != 0, 0);
	}

	public static Hand ParseHand(string text)
	{
		CardValue[] cardValues = text.Select(ParseCard)
		                             .ToArray();
		int[] cardGroups = cardValues.GroupBy(card => card, (_, values) => values.Count())
		                             .OrderDescending()
		                             .ToArray();
		HandType type = cardGroups switch
		{
			[5] => HandType.FiveOfAKind,
			[4, 1] => HandType.FourOfAKind,
			[3, 2] => HandType.FullHouse,
			[3, 1, 1] => HandType.ThreeOfAKind,
			[2, 2, 1] => HandType.TwoPair,
			[2, 1, 1, 1] => HandType.OnePair,
			[1, 1, 1, 1, 1] => HandType.HighCard,
			_ => throw new ArgumentException()
		};
		return new Hand(type, cardValues, text);
	}

	private static CardValue ParseCard(char character)
	{
		return character switch
		{
			'2' => CardValue.Two,
			'3' => CardValue.Three,
			'4' => CardValue.Four,
			'5' => CardValue.Five,
			'6' => CardValue.Six,
			'7' => CardValue.Seven,
			'8' => CardValue.Eight,
			'9' => CardValue.Nine,
			'T' => CardValue.Ten,
			'J' => CardValue.Jack,
			'Q' => CardValue.Queen,
			'K' => CardValue.King,
			'A' => CardValue.Ace,
			_ => throw new ArgumentException()
		};
	}
}