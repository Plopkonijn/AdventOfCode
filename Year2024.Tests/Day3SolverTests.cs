using Year2024.Solvers;

namespace Year2024.Tests;

public sealed class Day3SolverTests : AdventOfCodeSolverTests
{
    protected override int Day => 3;

    protected override AdventOfCodeSolver GetSolver(string[] input)
    {
        return new Day3Solver(input);
    }

    [Fact]
    public void Example1()
    {
        // Arrange
        string[] input = ["xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"];
        AdventOfCodeSolver solver = GetSolver(input);

        // Act
        long result = solver.SolvePart1();

        // Assert
        Assert.Equal(161, result);
    }

    [Fact]
    public void Example2()
    {
        // Arrange
        string[] input = ["xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"];
        AdventOfCodeSolver solver = GetSolver(input);

        // Act
        long result = solver.SolvePart2();

        // Assert
        Assert.Equal(48, result);
    }
}

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
}