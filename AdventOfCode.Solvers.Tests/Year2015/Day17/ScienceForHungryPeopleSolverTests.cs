using AdvenOfCode.Solvers.Year2015.Day17;

namespace AdventOfCode.Solvers.Tests.Year2015.Day17;

public sealed class ScienceForHungryPeopleSolverTests : AdventOfCodeTestsBase
{
    public override string PuzzleInputPath => @"Year2015\Day17";

    [Theory]
    [InlineData("example01.txt", 25, 4)]
    [InlineData("input.txt", 150, 4372)]
    public void Part1(string inputFilePath, long totalVolume, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        ScienceForHungryPeopleSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1(totalVolume);

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("example01.txt", 25, 3)]
    [InlineData("input.txt", 150, 4)]
    public void Part2(string inputFilePath, long totalVolume, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        ScienceForHungryPeopleSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart2(totalVolume);

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }

    private ScienceForHungryPeopleSolver CreateSolver(string[] puzzleInput)
    {
        return new ScienceForHungryPeopleSolver(puzzleInput);
    }
}
