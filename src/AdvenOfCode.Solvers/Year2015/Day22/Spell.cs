namespace AdvenOfCode.Solvers.Year2015.Day22;

internal sealed record Spell(string Name, long Cost, long Damage = 0, long Healing = 0, long Armor = 0, long Recharge = 0, long Turns = 0)
{
    public long Turns { get; set; } = Turns;
}
