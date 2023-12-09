// var example = """
// 			  467..114..
// 			  ...*......
// 			  ..35..633.
// 			  ......#...
// 			  617*......
// 			  .....+.58.
// 			  ..592.....
// 			  ......755.
// 			  ...$.*....
// 			  .664.598..
// 			  """;
// var lines = example.Split('\n');
var lines = File.ReadAllLines("input.txt");

var engineSchematic = new EngineSchematic(lines);
var partNumbers = engineSchematic.GetPartNumbers().ToArray();
var sumOfPartNumbers = partNumbers.Sum();
Console.WriteLine(sumOfPartNumbers);

class EngineSchematic
{
	private int _width;
	private int _height;
	private readonly EngineSchematicEntry[,] _entries;

	public EngineSchematic(string[] lines)
	{
		_width = lines.Max(s => s.Length);
		_height = lines.Length;
		_entries = new EngineSchematicEntry[_height,_width];
		ParseRows(lines);
	}

	private void ParseRows(string[] lines)
	{
		for (int i = 0; i < lines.Length; i++)
		{
			ParseColumns(lines, i);
		}
	}

	private void ParseColumns(string[] lines, int i)
	{
		var line = lines[i];
		for (int j = 0; j < line.Length; j++)
		{
			ParseEntry(line, i,j);
		}
	}

	private void ParseEntry(string line, int i,int j)
	{
		var symbol = line[j];
		if (symbol == '.')
		{
			ParseEmpty(i,j);
		}
		else if (char.IsNumber(symbol))
		{
			ParseNumber(symbol, i,j);
		}
		else
		{
			ParseSymbol(symbol, i,j);
		}
	}

	public IEnumerable<int> GetPartNumbers()
	{
		var numbers = new HashSet<Number>();
		for (int i = 0; i < _width; i++)
		{
			for (int j = 0; j < _height; j++)
			{
				if (_entries[j,i] is not Number number || numbers.Contains(number))
				{
					continue;
				}

				if (IsPartNumber(number,i,j))
				{
					numbers.Add(number);
				}
			}
		}

		return numbers.Select(number => number.Value);
	}

	private bool IsPartNumber(Number number, int x, int y)
	{
		for (int i = x-1; i <= x+1; i++)
		{
			if (i < 0 || i >= _width)
			{
				continue;
			}
			for (int j = y-1; j <= y+1; j++)
			{
				if (j < 0 || j >= _height)
				{
					continue;
				}
				if (_entries[j,i] is Symbol)
				{
					return true;
				}
			}
		}

		return false;
	}

	private void ParseEmpty(int i, int j)
	{
		_entries[i,j] = new Empty();
	}

	private void ParseNumber(char symbol, int i, int j)
	{
		int value = int.Parse(symbol.ToString());
		if (j > 0 && _entries[i,j-1] is Number number)
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

		_entries[i,j] = number;
	}

	private void ParseSymbol(char symbol, int i, int j)
	{
		_entries[i,j] = new Symbol
		{
			Value = symbol
		};
	}
}

abstract class EngineSchematicEntry
{
	
}

class Number : EngineSchematicEntry 
{
	public int Value { get; set; }
}

class Symbol : EngineSchematicEntry
{
	public char Value { get; init; }
}

class Empty : EngineSchematicEntry
{
	
}