using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day23;

namespace AdventOfCode.Solvers.Tests.Year2015.Day23;

public sealed class OpeningTheTuringLockSolverTests : AdventOfCodeTestsBase<OpeningTheTuringLockSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day23";

    protected override OpeningTheTuringLockSolver CreateSolver(string[] puzzleInput)
    {
        return new OpeningTheTuringLockSolver(puzzleInput);
    }

    [Theory]
    [InlineData("input.txt", 170)]
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
    [InlineData("input.txt", 247)]
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
