using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day04;

namespace AdventOfCode.Solvers.Tests.Year2015.Day04;

public sealed class IWasToldThereWouldBeNoMathSolverTests : AdventOfCodeTestsBase<TheIdealStockingStufferSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day04";

    protected override TheIdealStockingStufferSolver CreateSolver(string[] puzzleInput)
    {
        return new TheIdealStockingStufferSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 609043)]
    [InlineData("example02.txt", 1048970)]
    [InlineData("input.txt", 282749)]
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
    [InlineData("input.txt", 9962624)]
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
