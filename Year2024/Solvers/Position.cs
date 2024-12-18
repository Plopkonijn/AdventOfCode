using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Year2024.Solvers;

public partial record struct Position(int X, int Y) : IParsable<Position>
{
    public static Position Parse(string s, IFormatProvider? provider)
    {
        if (!TryParse(s, provider, out Position result))
        {
            throw new FormatException();
        }

        return result;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Position result)
    {
        if (s is null || PositionRegex().Match(s) is not { Success: true } match)
        {
            result = default;
            return false;
        }

        result = new Position(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
        return true;
    }

    public static Position operator +(Position a, Direction b)
    {
        return new(a.X + b.DX, a.Y + b.DY);
    }

    [GeneratedRegex(@"(\d+),(\d+)")]
    private static partial Regex PositionRegex();
}
