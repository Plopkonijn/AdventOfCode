
using System.Collections;

namespace AdvenOfCode.Solvers.Year2015.Day24;

internal record struct GroupTriplet(Group First, Group Second, Group Third) : IGroupTuple<GroupTriplet>
{
    public Group this[int index] => index switch
    {
        0 => First,
        1 => Second,
        2 => Third,
        _ => throw new ArgumentOutOfRangeException(nameof(index))
    };

    public static int Length => 3;

    public GroupTriplet AddWeight(int index, long weight)
    {
        return index switch
        {
            0 => this with { First = First.AddWeight(weight) },
            1 => this with { Second = Second.AddWeight(weight) },
            2 => this with { Third = Third.AddWeight(weight) },
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };
    }

    public IEnumerator<Group> GetEnumerator()
    {
        yield return First;
        yield return Second;
        yield return Third;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}