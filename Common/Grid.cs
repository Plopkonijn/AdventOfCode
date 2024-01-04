using System.Text;

namespace Common;

public class Grid<TValue>
	where TValue : IParsable<TValue>
{
	protected readonly TValue[,] _values;

	public Grid(int width, int height)
	{
		if (width < 0)
		{
			throw new ArgumentException(nameof(width), $"Expected non negative width {width}");
		}

		if (height < 0)
		{
			throw new ArgumentException(nameof(height), $"Expected non negative height {height}");
		}

		_values = new TValue[width, height];
	}

	public int Width => _values.GetLength(0);
	public int Height => _values.GetLength(1);

	public TValue this[int x, int y]
	{
		get => _values[x, y];
		set => _values[x, y] = value;
	}

	public TValue this[Position position]
	{
		get => _values[position.X, position.Y];
		set => _values[position.X, position.Y] = value;
	}

	public static Grid<TValue> Parse(string[] text)
	{
		var grid = new Grid<TValue>(text[0].Length, text.Length);
		for (var y = 0; y < text.Length; y++)
		{
			var line = text[y];
			for (var x = 0; x < line.Length; x++)
			{
				grid[x, y] = TValue.Parse(line[x]
					.ToString(), null);
			}
		}

		return grid;
	}

	public Grid<TValue> Transpose()
	{
		var transpose = new Grid<TValue>(Height, Width);
		for (var x = 0; x < Width; x++)
		for (var y = 0; y < Height; y++)
		{
			transpose[y, x] = this[x, y];
		}

		return transpose;
	}

	public override string ToString()
	{
		var stringBuilder = new StringBuilder();
		for (var y = 0; y < Height; y++)
		{
			for (var x = 0; x < Width; x++)
			{
				stringBuilder.Append(_values[x, y]);
			}

			stringBuilder.AppendLine();
		}

		return stringBuilder.ToString();
	}
}