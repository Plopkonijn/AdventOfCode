using AdvenOfCode.Solvers.Year2015.Day10;

namespace AdventOfCode.Solvers.Tests.Year2015.Day10;

public sealed class ElvesLookElvesSaySolverTests : AdventOfCodeTestsBase
{
    public override string PuzzleInputPath => @"Year2015\Day10";

    protected ElvesLookElvesSaySolver CreateSolver(string[] puzzleInput)
    {
        return new ElvesLookElvesSaySolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 1, 2)]
    [InlineData("example02.txt", 1, 2)]
    [InlineData("example03.txt", 1, 4)]
    [InlineData("example04.txt", 1, 6)]
    [InlineData("example05.txt", 1, 6)]
    [InlineData("input.txt", 40, 329356)]
    public void Part1(string inputFilePath, int iterations, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        ElvesLookElvesSaySolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.Solve(iterations);

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("input.txt", 50, 4666278)]
    public void Part2(string inputFilePath, int iterations, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        ElvesLookElvesSaySolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.Solve(iterations);

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }
}
