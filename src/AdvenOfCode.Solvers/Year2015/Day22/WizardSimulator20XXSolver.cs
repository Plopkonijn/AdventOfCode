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
        new Spell("Recharge",229,Recharge:101,Turns:5)
    ];

    public override long SolvePart1()
    {
        long playerHP = 50;
        long playerMana = 500;
        long bossHP = long.Parse(DigitRegex().Match(Input[0]).Value, CultureInfo.InvariantCulture);
        long bossDamage = long.Parse(DigitRegex().Match(Input[1]).Value, CultureInfo.InvariantCulture);

        GameState startState = new(playerHP, playerMana, bossHP, bossDamage, []);
        return FindMinimumManaUsage(startState, (state, spell) => state.CastSpellEasy(spell));
    }

    private long FindMinimumManaUsage(GameState startState, Action<GameState, Spell> castSpell)
    {
        PriorityQueue<GameState, long> queue = new();
        Dictionary<GameState, long> manaDictionary = new() { { startState, 0 } };
        queue.Enqueue(startState, 0);

        while (queue.TryDequeue(out GameState? current, out long usedMana))
        {
            if (current.HasPlayerWon)
            {
                return usedMana;
            }
            if (current.HasBossWon || current.IsFinised)
            {
                continue;
            }

            foreach (Spell spell in _spells)
            {
                if (spell.Cost > current.PlayerMana || current.Effects.Any(s => s.Turns > 1 && s.Name == spell.Name))
                {
                    continue;
                }

                GameState next = current with { };
                long newUsedMana = usedMana + spell.Cost;
                castSpell(next, spell);
                if (!manaDictionary.TryGetValue(next, out long existingUsedMana) || newUsedMana < existingUsedMana)
                {
                    manaDictionary.Add(next, newUsedMana);
                    queue.Enqueue(next, newUsedMana);
                }
            }
        }
        throw new InvalidOperationException();
    }

    public override long SolvePart2()
    {
        long playerHP = 50;
        long playerMana = 500;
        long bossHP = long.Parse(DigitRegex().Match(Input[0]).Value, CultureInfo.InvariantCulture);
        long bossDamage = long.Parse(DigitRegex().Match(Input[1]).Value, CultureInfo.InvariantCulture);

        GameState startState = new(playerHP, playerMana, bossHP, bossDamage, []);
        return FindMinimumManaUsage(startState, (state, spell) => state.CastSpellHard(spell));
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex DigitRegex();
}
