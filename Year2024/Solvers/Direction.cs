
namespace Year2024.Solvers;

internal record struct Direction(int DX, int DY)
{
    internal Direction TurnClockWise()
    {
        return new Direction(-DY, DX);
    }

    public static implicit operator Direction((int DX, int DY) direction)
    {
        return new Direction(direction.DX, direction.DY);
    }
}