using ClumsyCrucible;

internal class City(int[,] cityBlocks)
{
	public int Width => cityBlocks.GetLength(0);
	public int Height => cityBlocks.GetLength(1);

	public int this[Position position] => cityBlocks[position.X, position.Y];

	public static City Parse(string[] text)
	{
		int[,] cityBlocks = new int[text[0].Length, text.Length];
		for (int y = 0; y < text.Length; y++)
		{
			string line = text[y];
			for (int x = 0; x < line.Length; x++)
				cityBlocks[x, y] = int.Parse(line[x].ToString());
		}

		return new City(cityBlocks);
	}

	public bool IsInBounds(Position neighbourPosition)
	{
		return 0 <= neighbourPosition.X &&
		       neighbourPosition.X < Width &&
		       0 <= neighbourPosition.Y &&
		       neighbourPosition.Y < Height;
	}
}