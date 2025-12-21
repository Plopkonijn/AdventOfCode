namespace AdvenOfCode.Solvers.Year2025.Day10;

public sealed class FactorySolver(string[] input) : Solver(input)
{

    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            MachineConfiguration config = MachineConfiguration.Parse(line);
            result += CalculatePresses1(config).Count;
        }
        return result;
    }

    private static List<int> CalculatePresses1(MachineConfiguration config)
    {
        Dictionary<int, (long presses, int wiring)> cache = new() { { 0, (0, 0) } };
        PriorityQueue<int, long> queue = new();
        queue.Enqueue(0, 0);
        while (queue.TryDequeue(out int state, out long presses))
        {
            if (state == config.Diagram)
            {
                List<int> wirings = [];
                while (state is not 0)
                {
                    int wiring = cache[state].wiring;
                    wirings.Add(wiring);
                    state ^= wiring;
                }
                return wirings;
            }

            foreach (int wiring in config.Wirings)
            {
                int neighbourState = state ^ wiring;
                long alternativePresses = presses + 1;
                if (!cache.TryGetValue(neighbourState, out (long presses, int wiring) current) || alternativePresses < current.presses)
                {
                    cache[neighbourState] = (alternativePresses, wiring);
                    queue.Enqueue(neighbourState, alternativePresses);
                }
            }
        }
        throw new InvalidOperationException();
    }

    public override long SolvePart2()
    {
        long totalResult = 0;
        foreach (string line in Input)
        {
            MachineConfiguration config = MachineConfiguration.Parse(line);
            List<List<int>> combinations = FindPressCombinations(config.Wirings);
            long result = CalculatePresses2(config.Joltage, config.Wirings, combinations);
            totalResult += result;
        }
        return totalResult;
    }



    private static long CalculatePresses2(Joltage joltage, int[] wirings, IReadOnlyList<IReadOnlyList<int>> combinations)
    {
        if (joltage.IsZero)
        {
            return 0;
        }
        int diagram = joltage.Values.Index()
            .Aggregate(0, (d, t) => d | (t.Item % 2 == 0 ? 0 : 1 << t.Index));

        long bestResult = long.MaxValue;
        foreach (List<int> combination in combinations)
        {
            if (combination.Count == 0)
            {
                continue;
            }
            int resultingDiagram = combination.Aggregate((a, b) => a ^ b);
            if (resultingDiagram != diagram)
            {
                continue;
            }
            Joltage newJoltage = new(joltage.Values.ToArray());
            foreach (int p in combination)
            {
                newJoltage = newJoltage.Press(p);
            }
            if (!newJoltage.IsValid)
            {
                continue;
            }
            for (int i = 0; i < newJoltage.Values.Length; i++)
            {
                newJoltage.Values[i] /= 2;
            }
            long result = combination.Count + (2 * CalculatePresses2(newJoltage, wirings, combinations));
            if (result < bestResult)
            {
                bestResult = result;
            }
        }
        return bestResult;
    }

    private static List<List<int>> FindPressCombinations(ReadOnlySpan<int> wirings)
    {
        List<List<int>> result = [[]];
        foreach (int wiring in wirings)
        {
            for (int i = result.Count - 1; i >= 0; i--)
            {
                List<int> combination = result[i];
                combination = combination.Append(wiring).ToList();
                result.Add(combination);
            }
        }
        return result;
    }
}
