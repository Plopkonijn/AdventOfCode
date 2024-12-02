Console.WriteLine("Select a day to run:");

int day = PromptDay();

if (!TryGetFilePath(day, out string filePath))
{
    Console.WriteLine($"Input file for day {day} not found.");
    return;
}

int part = PromptPart();

string[] input = ReadInput(filePath);

AdventOfCodeSolver solver = SelectSolver(day, input);

Console.WriteLine("Output:");
long output = Solve(part, input, solver);
Console.WriteLine(output);

static int PromptDay()
{
    int day;
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

static AdventOfCodeSolver SelectSolver(int day, string[] input)
{
    return day switch
    {
        1 => new Day1Solver(input),
        _ => throw new NotImplementedException()
    };
}

static long Solve(int part, string[] input, AdventOfCodeSolver solver)
{
    return part == 0 ? solver.SolvePart1(input) : solver.SolvePart2(input);
}