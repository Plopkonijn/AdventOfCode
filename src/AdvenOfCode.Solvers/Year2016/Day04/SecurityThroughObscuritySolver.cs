using System.Diagnostics;
using System.Globalization;

namespace AdvenOfCode.Solvers.Year2016.Day04;

public sealed class SecurityThroughObscuritySolver(string[] Input) : Solver(Input)
{
    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {

            bool isValid = IsValid(line);
            if (isValid)
            {

                result += GetSectorId(line);
            }
        }
        return result;
    }

    private static bool IsValid(string line)
    {
        int bracketIndex = line.IndexOf('[', StringComparison.OrdinalIgnoreCase);
        string checksum = line[(bracketIndex + 1)..^1];
        return line[0..bracketIndex].Where(char.IsLetter)
                      .GroupBy(c => c)
                      .Select(g => (g.Key, Count: g.Count()))
                      .OrderByDescending(t => t.Count)
                      .ThenBy(t => t.Key)
                      .Select(t => t.Key)
                      .Take(checksum.Length)
                      .SequenceEqual(checksum);
    }

    private static long GetSectorId(string line)
    {
        int dashIndex = line.LastIndexOf('-');
        int bracketIndex = line.IndexOf('[', StringComparison.OrdinalIgnoreCase);
        string sectorId = line[(1 + dashIndex)..bracketIndex];
        return long.Parse(sectorId, CultureInfo.InvariantCulture);
    }

    public override long SolvePart2()
    {
        foreach (string line in Input)
        {

            bool isValid = IsValid(line);
            if (!isValid)
            {

                continue;
            }
            long sectorId = GetSectorId(line);
            string decrypted = Decrypt(line, sectorId);
            if (decrypted == "northpole object storage ")
            {
                return sectorId;
            }
            Debug.WriteLine(decrypted);
        }
        throw new InvalidOperationException();
    }

    private static string Decrypt(string line, long length)
    {
        length %= 26;
        char[] decrypted = line.AsSpan(0, line.Length - 10).ToArray();
        for (int i = 0; i < decrypted.Length; i++)
        {
            if (decrypted[i] is '-')
            {
                decrypted[i] = ' ';
            }
            else if (char.IsAsciiLetter(decrypted[i]))
            {
                decrypted[i] += (char)length;
                if (decrypted[i] > 'z')
                {
                    decrypted[i] -= (char)26;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        string result = new(decrypted);
        return result;
    }
}