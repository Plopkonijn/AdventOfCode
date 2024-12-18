using System.Text.RegularExpressions;

namespace Year2024.Solvers;

public sealed partial class Day1Solver(string[] input) : DefaultAdventOfCodeSolver(input)
{
    public override long SolvePart1()
    {
        List<long> leftList = [];
        List<long> rightList = [];
        foreach (string line in _input)
        {
            MatchCollection matches = AdventOfCodeUtilities.NumberRegex().Matches(line); ;
            long leftValue = long.Parse(matches[0].Value);
            long rightValue = long.Parse(matches[1].Value);
            leftList.Add(leftValue);
            rightList.Add(rightValue);
        }

        leftList.Sort();
        rightList.Sort();
        return leftList.Zip(rightList, (left, right) => Math.Abs(left - right)).Sum();
    }

    public override long SolvePart2()
    {
        List<long> leftList = [];
        List<long> rightList = [];
        foreach (string line in _input)
        {
            MatchCollection matches = AdventOfCodeUtilities.NumberRegex().Matches(line); ;
            long leftValue = long.Parse(matches[0].Value);
            long rightValue = long.Parse(matches[1].Value);
            leftList.Add(leftValue);
            rightList.Add(rightValue);
        }

        long total = 0;
        Dictionary<long, long> leftOccurrenceValues = [];
        foreach (long leftValue in leftList)
        {
            if (!leftOccurrenceValues.TryGetValue(leftValue, out long occurrenceValue))
            {
                occurrenceValue = leftValue * rightList.Count(rightValue => rightValue == leftValue);
                leftOccurrenceValues[leftValue] = occurrenceValue;
            }

            total += occurrenceValue;
        }

        return total;
    }
}