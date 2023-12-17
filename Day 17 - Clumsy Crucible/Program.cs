using ClumsyCrucible;

string[] fileNames = { "example1.txt", "example2.txt", "input.txt" };

foreach (string fileName in fileNames)
{
	Console.WriteLine($"file :{fileName}");
	string[] text = File.ReadAllLines(fileName);
	City city = City.Parse(text);
	var solver = new Solver(city);

	var startPosition = new Position(0, 0);
	var endPosition = new Position(city.Width - 1, city.Height - 1);
	int answerPartOne = solver.MinimizeHeatLoss(startPosition, endPosition, (p, d) => new Crucible(p, d));
	Console.WriteLine($"answer part one:{answerPartOne}");

	int answerPartTwo = solver.MinimizeHeatLoss(startPosition, endPosition, (p, d) => new UltraCrucible(p, d));
	Console.WriteLine($"answer part two:{answerPartTwo}");
	Console.WriteLine();
}