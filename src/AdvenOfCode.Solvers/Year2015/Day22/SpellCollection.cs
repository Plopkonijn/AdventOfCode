namespace AdvenOfCode.Solvers.Year2015.Day22;

internal sealed class SpellCollection : List<Spell>
{
    public SpellCollection()
    {
    }

    public SpellCollection(IEnumerable<Spell> collection) : base(collection)
    {
    }

    public SpellCollection(int capacity) : base(capacity)
    {
    }

    public override bool Equals(object? obj)
    {
        return obj is SpellCollection other
            && this.SequenceEqual(other);
    }

    public override int GetHashCode()
    {
        return this.Aggregate(0, HashCode.Combine);
    }
}
