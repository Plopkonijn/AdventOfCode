
using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day16;

internal sealed record Sue(int Number, List<string> Properties)
{
    internal static Sue Parse(string line)
    {
        Match match = Regex.Match(line, @"Sue (?<sue>\d+):( (?<property>\w+: \d+),?)+");
        if (!match.Success)
        {
            throw new InvalidOperationException();
        }

        int number = int.Parse(match.Groups["sue"].Value, CultureInfo.InvariantCulture);
        List<string> properties = match.Groups["property"].Captures.Select(c => c.Value).ToList();
        return new Sue(number, properties);
    }
}