using System.Globalization;

namespace AdvenOfCode.Solvers.Year2015.Day20;

public sealed class InfiniteElvesAndInfiniteHousesSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long targetPresentCount = long.Parse(Input[0], CultureInfo.InvariantCulture);
        for (long house = 1; ; house++)
        {
            long presentCount = 0;
            for (long d = 1; d <= (long)Math.Sqrt(house); d++)
            {
                if (house % d != 0)
                {
                    continue;
                }
                presentCount += d;
                long dd = house / d;
                if (dd != d)
                {
                    presentCount += dd;
                }
            }
            presentCount *= 10;
            if (presentCount >= targetPresentCount)
            {
                return house;
            }
        }
    }

    public override long SolvePart2()
    {
        long targetPresentCount = long.Parse(Input[0], CultureInfo.InvariantCulture);
        for (long house = 1; ; house++)
        {
            long presentCount = 0;
            for (long d = 1; d <= (long)Math.Sqrt(house); d++)
            {
                if (house % d != 0)
                {
                    continue;
                }
                long dd = house / d;
                if (dd < 50)
                {
                    presentCount += d;
                }
                if (dd != d && d < 50)
                {
                    presentCount += dd;
                }
            }
            presentCount *= 11;
            if (presentCount >= targetPresentCount)
            {
                return house;
            }
        }
    }
}