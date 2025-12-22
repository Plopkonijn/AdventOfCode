namespace AdvenOfCode.Solvers.Year2025.Day09;

internal record struct Edge(Tile Start, Tile End)
{
    public readonly long MinX => Start.X <= End.X ? Start.X : End.X;
    public readonly long MaxX = Start.X >= End.X ? Start.X : End.X;
    public readonly long MinY => Start.Y <= End.Y ? Start.Y : End.Y;
    public readonly long MaxY = Start.Y >= End.Y ? Start.Y : End.Y;

}
