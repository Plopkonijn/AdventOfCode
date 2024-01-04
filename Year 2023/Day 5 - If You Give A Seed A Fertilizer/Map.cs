using Common;
using Year2023.Day5;

internal class Map
{
	public required string SourceName { get; init; }
	public required string DestinationName { get; init; }
	public List<MapEntry> Entries { get; init; } = new();

	public long MapNumber(long value)
	{
		foreach (var entry in Entries)
		{
			if (entry.TryMapNumber(value, out var mappedValue))
			{
				return mappedValue;
			}
		}

		return value;
	}

	public IEnumerable<ValueRange> MapRange(ValueRange valueRangeSplitBy)
	{
		foreach (var entry in Entries)
		{
			if (valueRangeSplitBy.End <= entry.SourceRange.Start)
			{
				break;
			}

			(var left, var middle, var right) = valueRangeSplitBy.SplitBy(entry.SourceRange);
			if (!left.IsEmpty)
			{
				yield return left;
			}

			if (!middle.IsEmpty)
			{
				yield return middle with
				{
					Start = entry.DestinationRangeStart + (middle.Start - entry.SourceRange.Start)
				};
			}

			valueRangeSplitBy = right;
		}

		if (!valueRangeSplitBy.IsEmpty)
		{
			yield return valueRangeSplitBy;
		}
	}
}