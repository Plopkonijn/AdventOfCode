using System.Text;

namespace AdvenOfCode.Solvers.Year2016.Day02;

public sealed class BathroomSecuritySolver(string[] Input)
{
    public long SolvePart1()
    {
        long result = 0;
        int x = 1;
        int y = 1;
        foreach (string line in Input)
        {
            result *= 10;
            FindNextPositionSimple(ref x, ref y, line);
            result += GetDigitSimple(x, y);
        }
        return result;
    }

    private static long GetDigitSimple(int x, int y)
    {
        return 1 + x + (3 * y);
    }

    private static void FindNextPositionSimple(ref int x, ref int y, string line)
    {
        foreach (char c in line)
        {
            switch (c)
            {
                case 'U':
                    if (y > 0)
                    {
                        y--;
                    }
                    break;
                case 'D':
                    if (y < 2)
                    {
                        y++;
                    }
                    break;
                case 'L':
                    if (x > 0)
                    {
                        x--;
                    }
                    break;
                case 'R':
                    if (x < 2)
                    {
                        x++;
                    }

                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    public string SolvePart2()
    {
        StringBuilder result = new();
        int x = 0;
        int y = 2;
        foreach (string line in Input)
        {
            FindNextPositionComplex(ref x, ref y, line);
            char digit = GetDigitComplex(x, y);
            _ = result.Append(digit);
        }
        return result.ToString();
    }


    private static void FindNextPositionComplex(ref int x, ref int y, string line)
    {
        foreach (char c in line)
        {
            switch (c)
            {
                case 'U':
                    if (Math.Abs(x - 2) + Math.Abs(y - 2 - 1) <= 2)
                    {
                        y--;
                    }
                    break;
                case 'D':
                    if (Math.Abs(x - 2) + Math.Abs(y - 2 + 1) <= 2)
                    {
                        y++;
                    }
                    break;
                case 'L':
                    if (Math.Abs(x - 2 - 1) + Math.Abs(y - 2) <= 2)
                    {
                        x--;
                    }
                    break;
                case 'R':
                    if (Math.Abs(x - 2 + 1) + Math.Abs(y - 2) <= 2)
                    {
                        x++;
                    }

                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    private static char GetDigitComplex(int x, int y)
    {
        return y switch
        {
            0 => "1"[x - 2],
            1 => "234"[x - 1],
            2 => "56789"[x],
            3 => "ABC"[x - 1],
            4 => "D"[x - 2],
            _ => throw new InvalidOperationException(),
        };
    }
}