namespace AdvenOfCode.Solvers.Year2025;

public abstract class Solver(string[] input)
{
    protected IReadOnlyList<string> Input { get; } = input;

    public abstract long SolvePart1();
    public abstract long SolvePart2();
}