namespace AdvenOfCode.Solvers.Year2025.Day11;

public sealed class ReactorSolver(string[] input) : Solver(input)
{

    public override long SolvePart1()
    {
        Dictionary<string, string[]> connections = Input.Select(line => line.Split(':', StringSplitOptions.RemoveEmptyEntries))
            .ToDictionary(split => split[0], split => split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries));
        Queue<string> queue = new();
        queue.Enqueue("you");

        long result = 0;
        while (queue.TryDequeue(out string? current))
        {
            if (current is "out")
            {
                result++;
                continue;
            }
            foreach (string neighbour in connections[current])
            {
                queue.Enqueue(neighbour);
            }
        }
        return result;
    }



    public override long SolvePart2()
    {
        Dictionary<string, string[]> connections = Input.Select(line => line.Split(':', StringSplitOptions.RemoveEmptyEntries))
            .ToDictionary(split => split[0], split => split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries));
        long svr2dac = GetCount("svr", "dac", connections, new() { { "dac", 1 } });
        long dac2fft = GetCount("dac", "fft", connections, new() { { "fft", 1 } });
        long fft2out = GetCount("fft", "out", connections, new() { { "out", 1 } });

        long svr2fft = GetCount("svr", "fft", connections, new() { { "fft", 1 } });
        long ffth2dac = GetCount("fft", "dac", connections, new() { { "dac", 1 } });
        long dac2out = GetCount("dac", "out", connections, new() { { "out", 1 } });
        return (svr2dac * dac2fft * fft2out) + (svr2fft * ffth2dac * dac2out);
    }

    private static long GetCount(
        string source,
        string target,
        Dictionary<string, string[]> connections,
        Dictionary<string, long> cache)
    {
        if (cache.TryGetValue(source, out long result))
        {
            return result;
        }

        if (source == target)
        {
            return 1;
        }
        result = 0;
        if (connections.TryGetValue(source, out string[]? neighbours))
        {
            foreach (string neighbour in neighbours)
            {
                result += GetCount(neighbour, target, connections, cache);
            }
        }
        cache.Add(source, result);

        return result;
    }

    internal record struct Node(string Value, bool VisitedDAC, bool VisitedFFT);
}
