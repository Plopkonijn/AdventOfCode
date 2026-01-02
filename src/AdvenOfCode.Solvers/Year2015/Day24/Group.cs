namespace AdvenOfCode.Solvers.Year2015.Day24;

internal record struct Group(long Weight, long Size)
{
    public Group AddWeight(long weight)
    {
        return this with
        {
            Weight = Weight + weight,
            Size = Size + 1
        };
    }
}
