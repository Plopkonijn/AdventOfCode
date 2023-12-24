using System.Text.RegularExpressions;

string text = """
              seeds: 79 14 55 13

              seed-to-soil map:
              50 98 2
              52 50 48

              soil-to-fertilizer map:
              0 15 37
              37 52 2
              39 0 15

              fertilizer-to-water map:
              49 53 8
              0 11 42
              42 0 7
              57 7 4

              water-to-light map:
              88 18 7
              18 25 70

              light-to-temperature map:
              45 77 23
              81 45 19
              68 64 13

              temperature-to-humidity map:
              0 69 1
              1 0 69

              humidity-to-location map:
              60 56 37
              56 93 4
              """;
text = File.ReadAllText("input.txt");
List<long> seeds = ParseSeeds(text);
List<Map> maps = ParseMaps(text);

List<long> locations = seeds.Select(seed => GetLocationNumber(seed, maps))
                            .ToList();

long minimumLocation = locations.Min();

Console.WriteLine($"Step One: {minimumLocation}");

long GetLocationNumber(long seed, List<Map> maps)
{
	long value = seed;
	string valueType = "seed";
	foreach (Map map in maps)
	{
		if (map.SourceName != valueType)
			throw new InvalidOperationException();
		value = map.MapNumber(value);
		valueType = map.DestinationName;
	}

	return value;
}

List<long> ParseSeeds(string text)
{
	return Regex.Matches(text, @"(?<=seeds:.*)(\d+)")
	            .Select(match => long.Parse(match.Value))
	            .ToList();
}

List<Map> ParseMaps(string text)
{
	return Regex.Matches(text, @"(?<mapSourceName>\w*)-to-(?<mapDestinationName>\w*) map:\r\n((?<mapEntry>\d+\s\d+\s\d+)\s*\r\n)+")
	            .Select(mapMatch =>
	            {
		            string sourceName = mapMatch.Groups["mapSourceName"].Value;
		            string destinationName = mapMatch.Groups["mapDestinationName"].Value;
		            List<MapEntry> mapEntries = mapMatch.Groups["mapEntry"]
		                                             .Captures
		                                             .Select(capture => capture.Value)
		                                             .Select(ParseMapEntry)
		                                             .ToList();
		            return new Map
		            {
			            SourceName = sourceName,
			            DestinationName = destinationName,
			            Entries = mapEntries
		            };
	            })
	            .ToList();
}

MapEntry ParseMapEntry(string s)
{
	var entryMatch = Regex.Match(s,@"(?<destinationStart>\d+)\s(?<sourceStart>\d+)\s(?<length>\d+)");
	long sourceStart = long.Parse(entryMatch.Groups["sourceStart"].Value);
	long destinationStart = long.Parse(entryMatch.Groups["destinationStart"].Value);
	long length = long.Parse(entryMatch.Groups["length"].Value);
	return new MapEntry
	{
		SourceRangeStart = sourceStart,
		DestinationRangeStart = destinationStart,
		RangeLength = length
	};
}