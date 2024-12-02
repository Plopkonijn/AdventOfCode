Console.WriteLine("Select a day to run:");

int day;
while (!int.TryParse(Console.ReadLine(), out day))
{
    Console.WriteLine("Invalid input, please try again.");
}

string currentDirectory = Directory.GetCurrentDirectory();
string filePath = Path.Combine(currentDirectory, "data", $"InputDay{day:00}.txt");
if (!File.Exists(filePath))
{
    Console.WriteLine($"Input file for day {day} not found.");
    return;
}

int part;
while (!int.TryParse(Console.ReadLine(), out part) || (part is not 1 && part is not 2))
{
    Console.WriteLine("Invalid input, please try again.");
}

string[] input = File.ReadAllLines(filePath);
Console.WriteLine("Input:");
foreach (string line in input)
{
    Console.WriteLine(line);
}

Day1Solver solver = day switch
{
    1 => new Day1Solver(input),
    _ => throw new NotImplementedException()
};
Console.WriteLine("Output:");
long output = part == 0 ? solver.SolvePart1(input) : solver.SolvePart2(input);
Console.WriteLine(output);
