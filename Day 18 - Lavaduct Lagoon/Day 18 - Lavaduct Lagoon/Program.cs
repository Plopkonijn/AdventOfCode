using LavaductLagoon;

string[] fileNames = { "example.txt" };

foreach (string fileName in fileNames)
{
	Console.WriteLine($"file name: {fileName}");
	IEnumerable<string> text = File.ReadLines(fileName);
	DigPlan digPlan = DigPlan.Parse(text);
}