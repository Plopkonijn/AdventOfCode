namespace AdvenOfCode.Solvers.Year2015.Day11;

public sealed class CorporatePolicySolver(string[] Input)
{
    public string SolvePart1()
    {
        char[] password = Input[0].ToArray();
        FindNextPassword(password);
        return new string(password);
    }

    private static void FindNextPassword(char[] password)
    {
        while (!IsValid(password))
        {
            IncrementPassword(password);
        }
    }

    private static void IncrementPassword(char[] password)
    {
        for (int i = password.Length - 1; i >= 0; i--)
        {
            if (password[i] == 'z')
            {
                password[i] = 'a';
            }
            else
            {
                password[i]++;
                break;
            }
        }
    }

    private static bool IsValid(char[] password)
    {
        return ContainsStraight(password) &&
               !ContainsForbidd(password) &&
               ContainsDistinctPairs(password, 2);
    }

    private static bool ContainsStraight(ReadOnlySpan<char> password)
    {
        while (password.Length >= 3)
        {
            if (password[0] + 1 != password[1])
            {
                password = password[1..];
                continue;
            }
            if (password[1] + 1 != password[2])
            {
                password = password[2..];
                continue;
            }
            return true;
        }
        return false;
    }

    private static bool ContainsForbidd(char[] password)
    {
        return password.Any("iol".Contains);
    }

    private static bool ContainsDistinctPairs(ReadOnlySpan<char> password, int pairs)
    {
        int pairsFound = 0;
        while (password.Length >= 2)
        {
            if (password[0] != password[1])
            {
                password = password[1..];
                continue;
            }
            pairsFound++;
            if (pairsFound == pairs)
            {
                return true;
            }
            do
            {
                password = password[1..];
            } while (password.Length >= 2 && password[0] == password[1]);
        }
        return pairsFound == pairs;
    }

    public string SolvePart2()
    {
        char[] password = Input[0].ToArray();
        IncrementPassword(password);
        FindNextPassword(password);
        return new string(password);
    }
}