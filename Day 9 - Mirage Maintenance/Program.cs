using System.Text.RegularExpressions;

string text = """
              0 3 6 9 12 15
              1 3 6 10 15 21
              10 13 16 21 30 45
              """;
//text = File.ReadAllText("input.txt");

List<Sequence> sequences = Sequence.ParseSequences(text).ToList();
var answerPartOne = "NaN";
Console.WriteLine(answerPartOne);

internal class Sequence
{
	private readonly int[] _values;

	private Sequence(IEnumerable<int> values)
	{
		_values = values.ToArray();
	}

	public static IEnumerable<Sequence> ParseSequences(string text)
	{
		return Regex.Matches(text, @"((?<values>\d+)[ ]*)+")
		            .Select(match => match.Groups["values"]
		                                  .Captures
		                                  .Select(capture => int.Parse(capture.Value)))
		            .Select(values => new Sequence(values));
	}
}