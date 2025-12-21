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
        throw new NotImplementedException();
    }
}
