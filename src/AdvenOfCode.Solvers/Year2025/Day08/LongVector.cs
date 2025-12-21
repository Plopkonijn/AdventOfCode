
namespace AdvenOfCode.Solvers.Year2025.Day08;

internal sealed record LongVector(long X, long Y, long Z)
{
    public long GetLengthSquared()
    {
        return (X * X) + (Y * Y) + (Z * Z);
    }

    public static long DistanceSquared(LongVector a, LongVector b)
    {
        return (a - b).GetLengthSquared();
    }

    internal static LongVector Max(LongVector a, LongVector b)
    {
        return new LongVector(long.Max(a.X, b.X), long.Max(a.Y, b.Y), long.Max(a.Z, b.Z));
    }

    public static LongVector operator -(LongVector a, LongVector b)
    {
        return new LongVector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

}