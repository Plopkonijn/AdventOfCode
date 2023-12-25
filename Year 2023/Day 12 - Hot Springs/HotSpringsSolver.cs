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
			var damagedRecord = string.Join('?', Enumerable.Repeat(record.DamagedRecord, 5));
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

/*   string length 	: 14
 *   minimum size  	: (1+1+3) + (3 - 1) = 7
 *   wiggle room	: 14 - 7 + 1 = 8
 *
 *		.	?	?	.	.	?	?	.	.	.	?	#	#	.
 *  *  [1	1	1	1	1	1	1	1]
 *	1  [0   1	2	2	2	3	4	4]
 *	1		   [0   0	0	2	4	4	4	4]
 *	3				   [0   0   0	0	0	0	4	4]
 *
 *	string length	: 12
 *  minimum size	: (3 + 2 + 1 ) + (3 - 1) = 8
 *
 *		?	#	#	#	?	?	?	?	?	?	?	?
 *  *  [1   1   1   1   1]
 *	3  [0   1   1	1	1]
 *	2				   [0   1	2	3	4]
 *	1							   [0   1   3	6	10]
 *
 *	string length	: 15
 *  minimum size	: (1+3+1+6) + (4 - 1) = 14
 *		?	#	?	#	?	#	?	#	?	#	?	#	?	#	?
 *  *  [1	1]
 *	1  [0   1]
 *	3          [0	1]
 *	1						   [0	1]
 *	6								   [0   1]
 *
 *	string length	: 19
 *	minimum size	: (1 + 6 + 4) + (3 - 1) = 13
 *  wiggle room		: 19 - 13 + 1 = 7
 *
 *		?	?	?	?	.	#	#	#	#	#	#	.	.	#	#	#	#	#	.
 *	*  [1	1	1	1	1	1	1]
 *	1  [1	2	3	4	4	4	4]
 *	6		   [0	0	0	4	4	4	4]
 *	5									   [0	0	0	0	4	4	4]
 *
 */