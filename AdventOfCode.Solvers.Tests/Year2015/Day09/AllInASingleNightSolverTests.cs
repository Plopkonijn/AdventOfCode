using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day09;

namespace AdventOfCode.Solvers.Tests.Year2015.Day09;

public sealed class AllInASingleNightSolverTests : AdventOfCodeTestsBase<AllInASingleNightSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day09";

    protected override AllInASingleNightSolver CreateSolver(string[] puzzleInput)
    {
        return new AllInASingleNightSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 605)]
    [InlineData("input.txt", 141)]
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
    [InlineData("example01.txt", 0)]
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
