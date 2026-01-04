using AdvenOfCode.Solvers.Year2016.Day05;

namespace AdventOfCode.Solvers.Tests.Year2016.Day05;

public sealed class HowAboutANiceGameOfChessSolverTests : AdventOfCodeTestsBase
{
    public override string PuzzleInputPath => @"Year2016\Day05";

    private HowAboutANiceGameOfChessSolver CreateSolver(string[] puzzleInput)
    {
        return new HowAboutANiceGameOfChessSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", "18f47a30")]
    [InlineData("input.txt", "")]
    public void Part1(string inputFilePath, string expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        HowAboutANiceGameOfChessSolver solver = CreateSolver(input);

        //Act
        string actualSolution = solver.SolvePart1();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("input.txt", "")]
    public void Part2(string inputFilePath, string expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        HowAboutANiceGameOfChessSolver solver = CreateSolver(input);

        //Act
        string actualSolution = solver.SolvePart2();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }
}
