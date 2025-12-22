using AdvenOfCode.Solvers.Year2025.Day09;

namespace AdventOfCode.Solvers.Tests.Year2025.Day09;

public sealed class MovieTheaterSolverTests : AdventOfCodeTestsBase<MovieTheaterSolver>
{
    public override string PuzzleInputPath => @"Year2025\Day09";

    [Theory]
    [InlineData("example.txt", 50)]
    [InlineData("input.txt", 4777816465)]
    public override void Part1(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        MovieTheaterSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("example.txt", 24)]
    [InlineData("input.txt", 1410501884)]
    public override void Part2(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        MovieTheaterSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart2();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }

    protected override MovieTheaterSolver CreateSolver(string[] puzzleInput)
    {
        return new MovieTheaterSolver(puzzleInput);
    }
}
