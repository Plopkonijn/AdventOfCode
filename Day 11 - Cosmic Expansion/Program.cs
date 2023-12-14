string fileName = "example.txt";
fileName = "input.txt";

string[] text = File.ReadAllLines(fileName);

var cosmos = new Cosmos(text);

Cosmos expandedCosmos = cosmos.Expand();

int answerPartOne = expandedCosmos.SumOfGalaxyDistances();
Console.WriteLine(answerPartOne);