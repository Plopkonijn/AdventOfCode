namespace AdvenOfCode.Solvers.Year2025.Day7;

public sealed class LaboratoriesSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long result = 0;
        LinkedList<int> beams = new([Input[0].IndexOf('S', StringComparison.InvariantCulture)]);
        foreach (string line in Input[1..])
        {
            for (LinkedListNode<int>? n = beams.First; n != null; n = n.Next)
            {
                int beam = n.Value;
                if (line[beam] is '^')
                {
                    result++;
                    if (n.Previous is not { Value: { } previousBeam } || previousBeam != beam - 1)
                    {
                        n.Value = beam - 1;
                        n = beams.AddAfter(n, beam + 1);
                    }
                    else
                    {
                        n.Value = beam + 1;
                    }
                }
                else if (n.Previous is { Value: { } previousBeam } && previousBeam == n.Value)
                {
                    LinkedListNode<int> t = n.Previous;
                    beams.Remove(n);
                    n = t;
                }
            }
        }
        return result;
    }

    public override long SolvePart2()
    {
        int startPosition = Input[0].IndexOf('S', StringComparison.InvariantCulture);
        long result = SolvePart2(0, startPosition, []);
        return result;
    }

    private long SolvePart2(int row, int column, Dictionary<(int row, int column), long> cache)
    {
        if (row == Input.Length)
        {
            return 1;
        }
        if (cache.TryGetValue((row, column), out long result))
        {
            return result;
        }

        result = Input[row][column] is '^'
            ? SolvePart2(row + 1, column - 1, cache) + SolvePart2(row + 1, column + 1, cache)
            : SolvePart2(row + 1, column, cache);
        cache.Add((row, column), result);
        return result;
    }
}
