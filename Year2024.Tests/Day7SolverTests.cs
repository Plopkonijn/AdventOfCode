using Year2024.Solvers;

namespace Year2024.Tests;

public sealed class Day7SolverTests : DefaultAdventOfCodeSolverTests
{
    protected override int Day => 7;

    protected override AdventOfCodeSolver<long, long> GetSolver(string[] input)
    {
        return new Day7Solver(input);
    }
    [Fact]
    public void Example1()
    {
        //Arrange
        string[] input =
        [
            "190: 10 19",
            "3267: 81 40 27",
            "83: 17 5",
            "156: 15 6",
            "7290: 6 8 6 15",
            "161011: 16 10 13",
            "192: 17 8 14",
            "21037: 9 7 18 13",
            "292: 11 6 16 20"
        ];
        AdventOfCodeSolver<long, long> solver = GetSolver(input);

        //Act
        var result = solver.SolvePart1();

        //Assert
        Assert.Equal(3749, result);
    }

    [Fact]
    public void Example2()
    {
        //Arrange
        string[] input =
        [
            "190: 10 19",
            "3267: 81 40 27",
            "83: 17 5",
            "156: 15 6",
            "7290: 6 8 6 15",
            "161011: 16 10 13",
            "192: 17 8 14",
            "21037: 9 7 18 13",
            "292: 11 6 16 20"
        ];
        AdventOfCodeSolver<long, long> solver = GetSolver(input);

        //Act
        var result = solver.SolvePart2();

        //Assert
        Assert.Equal(11387, result);
    }
}