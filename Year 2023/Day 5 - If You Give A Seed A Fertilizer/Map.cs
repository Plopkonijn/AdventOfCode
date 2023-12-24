internal class Map
{
	public required string SourceName { get; init; }
	public required string DestinationName { get; init; }
	public List<MapEntry> Entries { get; init; } = new();

	public long MapNumber(long value)
	{
		foreach (MapEntry entry in Entries)
			if (entry.TryMapNumber(value, out long mappedValue))
				return mappedValue;
		return value;
	}
}