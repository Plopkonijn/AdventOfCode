using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2016.Day03;

namespace AdventOfCode.Solvers.Tests.Year2016.Day03;

public sealed class SquaresWithThreeSidesSolverTests : AdventOfCodeTestsBase<SquaresWithThreeSidesSolver>
{
    public override string PuzzleInputPath => @"Year2016\Day03";

    protected override SquaresWithThreeSidesSolver CreateSolver(string[] puzzleInput)
    {
        return new SquaresWithThreeSidesSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 0)]
    [InlineData("input.txt", 983)]
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
    [InlineData("example02.txt", 6)]
    [InlineData("input.txt", 0)]
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
