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

	public static Hand ParseHands(string text)
	{
		CardValue[] cardValues = text.Select(ParseCard)
		                             .ToArray();
		int[] cardGroups = cardValues.GroupBy(card => card, (_, values) => values.Count())
		                             .OrderDescending()
		                             .ToArray();
		HandType type = GetHandType(cardGroups);
		return new Hand(type, cardValues, text);
	}

	public static Hand ConvertToJokerHandType(Hand hand)
	{
		var cardValues = hand.CardValues
		                     .Select(cardValue => cardValue == CardValue.Jack ? CardValue.Joker : cardValue)
		                     .ToArray();
		var jokers = cardValues.Count(cardValue => cardValue == CardValue.Joker);
		switch (jokers)
		{
			case 0 or 5:
				return hand with
				{
					CardValues = cardValues
				};
			case 1:
				return hand with
				{
					CardValues = cardValues,
					HandType = hand.HandType switch
					{
						HandType.HighCard => HandType.OnePair,
						HandType.OnePair => HandType.ThreeOfAKind,
						HandType.TwoPair => HandType.FullHouse,
						HandType.ThreeOfAKind => HandType.FourOfAKind,
						HandType.FourOfAKind => HandType.FiveOfAKind,
						_ => throw new ArgumentOutOfRangeException()
					}
				};
			case 2:
				return hand with
				{
					CardValues = cardValues,
					HandType = hand.HandType switch
					{
						HandType.OnePair => HandType.ThreeOfAKind,
						HandType.TwoPair => HandType.FourOfAKind,
						HandType.FullHouse => HandType.FiveOfAKind,
						_ => throw new ArgumentOutOfRangeException()
					}
				};
			case 3:
				return hand with
				{
					CardValues = cardValues,
					HandType = hand.HandType switch
					{
						HandType.ThreeOfAKind => HandType.FourOfAKind,
						HandType.FullHouse => HandType.FiveOfAKind,
						_ => throw new ArgumentOutOfRangeException()
					}
				};
			case 4:
				return hand with
				{
					CardValues = cardValues,
					HandType = hand.HandType switch
					{
						HandType.FourOfAKind => HandType.FiveOfAKind,
						_ => throw new ArgumentOutOfRangeException()
					}
				};
			default:
				throw new InvalidOperationException();
		}
	}

	private static HandType GetHandType(int[] cardGroups)
	{
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
		return type;
	}

	private static global::CardValue ParseCard(char character)
	{
		return character switch
		{
			'2' => global::CardValue.Two,
			'3' => global::CardValue.Three,
			'4' => global::CardValue.Four,
			'5' => global::CardValue.Five,
			'6' => global::CardValue.Six,
			'7' => global::CardValue.Seven,
			'8' => global::CardValue.Eight,
			'9' => global::CardValue.Nine,
			'T' => global::CardValue.Ten,
			'J' => global::CardValue.Jack,
			'Q' => global::CardValue.Queen,
			'K' => global::CardValue.King,
			'A' => global::CardValue.Ace,
			_ => throw new ArgumentException()
		};
	}
}