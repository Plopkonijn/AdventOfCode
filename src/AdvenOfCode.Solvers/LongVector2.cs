using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace AdvenOfCode.Solvers;

internal record struct LongVector2(long X, long Y) :
    IAdditionOperators<LongVector2, LongVector2, LongVector2>,
    IMultiplyOperators<LongVector2, long, LongVector2>
{
    [Pure]
    public readonly long TaxicabDistance(LongVector2 other)
    {
        return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LongVector2 operator +(LongVector2 left, LongVector2 right)
    {
        return new LongVector2(left.X + right.X, left.Y + right.Y);
    }

    public static LongVector2 operator *(LongVector2 vector, long scalar)
    {
        return new LongVector2(vector.X * scalar, vector.Y * scalar);
    }
}



