var text = File.ReadAllLines("input.txt");

var platform1 = new Platform(text);
// Console.WriteLine(platform1.ToString());
platform1.RollDirections(new []{new Direction(0,-1)},1);
Console.WriteLine();
// Console.WriteLine(platform1.ToString());

int answerPartOne = platform1.GetLoadNorthBeams();
Console.WriteLine(answerPartOne);

var platform2 = new Platform(text);
// Console.WriteLine(platform2.ToString());
Console.WriteLine();
var directions = new[]
{
	new Direction(0, -1),
	new Direction(-1, 0),
	new Direction(0, 1),
	new Direction(1, 0)
};
// platform2.RollDirections(directions,1000000000);
var cycles = platform2.RollDirections(directions,1000000000);
Console.WriteLine(platform2.ToString());
Console.WriteLine();

Console.WriteLine(cycles);
Console.WriteLine(1000000000%cycles.cycleLength);
Console.WriteLine();
int answerPartTwo = platform2.GetLoadNorthBeams();
Console.WriteLine(answerPartTwo);