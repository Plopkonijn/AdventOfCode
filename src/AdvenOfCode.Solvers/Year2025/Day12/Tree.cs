using System.Collections.Immutable;
using System.Globalization;

namespace AdvenOfCode.Solvers.Year2025.Day12;

internal sealed class Tree
{
    public int Width { get; init; }
    public int Height { get; init; }
    public ImmutableArray<int> Quantities { get; init; }

    public Tree(int width, int height, int[] quantities)
    {
        Width = width;
        Height = height;
        Quantities = quantities.ToImmutableArray();
    }

    internal static Tree Parse(string line)
    {
        string[] split = line.Split(':');
        string[] dimensionsSplit = split[0].Split('x');
        string[] quantitiesSplit = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int width = int.Parse(dimensionsSplit[0], CultureInfo.InvariantCulture);
        int height = int.Parse(dimensionsSplit[1], CultureInfo.InvariantCulture);
        int[] quantities = quantitiesSplit.Select(s => int.Parse(s, CultureInfo.InvariantCulture)).ToArray();
        return new Tree(width, height, quantities);
    }
}
