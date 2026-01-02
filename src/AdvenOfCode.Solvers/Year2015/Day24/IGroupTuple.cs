namespace AdvenOfCode.Solvers.Year2015.Day24;

internal interface IGroupTuple<TSelf> : IEnumerable<Group>
{
    static abstract int Length { get; }
    Group this[int index] { get; }

    TSelf AddWeight(int v1, long v2);
}
