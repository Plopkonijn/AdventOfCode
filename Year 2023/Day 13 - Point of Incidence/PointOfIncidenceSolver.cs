using System.Data;
using System.IO.Compression;
using Application;
using Common;

public sealed class PointOfIncidenceSolver : ISolver
{
	private readonly List<List<string>> _patterns;

	public PointOfIncidenceSolver(string[] args)
	{
		_patterns = args.Split(string.IsNullOrEmpty)
		                .ToList();
	}

	public long PartOne()
	{
		int verticalTotal = _patterns.Select((pattern, i) => (GetFirstVerticalMirrorIndex(pattern), i))
		                             .ToArray()
		                             .Sum(t => t.Item1);
		int horizontalTotal = _patterns.Select((pattern, i) => (GetFirstHorizontalMirrorIndex(pattern), i))
		                               .ToArray()
		                               .Sum(t => t.Item1);
		int result = horizontalTotal * 100 + verticalTotal;
		return result;
	}

	public long PartTwo()
	{
		foreach (List<string> pattern in _patterns)
		{
			var vertical = GetFirstVerticalMirrorIndex(pattern);
			var horizontal = GetFirstHorizontalMirrorIndex(pattern);
			var verticalSmudge = GetFirstVerticalSmudgedMirrorIndex(pattern);
			var horizontalSmudge = GetFirstHorizontalSmudgedMirrorIndex(pattern);
		}

		return default;

		// int verticalTotal = _patterns.Select((pattern, i) => (GetFirstVerticalMirrorIndex(pattern, 1), i))
		//                              .ToArray()
		//                              .Sum(t => t.Item1);
		// int horizontalTotal = _patterns.Select((pattern, i) => (GetFirstHorizontalMirrorIndex(pattern, 1), i))
		//                                .ToArray()
		//                                .Sum(t => t.Item1);
		// int result = horizontalTotal * 100 + verticalTotal;
		// return result;
	}

	private int GetFirstVerticalMirrorIndex(List<string> pattern)
	{
		return Enumerable.Range(1, pattern[0].Length - 1)
		                 .FirstOrDefault(i =>
				                 pattern.All(line =>
					                 line.Take(i)
					                     .Reverse()
					                     .Zip(line.Skip(i))
					                     .All(t => t.First == t.Second)
				                 )
			               , 0);
	}

	record struct SmudgeMirrorMatch(int MirrorIndex, int? SmudgeColumn, int? SmudgeRow);

	private SmudgeMirrorMatch? GetFirstVerticalSmudgedMirrorIndex(List<string> pattern)
	{
		var result = Enumerable.Range(1, pattern[0].Length - 1)
		                       .Select(i =>
		                       {
			                       foreach ((string line, int row) in pattern.Select((s, i) => (s, i)))
			                       {
				                       var smudges = line.Take(i)
				                                         .Reverse()
				                                         .Zip(line.Skip(i))
				                                         .Select((c, column) => (c, column))
				                                         .Where(t => t.c.First != t.c.Second);
				                       switch (smudges.Count())
				                       {
					                       case > 1:
						                       continue;
					                       case 0:
						                       return new SmudgeMirrorMatch(i, null, null);
					                       case 1:
						                       ((char First, char Second) c, int column) smudge = smudges.SingleOrDefault();
						                       return new SmudgeMirrorMatch(i, smudge
						                                                              .column, row);
				                       }
			                       }

			                       return (SmudgeMirrorMatch?)null;
		                       })
		                       .FirstOrDefault(o => o != null,null);
		return result;
	}

	private int GetFirstHorizontalMirrorIndex(List<string> pattern)
	{
		return Enumerable.Range(1, pattern.Count - 1)
		                 .FirstOrDefault(i =>
				                 pattern.Take(i)
				                        .Reverse()
				                        .Zip(pattern.Skip(i))
				                        .All(t =>
					                        t.First.Equals(t.Second)
				                        )
			               , 0);
	}

	private SmudgeMirrorMatch? GetFirstHorizontalSmudgedMirrorIndex(List<string> pattern)
	{
		var result = Enumerable.Range(1, pattern.Count - 1)
		                       .Select(i =>
		                       {
			                       var smudges = pattern.Take(i)
			                                            .Reverse()
			                                            .Zip(pattern.Skip(i))
			                                            .Select((s, row) => (s, row))
			                                            .SelectMany(t1 => t1.s.First.Zip(t1.s.Second, (x, y) => { return (x, y, t1.row); })
			                                                                .Select((t2, column) => (t2.x, t2.y, column, t2.row)))
			                                            .Where(t3 => t3.x != t3.y);
			                       switch (smudges.Count())
			                       {
				                       case 0:
					                       return new SmudgeMirrorMatch(i, null, null);
				                       case 1:
					                       (char x, char y, int column, int row) smudge = smudges.SingleOrDefault();
					                       return new SmudgeMirrorMatch(i, smudge.column, smudge.row);
				                       default:
					                       return (SmudgeMirrorMatch?)null;
			                       }
		                       })
		                       .FirstOrDefault(o=>o!=null,null);
		return result;
	}
}