public abstract class AdventOfCodeSolver
{
    protected string[] _input;

    public AdventOfCodeSolver(string[] input)
    {
        _input = input;
    }
    public abstract long SolvePart1(string[] input);
    public abstract long SolvePart2(string[] input);
}
