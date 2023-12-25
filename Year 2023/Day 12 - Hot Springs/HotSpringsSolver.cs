using Application;

namespace Year2023.Day12;

public sealed class HotSpringsSolver : ISolver
{
	private readonly List<SpringRecord> _springRecordsFolded;
	private readonly IEnumerable<SpringRecord> _springRecordsUnfolded;

	public HotSpringsSolver(string[] args)
	{
		_springRecordsFolded = args.Select(SpringRecord.Parse)
		                           .ToList();

		_springRecordsUnfolded = _springRecordsFolded.Select(record =>
		{
			string damagedRecord = string.Join('?', Enumerable.Repeat(record.DamagedRecord, 5));
			int[] springGroups = Enumerable.Repeat(record.SpringGroups, 5)
			                               .SelectMany(o => o)
			                               .ToArray();
			return new SpringRecord(damagedRecord, springGroups);
		});
	}

	public long PartOne()
	{
		return _springRecordsFolded.Select(record => record.CountPossibleArrangements())
		                           .Sum();
	}

	public long PartTwo()
	{
		return _springRecordsUnfolded.Select(record => record.CountPossibleArrangements())
		                             .Sum();
	}
}