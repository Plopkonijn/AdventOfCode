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

    private sealed record Beam(int Index, long Amount)
    {
        public int Index { get; set; } = Index;
        public long Amount { get; set; } = Amount;
    }
    public override long SolvePart2()
    {
        long result = 0;
        LinkedList<Beam> beams = new([new Beam(Input[0].IndexOf('S', StringComparison.InvariantCulture), 1)]);
        foreach (string line in Input[1..])
        {
            for (LinkedListNode<Beam>? n = beams.First; n != null; n = n.Next)
            {
                Beam beam = n.Value;
                if (line[beam.Index] is '^')
                {
                    result += beam.Amount;
                    if (n.Previous is { Value: { } previousBeam } && previousBeam.Index == beam.Index - 1)
                    {
                        previousBeam.Amount += beam.Amount;
                        beam.Index++;
                    }
                    else
                    {
                        n = beams.AddAfter(n, new Beam(beam.Index + 1, beam.Amount));
                        beam.Index--;
                    }
                }
                else if (n.Previous is { Value: { } previousBeam } && previousBeam == n.Value)
                {
                    previousBeam.Amount += beam.Amount;
                    LinkedListNode<Beam> t = n.Previous;
                    beams.Remove(n);
                    n = t;
                }
            }
        }
        return beams.Sum(b => b.Amount);
    }
}
