using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day13;

public sealed class KnightsOfTheDinnerTableSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        HashSet<string> people = [];
        Dictionary<(string, string), long> happinessDictionary = [];
        foreach (string line in Input)
        {
            Match match = Regex.Match(line, @"(\w+) would (gain|lose) (\d+) happiness units by sitting next to (\w+).");
            if (!match.Success)
            {
                throw new InvalidOperationException();
            }
            string source = match.Groups[1].Value;
            long hapiness = long.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
            hapiness = match.Groups[2].Value switch
            {
                "gain" => hapiness,
                "lose" => -hapiness,
                _ => throw new InvalidOperationException()
            };
            string target = match.Groups[4].Value;
            happinessDictionary.Add((source, target), hapiness);
            _ = people.Add(source);
            _ = people.Add(target);
        }

        Stack<Node> stack = new();
        foreach (string person in people)
        {
            stack.Push(new Node(person, 0, 1));
        }
        long bestHappiness = 0;
        while (stack.TryPop(out Node? currentNode))
        {
            if (currentNode.Length == people.Count)
            {
                string firstPerson = currentNode.GetRoute().Last();
                long totalHappiness = currentNode.TotalHappiness;
                totalHappiness += happinessDictionary[(firstPerson, currentNode.Name)];
                totalHappiness += happinessDictionary[(currentNode.Name, firstPerson)];
                if (totalHappiness > bestHappiness)
                {
                    bestHappiness = totalHappiness;
                }
                continue;
            }
            foreach (string? neighbour in people.Except(currentNode.GetRoute()))
            {
                long newHappiness = currentNode.TotalHappiness +
                    happinessDictionary[(currentNode.Name, neighbour)] +
                    happinessDictionary[(neighbour, currentNode.Name)];
                Node newNode = new(neighbour, newHappiness, currentNode.Length + 1, currentNode);
                stack.Push(newNode);
            }
        }
        return bestHappiness;
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}

internal sealed record Node(string Name, long TotalHappiness, long Length = 0, Node? Previous = null)
{
    public IEnumerable<string> GetRoute()
    {

        for (Node? node = this; node != null; node = node.Previous)
        {
            yield return node.Name;
        }
    }
}
