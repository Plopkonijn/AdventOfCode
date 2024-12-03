using System.Text.RegularExpressions;

namespace Year2024.Solvers;

public sealed partial class Day1Solver(string[] input) : AdventOfCodeSolver(input)
{
    public override long SolvePart1(string[] input)
    {
        List<long> leftList = [];
        List<long> rightList = [];
        foreach (string line in input)
        {
            MatchCollection matches = NumberRegex().Matches(line); ;
            long leftValue = long.Parse(matches[0].Value);
            long rightValue = long.Parse(matches[1].Value);
            leftList.Add(leftValue);
            rightList.Add(rightValue);
        }

        leftList.Sort();
        rightList.Sort();
        return leftList.Zip(rightList, (left, right) => Math.Abs(left - right)).Sum();
    }

    public override long SolvePart2(string[] input)
    {
        List<long> unProcessedRightList = [];
        Dictionary<long, long> leftListOccurrences = [];
        foreach (string line in input)
        {
            MatchCollection matches = NumberRegex().Matches(line); ;
            long leftValue = long.Parse(matches[0].Value);
            _ = leftListOccurrences.TryAdd(leftValue, 0);
            long rightValue = long.Parse(matches[1].Value);
            if (leftListOccurrences.TryGetValue(rightValue, out long occurrences))
            {
                leftListOccurrences[rightValue] = occurrences + 1;
            }
            else
            {
                unProcessedRightList.Add(rightValue);
            }
        }

        foreach (long rightValue in unProcessedRightList)
        {
            if (leftListOccurrences.TryGetValue(rightValue, out long occurrences))
            {
                leftListOccurrences[rightValue] = occurrences + 1;
            }
        }

        return leftListOccurrences.Sum(kvp => kvp.Key * kvp.Value);
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();
}