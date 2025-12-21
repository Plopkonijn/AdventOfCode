namespace AdvenOfCode.Solvers.Year2025.Day10;

internal sealed class Joltage : IEquatable<Joltage>
{
    public int Length => Values.Length;
    public int[] Values { get; private set; }
    public Joltage(int[] values)
    {
        Values = values;
    }

    public bool Equals(Joltage? other)
    {
        return other is not null &&
               other.Values.SequenceEqual(Values);
    }

    public override bool Equals(object? obj)
    {
        return obj is Joltage other &&
            Equals(other);
    }

    public override int GetHashCode()
    {
        return Values.Aggregate(HashCode.Combine);
    }

    internal Joltage Press(int wiring)
    {
        int[] values = Values.ToArray();
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

    internal bool IsValid => Values.All(i => i >= 0);
    internal bool IsZero => Values.All(i => i == 0);
}
