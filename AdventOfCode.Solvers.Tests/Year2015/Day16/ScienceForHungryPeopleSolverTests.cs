using AdvenOfCode.Solvers.Year2015.Day16;

namespace AdventOfCode.Solvers.Tests.Year2015.Day16;

public sealed class ScienceForHungryPeopleSolverTests : AdventOfCodeTestsBase<ScienceForHungryPeopleSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day16";

    [Theory]
    [InlineData("input.txt", 103)]
    public override void Part1(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        ScienceForHungryPeopleSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart1();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }


    [InlineData("input.txt", 0)]
    [Theory]
    public override void Part2(string inputFilePath, long expectedSolution)
    {
        //Arrange
        string[] input = ReadPuzzleInput(inputFilePath);
        ScienceForHungryPeopleSolver solver = CreateSolver(input);

        //Act
        long actualSolution = solver.SolvePart2();

        //Assert
        Assert.Equal(expectedSolution, actualSolution);
    }

    protected override ScienceForHungryPeopleSolver CreateSolver(string[] puzzleInput)
    {
        return new ScienceForHungryPeopleSolver(puzzleInput);
    }
}
