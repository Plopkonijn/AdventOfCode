using Year2024.Solvers;

namespace Year2024.Tests;

public sealed class Day4SolverTests : AdventOfCodeSolverTests
{
    protected override int Day => 4;
    protected override AdventOfCodeSolver GetSolver(string[] input)
    {
        return new Day4Solver(input);
    }

    [Fact]
    public void Example1()
    {
        // Arrange
        string[] input =
        [
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"
         ];
        AdventOfCodeSolver solver = GetSolver(input);

        // Act
        long result = solver.SolvePart1();
        // Assert

        Assert.Equal(18, result);
    }

    [Fact]
    public void Example2()
    {
        // Arrange
        string[] input =
        [
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"
         ];
        AdventOfCodeSolver solver = GetSolver(input);

        // Act
        long result = solver.SolvePart2();
        // Assert

        Assert.Equal(9, result);
    }
}