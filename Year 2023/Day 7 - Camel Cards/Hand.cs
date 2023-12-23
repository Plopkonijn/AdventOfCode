namespace Year2023.Day7;

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

	public static Hand Parse(string text)
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
		CardValue[] cardValues = hand.CardValues
		                             .Select(cardValue => cardValue == CardValue.Jack ? CardValue.Joker : cardValue)
		                             .ToArray();
		int jokers = cardValues.Count(cardValue => cardValue == CardValue.Joker);
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