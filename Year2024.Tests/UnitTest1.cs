using Year2024.Solvers;

namespace Year2024.Tests;

public class Day1SolverTests
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
        _ = new Day1Solver(input);

        // Act
        long result = new Day1Solver(input).SolvePart1();

        // Assert
        Assert.Equal(11, result);
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
        _ = new Day1Solver(input);
        // Act
        long result = new Day1Solver(input).SolvePart2();
        // Assert
        Assert.Equal(31, result);
    }
}
