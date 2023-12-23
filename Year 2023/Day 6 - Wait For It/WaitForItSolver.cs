using Application;
using Year2023.Day6;

public sealed class WaitForItSolver : ISolver
{
	private readonly string[] _args;

	public WaitForItSolver(string[] args)
	{
		_args = args;
	}

	public long PartOne()
	{
		IEnumerable<Record> records = ParserOne.ParseRecords(_args);
		return records.Select(record => record.GetNumberOfWaysToBeat())
		              .Aggregate((x, y) => x * y);
	}

	public long PartTwo()
	{
		Record record = ParserTwo.ParseRecord(_args);
		return record.GetNumberOfWaysToBeat();
	}
}