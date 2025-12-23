using System.Security.Cryptography;
using System.Text;

namespace AdvenOfCode.Solvers.Year2015.Day04;

#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms
public sealed class TheIdealStockingStufferSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        long result = 0;
        foreach (string line in Input)
        {
            return FindHashNumber(line, 5);

        }

        return result;
    }

    private static long FindHashNumber(string line, int expectedZeros)
    {
        long number = 1;
        while (true)
        {
            string secret = $"{line}{number}";
            byte[] secretBytes = Encoding.ASCII.GetBytes(secret);
            byte[] hashBytes = MD5.HashData(secretBytes);
            string hash = BitConverter.ToString(hashBytes);
            int count = hash.Where(char.IsAsciiLetterOrDigit).ToArray()
                .TakeWhile(c => c == '0')
                .Count();
            if (count == expectedZeros)
            {
                return number;
            }
            number++;
        }
    }

    public override long SolvePart2()
    {
        long result = 0;
        foreach (string line in Input)
        {
            return FindHashNumber(line, 6);

        }

        return result;
    }
}