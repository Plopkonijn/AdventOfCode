using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day03;

namespace AdventOfCode.Solvers.Tests.Year2015.Day03;

public sealed class IWasToldThereWouldBeNoMathSolverTests : AdventOfCodeTestsBase<PerfectlySphericalHousesinaVacuumSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day03";

    protected override PerfectlySphericalHousesinaVacuumSolver CreateSolver(string[] puzzleInput)
    {
        return new PerfectlySphericalHousesinaVacuumSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 2)]
    [InlineData("example02.txt", 4)]
    [InlineData("example03.txt", 2)]
    [InlineData("input.txt", 2572)]
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
    [InlineData("example04.txt", 3)]
    [InlineData("example02.txt", 3)]
    [InlineData("example03.txt", 11)]
    [InlineData("input.txt", 2631)]
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
