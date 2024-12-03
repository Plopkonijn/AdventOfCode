using Year2024.Solvers;

namespace Year2024.Tests;

public sealed class Day2SolverTests
{
    [Fact]
    public void Example1()
    {
        // Arrange
        string[] input =
        [
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"
        ];
        Day2Solver solver = new(input);

        // Act
        long result = solver.SolvePart1();

        // Assert
        Assert.Equal(2, result);

    }

    [Fact]
    public void Example2()
    {
        // Arrange
        string[] input =
        [
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"
        ];
        Day2Solver solver = new(input);

        // Act
        long result = solver.SolvePart1();

        // Assert
        Assert.Equal(2, result);
    }
}