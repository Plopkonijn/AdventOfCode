namespace Year2024.Solvers;

internal record struct Position(int X, int Y)
{
    public static Position operator +(Position a, Direction b)
    {
        return new(a.X + b.DX, a.Y + b.DY);
    }
}
