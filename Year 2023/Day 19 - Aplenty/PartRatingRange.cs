using Common;

namespace Year2023.Day19;

internal record PartRatingRange(ValueRange X, ValueRange M, ValueRange A, ValueRange S)
{
	public long Total => X.Length * M.Length * A.Length * S.Length;
}