using System.Text;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day19;

public sealed class MedicineForRudolphSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        Dictionary<string, List<string>> replacementDictionary = ParseReplacements(Input[0..^2]);
        string molecule = Input[^1];
        HashSet<string> createdMolecules = [];
        foreach ((string? source, List<string>? targets) in replacementDictionary)
        {
            IEnumerable<string> newMolecules = Create(molecule, source, targets);
            createdMolecules.UnionWith(newMolecules);
        }
        return createdMolecules.Count;
    }

    private static IEnumerable<string> Create(string molecule, string source, IEnumerable<string> targets)
    {
        StringBuilder sb = new();
        MatchCollection matches = Regex.Matches(molecule, source);
        foreach (Match match in matches)
        {
            foreach (string target in targets)
            {
                _ = sb.Clear();
                ReadOnlySpan<char> start = molecule.AsSpan()[0..match.Index];
                ReadOnlySpan<char> end = molecule.AsSpan()[(match.Index + match.Length)..];
                _ = sb.Append(start);
                _ = sb.Append(target);
                _ = sb.Append(end);
                yield return sb.ToString();
            }
        }
    }

    private static Dictionary<string, List<string>> ParseReplacements(IEnumerable<string> input)
    {
        return input.Select(Parse)
             .GroupBy(r => r.Source, r => r.Target)
             .ToDictionary(g => g.Key, g => g.ToList());
    }
    public static (string Source, string Target) Parse(string input)
    {
        Match replacementMatch = Regex.Match(input, @"(\w+) => (\w+)");
        if (!replacementMatch.Success)
        {
            throw new InvalidOperationException();
        }
        string source = replacementMatch.Groups[1].Value;
        string target = replacementMatch.Groups[2].Value;
        return (source, target);
    }
    public override long SolvePart2()
    {
        Dictionary<string, string> replacementDictionary = ParseInverseReplacements(Input[0..^2]);
        Dictionary<string, long> gScore = new() { { Input[^1], 0 } };
        Dictionary<string, long> fScore = new() { { Input[^1], Input[^1].Length } };

        PriorityQueue<string, long> queue = new();
        queue.Enqueue(Input[^1], 0);
        while (queue.TryDequeue(out string? molecule, out _) && molecule is not null)
        {
            long currentGScore = gScore[molecule];
            if (molecule == "e")
            {
                return currentGScore;
            }
            foreach ((string? source, string? target) in replacementDictionary)
            {
                if (target == "e" && molecule != source)
                {
                    continue;
                }
                IEnumerable<string> neighbours = Create(molecule, source, [target]);
                foreach (string neighbour in neighbours)
                {
                    long tentativeGScore = currentGScore + 1;
                    if (!gScore.TryGetValue(neighbour, out long existingGScore) || tentativeGScore < existingGScore)
                    {
                        gScore[neighbour] = tentativeGScore;
                        long newFScore = tentativeGScore + neighbour.Length;
                        fScore[neighbour] = newFScore;
                        queue.Enqueue(neighbour, newFScore);
                    }
                }

            }
        }
        throw new InvalidOperationException();
    }

    private static Dictionary<string, string> ParseInverseReplacements(IEnumerable<string> input)
    {
        return input.Select(Parse)
             .ToDictionary(g => g.Target, g => g.Source);
    }
}
