using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day13;

namespace AdventOfCode.Solvers.Tests.Year2015.Day13;

public sealed class SAbacusFrameworkIOSolverTests : AdventOfCodeTestsBase<KnightsOfTheDinnerTableSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day13";

    protected override KnightsOfTheDinnerTableSolver CreateSolver(string[] puzzleInput)
    {
        return new KnightsOfTheDinnerTableSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 330)]
    [InlineData("input.txt", 733)]
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
