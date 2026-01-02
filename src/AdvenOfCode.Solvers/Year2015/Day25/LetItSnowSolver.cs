using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day25;

public sealed partial class LetItSnowSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        MatchCollection matches = Regex.Matches(Input[0], @"\d+");
        if (matches.Count != 2)
        {
            throw new InvalidOperationException();
        }
        long targetRow = long.Parse(matches[0].Value, CultureInfo.InvariantCulture);
        long targetColumn = long.Parse(matches[1].Value, CultureInfo.InvariantCulture);
        long row = 1;
        long column = 1;
        long code = 20151125;
        while (row != targetRow || column != targetColumn)
        {
            Increment(ref row, ref column);
            code *= 252533;
            code %= 33554393;
        }
        return code;
    }

    private static void Increment(ref long row, ref long column)
    {
        if (row == 1)
        {
            row = column + 1;
            column = 1;
        }
        else
        {
            row--;
            column++;
        }
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}