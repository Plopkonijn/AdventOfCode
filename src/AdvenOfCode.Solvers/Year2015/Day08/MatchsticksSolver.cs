namespace AdvenOfCode.Solvers.Year2015.Day08;

public sealed class MatchsticksSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            result += line.Length;
            result -= GetMemoryCount(line);
        }


        return result;
    }

    private static long GetMemoryCount(string input)
    {
        ReadOnlySpan<char> line = input;
        long result = 0;
        while (line.Length > 0)
        {
            char c = line[0];
            if (c == '\\')
            {
                if (line[1] is 'x' && char.IsAsciiHexDigit(line[2]) && char.IsAsciiHexDigit(line[3]))
                {
                    result++;
                    line = line[3..];
                }
                else if (line[1] is '\\' or '"')
                {
                    result++;
                    line = line[1..];
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else if (c != '"')
            {
                result++;
            }
            line = line[1..];
        }
        return result;
    }

    public override long SolvePart2()
    {
        long result = 0;
        foreach (string line in Input)
        {
            result += GetNewCount(line);
            result -= line.Length;
        }


        return result;
    }

    private static long GetNewCount(string input)
    {
        ReadOnlySpan<char> line = input;
        long result = 0;
        while (line.Length > 0)
        {
            char c = line[0];
            if (c == '\\')
            {
                if (line[1] is 'x' && char.IsAsciiHexDigit(line[2]) && char.IsAsciiHexDigit(line[3]))
                {
                    result += 5;
                    line = line[3..];
                }
                else if (line[1] is '\\' or '"')
                {
                    result += 4;
                    line = line[1..];
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else if (c == '"')
            {
                result += 3;
            }
            else
            {
                result++;
            }
            line = line[1..];
        }
        return result;
    }
}