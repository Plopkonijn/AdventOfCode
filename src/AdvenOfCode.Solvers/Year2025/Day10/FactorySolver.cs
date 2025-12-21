namespace AdvenOfCode.Solvers.Year2025.Day10;

public sealed class FactorySolver(string[] input) : Solver(input)
{

    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            result += CalculatePresses1(line);
        }
        return result;
    }

    private static long CalculatePresses1(string line)
    {
        MachineConfiguration config = MachineConfiguration.Parse(line);
        Dictionary<int, long> dist = new() { { 0, 0 } };
        PriorityQueue<int, long> queue = new();
        queue.Enqueue(0, 0);
        while (queue.TryDequeue(out int element, out long priority))
        {
            if (element == config.Diagram)
            {
                return priority;
            }

            foreach (int wiring in config.Wirings)
            {
                int neighbour = element ^ wiring;
                long alternativeDistance = priority + 1;
                if (!dist.TryGetValue(neighbour, out long currentDistance) || alternativeDistance < currentDistance)
                {
                    dist[neighbour] = alternativeDistance;
                    queue.Enqueue(neighbour, alternativeDistance);
                }
            }
        }
        throw new InvalidOperationException();
    }

    public override long SolvePart2()
    {
        long result = 0;
        foreach (string line in Input)
        {
            MachineConfiguration config = MachineConfiguration.Parse(line);
            result += CalculatePresses2(config.Joltage, config.Wirings);
        }
        return result;
    }

    private static long CalculatePresses2(Joltage joltage, ReadOnlySpan<int> wirings)
    {
        if (joltage.IsZero)
        {
            return 0;
        }
        if (wirings.Length == 0)
        {
            return int.MaxValue;
        }

        long bestResult = CalculatePresses2(joltage, wirings[1..]);
        joltage = joltage.Press(wirings[0]);
        for (long i = 1; joltage.IsValid; i++, joltage = joltage.Press(wirings[0]))
        {
            long result = i + CalculatePresses2(joltage, wirings[1..]);
            if (result < bestResult)
            {
                bestResult = result;
            }
        }
        return bestResult;
    }
}
