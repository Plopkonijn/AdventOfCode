using System.Globalization;

namespace AdvenOfCode.Solvers.Year2015.Day10;

public sealed class ElvesLookElvesSaySolver(string[] Input)
{
    public long Solve(int iterations)
    {
        LinkedList<char> list = new(Input[0]);
        for (int i = 0; i < iterations; i++)
        {
            LookAndSay(list);
        }
        return list.Count;
    }

    private static void LookAndSay(LinkedList<char> list)
    {
        LinkedListNode<char>? current = list.First;
        while (current != null)
        {
            char currentValue = current.Value;
            long length = 1;
            LinkedListNode<char>? next = current.Next;
            while (next != null && next.Value == currentValue)
            {
                length++;
                list.Remove(current);
                current = next;
                next = next.Next;
            }

            _ = length.ToString(CultureInfo.InvariantCulture);
            foreach (char c in length.ToString(CultureInfo.InvariantCulture))
            {
                _ = list.AddBefore(current, c);
            }
            current = next;
        }
    }
}