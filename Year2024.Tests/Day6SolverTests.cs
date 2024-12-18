using Year2024.Solvers;

namespace Year2024.Tests;

public sealed class Day6SolverTests : DefaultAdventOfCodeSolverTests
{
    protected override int Day => 6;

    protected override DefaultAdventOfCodeSolver GetSolver(string[] input)
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

        DefaultAdventOfCodeSolver solver = GetSolver(input);

        // Act
        long result = solver.SolvePart1();

        // Assert
        Assert.Equal(41, result);
    }
}
