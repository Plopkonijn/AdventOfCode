using AdvenOfCode.Solvers.Year2015.Day18;

namespace AdventOfCode.Solvers.Tests.Year2015.Day18;

public sealed class LikeAGifForYourYardSolverTests : AdventOfCodeTestsBase
{
    public override string PuzzleInputPath => @"Year2015\Day18";

    [Theory]
    [InlineData("example01.txt", 4, 4)]
    [InlineData("input.txt", 100, 814)]
    public void Part1(string inputFilePath, int steps, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        LikeAGifForYourYardSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1(steps);

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("example01.txt", 5, 17)]
    [InlineData("input.txt", 100, 0)]
    public void Part2(string inputFilePath, int steps, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        LikeAGifForYourYardSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart2(steps);

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }

    private LikeAGifForYourYardSolver CreateSolver(string[] puzzleInput)
    {
        return new LikeAGifForYourYardSolver(puzzleInput);
    }
}
