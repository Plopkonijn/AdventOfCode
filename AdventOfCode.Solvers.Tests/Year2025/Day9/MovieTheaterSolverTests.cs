using AdvenOfCode.Solvers.Year2025.Day9;

namespace AdventOfCode.Solvers.Tests.Year2025.Day9;

public sealed class MovieTheaterSolverTests : AdventOfCodeTestsBase<MovieTheaterSolver>
{
    public override string PuzzleInputPath => @"Year2025\Day9";

    [Theory]
    [InlineData("example.txt", 50)]
    [InlineData("input.txt", 0)]
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
    [InlineData("example.txt", 0)]
    [InlineData("input.txt", 0)]
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
