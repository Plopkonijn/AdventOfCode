namespace Year2023.Day25;

internal readonly struct Link
{
	public string Source { get; init; }
	public string Target { get; init; }
	public int Weight { get; init; }

	public string Opposite(string node)
	{
		if (node == Source)
			return Target;
		if (node == Target)
			return Source;
		throw new ArgumentException();
	}
}