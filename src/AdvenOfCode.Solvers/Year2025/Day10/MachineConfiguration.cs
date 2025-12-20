using System.Collections.Immutable;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2025.Day10;

internal sealed class MachineConfiguration
{
    public int Diagram { get; init; }
    public ImmutableArray<int> Wirings { get; init; }
    public MachineConfiguration(int diagram, ImmutableArray<int> wirings)
    {
        Diagram = diagram;
        Wirings = wirings;
    }

    public static MachineConfiguration Parse(string input)
    {
        Match diagramMatch = Regex.Match(input, @"(\.|#)+");
        if (!diagramMatch.Success)
        {
            throw new ArgumentException("Could not parse diagram");
        }
        int diagram = 0;
        foreach ((int i, char c) in diagramMatch.Value.Index())
        {
            diagram |= c switch
            {
                '.' => 0,
                '#' => 1 << i,
                _ => throw new InvalidOperationException()
            };
        }

        MatchCollection wiringsMatches = Regex.Matches(input, @"\((\d+,)*\d+\)");
        if (wiringsMatches.Count == 0)
        {
            throw new ArgumentException("Could not parse wirings");
        }
        ImmutableArray<int> wirings = wiringsMatches.Select(m => m.Value[1..^1])
            .Select(s => s.Split(',')
                          .Select(c => int.Parse(c, CultureInfo.InvariantCulture))
                          .Aggregate(0, (wiring, button) => wiring |= 1 << button)
                          )
            .ToImmutableArray();
        return new MachineConfiguration(diagram, wirings);
    }
}
