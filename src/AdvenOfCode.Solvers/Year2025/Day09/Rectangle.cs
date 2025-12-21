namespace AdvenOfCode.Solvers.Year2025.Day09;

internal record struct Rectangle(Tile First, Tile Second)
{
    public readonly long MinX => First.X <= Second.X ? First.X : Second.X;
    public readonly long MaxX => First.X >= Second.X ? First.X : Second.X;
    public readonly long MinY => First.Y <= Second.Y ? First.Y : Second.Y;
    public readonly long MaxY => First.Y >= Second.Y ? First.Y : Second.Y;
    internal long CalculateArea()
    {
        long width = First.X - Second.X;
        width = width < 0 ? -width : width;
        width++;

        long height = First.Y - Second.Y;
        height = height < 0 ? -height : height;
        height++;
        return width * height;
    }
}