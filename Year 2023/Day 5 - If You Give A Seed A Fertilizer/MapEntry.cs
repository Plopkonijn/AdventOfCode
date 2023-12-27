using Common;

namespace Year2023.Day5;

internal record MapEntry(ValueRange SourceRange, long DestinationRangeStart)
{
	public bool TryMapNumber(long value, out long mappedValue)
	{
		if (!IsValueInRange(value))
		{
			mappedValue = 0;
			return false;
		}

		mappedValue = value - SourceRange.Start + DestinationRangeStart;
		return true;
	}

	private bool IsValueInRange(long value)
	{
		return SourceRange.Start <= value && value < SourceRange.Start + SourceRange.Length;
	}
}