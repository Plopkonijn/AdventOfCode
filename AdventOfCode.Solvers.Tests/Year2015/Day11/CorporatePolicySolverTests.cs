using AdvenOfCode.Solvers.Year2015.Day11;

namespace AdventOfCode.Solvers.Tests.Year2015.Day11;

public sealed class CorporatePolicySolverTests : AdventOfCodeTestsBase
{
    public override string PuzzleInputPath => @"Year2015\Day11";

    protected CorporatePolicySolver CreateSolver(string[] puzzleInput)
    {
        return new CorporatePolicySolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", "abcdffaa")]
    [InlineData("example02.txt", "ghjaabcc")]
    [InlineData("input01.txt", "vzbxxyzz")]
    public void Part1(string inputFilePath, string expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        CorporatePolicySolver solver = CreateSolver(input);

        //Act
        string actualSolution = solver.SolvePart1();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("input02.txt", "")]
    public void Part2(string inputFilePath, string expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        CorporatePolicySolver solver = CreateSolver(input);

        //Act
        string actualSolution = solver.SolvePart2();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }

}
