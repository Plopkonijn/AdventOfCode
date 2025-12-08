using AdvenOfCode.Solvers.Year2025;
using AdvenOfCode.Solvers.Year2025.Day5;

namespace AdventOfCode.Solvers.Tests.Year2025.Day5;

public class CafeteriaSolverTests : AdventOfCodeTestsBase<CafeteriaSolver>
{
    public override string PuzzleInputPath => @"Year2025\Day5";

    [Theory]
    [InlineData("example.txt", 3)]
    [InlineData("input.txt", 643)]
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
    [InlineData("example.txt", 14)]
    [InlineData("input.txt", 342018167474526)]
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

    protected override CafeteriaSolver CreateSolver(string[] puzzleInput)
    {
        return new CafeteriaSolver(puzzleInput);
    }
}
