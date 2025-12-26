using AdvenOfCode.Solvers.Year2025.Day08;

namespace AdventOfCode.Solvers.Tests.Year2025.Day08;

public sealed class PlaygroundSolverTests : AdventOfCodeTestsBase
{
    public override string PuzzleInputPath => @"Year2025\Day08";

    [Theory]
    [InlineData("example.txt", 10, 40)]
    [InlineData("input.txt", 1000, 72150)]
    public void Part1(string inputFilePath, int iterations, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        PlaygroundSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1(iterations);

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("example.txt", 25272)]
    [InlineData("input.txt", 3926518899)]
    public void Part2(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        PlaygroundSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart2();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }

    private PlaygroundSolver CreateSolver(string[] puzzleInput)
    {
        return new PlaygroundSolver(puzzleInput);
    }
}
