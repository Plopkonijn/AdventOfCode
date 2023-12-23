string fileName = "example.txt";
 fileName = "input.txt";

string[] text = File.ReadAllLines(fileName);

var cosmos = new Cosmos(text);

Cosmos expandedCosmos = cosmos.Expand();

long answerPartOne = cosmos.SumOfGalaxyDistances(2);
Console.WriteLine(answerPartOne);

long answerPartTwo = cosmos.SumOfGalaxyDistances(1_000_000);
Console.WriteLine(answerPartTwo);