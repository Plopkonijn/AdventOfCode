using System.Diagnostics;
using System.Text;

namespace Year2023.CosmicExpansion;

internal class Cosmos
{
	private readonly string[] _cosmosText;

	public Cosmos(string[] cosmosText)
	{
		_cosmosText = cosmosText;
		Width = cosmosText.Min(s => s.Length);
		Height = cosmosText.Length;
	}

	public int Height { get; }
	public int Width { get; }

	public char this[int x, int y] => _cosmosText[y][x];

	public Cosmos Expand()
	{
		string[] newCosmosText = CreateExpandedCosmosText();
		return new Cosmos(newCosmosText);
	}

	private string[] CreateExpandedCosmosText()
	{
		int[] emptyRows = GetEmptyRowIndices();
		int[] emptyColumns = GetEmptyColumnIndices();
		string[] newCosmosText = CreateExpandedRows(emptyColumns, emptyRows);
		Debug.Assert(newCosmosText.Select(s => s.Length).Distinct().Count() == 1);
		return newCosmosText;
	}

	private string[] CreateExpandedRows(int[] emptyColumns, int[] emptyRows)
	{
		string[] newCosmosText = new string[Height + emptyRows.Length];
		string emptyRow = string.Concat(Enumerable.Repeat('.', Width + emptyColumns.Length));
		int rowOffset = 0;
		for (int i = 0; i < Height; i++)
		{
			if (rowOffset < emptyRows.Length && emptyRows[rowOffset] == i)
			{
				newCosmosText[i + rowOffset] = emptyRow;
				rowOffset++;
				newCosmosText[i + rowOffset] = emptyRow;
				continue;
			}

			StringBuilder stringBuilder = CreateExpandedRow(emptyColumns, i);

			newCosmosText[i + rowOffset] = stringBuilder.ToString();
		}

		return newCosmosText;
	}

	private StringBuilder CreateExpandedRow(int[] emptyColumns, int i)
	{
		var stringBuilder = new StringBuilder(Width + emptyColumns.Length);
		int columnOffset = 0;
		for (int j = 0; j < Width; j++)
		{
			if (columnOffset < emptyColumns.Length && emptyColumns[columnOffset] == j)
			{
				stringBuilder.Append('.');
				columnOffset++;
			}

			stringBuilder.Append(_cosmosText[i][j]);
		}

		return stringBuilder;
	}

	public int[] GetEmptyColumnIndices()
	{
		return _cosmosText.Select(row => row.Select((c, i) => (c, i))
		                                    .Where(t => Utilities.IsEmptySpace(t.c))
		                                    .Select(t => t.i)
		                  )
		                  .Aggregate((x, y) => x.Intersect(y)
		                                        .ToArray())
		                  .ToArray();
	}

	public int[] GetEmptyRowIndices()
	{
		return _cosmosText.Select((row, i) => (row, i))
		                  .Where(t => t.row.All(Utilities.IsEmptySpace))
		                  .Select(t => t.i)
		                  .ToArray();
	}
}