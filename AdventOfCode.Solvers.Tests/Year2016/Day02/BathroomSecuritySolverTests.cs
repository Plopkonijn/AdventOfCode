using AdvenOfCode.Solvers.Year2016.Day02;

namespace AdventOfCode.Solvers.Tests.Year2016.Day02;

public sealed class BathroomSecuritySolverTests : AdventOfCodeTestsBase
{
    public override string PuzzleInputPath => @"Year2016\Day02";

    private BathroomSecuritySolver CreateSolver(string[] puzzleInput)
    {
        return new BathroomSecuritySolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 1985)]
    [InlineData("input.txt", 74921)]
    public void Part1(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        BathroomSecuritySolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("example01.txt", "5DB3")]
    [InlineData("input.txt", "A6B35")]
    public void Part2(string inputFilePath, string expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        BathroomSecuritySolver solver = CreateSolver(input);

        //Act
        string actualSolution = solver.SolvePart2();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


}
