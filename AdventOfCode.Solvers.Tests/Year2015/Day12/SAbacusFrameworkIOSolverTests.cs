using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day12;

namespace AdventOfCode.Solvers.Tests.Year2015.Day12;

public sealed class SAbacusFrameworkIOSolverTests : AdventOfCodeTestsBase<SAbacusFrameworkIOSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day12";

    protected override SAbacusFrameworkIOSolver CreateSolver(string[] puzzleInput)
    {
        return new SAbacusFrameworkIOSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 18)]
    [InlineData("input.txt", 156366)]
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
    [InlineData("example02.txt", 16)]
    [InlineData("input.txt", 96852)]
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
