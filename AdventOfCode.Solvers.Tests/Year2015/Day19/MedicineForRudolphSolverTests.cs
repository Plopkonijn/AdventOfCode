using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day19;

namespace AdventOfCode.Solvers.Tests.Year2015.Day19;

public sealed class MedicineForRudolphSolverTests : AdventOfCodeTestsBase<MedicineForRudolphSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day19";

    protected override MedicineForRudolphSolver CreateSolver(string[] puzzleInput)
    {
        return new MedicineForRudolphSolver(puzzleInput);
    }

    [Theory]
    [InlineData("example01.txt", 4)]
    [InlineData("example02.txt", 7)]
    [InlineData("input.txt", 518)]
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
    [InlineData("example01.txt", 3)]
    [InlineData("example02.txt", 6)]
    [InlineData("input.txt", 200)]
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
