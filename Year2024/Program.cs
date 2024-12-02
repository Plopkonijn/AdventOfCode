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

Console.WriteLine("Output:");
long output = part == 0 ? SolveDay1Part1(input) : SolveDay1Part2(input);
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

static long SolveDay1Part2(string[] input)
{
    List<long> unProcessedRightList = [];
    Dictionary<long, long> leftListOccurences = [];
    foreach (string line in input)
    {
        MatchCollection matches = Regex.Matches(line, @"\d+"); ;
        long leftValue = long.Parse(matches[0].Value);
        _ = leftListOccurences.TryAdd(leftValue, 0);
        long rightValue = long.Parse(matches[1].Value);
        if (leftListOccurences.TryGetValue(rightValue, out long occurences))
        {
            leftListOccurences[rightValue] = occurences + 1;
        }
        else
        {
            unProcessedRightList.Add(rightValue);
        }
    }

    foreach (long rightValue in unProcessedRightList)
    {
        if (leftListOccurences.TryGetValue(rightValue, out long occurences))
        {
            leftListOccurences[rightValue] = occurences + 1;
        }
    }

    return leftListOccurences.Sum(kvp => kvp.Key * kvp.Value);
}