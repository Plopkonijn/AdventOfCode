using System.Text.RegularExpressions;

public record SpringRecord(string DamagedRecord, int[] SpringGroups)
{
	public static SpringRecord Parse(string text)
	{
		string damagedRecord = Regex.Match(text, "[.#?]+")
		                            .Value;
		int[] springGroups = Regex.Matches(text, @"\d+")
		                          .Select(match => int.Parse(match.Value))
		                          .ToArray();
		return new SpringRecord(damagedRecord, springGroups);
	}

	private long CountPossibleArrangements(Range stringRange, Range groupRange,
		Dictionary<(Range stringRange, Range groupRange), long> cachedArrangements)
	{
		if (cachedArrangements.TryGetValue((stringRange, groupRange), out long possibleArrangements))
			return possibleArrangements;

		if (!IsRemainingEnough(stringRange, groupRange))
		{
			cachedArrangements.Add((stringRange,groupRange),possibleArrangements);
			return possibleArrangements;
		}

		if (groupRange.Start.Value == groupRange.End.Value)
		{
			possibleArrangements = HasRemainingSprings(stringRange) ? 0L : 1L;
			cachedArrangements.Add((stringRange,groupRange),possibleArrangements);
			return possibleArrangements;
		}

		var currentString = DamagedRecord[stringRange];
		var currentGroup = SpringGroups[groupRange.Start];
		var window = currentString[0..currentGroup];
		
		char? prefix = stringRange.Start.Value - 1 >= 0 ? DamagedRecord[stringRange.Start.Value - 1] : null;
		char? suffix = stringRange.Start.Value + currentGroup < DamagedRecord.Length ? DamagedRecord[stringRange.Start.Value + currentGroup] : null;
		if (Ismatch(stringRange, groupRange.Start))
		{
			var newStringRange = new Range(stringRange.Start.Value + SpringGroups[groupRange.Start] + 1, stringRange.End);
			var newGroupRange = new Range(groupRange.Start.Value + 1, groupRange.End);
			possibleArrangements += CountPossibleArrangements(newStringRange, newGroupRange, cachedArrangements);
		}

		if (DamagedRecord[stringRange.Start] is not '#')
		{
			var newStringRange = new Range(stringRange.Start.Value + 1, stringRange.End);
			possibleArrangements += CountPossibleArrangements(newStringRange, groupRange, cachedArrangements);
		}

		cachedArrangements.Add((stringRange, groupRange), possibleArrangements);
		return possibleArrangements;
	}

	private bool IsRemainingEnough(Range stringRange, Range groupRange)
	{
		var stringLength = stringRange.End.Value - stringRange.Start.Value;
		var groupLength = SpringGroups[groupRange]
			.Sum(i => i + 1) - 1;
		return groupLength<=stringLength;
	}

	private bool HasRemainingSprings(Range stringRange)
	{
		return stringRange.Start.Value < stringRange.End.Value
		    && DamagedRecord.AsSpan(stringRange)
		                    .Contains('#');
	}

	private bool Ismatch(Range stringRange, Index groupIndex)
	{
		if (!IsPrefixMatch(stringRange.Start.Value - 1) || !IsSuffixMatch(stringRange.Start.Value +SpringGroups[groupIndex]))
			return false;
		ReadOnlySpan<char> currentString = DamagedRecord.AsSpan(stringRange);
		if (SpringGroups[groupIndex] > currentString.Length)
			return false;
		ReadOnlySpan<char> currentWindow = currentString.Slice(0, SpringGroups[groupIndex]);
		foreach (char c in currentWindow)
			if (c is not ('#' or '?'))
				return false;

		return true;
	}

	private bool IsPrefixMatch(int index)
	{
		return index < 0 || DamagedRecord[index] is '.' or '?';
	}

	private bool IsSuffixMatch(int index)
	{
		return index >= DamagedRecord.Length || DamagedRecord[index] is '.' or '?';
	}

	public long CountPossibleArrangements()
	{
		long result = CountPossibleArrangements(..DamagedRecord.Length, ..SpringGroups.Length,
			new Dictionary<(Range stringRange, Range groupRange), long>());
		return result;
	}
}

/*
 *	string length	= 7
 *  match length	= 7
 *	shifting space	= 7 - 7 + 1 = 1
 *		?	?	?	.	#	#	#
 * 1	[1]
 * 1			[1]
 * 3					[1]
 *
 *	string length	= 14
 *  match length	= 7
 *  shifting space	= 14 - 7 + 1 = 8
 *		.	?	?	.	.	?	?	.	.	.	?	#	#	.
 * 1	[0	1	1	0	0	1	1	0]
 * 1			[0	0	0	2	2	0	0	0]
 * 3					[0	0	0	0	0	0	4	0]
 *
 */