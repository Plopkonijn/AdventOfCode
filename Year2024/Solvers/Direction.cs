
namespace Year2024.Solvers;

public record struct Direction(int DX, int DY)
{
    internal readonly Direction TurnClockWise()
    {
        return new Direction(-DY, DX);
    }

    public static implicit operator Direction((int DX, int DY) direction)
    {
        return new Direction(direction.DX, direction.DY);
    }

    public static IEnumerable<Direction> All
    {
        get
        {
            yield return (0, -1);
            yield return (1, 0);
            yield return (0, 1);
            yield return (-1, 0);
        }
    }
}