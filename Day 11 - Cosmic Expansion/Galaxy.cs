using System.Diagnostics;
using System.Text;

internal class Galaxy
{
	private readonly string[] _galaxyText;
	private readonly int _height;
	private readonly int _width;

	public Galaxy(string[] galaxyText)
	{
		_galaxyText = galaxyText;
		_width = galaxyText.Min(s => s.Length);
		_height = galaxyText.Length;
	}

	public Galaxy Expand()
	{
		string[] newGalaxyText = CreateExpandedGalaxyText();
		return new Galaxy(newGalaxyText);
	}

	private string[] CreateExpandedGalaxyText()
	{
		int[] emptyRows = GetEmptyRowIndices();
		int[] emptyColumns = GetEmptyColumnIndices();
		string[] newGalaxyText = CreateExpandedRows(emptyColumns, emptyRows);
		Debug.Assert(newGalaxyText.Select(s => s.Length).Distinct().Count() == 1);
		return newGalaxyText;
	}

	private string[] CreateExpandedRows(int[] emptyColumns, int[] emptyRows)
	{
		string[] newGalaxyText = new string[_height + emptyRows.Length];
		string emptyRow = string.Concat(Enumerable.Repeat('.', _width + emptyColumns.Length));
		int rowOffset = 0;
		for (int i = 0; i < _height; i++)
		{
			if (rowOffset < emptyRows.Length && emptyRows[rowOffset] == i)
			{
				newGalaxyText[i + rowOffset] = emptyRow;
				rowOffset++;
				newGalaxyText[i + rowOffset] = emptyRow;
				continue;
			}

			StringBuilder stringBuilder = CreateExpandedRow(emptyColumns, i);

			newGalaxyText[i + rowOffset] = stringBuilder.ToString();
		}

		return newGalaxyText;
	}

	private StringBuilder CreateExpandedRow(int[] emptyColumns, int i)
	{
		var stringBuilder = new StringBuilder(_width + emptyColumns.Length);
		int columnOffset = 0;
		for (int j = 0; j < _width; j++)
		{
			if (columnOffset < emptyColumns.Length && emptyColumns[columnOffset] == j)
			{
				stringBuilder.Append('.');
				columnOffset++;
			}

			stringBuilder.Append(_galaxyText[i][j]);
		}

		return stringBuilder;
	}

	private int[] GetEmptyColumnIndices()
	{
		return _galaxyText.Select(row => row.Select((c, i) => (c, i))
		                                    .Where(t => IsEmptySpace(t.c))
		                                    .Select(t => t.i)
		                  )
		                  .Aggregate((x, y) => x.Intersect(y)
		                                        .ToArray())
		                  .ToArray();
	}

	private int[] GetEmptyRowIndices()
	{
		return _galaxyText.Select((row, i) => (row, i))
		                  .Where(t => t.row.All(IsEmptySpace))
		                  .Select(t => t.i)
		                  .ToArray();
	}

	private static bool IsEmptySpace(char c)
	{
		return c == '.';
	}
}