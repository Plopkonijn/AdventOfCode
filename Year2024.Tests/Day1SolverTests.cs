using Year2024.Solvers;

namespace Year2024.Tests;

public sealed class Day1SolverTests : AdventOfCodeSolverTests
{
    protected override int Day => 1;

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
        AdventOfCodeSolver solver = GetSolver(input);

        // Act
        long result = solver.SolvePart1();

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
        AdventOfCodeSolver solver = GetSolver(input);

        // Act
        long result = solver.SolvePart2();

        // Assert
        Assert.Equal(31, result);
    }

    protected override AdventOfCodeSolver GetSolver(string[] input)
    {
        return new Day1Solver(input);
    }
}
