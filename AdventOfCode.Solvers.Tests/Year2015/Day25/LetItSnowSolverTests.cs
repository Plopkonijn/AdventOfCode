using AdvenOfCode.Solvers;
using AdvenOfCode.Solvers.Year2015.Day25;

namespace AdventOfCode.Solvers.Tests.Year2015.Day25;

public sealed class LetItSnowSolverTests : AdventOfCodeTestsBase<LetItSnowSolver>
{
    public override string PuzzleInputPath => @"Year2015\Day25";

    protected override LetItSnowSolver CreateSolver(string[] puzzleInput)
    {
        return new LetItSnowSolver(puzzleInput);
    }

    [Theory]
    [InlineData("input.txt", 2650453)]
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


    public override void Part2(string inputFilePath, long expectedSolution)
    {
        throw new NotImplementedException("There was no part 2");
    }
}
