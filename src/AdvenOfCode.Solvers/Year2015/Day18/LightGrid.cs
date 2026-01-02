using System.Collections;
using System.Text;

namespace AdvenOfCode.Solvers.Year2015.Day18;

internal sealed class LightGrid(int width, int height)
{
    public int Width { get; init; } = width;
    public int Height { get; init; } = height;
    private readonly BitArray _lights = new(width * width);
    public bool this[int x, int y]
    {
        get => _lights[x + (Width * y)];
        set => _lights[x + (Width * y)] = value;
    }
    internal long LitLightCount()
    {
        return _lights.OfType<bool>().Count(b => b);
    }

    internal int TurnedOnNeighbours(int x, int y)
    {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++)
        {
            if (i < 0 || i >= Width)
            {
                continue;
            }
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (j < 0 || j >= Height)
                {
                    continue;
                }
                if (i == x && j == y)
                {
                    continue;
                }
                if (IsOn(i, j))
                {
                    count++;
                }
            }
        }
        return count;
    }

    internal bool IsOn(int x, int y)
    {
        return _lights[x + (Width * y)];
    }

    internal void TurnOn(int x, int y)
    {
        _lights[x + (Width * y)] = true;
    }

    internal void TurnOff(int x, int y)
    {
        _lights[x + (Width * y)] = false;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (IsOn(x, y))
                {
                    _ = sb.Append('#');
                }
                else
                {
                    _ = sb.Append('.');
                }
            }
            _ = sb.Append('|');
        }
        return sb.ToString();
    }
}