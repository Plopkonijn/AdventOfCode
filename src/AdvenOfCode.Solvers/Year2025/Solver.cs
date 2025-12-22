namespace AdvenOfCode.Solvers.Year2025;

public abstract class Solver(string[] input)
{
#pragma warning disable CA1819 // Properties should not return arrays
    protected string[] Input { get; } = input;
#pragma warning restore CA1819 // Properties should not return arrays

    public abstract long SolvePart1();
    public abstract long SolvePart2();
}