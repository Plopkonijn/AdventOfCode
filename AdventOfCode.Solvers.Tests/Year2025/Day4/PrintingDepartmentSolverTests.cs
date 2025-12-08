using AdvenOfCode.Solvers.Year2025;
using AdvenOfCode.Solvers.Year2025.Day4;

namespace AdventOfCode.Solvers.Tests.Year2025.Day4;

public class PrintingDepartmentSolverTests : AdventOfCodeTestsBase<PrintingDepartmentSolver>
{
    public override string PuzzleInputPath => @"Year2025\Day4";

    [Theory]
    [InlineData("example.txt", 13)]
    [InlineData("input.txt", 1508)]
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
    [InlineData("example.txt", 43)]
    [InlineData("input.txt", 8538)]
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

    protected override PrintingDepartmentSolver CreateSolver(string[] puzzleInput)
    {
        return new PrintingDepartmentSolver(puzzleInput);
    }
}
