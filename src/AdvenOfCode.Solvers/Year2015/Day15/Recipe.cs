namespace AdvenOfCode.Solvers.Year2015.Day15;

internal sealed class Recipe(int[] Amounts) : IEquatable<Recipe>
{
    public int[] Amounts { get; } = Amounts;

    public bool Equals(Recipe? other)
    {
        return other is not null && other.Amounts.SequenceEqual(Amounts);
    }

    public override bool Equals(object? obj)
    {
        return obj is Recipe other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Amounts.Aggregate(HashCode.Combine);
    }

    public override string ToString()
    {
        return string.Join(',', Amounts);
    }
}