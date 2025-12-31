namespace AdvenOfCode.Solvers.Year2015.Day22;

internal sealed record GameState(long PlayerHP, long PlayerMana, long BossHP, long BossDamage, SpellCollection? Effects = null) : IEquatable<GameState>
{
    public long PlayerHP { get; private set; } = PlayerHP;
    public long PlayerMana { get; private set; } = PlayerMana;
    public long BossHP { get; private set; } = BossHP;
    public SpellCollection Effects { get; private set; } = Effects ?? [];

    internal GameState(GameState original)
    {
        PlayerHP = original.PlayerHP;
        PlayerMana = original.PlayerMana;
        BossHP = original.BossHP;
        BossDamage = original.BossDamage;
        Effects = [.. original.Effects.Select(e => e with { })];
    }

    public bool HasPlayerWon => PlayerHP > 0 && BossHP <= 0;
    public bool HasBossWon => BossHP > 0 && PlayerHP <= 0;
    public bool IsFinised => BossHP <= 0 || PlayerHP <= 0;

    public bool Equals(GameState? other)
    {
        return other is not null
            && PlayerHP == other.PlayerHP
            && PlayerMana == other.PlayerMana
            && BossHP == other.BossHP
            && BossDamage == other.BossDamage
            && Effects.SequenceEqual(other.Effects);
    }

    public override int GetHashCode()
    {
        int hashCode = HashCode.Combine(PlayerHP, PlayerMana, BossHP, BossDamage);
        return Effects.Aggregate(hashCode, HashCode.Combine);
    }

    internal bool CastSpell(Spell spell)
    {
        return ExecutePlayersTurn(spell) || ExecuteBossTurn();
    }

    private bool ExecuteEffects(out long armor)
    {
        if (Effects.Count == 0)
        {
            armor = 0;
            return false;
        }

        armor = Effects.Sum(e => e.Armor);
        BossHP -= Effects.Sum(e => e.Damage);
        if (HasPlayerWon)
        {
            return true;
        }
        PlayerHP += Effects.Sum(e => e.Healing);
        PlayerMana += Effects.Sum(e => e.Recharge);
        _ = Effects.RemoveAll(e => (--e.Turns) == 0);
        return false;
    }

    private bool ExecuteBossTurn()
    {
        // Apply Effects before boss turn
        if (ExecuteEffects(out long armor))
        {
            return true;
        }

        // Execute boss's turn
        PlayerHP -= Math.Max(1, BossDamage - armor);
        if (HasBossWon)
        {
            return true;
        }

        return false;
    }

    private bool ExecutePlayersTurn(Spell spell)
    {
        // Apply Effects before players turn
        if (ExecuteEffects(out _))
        {
            return true;
        }

        // Execute players turn
        if (spell.Turns == 0)
        {
            PlayerHP += spell.Healing;
            BossHP -= spell.Damage;
        }
        else
        {
            Effects.Add(spell with { });
        }
        PlayerMana -= spell.Cost;
        if (HasPlayerWon)
        {
            return true;
        }

        return false;
    }
}
