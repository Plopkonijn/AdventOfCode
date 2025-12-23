using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day06;

public sealed class ProbablyAFireHazardSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        BinaryLightGrid lightGrid = new();
        foreach (string line in Input)
        {
            (Instruction instruction, IntLocation start, IntLocation end) = ParseInstruction(line);
            switch (instruction)
            {
                case Instruction.TurnOn:
                    lightGrid.TurnOn(start, end);
                    break;
                case Instruction.Toggle:
                    lightGrid.Toggle(start, end);
                    break;
                case Instruction.TurnOff:
                    lightGrid.TurnOff(start, end);
                    break;
            }

        }

        return lightGrid.LitLightCount();
    }


    private static (Instruction, IntLocation, IntLocation) ParseInstruction(string line)
    {
        Match match = Regex.Match(line, @"(?<instruction>.*) (?<startX>\d+),(?<startY>\d+) .* (?<endX>\d+),(?<endY>\d+)");
        if (!match.Success)
        {
            throw new InvalidOperationException();
        }
        Instruction instruction = match.Groups["instruction"].Value switch
        {
            "turn on" => Instruction.TurnOn,
            "toggle" => Instruction.Toggle,
            "turn off" => Instruction.TurnOff,
            _ => throw new InvalidOperationException()
        };
        int startX = int.Parse(match.Groups["startX"].Value, CultureInfo.InvariantCulture);
        int startY = int.Parse(match.Groups["startY"].Value, CultureInfo.InvariantCulture);
        IntLocation start = new(startX, startY);
        int endX = int.Parse(match.Groups["endX"].Value, CultureInfo.InvariantCulture);
        int endY = int.Parse(match.Groups["endY"].Value, CultureInfo.InvariantCulture);
        IntLocation end = new(endX, endY);
        return (instruction, start, end);
    }

    public override long SolvePart2()
    {
        BrightnessLightGrid lightGrid = new();
        foreach (string line in Input)
        {
            (Instruction instruction, IntLocation start, IntLocation end) = ParseInstruction(line);
            switch (instruction)
            {
                case Instruction.TurnOn:
                    lightGrid.TurnOn(start, end);
                    break;
                case Instruction.Toggle:
                    lightGrid.Toggle(start, end);
                    break;
                case Instruction.TurnOff:
                    lightGrid.TurnOff(start, end);
                    break;
            }

        }

        return lightGrid.GetTotalBrightness();
    }
}
