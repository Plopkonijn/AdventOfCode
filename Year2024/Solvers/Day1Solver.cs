using System.Text.RegularExpressions;

public sealed class Day1Solver : AdventOfCodeSolver
{
    public Day1Solver(string[] input) : base(input) { }

    public override long SolvePart1(string[] input)
    {
        List<long> leftList = [];
        List<long> rightList = [];
        foreach (string line in input)
        {
            MatchCollection matches = Regex.Matches(line, @"\d+"); ;
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
        Dictionary<long, long> leftListOccurences = [];
        foreach (string line in input)
        {
            MatchCollection matches = Regex.Matches(line, @"\d+"); ;
            long leftValue = long.Parse(matches[0].Value);
            _ = leftListOccurences.TryAdd(leftValue, 0);
            long rightValue = long.Parse(matches[1].Value);
            if (leftListOccurences.TryGetValue(rightValue, out long occurences))
            {
                leftListOccurences[rightValue] = occurences + 1;
            }
            else
            {
                unProcessedRightList.Add(rightValue);
            }
        }

        foreach (long rightValue in unProcessedRightList)
        {
            if (leftListOccurences.TryGetValue(rightValue, out long occurences))
            {
                leftListOccurences[rightValue] = occurences + 1;
            }
        }

        return leftListOccurences.Sum(kvp => kvp.Key * kvp.Value);
    }
}
