using System.Text.RegularExpressions;

namespace Year2024.Solvers;

public sealed class Day5Solver(string[] input) : AdventOfCodeSolver(input)
{
    public override long SolvePart1()
    {
        long total = 0;
        var (orderingRules, updates) = ParseInput();
        foreach (List<int> update in updates)
        {
            if (!IsValidUpdate(update, orderingRules))
            {
                continue;
            }

            total += update[(update.Count - 1) / 2];
        }

        return total;
    }

    private static bool IsValidUpdate(List<int> update, List<(long before, long after)> orderingRules)
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

    private (List<(long before, long after)>, List<List<int>> updates) ParseInput()
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

        List<List<int>> updates = new();
        while (i < _input.Length)
        {
            string line = _input[i];
            MatchCollection pageMatches = Regex.Matches(line, @"\d+");
            List<int> update = pageMatches.Select(m => int.Parse(m.Value)).ToList();
            updates.Add(update);
            i++;
        }

        return (orderingRules, updates);
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}