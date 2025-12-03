
using System.Globalization;

namespace AdvenOfCode.Solvers.Year2025.Day1;

public static class SecretEntranceSolver
{


    public static int SolvePart1(string[] input)
    {
        (int _, int result) = input.Select(PareLine)
                                  .Aggregate(seed: (dialValue: 50, result: 0), Turn);


        return result;
    }

    private static (int dialValue, int result) Turn((int dialValue, int result) t, int distance)
    {
        int newValue = (t.dialValue + distance + 100) % 100;
        return (newValue, t.result + (newValue == 0 ? 1 : 0));
    }

    private static int PareLine(string line)
    {
        int distance = int.Parse(line[1..], CultureInfo.InvariantCulture);
        return line[0] is 'L' ? -distance : distance;
    }


}


