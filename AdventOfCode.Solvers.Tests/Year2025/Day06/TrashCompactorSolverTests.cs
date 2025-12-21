using AdvenOfCode.Solvers.Year2025;
using AdvenOfCode.Solvers.Year2025.Day06;

namespace AdventOfCode.Solvers.Tests.Year2025.Day06;

public class TrashCompactorSolverTests : AdventOfCodeTestsBase<TrashCompactorSolver>
{
    public override string PuzzleInputPath => @"Year2025\Day06";

    [Theory]
    [InlineData("example.txt", 4277556)]
    [InlineData("input.txt", 4076006202939)]
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
    [InlineData("example.txt", 3263827)]
    [InlineData("input.txt", 7903168391557)]
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

    protected override TrashCompactorSolver CreateSolver(string[] puzzleInput)
    {
        return new TrashCompactorSolver(puzzleInput);
    }
}
