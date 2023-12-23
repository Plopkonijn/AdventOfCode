namespace Year2023.Day3;

internal class EngineSchematic
{
	private readonly EngineSchematicEntry[,] _entries;
	private readonly int _height;
	private readonly int _width;

	public EngineSchematic(IReadOnlyList<string> lines)
	{
		_width = lines.Max(s => s.Length);
		_height = lines.Count;
		_entries = new EngineSchematicEntry[_height, _width];
		ParseRows(lines);
	}

	private void ParseRows(IReadOnlyList<string> lines)
	{
		for (int i = 0; i < lines.Count; i++)
			ParseColumns(lines, i);
	}

	private void ParseColumns(IReadOnlyList<string> lines, int i)
	{
		string line = lines[i];
		for (int j = 0; j < line.Length; j++)
			_entries[i, j] = ParseEntry(line, i, j);
	}

	private EngineSchematicEntry ParseEntry(string line, int i, int j)
	{
		char symbol = line[j];
		if (symbol == '.')
			return new Empty();

		return char.IsNumber(symbol) ? ParseNumber(symbol, i, j) : ParseSymbol(symbol);
	}

	public IEnumerable<int> GetPartNumbers()
	{
		var numbers = new HashSet<Number>();
		for (int i = 0; i < _width; i++)
		for (int j = 0; j < _height; j++)
		{
			if (_entries[j, i] is not Number number || numbers.Contains(number))
				continue;

			if (IsPartNumber(i, j))
				numbers.Add(number);
		}

		return numbers.Select(number => number.Value);
	}

	private bool IsPartNumber(int x, int y)
	{
		for (int i = x - 1; i <= x + 1; i++)
		{
			if (i < 0 || i >= _width)
				continue;
			for (int j = y - 1; j <= y + 1; j++)
			{
				if (j < 0 || j >= _height)
					continue;
				if (_entries[j, i] is Symbol)
					return true;
			}
		}

		return false;
	}

	public IEnumerable<int> GetGearRatios()
	{
		for (int i = 0; i < _width; i++)
		for (int j = 0; j < _height; j++)
		{
			if (_entries[j, i] is not Gear)
				continue;

			IReadOnlyCollection<Number> numbers = GetNumbers(i, j);
			if (numbers.Count == 2)
				yield return numbers.First()
				                    .Value * numbers.Last()
				                                    .Value;
		}
	}

	private HashSet<Number> GetNumbers(int x, int y)
	{
		var numbers = new HashSet<Number>();
		for (int i = x - 1; i <= x + 1; i++)
		{
			if (i < 0 || i >= _width)
				continue;
			for (int j = y - 1; j <= y + 1; j++)
			{
				if (j < 0 || j >= _height)
					continue;
				if (_entries[j, i] is Number number)
					numbers.Add(number);
			}
		}

		return numbers;
	}

	private Number ParseNumber(char symbol, int i, int j)
	{
		int value = int.Parse(symbol.ToString());
		if (j > 0 && _entries[i, j - 1] is Number number)
		{
			number.Value *= 10;
			number.Value += value;
		}
		else
		{
			number = new Number
			{
				Value = value
			};
		}

		return number;
	}

	private static EngineSchematicEntry ParseSymbol(char symbol)
	{
		return symbol == '*' ? new Gear() : new Symbol();
	}
}