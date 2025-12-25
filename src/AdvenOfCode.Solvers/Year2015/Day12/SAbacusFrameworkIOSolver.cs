using System.Globalization;
using System.Text.Json;

namespace AdvenOfCode.Solvers.Year2015.Day12;

public sealed class SAbacusFrameworkIOSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            result += SumNumbers(line);
        }
        return result;
    }

    private static long SumNumbers(ReadOnlySpan<char> line)
    {
        long result = 0;
        while (line.Length > 0)
        {
            if (line[0] != '-' && !char.IsDigit(line[0]))
            {
                line = line[1..];
                continue;
            }
            int nonDigitIndex = 1;
            while (line.Length > 0 && char.IsDigit(line[nonDigitIndex]))
            {
                nonDigitIndex++;
            }
            ReadOnlySpan<char> digit = line[0..nonDigitIndex];
            result += long.Parse(digit, CultureInfo.InvariantCulture);
            line = line[nonDigitIndex..];
        }
        return result;
    }

    public override long SolvePart2()
    {
        long result = 0;
        foreach (string line in Input)
        {
            result += SumNonRedNumbers(line);
        }
        return result;
    }

    private static long SumNonRedNumbers(string line)
    {
        JsonDocument json = JsonDocument.Parse(line);
        return SumNonRedNumbers(json.RootElement);
    }

    private static long SumNonRedNumbers(JsonElement json)
    {
        return json.ValueKind switch
        {
            JsonValueKind.Object => HasRedProperty(json) ? 0 : json.EnumerateObject().Select(p => p.Value).Sum(SumNonRedNumbers),
            JsonValueKind.Array => json.EnumerateArray().Sum(SumNonRedNumbers),
            JsonValueKind.Number => json.GetInt64(),
            JsonValueKind.String or JsonValueKind.True or JsonValueKind.False or JsonValueKind.Null => 0,
            _ => throw new InvalidOperationException(),
        };
    }

    private static bool HasRedProperty(JsonElement json)
    {
        return json.EnumerateObject()
            .Any(p => p.Value is { ValueKind: JsonValueKind.String } stringElement &&
                    (stringElement.GetString()?.Contains("red", StringComparison.OrdinalIgnoreCase) ?? false));
    }
}