using AdvenOfCode.Solvers.Year2025.Day12;

namespace AdventOfCode.Solvers.Tests.Year2025.Day12;

public sealed class ChristmasTreeFarmSolverTests : AdventOfCodeTestsBase<ChristmasTreeFarmSolver>
{
    public override string PuzzleInputPath => @"Year2025\Day12";

    [Theory]
    [InlineData("example.txt", 2)]
    [InlineData("input.txt", 567)]
    public override void Part1(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        ChristmasTreeFarmSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    public override void Part2(string inputFilePath, long expectedSolution)
    {
        throw new NotImplementedException("There was no part 2");
    }

    protected override ChristmasTreeFarmSolver CreateSolver(string[] puzzleInput)
    {
        return new ChristmasTreeFarmSolver(puzzleInput);
    }
}
