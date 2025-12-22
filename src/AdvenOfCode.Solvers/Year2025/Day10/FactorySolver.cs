using System.Collections.Specialized;
using System.Diagnostics;

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
    public override long SolvePart2()
    {
        long totalResult = 0;
        foreach (string line in Input)
        {
            MachineConfiguration config = MachineConfiguration.Parse(line);
            List<List<Button>> combinations = GetButtonCombinations(config.Buttons);
            long result = CalculatePresses2(config.Joltage, config.Buttons, combinations, []) ?? throw new InvalidOperationException();
            Debug.WriteLine($"Found result {result}");
            totalResult += result;
        }
        return totalResult;
    }


    private static List<Button> CalculatePresses1(MachineConfiguration config)
    {
        Dictionary<BitVector32, (long presses, Button button)> cache = [];
        PriorityQueue<BitVector32, long> queue = new();
        queue.Enqueue(new(), 0);
        while (queue.TryDequeue(out BitVector32 state, out long presses))
        {
            if (state.Equals(config.Diagram))
            {
                List<Button> buttons = [];
                while (state.Data != 0)
                {
                    Button button = cache[state].button;
                    buttons.Add(button);
                    state = button.Press(state);
                }
                return buttons;
            }

            foreach (Button button in config.Buttons)
            {
                BitVector32 neighbourState = button.Press(state);
                long alternativePresses = presses + 1;
                if (!cache.TryGetValue(neighbourState, out (long presses, Button button) current) || alternativePresses < current.presses)
                {
                    cache[neighbourState] = (alternativePresses, button);
                    queue.Enqueue(neighbourState, alternativePresses);
                }
            }
        }
        throw new InvalidOperationException();
    }




    private static long? CalculatePresses2(Joltage joltage, List<Button> buttons, IReadOnlyList<IReadOnlyList<Button>> buttonCombinations, Dictionary<Joltage, long?> cache)
    {
        if (joltage.IsZero)
        {
            return 0;
        }
        if (cache.TryGetValue(joltage, out long? cachedResult))
        {
            if (cachedResult.HasValue)
            {
                Debug.WriteLine($"Found cached {cachedResult} presses for joltage: {joltage}");
            }
            return cachedResult;
        }
        BitVector32 diagram = joltage.Values.Index()
            .Aggregate(new BitVector32(), (d, t) => new(d.Data | (t.Item % 2 == 0 ? 0 : 1 << t.Index)));

        long? bestResult = null;
        foreach (IReadOnlyList<Button> combination in buttonCombinations)
        {
            BitVector32 resultingDiagram = combination.Aggregate(new BitVector32(), (a, b) => b.Press(a));
            if (!resultingDiagram.Equals(diagram))
            {
                continue;
            }
            Joltage newJoltage = new(joltage.Values.ToArray());
            foreach (Button button in combination)
            {
                button.Press(newJoltage);
            }
            if (!newJoltage.IsValid)
            {
                continue;
            }
            for (int i = 0; i < newJoltage.Values.Length; i++)
            {
                newJoltage.Values[i] /= 2;
            }
            if (CalculatePresses2(newJoltage, buttons, buttonCombinations, cache) is not { } result)
            {
                continue;
            }
            result *= 2;
            result += combination.Count;
            if (bestResult is null || result < bestResult.Value)
            {
                bestResult = result;
            }
        }
        cache.Add(joltage, bestResult);
        if (bestResult.HasValue)
        {
            Debug.WriteLine($"Calculated {bestResult.Value} presses for joltage: {joltage}");
        }

        return bestResult;
    }

    private static List<List<Button>> GetButtonCombinations(List<Button> buttons)
    {
        List<List<Button>> result = [[]];
        foreach (Button button in buttons)
        {
            for (int i = result.Count - 1; i >= 0; i--)
            {
                List<Button> combination = result[i];
                combination = combination.Append(button).ToList();
                result.Add(combination);
            }
        }
        return result;
    }
}
