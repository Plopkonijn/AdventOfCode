using System.Diagnostics;

namespace AdvenOfCode.Solvers.Year2015.Day22;

internal abstract record Spell(long Cost)
{
    internal virtual void Execute(Boss boss, Player player)
    {
        Debug.WriteLine($"Player casts {GetType().Name}.");
    }
}

internal abstract record InstantSpell(long Cost) : Spell(Cost);

internal abstract record EffectSpell(long Cost, long Turns) : Spell(Cost)
{
    internal long Turns { get; set; } = Turns;
    internal virtual void Apply(Boss boss, Player player)
    {
        Turns--;
        Debug.WriteLine($"{GetType().Name}'s timer is now {Turns}.");
    }
    internal virtual void Remove(Boss boss, Player player) { }
}

internal sealed record MagicMissile() : InstantSpell(53)
{
    internal override void Execute(Boss boss, Player _)
    {
        Debug.WriteLine($"Player casts {GetType().Name}, dealing 4 damage");
        boss.TakeDamage(4);
    }
}

internal sealed record Drain() : InstantSpell(73)
{
    internal override void Execute(Boss boss, Player player)
    {
        Debug.WriteLine($"Player casts {GetType().Name}, dealing 2 damage, and healing 2 hit points");
        boss.TakeDamage(2);
        player.HitPoints += 2;
    }
}

internal sealed record Shield() : EffectSpell(113, 6)
{
    internal override void Execute(Boss _, Player player)
    {
        Debug.WriteLine($"Player casts {GetType().Name}, increasing armor by 7.");
        player.Armor += 7;
    }

    internal override void Remove(Boss _, Player player)
    {
        Debug.WriteLine($"Shield wears off, decreasing armor by 7.");
        player.Armor -= 7;
    }
}

internal sealed record Poison() : EffectSpell(173, 6)
{
    internal override void Apply(Boss boss, Player player)
    {
        base.Apply(boss, player);
        Debug.WriteLine($"Poison deals 3 damage; its timer is now {Turns}.");
        boss.HitPoints -= 3;
    }
}

internal sealed record Recharge() : EffectSpell(229, 5)
{
    internal override void Apply(Boss _, Player player)
    {
        base.Apply(_, player);
        Debug.WriteLine($"Recharge provides 101 mana; its timer is now {Turns}.");
        player.Mana += 101;
    }
}




