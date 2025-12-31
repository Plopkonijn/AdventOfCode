using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day22;

public sealed partial class WizardSimulator20XXSolver(string[] input) : Solver(input)
{
    private readonly Spell[] _spells =
    [
        new Spell("Magic Missile",53,Damage:4),
        new Spell("Drain",73,Damage:2,Healing:2),
        new Spell("Shield",113,Armor:7,Turns:6),
        new Spell("Poison", 173,Damage:3,Turns:6),
        new Spell("Recharge",229,Recharge:4,Turns:5)
    ];

    public override long SolvePart1()
    {
        long playerHP = 50;
        long playerMana = 500;
        long bossHP = long.Parse(DigitRegex().Match(Input[0]).Value, CultureInfo.InvariantCulture);
        long bossDamage = long.Parse(DigitRegex().Match(Input[1]).Value, CultureInfo.InvariantCulture);

        return Calculate(playerHP, playerMana, bossHP, bossDamage, []) ?? throw new InvalidOperationException();
    }

    private long? Calculate(long playerHP, long playerMana, long bossHP, long bossDamage, List<Spell> effects)
    {
        // Activate effects before players turn
        bossHP -= effects.Sum(e => e.Damage);
        if (bossHP <= 0)
        {
            return 0;
        }
        playerHP += effects.Sum(e => e.Healing);
        playerMana += effects.Sum(e => e.Recharge);
        effects.ForEach(e => e.Turns--);
        _ = effects.RemoveAll(e => e.Turns == 0);

        long? leastMana = null;
        foreach (Spell spell in _spells)
        {
            // players turn
            if (effects.Any(e => e.Name == spell.Name))
            {
                continue;
            }
            else if (spell.Cost > playerMana)
            {
                continue;
            }
            long newPlayerMana = playerMana - spell.Cost;
            List<Spell> newEffects = effects.Select(e => e with { }).ToList();
            newEffects.Add(spell);


            // Activate effects before boss turn
            long newBossHP = bossHP - effects.Sum(e => e.Damage);
            if (newBossHP <= 0)
            {
                if (spell.Cost < leastMana)
                {
                    leastMana = spell.Cost;
                    continue;
                }
            }
            long newPlayerHP = playerHP + effects.Sum(e => e.Healing);
            newPlayerMana += effects.Sum(e => e.Recharge);
            newEffects.ForEach(e => e.Turns--);
            _ = newEffects.RemoveAll(e => e.Turns == 0);

            //boss turn
            newPlayerHP -= Math.Max(1, bossDamage - effects.Sum(e => e.Armor));
            if (newPlayerHP <= 0)
            {
                continue;
            }
            if (Calculate(newPlayerHP, newPlayerMana, newBossHP, bossDamage, newEffects) is not { } mana)
            {
                continue;
            }
            mana += spell.Cost;
            if (!leastMana.HasValue || mana < leastMana.Value)
            {
                leastMana = mana;
            }
        }

        return leastMana;
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex DigitRegex();
}

internal sealed record Spell(string Name, long Cost, long Damage = 0, long Healing = 0, long Armor = 0, long Recharge = 0, long Turns = 1)
{
    public long Turns { get; set; } = Turns;
}
