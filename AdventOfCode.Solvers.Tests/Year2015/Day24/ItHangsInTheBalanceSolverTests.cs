using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day24;

namespace AdventOfCode.Solvers.Tests.Year2015.Day24;

public sealed class ItHangsInTheBalanceSolverTests : AdventOfCodeTestsBase<ItHangsInTheBalanceSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day24";

    protected override ItHangsInTheBalanceSolver CreateSolver(string[] puzzleInput)
    {
        return new ItHangsInTheBalanceSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 99)]
    [InlineData("input.txt", 0)]
    public override void Part1(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        Solver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("input.txt", 11846773891)]
    public override void Part2(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        Solver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart2();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }
}
