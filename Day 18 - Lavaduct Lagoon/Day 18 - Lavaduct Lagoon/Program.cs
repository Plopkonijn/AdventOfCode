using System.Diagnostics;
using LavaductLagoon;

string[] fileNames = { "example.txt", "input.txt" };

foreach (string fileName in fileNames)
{
	Console.WriteLine($"file name	: {fileName}");
	IEnumerable<string> text = File.ReadLines(fileName);
	DigPlan digPlan = DigPlan.Parse(text);

	long timestamp = Stopwatch.GetTimestamp();
	ICollection<(int x, int y)> trenches = digPlan.Execute();
	int answerPartOne = trenches.Count;
	TimeSpan elapsedTime = Stopwatch.GetElapsedTime(timestamp);
	Console.WriteLine($"answer part one	: {answerPartOne} in {elapsedTime.TotalMilliseconds} ms");

	Console.WriteLine();
}