namespace Year2023.Day6;

internal record Record(long Time, long Distance)
{
	public int GetNumberOfWaysToBeat()
	{
		/*
		 * t + S/t < T
		 * t^2 + S < T*t
		 * t^2 - T*t + S < 0
		 * t = (T +- Sqrt(T^2-4S)) / 2
		 *
		 */
		long discriminant = Time * Time - 4 * Distance;
		if (discriminant < 0)
			return 0;
		double minimumHoldTime = (Time - Math.Sqrt(discriminant)) / 2;
		double maximumHoldTime = (Time + Math.Sqrt(discriminant)) / 2;

		if (maximumHoldTime < minimumHoldTime)
			return 0;

		double minimumHoldTimeCeiling = Math.Ceiling(minimumHoldTime);
		double maximumHoldTimeFloor = Math.Floor(maximumHoldTime);

		double numberOfWaysToBeat = maximumHoldTimeFloor - minimumHoldTimeCeiling + 1;
		if (minimumHoldTime == minimumHoldTimeCeiling)
			numberOfWaysToBeat--;

		if (maximumHoldTime == maximumHoldTimeFloor)
			numberOfWaysToBeat--;

		return (int)numberOfWaysToBeat;
	}
}