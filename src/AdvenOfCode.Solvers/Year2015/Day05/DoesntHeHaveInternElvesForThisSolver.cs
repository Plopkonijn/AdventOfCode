namespace AdvenOfCode.Solvers.Year2015.Day05;

public sealed class DoesntHeHaveInternElvesForThisSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        return Input.Count(IsNice1);
    }

    private static bool IsNice1(string input)
    {
        return ContainsAtLeastThreeVowels(input)
            && ContainsDuplicate(input)
            && DoesNotContainForbidden(input);
    }
    private static readonly string[] _forbidden =
    [
        "ab",
        "cd",
        "pq",
        "xy"
    ];

    private static bool DoesNotContainForbidden(string input)
    {
        for (int i = 0; i < input.Length - 1; i++)
        {
            if (_forbidden.Contains(input[i..(i + 2)]))
            {
                return false;
            }
        }
        return true;
    }

    private static bool ContainsDuplicate(string input)
    {
        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] == input[i + 1])
            {
                return true;
            }
        }
        return false;
    }

    private const string _vowels = "aeiou";
    private static bool ContainsAtLeastThreeVowels(string input)
    {
        int vowelCount = 0;
        foreach (char c in input)
        {
            if (!_vowels.Contains(c, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }
            vowelCount++;
            if (vowelCount == 3)
            {
                return true;
            }
        }
        return false;
    }

    public override long SolvePart2()
    {
        return Input.Count(IsNice2);
    }

    private static bool IsNice2(string input)
    {
        return ContainsRepeatedSubstring(input) &&
            ContainsSandwich(input);
    }

    private static bool ContainsSandwich(string input)
    {
        for (int i = 0; i < input.Length - 2; i++)
        {
            if (input[i] == input[i + 2] && input[i] != input[i + 1])
            {
                return true;
            }
        }
        return false;
    }

    private static bool ContainsRepeatedSubstring(string input)
    {
        for (ReadOnlySpan<char> s = input.AsSpan(); s.Length >= 4; s = s[1..])
        {
            ReadOnlySpan<char> pair = s[0..2];
            for (ReadOnlySpan<char> ss = s[2..]; ss.Length >= 2; ss = ss[1..])
            {
                if (pair.SequenceEqual(ss[0..2]))
                {
                    return true;
                }
            }
        }
        return false;
    }
}