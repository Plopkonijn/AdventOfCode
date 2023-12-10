internal class MapEntry
{
	public long DestinationRangeStart { get; init; }
	public long SourceRangeStart { get; init; }
	public long RangeLength { get; init; }

	public bool TryMapNumber(long value, out long mappedValue)
	{
		if (!IsValueInRange(value))
		{
			mappedValue = 0;
			return false;
		}

		mappedValue = value - SourceRangeStart + DestinationRangeStart;
		return true;
	}

	private bool IsValueInRange(long value)
	{
		return SourceRangeStart <= value && value < SourceRangeStart + RangeLength;
	}
}