using Year2024.Solvers;

namespace Year2024.Tests;
public sealed class Day2SolverTests : DefaultAdventOfCodeSolverTests
{
    protected override int Day => 2;

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
        DefaultAdventOfCodeSolver solver = GetSolver(input);

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
        DefaultAdventOfCodeSolver solver = GetSolver(input);

        // Act
        long result = solver.SolvePart1();

        // Assert
        Assert.Equal(2, result);
    }

    protected override DefaultAdventOfCodeSolver GetSolver(string[] input)
    {
        return new Day2Solver(input);
    }
}
