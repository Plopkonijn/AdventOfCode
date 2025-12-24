using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day08;

namespace AdventOfCode.Solvers.Tests.Year2015.Day08;

public sealed class MatchsticksSolverTests : AdventOfCodeTestsBase<MatchsticksSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day08";

    protected override MatchsticksSolver CreateSolver(string[] puzzleInput)
    {
        return new MatchsticksSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 12)]
    [InlineData("input.txt", 1342)]
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
