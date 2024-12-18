using System.Text.RegularExpressions;

namespace Year2024.Solvers;

public sealed partial class Day3Solver(string[] input) : DefaultAdventOfCodeSolver(input)
{
    public override long SolvePart1()
    {
        long total = 0;
        foreach (string line in _input)
        {
            MatchCollection matches = MulRegex().Matches(line);
            foreach (Match match in matches.OfType<Match>())
            {
                long firstOperand = long.Parse(match.Groups["first"].Value);
                long secondOperand = long.Parse(match.Groups["second"].Value);
                total += firstOperand * secondOperand;
            }
        }

        return total;
    }

    public override long SolvePart2()
    {
        long total = 0;
        bool mulEnabled = true;
        foreach (string line in _input)
        {
            MatchCollection matches = MulEnableDisableRegex().Matches(line);
            foreach (Match match in matches.OfType<Match>())
            {
                if (match.Groups.TryGetValue("enable", out Group? enableValue) && enableValue.Success)
                {
                    mulEnabled = true;
                }
                else if (match.Groups.TryGetValue("disable", out Group? disableValue) && disableValue.Success)
                {
                    mulEnabled = false;
                }
                else if (match.Groups.TryGetValue("mul", out Group? mulValue) && mulValue.Success && mulEnabled)
                {
                    long firstOperand = long.Parse(match.Groups["first"].Value);
                    long secondOperand = long.Parse(match.Groups["second"].Value);
                    total += firstOperand * secondOperand;
                }
            }
        }

        return total;
    }

    [GeneratedRegex(@"mul\((?<first>\d{1,3}),(?<second>\d{1,3})\)")]
    private static partial Regex MulRegex();
    [GeneratedRegex(@"(?<mul>mul\((?<first>\d{1,3}),(?<second>\d{1,3})\))|(?<enable>do\(\))|(?<disable>don\'t\(\))")]
    private static partial Regex MulEnableDisableRegex();
}