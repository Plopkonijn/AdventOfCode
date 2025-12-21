using AdvenOfCode.Solvers.Year2025.Day2;

namespace AdventOfCode.Solvers.Tests.Year2025.Day02;

public class GiftShopSolverTests : AdventOfCodeTestsBase<GiftShopSolver>
{
    public override string PuzzleInputPath => @"Year2025\Day02";
    protected override GiftShopSolver CreateSolver(string[] puzzleInput)
    {
        return new GiftShopSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example.txt", 1227775554)]
    [InlineData("input.txt", 24157613387)]
    public override void Part1(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        GiftShopSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("example.txt", 4174379265)]
    [InlineData("input.txt", 33832678380)]
    public override void Part2(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        GiftShopSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart2();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


}
