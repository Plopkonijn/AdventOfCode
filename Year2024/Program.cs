
using System.Diagnostics;
using Year2024;
using Year2024.Solvers;

int day = PromptDay();

if (!TryGetFilePath(day, out string filePath))
{
    Console.WriteLine($"Input file for day {day} not found.");
    return;
}

int part = PromptPart();

string[] input = ReadInput(filePath);

DefaultAdventOfCodeSolver solver = SelectSolver(day, input);

long timeStamp = Stopwatch.GetTimestamp();
long output = Solve(part, solver);
TimeSpan solveTime = Stopwatch.GetElapsedTime(timeStamp);

Console.WriteLine($"Output in {solveTime.TotalMilliseconds}ms:");
Console.WriteLine(output);

static int PromptDay()
{
    int day;
    Console.WriteLine("Select a day to run:");
    while (!int.TryParse(Console.ReadLine(), out day))
    {
        Console.WriteLine("Invalid input, please try again.");
    }

    return day;
}

static bool TryGetFilePath(int day, out string filePath)
{
    string currentDirectory = Directory.GetCurrentDirectory();
    filePath = Path.Combine(currentDirectory, "data", $"InputDay{day:00}.txt");
    return File.Exists(filePath);
}

static int PromptPart()
{
    int part;
    Console.WriteLine("Select a part to run (1 or 2):");
    while (!int.TryParse(Console.ReadLine(), out part) || (part is not 1 && part is not 2))
    {
        Console.WriteLine("Invalid input, please try again.");
    }

    return part;
}

static string[] ReadInput(string filePath)
{
    string[] input = File.ReadAllLines(filePath);
    Console.WriteLine("Input:");
    foreach (string line in input)
    {
        Console.WriteLine(line);
    }

    return input;
}

static DefaultAdventOfCodeSolver SelectSolver(int day, string[] input)
{
    return day switch
    {
        1 => new Day1Solver(input),
        2 => new Day2Solver(input),
        3 => new Day3Solver(input),
        _ => throw new NotImplementedException()
    };
}

static long Solve(int part, DefaultAdventOfCodeSolver solver)
{
    return part switch
    {
        1 => solver.SolvePart1(),
        2 => solver.SolvePart2(),
        _ => throw new InvalidOperationException()
    };
}