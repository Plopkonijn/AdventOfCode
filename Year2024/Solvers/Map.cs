
namespace Year2024.Solvers;

internal class Map
{
    private readonly string[] _input;

    public Map(string[] input)
    {
        _input = input;
    }

    public char this[Position position] => _input[position.Y][position.X];

    internal Position FindPositionOf(char v)
    {
        for (int y = 0; y < _input.Length; y++)
        {
            for (int x = 0; x < _input[y].Length; x++)
            {
                if (_input[y][x] == v)
                {
                    return new Position(x, y);
                }
            }
        }

        throw new ArgumentException("Character not found", nameof(v));
    }

    internal bool IsOutOfBounds(Position position)
    {
        return position.Y < 0
            || position.Y >= _input.Length
            || position.X < 0
            || position.X >= _input[position.Y].Length;
    }
}
