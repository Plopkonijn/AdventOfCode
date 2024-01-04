using System.Text.RegularExpressions;
using Application;
using Common;
using Year2023.Day5;

public sealed partial class IfYouGiveASeedAFertilizerSolver : ISolver
{
	private readonly List<Map> _maps;
	private readonly List<ValueRange> _seedRanges;
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

	private List<ValueRange> ParseSeedRanges()
	{
		var seedRanges = new List<ValueRange>();
		var i = 0;
		while (i < _seeds.Count)
		{
			var start = _seeds[i++];
			var length = _seeds[i++];
			seedRanges.Add(new ValueRange(start, length));
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
		for (var i = 2; i < args.Length; i++)
		{
			var mapTitleMatch = MapTitleRegex()
				.Match(args[i]);
			var sourceName = mapTitleMatch.Groups["source"].Value;
			var destinationName = mapTitleMatch.Groups["destination"].Value;
			var entries = ParseMapEntries(args, ref i);
			entries.Sort((a, b) => a.SourceRange.Start.CompareTo(b.SourceRange.Start));
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
			var match = MapEntryRegex()
				.Match(args[i]);
			if (!match.Success)
			{
				break;
			}

			entries.Add(new MapEntry(new ValueRange
			{
				Start = long.Parse(match.Groups["source"].Value),
				Length = long.Parse(match.Groups["length"].Value)
			}, long.Parse(match.Groups["destination"].Value)));
		}

		return entries;
	}

	private long GetLocationNumber(ValueRange seedRange)
	{
		var valueRanges = Enumerable.Repeat(seedRange, 1)
		                            .ToList();
		var valueType = "seed";
		foreach (var map in _maps)
		{
			if (map.SourceName != valueType)
			{
				throw new InvalidOperationException();
			}

			var newValueRanges = valueRanges.SelectMany(map.MapRange)
			                                .Distinct()
			                                .ToList();
			valueType = map.DestinationName;
			valueRanges = newValueRanges;
		}

		return valueRanges.Min(range => range.Start);
	}

	private long GetLocationNumber(long seed)
	{
		var value = seed;
		var valueType = "seed";
		foreach (var map in _maps)
		{
			if (map.SourceName != valueType)
			{
				throw new InvalidOperationException();
			}

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