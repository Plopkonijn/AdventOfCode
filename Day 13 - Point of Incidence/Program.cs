IEnumerable<string> text = File.ReadLines("example.txt");
ParsePatterns(text);
Console.WriteLine();

void ParsePatterns(IEnumerable<string> enumerable)
{
	var patterns = new List<List<string>>();
	var currentPattern = new List<string>();
	foreach (string line in enumerable)
	{
	
		if (string.IsNullOrWhiteSpace(line))
		{
			patterns.Add(currentPattern);
			currentPattern = new List<string>();
			continue;
		}
		currentPattern.Add(line);
	}

	if (currentPattern.Any())
	{
		patterns.Add(currentPattern);
	}
}