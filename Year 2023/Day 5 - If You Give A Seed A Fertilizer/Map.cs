using Common;
using Year2023.Day5;

internal class Map
{
	public required string SourceName { get; init; }
	public required string DestinationName { get; init; }
	public List<MapEntry> Entries { get; init; } = new();

	public long MapNumber(long value)
	{
		foreach (MapEntry entry in Entries)
			if (entry.TryMapNumber(value, out long mappedValue))
				return mappedValue;
		return value;
	}

	public IEnumerable<ValueRange> MapRange(ValueRange valueRangeSplitBy)
	{
		foreach (MapEntry entry in Entries)
		{
			if (valueRangeSplitBy.End <= entry.SourceRange.Start)
				break;

			(ValueRange left, ValueRange middle, ValueRange right) = valueRangeSplitBy.SplitBy(entry.SourceRange);
			if (!left.IsEmpty)
				yield return left;

			if (!middle.IsEmpty)
				yield return middle with
				{
					Start = entry.DestinationRangeStart + (middle.Start - entry.SourceRange.Start)
				};

			valueRangeSplitBy = right;
		}

		if (!valueRangeSplitBy.IsEmpty)
			yield return valueRangeSplitBy;
	}
}