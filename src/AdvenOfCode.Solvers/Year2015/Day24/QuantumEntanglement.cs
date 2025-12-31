namespace AdvenOfCode.Solvers.Year2015.Day24;

public sealed partial class ItHangsInTheBalanceSolver
{
    internal record struct QuantumEntanglement(long Value, int Size) : IComparable<QuantumEntanglement>
    {
        public int CompareTo(QuantumEntanglement other)
        {
            int sizeComparison = Size.CompareTo(other.Size);
            if (sizeComparison != 0)
            {
                return sizeComparison;
            }
            return Value.CompareTo(other.Value);
        }

        internal QuantumEntanglement AddWeight(long weight)
        {
            return this with
            {
                Value = Value * weight,
                Size = Size + 1
            };
        }
    }
}