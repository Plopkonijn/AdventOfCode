using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day06;

namespace AdventOfCode.Solvers.Tests.Year2015.Day06;

public sealed class DoesntHeHaveInternElvesForThisSolverTests : AdventOfCodeTestsBase<ProbablyAFireHazardSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day06";

    protected override ProbablyAFireHazardSolver CreateSolver(string[] puzzleInput)
    {
        return new ProbablyAFireHazardSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 998996)]
    [InlineData("input.txt", 569999)]
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
    [InlineData("example01.txt", 0)]
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
