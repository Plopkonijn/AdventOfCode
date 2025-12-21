using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2025.Day12;

public sealed class ChristmasTreeFarmSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        (List<Shape>? shapes, List<Tree>? trees) = ParseInput();
        long result = 0;
        foreach (Tree tree in trees)
        {
            int capacity = tree.Width * tree.Height;
            int needed = tree.Quantities.Index()
                .Sum(t => t.Item * shapes[t.Index].Form.Sum(row => row.Count(value => value)));
            if (capacity >= needed)
            {
                result++;
            }
        }
        return result;
    }

    private (List<Shape> shapes, List<Tree> trees) ParseInput()
    {
        Span<string> input = Input.AsSpan();
        List<Shape> shapes = [];
        List<Tree> trees = [];
        while (input.Length > 0)
        {
            string line = input[0];
            if (Regex.IsMatch(line, @"^\d+:$"))
            {
                Shape shape = Shape.Parse(ref input);
                shapes.Add(shape);
            }
            else if (Regex.IsMatch(line, @"^\d+x\d+:"))
            {
                Tree tree = Tree.Parse(line);
                trees.Add(tree);
            }
            else
            {
                throw new InvalidOperationException();
            }
            input = input[1..];
        }
        return (shapes, trees);
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}
