using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day09;

public sealed class AllInASingleNightSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        HashSet<string> places = [];
        Dictionary<(string, string), long> distances = [];
        foreach (string line in Input)
        {
            Match match = Regex.Match(line, @"(\w+) to (\w+) = (\d+)");
            if (!match.Success)
            {
                throw new InvalidOperationException();
            }
            string source = match.Groups[1].Value;
            string target = match.Groups[2].Value;
            long distance = long.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
            distances.Add((source, target), distance);
            _ = places.Add(source);
            _ = places.Add(target);
        }


        Stack<Node> stack = new();
        foreach (string place in places)
        {
            stack.Push(new Node(place, 0, 1));
        }

        long bestDistance = long.MaxValue;
        while (stack.TryPop(out Node? currentNode))
        {
            if (currentNode.TotalDistance > bestDistance)
            {
                continue;
            }
            if (currentNode.Length == places.Count)
            {
                if (currentNode.TotalDistance < bestDistance)
                {
                    bestDistance = currentNode.TotalDistance;
                }
                continue;
            }

            foreach (string? place in places.Except(currentNode.GetRoute()))
            {
                if (!distances.TryGetValue((currentNode.Name, place), out long distance))
                {
                    distance = distances[(place, currentNode.Name)];
                }
                Node newNode = new(place, currentNode.TotalDistance + distance, currentNode.Length + 1, currentNode);
                stack.Push(newNode);
            }
        }
        return bestDistance;
    }



    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}

internal sealed record Node(string Name, long TotalDistance, long Length = 0, Node? Previous = null)
{
    public IEnumerable<string> GetRoute()
    {
        for (Node? node = this; node != null; node = node.Previous)
        {
            yield return node.Name;
        }
    }
}
