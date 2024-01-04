namespace AdventOfCode;

internal record ProblemSelection(int Year, int Day, int Part, string FileName)
{
	public override string ToString()
	{
		return $"Year {Year}, Day {Day}, Part {Part}";
	}
}