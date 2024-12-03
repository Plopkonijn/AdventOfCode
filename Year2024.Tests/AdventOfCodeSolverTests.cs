namespace Year2024.Tests;

public abstract class AdventOfCodeSolverTests
{
    protected abstract int Day { get; }

    protected abstract AdventOfCodeSolver GetSolver(string[] input);

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Puzzle(int part)
    {
        // Arrange
        string[] input = TestUtilities.GetPuzzleInput(Day);
        long expectedOutput = TestUtilities.GetPuzzleOutput(Day, part);
        AdventOfCodeSolver solver = GetSolver(input);

        // Act
        long actualOutput = part switch
        {
            1 => solver.SolvePart1(),
            2 => solver.SolvePart2(),
            _ => throw new NotImplementedException()
        };

        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }
}
