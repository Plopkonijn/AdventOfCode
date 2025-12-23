using System.Globalization;

namespace AdvenOfCode.Solvers.Year2015.Day02;

internal sealed record Box(long Length, long Width, long Height)
{
    public static Box Parse(string input)
    {
        string[] split = input.Split('x');
        long length = long.Parse(split[0], CultureInfo.InvariantCulture);
        long width = long.Parse(split[1], CultureInfo.InvariantCulture);
        long height = long.Parse(split[2], CultureInfo.InvariantCulture);
        return new Box(length, width, height);
    }
}