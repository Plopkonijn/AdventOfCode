namespace Common;

public readonly record struct ValueRangeSplitBy(long Start, long Length)
{
	public long End => Start + Length;

	public bool IsEmpty => Length == 0;

	public (ValueRangeSplitBy left, ValueRangeSplitBy middle, ValueRangeSplitBy right) SplitBy(ValueRangeSplitBy valueRangeSplitBy)
	{
		if (End < valueRangeSplitBy.Start)
			return (this,
				new ValueRangeSplitBy(End, 0),
				new ValueRangeSplitBy(valueRangeSplitBy.Start, 0));

		if (valueRangeSplitBy.End < Start)
			return (new ValueRangeSplitBy(valueRangeSplitBy.Start, 0),
				new ValueRangeSplitBy(valueRangeSplitBy.End, 0),
				this);

		long startIntersection = Math.Max(Start, valueRangeSplitBy.Start);
		long endIntersection = Math.Min(End, valueRangeSplitBy.End);
		return (new ValueRangeSplitBy(Start, startIntersection - Start),
			new ValueRangeSplitBy(startIntersection, endIntersection - startIntersection),
			new ValueRangeSplitBy(endIntersection, End - endIntersection));
	}
}