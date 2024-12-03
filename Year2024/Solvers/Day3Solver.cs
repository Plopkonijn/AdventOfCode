using System.Text.RegularExpressions;

public sealed class Day3Solver : AdventOfCodeSolver
{
    public Day3Solver(string[] input) : base(input)
    {
    }

    public override long SolvePart1(string[] input)
    {
        long total = 0;
        foreach (string line in input)
        {
            MatchCollection matches = Regex.Matches(line, @"mul\((?<first>\d{1,3}),(?<second>\d{1,3})\)");
            foreach (Match match in matches.OfType<Match>())
            {
                long firstOperand = long.Parse(match.Groups["first"].Value);
                long secondOperand = long.Parse(match.Groups["second"].Value);
                total += firstOperand * secondOperand;
            }
        }

        return total;
    }

    public override long SolvePart2(string[] input)
    {
        long total = 0;
        bool mulEnabled = true;
        foreach (string line in input)
        {
            MatchCollection matches = Regex.Matches(line, @"(?<mul>mul\((?<first>\d{1,3}),(?<second>\d{1,3})\))|(?<do>do\(\))|(?<dont>don\'t\(\))");
            foreach (Match match in matches.OfType<Match>())
            {
                if (match.Groups.TryGetValue("do", out Group? doValue) && doValue.Success)
                {
                    mulEnabled = true;
                }
                else if (match.Groups.TryGetValue("dont", out Group? dontValue) && dontValue.Success)
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
}