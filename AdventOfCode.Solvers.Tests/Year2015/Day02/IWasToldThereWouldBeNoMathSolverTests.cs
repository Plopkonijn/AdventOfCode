using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day02;

namespace AdventOfCode.Solvers.Tests.Year2015.Day02;

public sealed class IWasToldThereWouldBeNoMathSolverTests : AdventOfCodeTestsBase<IWasToldThereWouldBeNoMathSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day02";

    protected override IWasToldThereWouldBeNoMathSolver CreateSolver(string[] puzzleInput)
    {
        return new IWasToldThereWouldBeNoMathSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 58)]
    [InlineData("example02.txt", 43)]
    [InlineData("input.txt", 1586300)]
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
    [InlineData("example01.txt", 34)]
    [InlineData("example02.txt", 14)]
    [InlineData("input.txt", 3737498)]
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
