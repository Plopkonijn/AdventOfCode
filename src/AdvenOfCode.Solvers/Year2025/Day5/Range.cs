using System.Globalization;

namespace AdvenOfCode.Solvers.Year2025.Day5;

internal sealed record Range(long Min, long Max)
{
    public static Range Parse(string s)
    {
        string[] range = s.Split('-');
        long min = long.Parse(range[0], CultureInfo.InvariantCulture);
        long max = long.Parse(range[1], CultureInfo.InvariantCulture);
        return new Range(min, max);
    }

    public bool OverlapsWith(Range other)
    {
        return Min <= other.Max && other.Min <= Max;
    }

    public Range Merge(Range other)
    {
        long min = Min <= other.Min ? Min : other.Min;
        long max = Max >= other.Max ? Max : other.Max;
        return new Range(min, max);
    }


}