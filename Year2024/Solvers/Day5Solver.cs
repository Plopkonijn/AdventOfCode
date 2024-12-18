using System.Text.RegularExpressions;

namespace Year2024.Solvers;

public sealed class Day5Solver(string[] input) : DefaultAdventOfCodeSolver(input)
{
    public override long SolvePart1()
    {
        long total = 0;
        var (orderingRules, updates) = ParseInput();
        foreach (List<long> update in updates)
        {
            if (!IsValidUpdate(update, orderingRules))
            {
                continue;
            }

            total += update[(update.Count - 1) / 2];
        }

        return total;
    }

    private static bool IsValidUpdate(List<long> update, List<(long before, long after)> orderingRules)
    {
        HashSet<long> visited = new();
        foreach (int page in update)
        {
            if (orderingRules.Any(rule => rule.before == page && visited.Contains(rule.after)))
            {
                return false;
            }

            visited.Add(page);
        }

        return true;
    }

    private (List<(long before, long after)>, List<List<long>> updates) ParseInput()
    {
        List<(long before, long after)> orderingRules = new();
        int i = 0;
        while (i < _input.Length)
        {
            string line = _input[i];
            Match orderingRuleMatch = Regex.Match(line, @"(?<before>\d+)\|(?<after>\d+)");
            if (!orderingRuleMatch.Success)
            {
                break;
            }

            long before = long.Parse(orderingRuleMatch.Groups["before"].Value);
            long after = long.Parse(orderingRuleMatch.Groups["after"].Value);
            orderingRules.Add((before, after));

            i++;
        }

        i++;

        List<List<long>> updates = new();
        while (i < _input.Length)
        {
            string line = _input[i];
            MatchCollection pageMatches = Regex.Matches(line, @"\d+");
            List<long> update = pageMatches.Select(m => long.Parse(m.Value)).ToList();
            updates.Add(update);
            i++;
        }

        return (orderingRules, updates);
    }

    public override long SolvePart2()
    {
        long total = 0;
        var (orderingRules, updates) = ParseInput();
        foreach (List<long> update in updates)
        {
            if (IsValidUpdate(update, orderingRules))
            {
                continue;
            }

            ReorderPages(update, orderingRules);
            total += update[(update.Count - 1) / 2];
        }

        return total;
    }

    private void ReorderPages(List<long> update, List<(long before, long after)> orderingRules)
    {
        Dictionary<long, int> pageIndices = update.Select((page, index) => (page, index)).ToDictionary(t => t.page, t => t.index);

        for (int i = 0; i < update.Count; i++)
        {
            long page = update[i];
            List<(long before, long after)> applicableRules = orderingRules.Where(rule => rule.before == page && pageIndices.ContainsKey(rule.after))
                                                                           .OrderByDescending(rule => pageIndices[rule.after])
                                                                           .ToList();
            int j = i;
            foreach ((long before, long after) in applicableRules)
            {
                if (!pageIndices.TryGetValue(after, out int k) || k > j)
                {
                    continue;
                }

                update[k] = before;
                pageIndices[before] = k;

                update[j] = after;
                pageIndices[after] = j;
                j = k;
            }
        }
    }
}