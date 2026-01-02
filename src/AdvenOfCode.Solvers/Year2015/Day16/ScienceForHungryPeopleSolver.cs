namespace AdvenOfCode.Solvers.Year2015.Day16;

public sealed class ScienceForHungryPeopleSolver(string[] Input) : Solver(Input)
{

    private readonly Dictionary<string, long> properties = new()
    {
        { "children" ,3},
        { "cats" ,7},
        { "samoyeds" ,2},
        { "pomeranians" ,3},
        { "akitas" ,0},
        { "vizslas" ,0},
        { "goldfish" ,5},
        { "trees" ,3},
        { "cars" ,2},
        { "perfumes" ,1},
    };
    public override long SolvePart1()
    {
        List<Sue> sues = Input.Select(Sue.Parse)
                        .ToList();
        Sue sue = sues.First(s => s.Properties.All(p => properties.TryGetValue(p.Key, out long v) && v == p.Value));
        return sue.Number;
    }

    public override long SolvePart2()
    {
        List<Sue> sues = Input.Select(Sue.Parse)
                        .ToList();
        Sue sue = sues.First(IsValidSue);
        return sue.Number;
    }

    private bool IsValidSue(Sue sue)
    {
        long v;
        foreach ((string key, long value) in sue.Properties)
        {
            switch (key)
            {
                case "cats":
                case "trees":
                    if (!properties.TryGetValue(key, out v) || value <= v)
                    {
                        return false;
                    }

                    break;
                case "pomeranians":
                case "goldfish":
                    if (!properties.TryGetValue(key, out v) || value >= v)
                    {
                        return false;
                    }

                    break;
                default:
                    if (!properties.TryGetValue(key, out v) || value != v)
                    {
                        return false;
                    }

                    break;
            }
        }
        return true;
    }
}
