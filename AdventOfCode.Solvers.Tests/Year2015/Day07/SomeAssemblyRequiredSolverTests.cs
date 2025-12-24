using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day07;

namespace AdventOfCode.Solvers.Tests.Year2015.Day07;

public sealed class SomeAssemblyRequiredSolverTests : AdventOfCodeTestsBase<SomeAssemblyRequiredSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day07";

    protected override SomeAssemblyRequiredSolver CreateSolver(string[] puzzleInput)
    {
        return new SomeAssemblyRequiredSolver(puzzleInput);
    }

    [Theory]
    [InlineData("input.txt", 16076)]
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
