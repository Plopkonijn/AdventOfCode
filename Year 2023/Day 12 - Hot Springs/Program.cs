using Application;

public sealed class HotSpringsSolver : ISolver
{
	private readonly List<SpringRecord> _springRecords;

	public HotSpringsSolver(string[] args)
	{
		_springRecords = args.Select(SpringRecord.Parse)
		                     .ToList();
	}

	public long PartOne()
	{
		return _springRecords.Select(record => record.CountPossibleArrangements())
		                     .Sum();
	}

	public long PartTwo()
	{
		throw new NotImplementedException();
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