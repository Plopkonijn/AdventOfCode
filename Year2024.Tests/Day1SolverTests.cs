using Year2024.Solvers;

namespace Year2024.Tests;

public sealed class Day1SolverTests
{
    [Fact]
    public void Example1()
    {
        // Arrange
        string[] input =
        [
            "3    4",
            "4    3",
            "2    5",
            "1    3",
            "3    9",
            "3    3",
        ];
        Day1Solver solver = new(input);

        // Act
        long result = solver.SolvePart1();

        // Assert
        Assert.Equal(11, result);
    }

    [Fact]
    public void Puzzle1()
    {
        // Arrange
        string[] input = GetPuzzleInput();
        long expectedOutput = GetPuzzleOutput(1);
        Day1Solver solver = new(input);

        // Act
        long actualOutput = solver.SolvePart1();

        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void Example2()
    {
        // Arrange
        string[] input =
        [
            "3    4",
            "4    3",
            "2    5",
            "1    3",
            "3    9",
            "3    3",
        ];
        Day1Solver solver = new(input);

        // Act
        long result = solver.SolvePart2();

        // Assert
        Assert.Equal(31, result);
    }

    [Fact]
    public void Puzzle2()
    {
        // Arrange
        string[] input = GetPuzzleInput();
        long expectedOutput = GetPuzzleOutput(2);
        Day1Solver solver = new(input);

        // Act
        long actualOutput = solver.SolvePart2();

        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }

    private static string[] GetPuzzleInput()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string directory = Path.Combine(currentDirectory, "data");
        string filePath = Path.Combine(directory, $"InputDay01.txt");
        return File.ReadAllLines(filePath);
    }

    private static long GetPuzzleOutput(int part)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string directory = Path.Combine(currentDirectory, "data");
        string filePath = Path.Combine(directory, $"OutputDay01Part{part}.txt");
        string outputText = File.ReadAllText(filePath);
        return long.Parse(outputText);
    }
}
