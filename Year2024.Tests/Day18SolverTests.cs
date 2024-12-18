
using Year2024.Solvers;

namespace Year2024.Tests;

public class Day18SolverTests : AdventOfCodeSolverTests
{
    protected override int Day => 18;

    protected override Day18Solver GetSolver(string[] input)
    {
        return new Day18Solver(input, 1024, new Position(70, 70));
    }

    [Fact]
    public void Part1Example1()
    {
        // Arrange
        string[] input =
        [
            "5,4",
            "4,2",
            "4,5",
            "3,0",
            "2,1",
            "6,3",
            "2,4",
            "1,5",
            "0,6",
            "3,3",
            "2,6",
            "5,1",
            "1,2",
            "5,5",
            "2,5",
            "6,5",
            "1,4",
            "0,4",
            "6,4",
            "1,1",
            "6,1",
            "1,0",
            "0,5",
            "1,6",
            "2,0",
        ];
        Day18Solver solver = GetSolver(input);
        solver.StepsToTake = 12;
        solver.EndPosition = new Position(6, 6);

        // Act
        long result = solver.SolvePart1();

        // Assert
        Assert.Equal(22, result);
    }
}
