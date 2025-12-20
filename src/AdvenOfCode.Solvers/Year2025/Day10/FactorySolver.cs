namespace AdvenOfCode.Solvers.Year2025.Day10;

public sealed class FactorySolver(string[] input) : Solver(input)
{

    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            result += CalculatePresses(line);
        }
        return result;
    }

    private static long CalculatePresses(string line)
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
        throw new NotImplementedException();
    }
}
