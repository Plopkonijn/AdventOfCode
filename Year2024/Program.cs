using System.Text.RegularExpressions;

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

string[] input = File.ReadAllLines(filePath);
Console.WriteLine("Input:");
foreach (string line in input)
{
    Console.WriteLine(line);
}

Console.WriteLine("Output:");
long output = SolveDay1Part1(input);
Console.WriteLine(output);

static long SolveDay1Part1(string[] input)
{
    List<long> leftList = [];
    List<long> rightList = [];
    foreach (string line in input)
    {
        MatchCollection matches = Regex.Matches(line, @"\d+"); ;
        long leftValue = long.Parse(matches[0].Value);
        long rightValue = long.Parse(matches[1].Value);
        leftList.Add(leftValue);
        rightList.Add(rightValue);
    }

    leftList.Sort();
    rightList.Sort();
    return leftList.Zip(rightList, (left, right) => Math.Abs(left - right)).Sum();
}