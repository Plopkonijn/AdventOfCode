namespace Year2024.Tests;

public abstract class AdventOfCodeSolverTests<TPart1, TPart2>
    where TPart1 : IParsable<TPart1>
        where TPart2 : IParsable<TPart2>
{
    protected abstract int Day { get; }
    protected abstract AdventOfCodeSolver<TPart1, TPart2> GetSolver(string[] input);

    [Fact]
    public void PuzzlePart1()
    {
        // Arrange
        string[] input = TestUtilities.GetPuzzleInput(Day);
        TPart1 expectedOutput = TestUtilities.GetPuzzleOutput<TPart1>(Day, 1);
        AdventOfCodeSolver<TPart1, TPart2> solver = GetSolver(input);
        // Act
        TPart1 actualOutput = solver.SolvePart1();
        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void PuzzlePart2()
    {
        // Arrange
        string[] input = TestUtilities.GetPuzzleInput(Day);
        TPart2 expectedOutput = TestUtilities.GetPuzzleOutput<TPart2>(Day, 2);
        AdventOfCodeSolver<TPart1, TPart2> solver = GetSolver(input);

        // Act
        TPart2 actualOutput = solver.SolvePart2();

        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }
}

public abstract class DefaultAdventOfCodeSolverTests : AdventOfCodeSolverTests<long, long>
{
}