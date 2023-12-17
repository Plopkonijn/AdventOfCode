var text = File.ReadAllLines("example.txt");
var city = new City(text);

int answerPartOne = 0;
Console.WriteLine(answerPartOne);

class City
{
	private readonly string[] _text;
	public int Width { get; }
	public int Height { get; }

	public City(string[] text)
	{
		_text = text;
		Width = text[0].Length;
		Height = text.Length;
	}
}