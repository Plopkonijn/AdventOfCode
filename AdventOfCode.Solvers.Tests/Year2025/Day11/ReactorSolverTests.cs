using AdvenOfCode.Solvers.Year2025.Day11;

namespace AdventOfCode.Solvers.Tests.Year2025.Day11;

public sealed class ReactorSolverTests : AdventOfCodeTestsBase<ReactorSolver>
{
    public override string PuzzleInputPath => @"Year2025\Day11";

    [Theory]
    [InlineData("example.txt", 5)]
    [InlineData("input.txt", 431)]
    public override void Part1(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        ReactorSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("example2.txt", 2)]
    [InlineData("input.txt", 358458157650450)]
    public override void Part2(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        ReactorSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart2();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }

    protected override ReactorSolver CreateSolver(string[] puzzleInput)
    {
        return new ReactorSolver(puzzleInput);
    }
}
