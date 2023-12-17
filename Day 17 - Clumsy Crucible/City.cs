class City(int[,] cityBlocks)
{
	public int Width => cityBlocks.GetLength(0);
	public int Height => cityBlocks.GetLength(1);

	public static City Parse(string[] text)
	{
		var cityBlocks = new int[text[0].Length, text.Length];
		return new City(cityBlocks);
	}
}