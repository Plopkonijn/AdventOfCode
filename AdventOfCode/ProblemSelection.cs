namespace AdventOfCode;

record ProblemSelection(int Year, int Day, int Part)
{
	public override string ToString()
	{
		return $"Year {Year}, Day {Day}, Part {Part}";
	}
};