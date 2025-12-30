using System.Collections.Specialized;

namespace AdvenOfCode.Solvers.Year2015.Day24;

internal record struct Distribution(
    long FirstWeight,
    BitVector32 FirstIndices,
    long SecondWeight,
    BitVector32 SecondIndices,
    long ThirdWeight,
    BitVector32 ThirdIndices)
{
    internal readonly bool IsValid()
    {
        if (FirstWeight != SecondWeight || SecondWeight != ThirdWeight)
        {
            return false;
        }
        int size1 = GetSize(FirstIndices);
        int size2 = GetSize(SecondIndices);
        if (size1 > size2)
        {
            return false;
        }

        int size3 = GetSize(ThirdIndices);
        if (size1 > size3)
        {
            return false;
        }
        return true;
    }

    internal static int GetSize(BitVector32 indices)
    {
        int size = 0;
        for (int mask = indices.Data; mask != 0; mask &= mask - 1)
        {
            size++;
        }

        return size;
    }
}