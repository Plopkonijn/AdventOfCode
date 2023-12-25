using System.Text.RegularExpressions;
using Application;
using Common;
using Year2023.Day5;

public sealed partial class IfYouGiveASeedAFertilizerSolver : ISolver
{
	private readonly List<Map> _maps;
	private readonly List<ValueRangeSplitBy> _seedRanges;
	private readonly List<long> _seeds;

	public IfYouGiveASeedAFertilizerSolver(string[] args)
	{
		_seeds = ParseSeeds(args);
		_maps = ParseMaps(args);
		_seedRanges = ParseSeedRanges();
	}

	public long PartOne()
	{
		return _seeds.Select(GetLocationNumber)
		             .Min();
	}

	public long PartTwo()
	{
		return _seedRanges.Select(GetLocationNumber)
		                  .Min();
	}

	private List<ValueRangeSplitBy> ParseSeedRanges()
	{
		var seedRanges = new List<ValueRangeSplitBy>();
		int i = 0;
		while (i < _seeds.Count)
		{
			long start = _seeds[i++];
			long length = _seeds[i++];
			seedRanges.Add(new ValueRangeSplitBy(start, length));
		}

		return seedRanges;
	}

	private List<long> ParseSeeds(string[] args)
	{
		return SeedsRegex()
		       .Matches(args.First())
		       .Select(match => long.Parse(match.Value))
		       .ToList();
	}

	private List<Map> ParseMaps(string[] args)
	{
		var maps = new List<Map>();
		for (int i = 2; i < args.Length; i++)
		{
			Match mapTitleMatch = MapTitleRegex()
				.Match(args[i]);
			string sourceName = mapTitleMatch.Groups["source"].Value;
			string destinationName = mapTitleMatch.Groups["destination"].Value;
			List<MapEntry> entries = ParseMapEntries(args, ref i);
			entries.Sort((a, b) => a.SourceRangeSplitBy.Start.CompareTo(b.SourceRangeSplitBy.Start));
			maps.Add(new Map
			{
				SourceName = sourceName,
				DestinationName = destinationName,
				Entries = entries
			});
		}

		return maps;
	}

	private static List<MapEntry> ParseMapEntries(string[] args, ref int i)
	{
		var entries = new List<MapEntry>();
		for (i++; i < args.Length; i++)
		{
			Match match = MapEntryRegex()
				.Match(args[i]);
			if (!match.Success)
				break;
			entries.Add(new MapEntry(new ValueRangeSplitBy
			{
				Start = long.Parse(match.Groups["source"].Value),
				Length = long.Parse(match.Groups["length"].Value)
			}, long.Parse(match.Groups["destination"].Value)));
		}

		return entries;
	}

	private long GetLocationNumber(ValueRangeSplitBy seedRangeSplitBy)
	{
		List<ValueRangeSplitBy> valueRanges = Enumerable.Repeat(seedRangeSplitBy, 1)
		                                                .ToList();
		string valueType = "seed";
		foreach (Map map in _maps)
		{
			if (map.SourceName != valueType)
				throw new InvalidOperationException();
			List<ValueRangeSplitBy> newValueRanges = valueRanges.SelectMany(map.MapRange)
			                                                    .Distinct()
			                                                    .ToList();
			valueType = map.DestinationName;
			valueRanges = newValueRanges;
		}

		return valueRanges.Min(range => range.Start);
	}

	private long GetLocationNumber(long seed)
	{
		long value = seed;
		string valueType = "seed";
		foreach (Map map in _maps)
		{
			if (map.SourceName != valueType)
				throw new InvalidOperationException();
			value = map.MapNumber(value);
			valueType = map.DestinationName;
		}

		return value;
	}

	[GeneratedRegex(@"(?<=seeds:.*)(\d+)")]
	private static partial Regex SeedsRegex();

	[GeneratedRegex(@"(?<destination>\d+) (?<source>\d+) (?<length>\d+)")]
	private static partial Regex MapEntryRegex();

	[GeneratedRegex(@"(?<source>\w+)-to-(?<destination>\w+) map:")]
	private static partial Regex MapTitleRegex();
}