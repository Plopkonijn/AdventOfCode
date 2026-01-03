using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2016.Day04;

namespace AdventOfCode.Solvers.Tests.Year2016.Day04;

public sealed class SecurityThroughObscuritySolverTests : AdventOfCodeTestsBase<SecurityThroughObscuritySolver>
{
    public override string PuzzleInputPath => @"Year2016\Day04";

    protected override SecurityThroughObscuritySolver CreateSolver(string[] puzzleInput)
    {
        return new SecurityThroughObscuritySolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 1514)]
    [InlineData("input.txt", 173787)]
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
