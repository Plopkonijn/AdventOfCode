using System.Globalization;

namespace AdvenOfCode.Solvers.Year2025.Day8;

public sealed class PlaygroundSolver(string[] input)
{
    private string[] Input { get; } = input;

    public long SolvePart1(int iterations)
    {
        LongVector[] boxes = Input.Select(line => line.Split(',').Select(s => long.Parse(s, CultureInfo.InvariantCulture)).ToArray())
            .Select(split => new LongVector(split[0], split[1], split[2]))
            .ToArray();
        IEnumerable<((LongVector b1, LongVector b2) t, long)> items = boxes.SelectMany(b1 => boxes.TakeWhile(b2 => !ReferenceEquals(b1, b2)).Select(b2 => (b1, b2)))
            .Select(t => (t, LongVector.DistanceSquared(t.b1, t.b2)));
        PriorityQueue<(LongVector, LongVector), long> queue = new(items);
        Dictionary<LongVector, DisjointSet> pairs = new(1000);
        for (int i = 0; i < iterations && queue.TryDequeue(out (LongVector, LongVector) pair, out _); i++)
        {
            if (!pairs.TryGetValue(pair.Item1, out DisjointSet? boxes1))
            {
                boxes1 = new();
                pairs.Add(pair.Item1, boxes1);
            }

            if (!pairs.TryGetValue(pair.Item2, out DisjointSet? boxes2))
            {
                boxes2 = new();
                pairs.Add(pair.Item2, boxes2);
            }

            boxes1.Union(boxes2);
        }
        List<long> groups = pairs.Values.GroupBy(s => s.Find())
            .Select(g => g.LongCount()).ToList();
        return groups
            .OrderDescending()
            .Take(3)
            .Aggregate((x, y) => x * y);
    }

    public long SolvePart2()
    {
        LongVector[] boxes = Input.Select(line => line.Split(',').Select(s => long.Parse(s, CultureInfo.InvariantCulture)).ToArray())
            .Select(split => new LongVector(split[0], split[1], split[2]))
            .ToArray();
        IEnumerable<((LongVector b1, LongVector b2) t, long)> items = boxes.SelectMany(b1 => boxes.TakeWhile(b2 => !ReferenceEquals(b1, b2)).Select(b2 => (b1, b2)))
            .Select(t => (t, LongVector.DistanceSquared(t.b1, t.b2)));
        PriorityQueue<(LongVector, LongVector), long> queue = new(items);
        Dictionary<LongVector, DisjointSet> pairs = new(1000);
        int size = 0;
        while (queue.TryDequeue(out (LongVector, LongVector) pair, out _))
        {
            if (!pairs.TryGetValue(pair.Item1, out DisjointSet? boxes1))
            {
                boxes1 = new();
                pairs.Add(pair.Item1, boxes1);
            }

            if (!pairs.TryGetValue(pair.Item2, out DisjointSet? boxes2))
            {
                boxes2 = new();
                pairs.Add(pair.Item2, boxes2);
            }

            boxes1.Union(boxes2);
            size = boxes1.Find().Size;
            if (size == boxes.Length)
            {
                return pair.Item1.X * pair.Item2.X;
            }
        }
        throw new InvalidOperationException();
    }
}