
namespace AdvenOfCode.Solvers.Year2025.Day8;

internal sealed class DisjointSet
{
    private DisjointSet _parent;
    public int Size { get; private set; } = 1;

    public DisjointSet()
    {
        _parent = this;
    }

    public DisjointSet Find()
    {
        DisjointSet x = this;
        while (!ReferenceEquals(x._parent, x))
        {
            (x, x._parent) = (x._parent, x._parent._parent);
        }
        return x;
    }

    public void Union(DisjointSet other)
    {
        DisjointSet x = Find();
        DisjointSet y = other.Find();
        if (ReferenceEquals(x, y))
        {
            return;
        }
        if (x.Size < y.Size)
        {
            (x, y) = (y, x);
        }
        y._parent = x;
        x.Size += y.Size;
    }
}

