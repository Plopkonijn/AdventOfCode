namespace Year2024;

public abstract class AdventOfCodeSolver<TPart1, TPart2>(string[] input)
{
    protected string[] _input = input;

    public abstract TPart1 SolvePart1();
    public abstract TPart2 SolvePart2();
}

public abstract class DefaultAdventOfCodeSolver(string[] input) : AdventOfCodeSolver<long, long>(input)
{
}