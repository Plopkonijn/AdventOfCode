namespace AdvenOfCode.Solvers.Year2015.Day02;

public sealed class IWasToldThereWouldBeNoMathSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            Box box = Box.Parse(line);
            result += WrappingPaperArea(box);
        }
        return result;
    }

    private static long WrappingPaperArea(Box box)
    {
        return TotalArea(box) + SmallesSideArea(box);
    }

    private static long TotalArea(Box box)
    {
        return 2 * ((box.Length * box.Width) + (box.Width * box.Height) + (box.Height * box.Length));
    }

    private static long SmallesSideArea(Box box)
    {
        long top = box.Length * box.Width;
        long front = box.Width * box.Height;
        long side = box.Height * box.Length;
        return Math.Min(Math.Min(top, front), side);
    }

    public override long SolvePart2()
    {
        long result = 0;
        foreach (string line in Input)
        {
            Box box = Box.Parse(line);
            result += TotalRibbonLength(box);
        }
        return result;
    }

    private static long TotalRibbonLength(Box box)
    {
        return SmallesRibbonLength(box) + BowLength(box);
    }

    private static long SmallesRibbonLength(Box box)
    {
        long top = box.Length + box.Width;
        long front = box.Width + box.Height;
        long side = box.Height + box.Length;
        return 2 * Math.Min(Math.Min(top, front), side);
    }

    private static long BowLength(Box box)
    {
        return box.Length * box.Width * box.Height;
    }
}
