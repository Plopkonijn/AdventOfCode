namespace Year2024.Tests;

internal static class TestUtilities
{
    public static string[] GetPuzzleInput(int day)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string directory = Path.Combine(currentDirectory, "data");
        string filePath = Path.Combine(directory, $"InputDay{day:D2}.txt");
        return File.ReadAllLines(filePath);
    }

    public static TValue GetPuzzleOutput<TValue>(int day, int part)
        where TValue : IParsable<TValue>
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string directory = Path.Combine(currentDirectory, "data");
        string filePath = Path.Combine(directory, $"OutputDay{day:D2}Part{part}.txt");
        string outputText = File.ReadAllText(filePath);
        return TValue.Parse(outputText, null);
    }
}