using AdvenOfCode.Solvers.Year2015.Day15;

namespace AdventOfCode.Solvers.Tests.Year2015.Day15;

public sealed class ScienceForHungryPeopleSolverTests : AdventOfCodeTestsBase<ScienceForHungryPeopleSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day15";

    [Theory]
    [InlineData("example01.txt", 62842880)]
    [InlineData("input.txt", 13882464)]
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


    [InlineData("example01.txt", 57600000)]
    [InlineData("input.txt", 11171160)]
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
