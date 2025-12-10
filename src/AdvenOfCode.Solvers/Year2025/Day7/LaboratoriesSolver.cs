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
        throw new NotImplementedException();
    }
}
