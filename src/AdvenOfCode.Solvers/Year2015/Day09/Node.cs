namespace AdvenOfCode.Solvers.Year2015.Day09;

internal sealed record Node(string Name, long TotalDistance, long Length = 0, Node? Previous = null)
{
    public IEnumerable<string> GetRoute()
    {
        for (Node? node = this; node != null; node = node.Previous)
        {
            yield return node.Name;
        }
    }
}
