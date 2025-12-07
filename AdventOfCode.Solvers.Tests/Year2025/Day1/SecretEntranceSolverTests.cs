using AdvenOfCode.Solvers.Year2025;
using AdvenOfCode.Solvers.Year2025.Day1;

namespace AdventOfCode.Solvers.Tests.Year2025.Day1;

public sealed class SecretEntranceSolverTests : AdventOfCodeTestsBase<SecretEntranceSolver>
{
    public override string PuzzleInputPath => @"Year2025\Day1";

    protected override SecretEntranceSolver CreateSolver(string[] puzzleInput)
    {
        return new SecretEntranceSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example.txt", 3)]
    [InlineData("input.txt", 995)]
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
    [InlineData("example.txt", 6)]
    [InlineData("input.txt", 5847)]
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
}
