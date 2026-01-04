using System.Security.Cryptography;
using System.Text;

namespace AdvenOfCode.Solvers.Year2016.Day05;

public sealed class HowAboutANiceGameOfChessSolver(string[] Input)
{
    public string SolvePart1()
    {
        string doorId = Input[0];

        char[] password = new char[8];
        int index = 0;
        for (int i = 0; i < password.Length; i++)
        {
            for (; ; index++)
            {
                string sourceString = doorId + index;
                byte[] sourceBytes = Encoding.ASCII.GetBytes(sourceString);
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms
                byte[] hashBytes = MD5.HashData(sourceBytes);
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms
                char[] hashString = BitConverter.ToString(hashBytes).Where(char.IsAsciiLetterOrDigit).ToArray();
                if (hashString.Take(5).All(c => c == '0'))
                {
                    password[i] = hashString.ElementAt(5);
                    index++;
                    break;
                }
            }
        }
#pragma warning disable CA1308 // Normalize strings to uppercase
        return new string(password).ToLowerInvariant();
#pragma warning restore CA1308 // Normalize strings to uppercase
    }

    public string SolvePart2()
    {
        throw new NotImplementedException();
    }
}
