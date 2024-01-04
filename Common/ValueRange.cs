namespace Common;

public readonly record struct ValueRange(long Start, long Length)
{
	public long End => Start + Length;

	public bool IsEmpty => Length == 0;

	public (ValueRange left, ValueRange middle, ValueRange right) SplitBy(ValueRange valueRange)
	{
		if (End < valueRange.Start)
		{
			return (this,
				new ValueRange(End, 0),
				new ValueRange(valueRange.Start, 0));
		}

		if (valueRange.End < Start)
		{
			return (new ValueRange(valueRange.Start, 0),
				new ValueRange(valueRange.End, 0),
				this);
		}

		var startIntersection = Math.Max(Start, valueRange.Start);
		var endIntersection = Math.Min(End, valueRange.End);
		return (new ValueRange(Start, startIntersection - Start),
			new ValueRange(startIntersection, endIntersection - startIntersection),
			new ValueRange(endIntersection, End - endIntersection));
	}
}