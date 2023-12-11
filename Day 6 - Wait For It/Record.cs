record Record(int Time, int Distance)
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
		int disciminant = Time * Time - 4 * Distance;
		if (disciminant < 0)
			return 0;
		var minimumHoldTime = (Time - Math.Sqrt(disciminant)) / 2;
		var maximumHoldTime = (Time + Math.Sqrt(disciminant)) / 2;

		if (maximumHoldTime < minimumHoldTime)
		{
			return 0;
		}

		var minimumHoldTimeCeiling = Math.Ceiling(minimumHoldTime);
		var maximumHoldTimeFloor = Math.Floor(maximumHoldTime);
		
		var numberOfWaysToBeat = maximumHoldTimeFloor - minimumHoldTimeCeiling + 1;
		if (minimumHoldTime == minimumHoldTimeCeiling)
		{
			numberOfWaysToBeat--;
		}

		if (maximumHoldTime == maximumHoldTimeFloor)
		{
			numberOfWaysToBeat--;
		}
		
		
		return (int) numberOfWaysToBeat;
	}
}