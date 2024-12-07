using Year2024.Solvers;

namespace Year2024.Tests;

public sealed class Day6SolverTests : AdventOfCodeSolverTests
{
    protected override int Day => 6;

    protected override AdventOfCodeSolver GetSolver(string[] input)
    {
        return new Day6Solver(input);
    }

    [Fact]
    public void Example1()
    {
        // Arrange
        string[] input =
        [
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#...",
        ];

        AdventOfCodeSolver solver = GetSolver(input);

        // Act
        long result = solver.SolvePart1();

        // Assert
        Assert.Equal(41, result);
    }
}
