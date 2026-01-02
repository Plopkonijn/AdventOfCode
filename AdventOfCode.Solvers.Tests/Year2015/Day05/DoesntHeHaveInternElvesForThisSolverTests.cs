using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day05;

namespace AdventOfCode.Solvers.Tests.Year2015.Day05;

public sealed class DoesntHeHaveInternElvesForThisSolverTests : AdventOfCodeTestsBase<DoesntHeHaveInternElvesForThisSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day05";

    protected override DoesntHeHaveInternElvesForThisSolver CreateSolver(string[] puzzleInput)
    {
        return new DoesntHeHaveInternElvesForThisSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 2)]
    [InlineData("input.txt", 236)]
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
    [InlineData("example02.txt", 2)]
    [InlineData("input.txt", 51)]
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
