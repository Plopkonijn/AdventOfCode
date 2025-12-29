using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day20;

namespace AdventOfCode.Solvers.Tests.Year2015.Day20;

public sealed class InfiniteElvesAndInfiniteHousesSolverTests : AdventOfCodeTestsBase<InfiniteElvesAndInfiniteHousesSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day20";

    protected override InfiniteElvesAndInfiniteHousesSolver CreateSolver(string[] puzzleInput)
    {
        return new InfiniteElvesAndInfiniteHousesSolver(puzzleInput);
    }

    [Theory]
    [InlineData("input.txt", 831600)]
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
    [InlineData("input.txt", 884520)]
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
