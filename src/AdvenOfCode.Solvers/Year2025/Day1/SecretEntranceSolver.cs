
using System.Data;
using System.Globalization;

namespace AdvenOfCode.Solvers.Year2025.Day1;

public static class SecretEntranceSolver
{
    private const int dialStartValue = 50;
    private const int dialMaxValue = 100;


    public static int SolvePart1(string[] input)
    {
        return input.Select(ParseLine)
                    .Aggregate(seed: (dialValue: dialStartValue, result: 0), TurnPart1)
                    .result;
    }

    public static int SolvePart2(string[] input)
    {
        return input.Select(ParseLine)
                    .Aggregate(seed: (dialValue: dialStartValue, result: 0), TurnPart2)
                    .result;

    }
    private static (int dialValue, int result) TurnPart2((int dialValue, int result) t, int distance)
    {
        return distance switch
        {
            0 => t,
            < 0 => TurnLeft(t, -distance),
            > 0 => TurnRight(t, distance)
        };
    }

    private static (int dialValue, int result) TurnLeft((int dialValue, int result) t, int distance)
    {
        int newResult = t.result + (distance / dialMaxValue);
        distance %= dialMaxValue;
        int newValue = t.dialValue - distance;
        if (newValue < 0)
        {
            newValue += dialMaxValue;
            if (t.dialValue != 0)
            {
                newResult++;
            }
        }
        if (newValue == 0 && t.dialValue != 0)
        {
            newResult++;
        }
        return (newValue, newResult);
    }

    private static (int dialValue, int result) TurnRight((int dialValue, int result) t, int distance)
    {
        int newResult = t.result + (distance / dialMaxValue);
        distance %= dialMaxValue;
        int newValue = t.dialValue + distance;
        if (newValue >= dialMaxValue)
        {
            newValue -= dialMaxValue;
            if (t.dialValue != 0)
            {
                newResult++;
            }
        }
        return (newValue, newResult);
    }


    private static (int dialValue, int result) TurnPart1((int dialValue, int result) t, int distance)
    {
        int newValue = (t.dialValue + distance + 100) % 100;
        int newResult = t.result + (newValue == 0 ? 1 : 0);
        return (newValue, newResult);
    }

    private static int ParseLine(string line)
    {
        int distance = int.Parse(line[1..], CultureInfo.InvariantCulture);
        return line[0] is 'L' ? -distance : distance;
    }


}




