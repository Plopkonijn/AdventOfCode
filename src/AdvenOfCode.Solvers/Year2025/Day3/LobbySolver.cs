
namespace AdvenOfCode.Solvers.Year2025.Day3;

public sealed class LobbySolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            int firstIndex = 0;
            int i = 1;
            while (i < line.Length - 1)
            {
                if (line[firstIndex] < line[i])
                {
                    firstIndex = i;
                }
                i++;
            }
            int secondIndex = firstIndex + 1;
            i = secondIndex + 1;
            while (i < line.Length)
            {
                if (line[secondIndex] < line[i])
                {
                    secondIndex = i;
                }
                i++;
            }
            long joltage = (10 * (line[firstIndex] - '0')) + (line[secondIndex] - '0');
            result += joltage;
        }
        return result;
    }

    public override long SolvePart2()
    {
        long result = 0;
        foreach (string line in Input)
        {
            long joltage = CalculateJoltage(line, 12);
            result += joltage;
        }
        return result;
    }

    private static long CalculateJoltage(ReadOnlySpan<char> line, int size)
    {
        if (size == 0)
        {
            return 0;
        }
        char max = line[0];
        int maxIndex = 0;
        for (int i = 0; i <= line.Length - size; i++)
        {
            char c = line[i];
            if (max < c)
            {
                max = c;
                maxIndex = i;
            }
        }
        ReadOnlySpan<char> newLine = line[(maxIndex + 1)..];
        long result = (max - '0') * (long)Math.Pow(10, size - 1);
        result += CalculateJoltage(newLine, size - 1);
        return result;
    }
}
