using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2016.Day1;

namespace AdventOfCode.Solvers.Tests.Year2016.Day01;

public sealed class NoTimeForATaxicabSolverTests : AdventOfCodeTestsBase<NoTimeForATaxicabSolver>
{
    public override string PuzzleInputPath => @"Year2016\Day01";

    protected override NoTimeForATaxicabSolver CreateSolver(string[] puzzleInput)
    {
        return new NoTimeForATaxicabSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 5)]
    [InlineData("example02.txt", 2)]
    [InlineData("example03.txt", 12)]
    [InlineData("input.txt", 241)]
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
    [InlineData("example04.txt", 4)]
    [InlineData("input.txt", 116)]
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
