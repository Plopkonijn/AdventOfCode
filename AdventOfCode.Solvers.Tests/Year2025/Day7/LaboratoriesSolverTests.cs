using AdvenOfCode.Solvers.Year2025;
using AdvenOfCode.Solvers.Year2025.Day7;

namespace AdventOfCode.Solvers.Tests.Year2025.Day7;

public sealed class LaboratoriesSolverTests : AdventOfCodeTestsBase<LaboratoriesSolver>
{
    public override string PuzzleInputPath => @"Year2025\Day7";

    [Theory]
    [InlineData("example.txt", 21)]
    [InlineData("input.txt", 1546)]
    public override void Part1(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        Solver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [Theory]
    [InlineData("example.txt", 40)]
    [InlineData("input.txt", 13883459503480)]
    public override void Part2(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        Solver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart2();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }

    protected override LaboratoriesSolver CreateSolver(string[] puzzleInput)
    {
        return new LaboratoriesSolver(puzzleInput);
    }
}
