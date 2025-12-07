using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2025.Day2;

public sealed partial class GiftShopSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        return Input.SelectMany(line => line.Split(','))
             .Select(line => line.Split('-').Select(id => long.Parse(id, CultureInfo.InvariantCulture)))
             .Select(range => (range.ElementAt(0), range.ElementAt(1)))
             .Select(CountInvalidIdsPart1)
             .Sum();
    }

    private static long CountInvalidIdsPart1((long min, long max) input)
    {
        long result = 0;
        for (long i = input.min; i <= input.max; i++)
        {
            Match match = Part1Regex().Match(i.ToString(CultureInfo.InvariantCulture));
            if (match.Success)
            {
                result += i;
            }
        }
        return result;
    }

    public override long SolvePart2()
    {
        return Input.SelectMany(line => line.Split(','))
             .Select(line => line.Split('-').Select(id => long.Parse(id, CultureInfo.InvariantCulture)))
             .Select(range => (range.ElementAt(0), range.ElementAt(1)))
             .Select(CountInvalidIdsPart2)
             .Sum();
    }

    private static long CountInvalidIdsPart2((long min, long max) input)
    {
        long result = 0;
        for (long i = input.min; i <= input.max; i++)
        {
            Match match = Part2Regex().Match(i.ToString(CultureInfo.InvariantCulture));
            if (match.Success)
            {
                result += i;
            }
        }
        return result;
    }

    [GeneratedRegex(@"^(\d+)\1$")]
    private static partial Regex Part1Regex();

    [GeneratedRegex(@"^(\d+)\1+$")]
    private static partial Regex Part2Regex();


}

