using System.Diagnostics;

namespace AdvenOfCode.Solvers.Year2015.Day22;

internal abstract record Character(long HitPoints)
{
    public long HitPoints { get; set; } = HitPoints;
    public virtual void TakeDamage(long damage)
    {
        HitPoints -= damage;
    }
}
internal sealed record Player(long HitPoints, long Armor, long Mana) : Character(HitPoints)
{
    public long Mana { get; set; } = Mana;
    public long Armor { get; set; } = Armor;
    public override void TakeDamage(long damage)
    {
        long newDamage = Math.Max(1, damage - Armor);
        Debug.WriteLine($"Boss attacks for {damage} - {Armor} = {newDamage} damage!");
        base.TakeDamage(newDamage);
    }
}


internal sealed record Boss(long HitPoints, long Damage) : Character(HitPoints);