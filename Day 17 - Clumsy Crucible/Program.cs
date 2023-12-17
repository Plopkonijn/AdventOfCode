using ClumsyCrucible;

string[] text = File.ReadAllLines("input.txt");
City city = City.Parse(text);
var solver = new Solver(city);

var startPosition = new Position(0, 0);
var endPosition = new Position(city.Width - 1, city.Height - 1);
int answerPartOne = solver.MinimizeHeatLoss(startPosition, endPosition);
Console.WriteLine(answerPartOne);