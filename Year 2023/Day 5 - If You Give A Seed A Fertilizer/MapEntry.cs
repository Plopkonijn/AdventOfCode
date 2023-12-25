using Common;

namespace Year2023.Day5;

internal record MapEntry(ValueRangeSplitBy SourceRangeSplitBy, long DestinationRangeStart)
{
	public bool TryMapNumber(long value, out long mappedValue)
	{
		if (!IsValueInRange(value))
		{
			mappedValue = 0;
			return false;
		}

		mappedValue = value - SourceRangeSplitBy.Start + DestinationRangeStart;
		return true;
	}

	private bool IsValueInRange(long value)
	{
		return SourceRangeSplitBy.Start <= value && value < SourceRangeSplitBy.Start + SourceRangeSplitBy.Length;
	}
}