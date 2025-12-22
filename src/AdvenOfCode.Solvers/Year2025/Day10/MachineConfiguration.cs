using System.Collections.Specialized;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2025.Day10;

internal sealed class MachineConfiguration
{
    public BitVector32 Diagram { get; init; }
    public List<Button> Buttons { get; init; }
    public Joltage Joltage { get; init; }
    internal MachineConfiguration(BitVector32 diagram, List<Button> buttons, int[] joltage)
    {
        Diagram = diagram;
        Buttons = buttons;
        Joltage = new(joltage);
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

        MatchCollection buttonsMatch = Regex.Matches(input, @"\((\d+,)*\d+\)");
        if (buttonsMatch.Count == 0)
        {
            throw new ArgumentException("Could not parse wirings");
        }
        List<Button> buttons = buttonsMatch.Select(m => m.Value[1..^1])
            .Select(s => s.Split(',')
                          .Select(c => int.Parse(c, CultureInfo.InvariantCulture))
                          .Aggregate(0, (wiring, button) => wiring |= 1 << button)
                          )
            .Select(i => new Button(new(i)))
            .ToList();

        Match joltageMatch = Regex.Match(input, @"\{(\d+,)*\d+\}");
        int[] joltage = joltageMatch.Value[1..^1]
            .Split(",")
            .Select(c => int.Parse(c, CultureInfo.InvariantCulture))
            .ToArray();

        return new MachineConfiguration(new(diagram), buttons, joltage);
    }
}
