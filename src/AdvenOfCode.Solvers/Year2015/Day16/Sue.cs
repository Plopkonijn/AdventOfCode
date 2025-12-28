
using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day16;

internal sealed record Sue(int Number, Dictionary<string, long> Properties)
{
    internal static Sue Parse(string line)
    {
        Match match = Regex.Match(line, @"Sue (?<sue>\d+):(?<property> (?<key>\w+): (?<value>\d+),?)+");
        if (!match.Success)
        {
            throw new InvalidOperationException();
        }

        int number = int.Parse(match.Groups["sue"].Value, CultureInfo.InvariantCulture);
        Dictionary<string, long> properties = match.Groups["property"].Captures.Index()
            .Select(t => t.Index)
            .ToDictionary(i => match.Groups["key"].Captures[i].Value,
            i => long.Parse(match.Groups["value"].Captures[i].Value, CultureInfo.InvariantCulture));
        return new Sue(number, properties);
    }
}