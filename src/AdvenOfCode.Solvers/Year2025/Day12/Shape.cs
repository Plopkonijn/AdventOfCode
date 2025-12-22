using System.Collections.Immutable;
using System.Globalization;

namespace AdvenOfCode.Solvers.Year2025.Day12;

internal sealed class Shape
{
    public int Index { get; init; }
    public IReadOnlyList<ImmutableArray<bool>> Form { get; init; }
    public Shape(int index, IReadOnlyList<ImmutableArray<bool>> shape)
    {
        Index = index;
        Form = shape;
    }

    public int Width => Form.Max(row => row.Length);
    public int Height => Form.Count;

    internal static Shape Parse(ref Span<string> input)
    {
        int index = int.Parse(input[0][..^1], CultureInfo.InvariantCulture);
        input = input[1..];
        List<ImmutableArray<bool>> shape = [];
        while (input.Length > 0)
        {
            string line = input[0];
            if (!line.Any(c => c is '#' or '.'))
            {
                return new Shape(index, shape.AsReadOnly());
            }
            ImmutableArray<bool> row = line.Select(c => c is '#').ToImmutableArray();
            shape.Add(row);
            input = input[1..];
        }
        throw new InvalidOperationException();
    }
}