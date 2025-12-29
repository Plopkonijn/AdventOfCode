using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day22;

namespace AdventOfCode.Solvers.Tests.Year2015.Day22;

public sealed class WizardSimulator20XXSolverTests : AdventOfCodeTestsBase<WizardSimulator20XXSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day22";

    protected override WizardSimulator20XXSolver CreateSolver(string[] puzzleInput)
    {
        return new WizardSimulator20XXSolver(puzzleInput);
    }

    [Theory]
    [InlineData("input.txt", 0)]
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
    [InlineData("input.txt", 0)]
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
