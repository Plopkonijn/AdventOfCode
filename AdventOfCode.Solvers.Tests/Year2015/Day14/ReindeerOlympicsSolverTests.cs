using AdvenOfCode.Solvers.Year2015.Day14;

namespace AdventOfCode.Solvers.Tests.Year2015.Day14;

public sealed class ReindeerOlympicsSolverTests : AdventOfCodeTestsBase
{
    public override string PuzzleInputPath => @"Year2015\Day14";

    private ReindeerOlympicsSolver CreateSolver(string[] puzzleInput)
    {
        return new ReindeerOlympicsSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 1000, 1120)]
    [InlineData("input.txt", 2503, 2640)]
    public void Part1(string inputFilePath, long totalTime, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        ReindeerOlympicsSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1(totalTime);

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [InlineData("example01.txt", 1000, 689)]
    [InlineData("input.txt", 2503, 1102)]
    [Theory]
    public void Part2(string inputFilePath, long totalTime, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        ReindeerOlympicsSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart2(totalTime);

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }
}
