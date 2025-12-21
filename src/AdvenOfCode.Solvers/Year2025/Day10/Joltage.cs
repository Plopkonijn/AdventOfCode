namespace AdvenOfCode.Solvers.Year2025.Day10;

internal sealed class Joltage : IEquatable<Joltage>
{
    public int Length => _values.Length;
    private readonly int[] _values;
    public Joltage(int[] values)
    {
        _values = values;
    }

    public bool Equals(Joltage? other)
    {
        return other is not null &&
               other._values.SequenceEqual(_values);
    }

    public override bool Equals(object? obj)
    {
        return obj is Joltage other &&
            Equals(other);
    }

    public override int GetHashCode()
    {
        return _values.Aggregate(HashCode.Combine);
    }

    internal Joltage Press(int wiring)
    {
        int[] values = _values.ToArray();
        int i = 0;
        while (wiring > 0)
        {
            if ((wiring & 1) == 1)
            {
                values[i]--;
            }
            i++;
            wiring >>= 1;
        }
        return new Joltage(values);
    }

    internal bool IsValid => _values.All(i => i >= 0);
    internal bool IsZero => _values.All(i => i == 0);
}
