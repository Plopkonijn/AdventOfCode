using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day21;

namespace AdventOfCode.Solvers.Tests.Year2015.Day21;

public sealed class RpgSimulator20XXSolverTests : AdventOfCodeTestsBase<RpgSimulator20XXSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day21";

    protected override RpgSimulator20XXSolver CreateSolver(string[] puzzleInput)
    {
        return new RpgSimulator20XXSolver(puzzleInput);
    }

    [Theory]
    [InlineData("input.txt", 111)]
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
    [InlineData("input.txt", 188)]
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
