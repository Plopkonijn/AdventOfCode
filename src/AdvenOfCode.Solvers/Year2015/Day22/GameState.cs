using System.Diagnostics;

namespace AdvenOfCode.Solvers.Year2015.Day22;

internal sealed record GameState(long TotalSpendMana, Player Player, Boss Boss, List<EffectSpell> Effects)
{
    public long TotalSpendMana { get; private set; } = TotalSpendMana;
    private GameState(GameState original)
    {
        TotalSpendMana = original.TotalSpendMana;
        Player = original.Player with { };
        Boss = original.Boss with { };
        Effects = original.Effects.Select(e => e with { }).ToList();
    }

    public GameState CastSpell(Spell spell)
    {
        GameState result = this with { };
        result.ExecuteSpell(spell);
        if (PlayerHasWon)
        {
            return result;
        }

        result.ExecuteBossAttack();
        return result;
    }

    public bool IsFinished => PlayerHasWon || BossHasWon;
    public bool PlayerHasWon => Boss.HitPoints <= 0;
    public bool BossHasWon => Player.HitPoints <= 0;
    private void ApplyEffects()
    {
        for (int i = Effects.Count - 1; i >= 0; i--)
        {
            EffectSpell effect = Effects[i];
            effect.Apply(Boss, Player);
        }
    }

    private void RemoveEffects()
    {
        for (int i = Effects.Count - 1; i >= 0; i--)
        {
            EffectSpell effect = Effects[i];
            if (effect.Turns == 0)
            {
                effect.Remove(Boss, Player);
                Effects.RemoveAt(i);
            }
        }
    }

    private void ExecuteBossAttack()
    {
        Debug.WriteLine("");
        Debug.WriteLine("-- Boss turn --");
        Debug.WriteLine($"- Player has {Player.HitPoints} hit points, {Player.Armor} armor, {Player.Mana} mana");
        Debug.WriteLine($"- Boss has {Boss.HitPoints} hit points");
        ApplyEffects();
        Player.TakeDamage(Boss.Damage);
        RemoveEffects();
    }

    private void ExecuteSpell(Spell spell)
    {
        Debug.WriteLine("");
        Debug.WriteLine("-- Player turn --");
        Debug.WriteLine($"- Player has {Player.HitPoints} hit points, {Player.Armor} armor, {Player.Mana} mana");
        Debug.WriteLine($"- Boss has {Boss.HitPoints} hit points");
        ApplyEffects();
        if (PlayerHasWon)
        {
            RemoveEffects();
            return;
        }
        TotalSpendMana += spell.Cost;
        spell.Execute(Boss, Player);
        RemoveEffects();
        if (spell is EffectSpell effect)
        {
            Effects.Add(effect);
        }
    }



}
