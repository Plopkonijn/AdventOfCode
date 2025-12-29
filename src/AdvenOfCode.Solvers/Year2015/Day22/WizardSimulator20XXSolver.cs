using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day22;

public sealed partial class WizardSimulator20XXSolver(string[] input) : Solver(input)
{
    private readonly List<Spell> _spells =
    [
        new MagicMissile(),
        new Drain(),
        new Shield(),
        new Poison(),
        new Recharge(),
    ];

    public override long SolvePart1()
    {
        Player player = new(50, 0, 500);
        Boss boss = ParseBoss();
        GameState turn = new(0, player, boss, []);
        Stack<GameState> stack = new();
        stack.Push(turn);
        long leastMana = long.MaxValue;
        while (stack.TryPop(out GameState? current))
        {
            if (current.TotalSpendMana > leastMana)
            {
                continue;
            }
            if (current.IsFinished)
            {
                if (current.PlayerHasWon && current.TotalSpendMana < leastMana)
                {
                    leastMana = current.TotalSpendMana;
                }
                continue;
            }
            foreach (Spell spell in _spells)
            {
                if (spell.Cost > current.Player.Mana ||
                    current.Effects.Any(e => e.GetType() == spell.GetType()))
                {
                    continue;
                }
                GameState next = current.CastSpell(spell with { });
                stack.Push(next);
            }
        }
        return leastMana;
    }

    private Boss ParseBoss()
    {
        long hitPoints = long.Parse(DigitRegex().Match(Input[0]).Value, CultureInfo.InvariantCulture);
        long damage = long.Parse(DigitRegex().Match(Input[1]).Value, CultureInfo.InvariantCulture);
        return new Boss(hitPoints, damage);
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex DigitRegex();
}

