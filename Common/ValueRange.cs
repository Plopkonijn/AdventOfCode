namespace Common;

public readonly record struct ValueRange(long Start, long Length)
{
	public long End => Start + Length;

	public (ValueRange left, ValueRange middle, ValueRange right) SplitBy(ValueRange valueRange)
	{
		var startIntersection = Math.Max(Start, valueRange.Start);
		var endIntersection = Math.Min(End, valueRange.End);
		var lengthIntersection = Math.Max(0, endIntersection - startIntersection);

		var left = new ValueRange(Start, startIntersection - Start);
		var middle = new ValueRange(startIntersection, lengthIntersection);
		var right = new ValueRange(endIntersection, End-endIntersection);
		return (left, middle, right);
	}

	

	public bool IsEmpty => Length == 0;
}