using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day01;

namespace AdventOfCode.Solvers.Tests.Year2015.Day01;

public sealed class NotQuiteLispSolverTests : AdventOfCodeTestsBase<NotQuiteLispSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day01";

    protected override NotQuiteLispSolver CreateSolver(string[] puzzleInput)
    {
        return new NotQuiteLispSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 0)]
    [InlineData("example02.txt", 0)]
    [InlineData("example03.txt", 3)]
    [InlineData("example04.txt", 3)]
    [InlineData("example05.txt", 3)]
    [InlineData("example06.txt", -1)]
    [InlineData("example07.txt", -1)]
    [InlineData("example08.txt", -3)]
    [InlineData("example09.txt", -3)]
    [InlineData("input.txt", 138)]
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
    [InlineData("example10.txt", 1)]
    [InlineData("example11.txt", 5)]
    [InlineData("input.txt", 1771)]
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
