namespace Year2024;

public abstract class AdventOfCodeSolver(string[] input)
{
    protected string[] _input = input;

    public abstract long SolvePart1();
    public abstract long SolvePart2();

}