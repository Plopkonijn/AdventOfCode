using AdvenOfCode.Solvers.Year2025.Day10;

namespace AdventOfCode.Solvers.Tests.Year2025.Day10;

public sealed class FactorySolverTests : AdventOfCodeTestsBase<FactorySolver>
{
    public override string PuzzleInputPath => @"Year2025\Day10";

    [Theory]
    [InlineData("example.txt", 7)]
    [InlineData("input.txt", 432)]
    public override void Part1(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        FactorySolver solver = CreateSolver(input);

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
        FactorySolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart2();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }

    protected override FactorySolver CreateSolver(string[] puzzleInput)
    {
        return new FactorySolver(puzzleInput);
    }
}
