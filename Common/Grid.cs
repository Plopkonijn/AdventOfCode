using System.Text;

namespace Common;

public class Grid
{
	private readonly char[,] _values;

	public Grid(int width, int height)
	{
		if (width < 0) throw new ArgumentException(nameof(width), $"Expected non negative width {width}");
		if (height < 0) throw new ArgumentException(nameof(height), $"Expected non negative height {height}");
		_values = new char[width, height];
	}

	public Grid(string[] args)
	{
		_values = new char[args[0].Length, args.Length];
		for (int y = 0; y < args.Length; y++)
		{
			string line = args[y];
			if (line.Length != Width)
				throw new ArgumentOutOfRangeException(nameof(args), "Expected a square grid");
			for (int x = 0; x < line.Length; x++)
				_values[x, y] = line[x];
		}
	}

	public int Width => _values.GetLength(0);
	public int Height => _values.GetLength(1);

	public char this[int x, int y]
	{
		get => _values[x, y];
		set => _values[x, y] = value;
	}

	public Grid Transpose()
	{
		var transpose = new Grid(Height, Width);
		for (int x = 0; x < Width; x++)
		for (int y = 0; y < Height; y++)
			transpose[y, x] = this[x, y];

		return transpose;
	}

	public override string ToString()
	{
		var stringBuilder = new StringBuilder();
		for (int y = 0; y < Height; y++)
		{
			for (int x = 0; x < Width; x++)
				stringBuilder.Append(_values[x, y]);

			stringBuilder.AppendLine();
		}

		return stringBuilder.ToString();
	}
}