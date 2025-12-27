namespace AdvenOfCode.Solvers.Year2015.Day16;

public sealed class ScienceForHungryPeopleSolver(string[] Input) : Solver(Input)
{
    public override long SolvePart1()
    {
        HashSet<string> properties = [
            "children: 3",
            "cats: 7",
            "samoyeds: 2",
            "pomeranians: 3",
            "akitas: 0",
            "vizslas: 0",
            "goldfish: 5",
            "trees: 3",
            "cars: 2",
            "perfumes: 1",
            ];
        List<Sue> sues = Input.Select(Sue.Parse)
                        .ToList();
        Sue sue = sues.First(s => properties.IsProperSupersetOf(s.Properties));
        return sue.Number;
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}
