using System.Globalization;

namespace AdvenOfCode.Solvers.Year2025.Day05;

public sealed class CafeteriaSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long result = 0;
        int i = 0;
        List<(long min, long max)> idRanges = [];
        while (i < Input.Length && Input[i] is string line && !string.IsNullOrEmpty(line))
        {
            string[] idRange = line.Split('-');
            long idMin = long.Parse(idRange[0], CultureInfo.InvariantCulture);
            long idMax = long.Parse(idRange[1], CultureInfo.InvariantCulture);
            idRanges.Add((idMin, idMax));
            i++;
        }
        i++;
        while (i < Input.Length && Input[i] is string line && !string.IsNullOrEmpty(line))
        {
            long id = long.Parse(line, CultureInfo.InvariantCulture);
            bool isInRange = idRanges.Any(range => range.min <= id && id <= range.max);
            if (isInRange)
            {
                result++;
            }
            i++;
        }

        return result;
    }

    public override long SolvePart2()
    {
        int i = 0;

        List<Range> idRanges = [];
        while (i < Input.Length && Input[i] is string line && !string.IsNullOrEmpty(line))
        {
            string[] rangeSplit = line.Split('-');
            long idMin = long.Parse(rangeSplit[0], CultureInfo.InvariantCulture);
            long idMax = long.Parse(rangeSplit[1], CultureInfo.InvariantCulture);
            Range newRange = new(idMin, idMax);
            idRanges.Add(newRange);
            i++;
        }

        MergeRanges(idRanges);
        MergeRanges(idRanges);
        long result = 0;
        foreach (Range range in idRanges)
        {
            long length = 1 + range.Max - range.Min;
            result += length;
        }
        return result;
    }

    private static void MergeRanges(List<Range> idRanges)
    {
        idRanges.Sort((a, b) =>
        {
            int comparison = a.Min.CompareTo(b.Min);
            return comparison != 0 ? comparison : a.Max.CompareTo(b.Max);
        });
        for (int i = 0; i < idRanges.Count; i++)
        {
            Range iRange = idRanges[i];
            int foundIndex;
            while ((foundIndex = idRanges.FindIndex(i, r => !object.ReferenceEquals(r, iRange) && r.OverlapsWith(iRange))) >= 0)
            {
                Range jRange = idRanges[foundIndex];
                Range mergeRange = iRange.Merge(jRange);
                iRange = mergeRange;
                idRanges[i] = iRange;
                idRanges.RemoveAt(foundIndex);
            }
        }
    }
}