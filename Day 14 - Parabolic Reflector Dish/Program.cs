var text = File.ReadAllLines("input.txt");

var platform = new Platform(text);
Console.WriteLine(platform.ToString());
platform.RollNorth();
Console.WriteLine();
Console.WriteLine(platform.ToString());

int answerPartOne = platform.GetLoadNorthBeams();
Console.WriteLine(answerPartOne);