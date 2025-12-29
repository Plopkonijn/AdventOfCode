using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day21;

public sealed class RpgSimulator20XXSolver(string[] input) : Solver(input)
{
    private readonly List<Item> _weapons =
    [
        new Item("Dagger" ,8     ,4       ,0),
        new Item("Shortsword" ,10     ,5       ,0),
        new Item("Warhammer" ,25     ,6       ,0),
        new Item("Longsword" ,40     ,7       ,0),
        new Item("Greataxe" ,74     ,8       ,0)
    ];
    private readonly List<Item> _armors =
    [
        new Item("Leather" ,13     ,0       ,1),
        new Item("Chainmail" ,31     ,0       ,2),
        new Item("Splintmail" ,53     ,0       ,3),
        new Item("Bandedmail" ,75     ,0       ,4),
        new Item("Platemail" ,102     ,0       ,5)
    ];
    private readonly List<Item> _rings =
     [
        new Item("Damage +1" ,25     ,1       ,0),
        new Item("Damage +2" ,50     ,2       ,0),
        new Item("Damage +3" ,100     ,3       ,0),
        new Item("Defense +1" ,20     ,0       ,1),
        new Item("Defense +2" ,40     ,0       ,2),
        new Item("Defense +3" ,80     ,0       ,3),
    ];


    public override long SolvePart1()
    {
        Player boss = ParseBoss();

        long minimumGold = long.MaxValue;
        foreach (Item weapon in _weapons)
        {
            long weaponCost = weapon.Cost;
            if (weaponCost >= minimumGold)
            {
                continue;
            }
            foreach (Item? armor in _armors.Prepend(null))
            {
                long armorCost = weaponCost + (armor?.Cost ?? 0);
                if (armorCost >= minimumGold)
                {
                    continue;
                }
                foreach (Item? ring1 in _rings.Prepend(null))
                {
                    long ring1Cost = armorCost + (ring1?.Cost ?? 0);
                    if (ring1Cost >= minimumGold)
                    {
                        continue;
                    }
                    foreach (Item? ring2 in _rings.Prepend(null))
                    {
                        long ring2Cost = ring1Cost + (ring2?.Cost ?? 0);
                        if (ring2Cost >= minimumGold)
                        {
                            continue;
                        }

                        long totalDamage = weapon.Damage + (ring1?.Damage ?? 0) + (ring2?.Damage ?? 0);
                        long toalArmor = weapon.Armor + (armor?.Armor ?? 0) + (ring1?.Armor ?? 0) + (ring2?.Armor ?? 0);
                        Player player = new("You", 100, totalDamage, toalArmor);
                        if (CanDefeat(boss, player))
                        {
                            minimumGold = ring2Cost;
                        }
                    }
                }
            }
        }

        return minimumGold;
    }

    private static bool CanDefeat(Player boss, Player player)
    {
        long killBossSteps = StepsToKill(player, boss);
        long killPlayerSteps = StepsToKill(boss, player);
        return killBossSteps <= killPlayerSteps;
    }

    private static long StepsToKill(Player attacker, Player defender)
    {
        long damage = Math.Max(1, attacker.Damage - defender.Armor);
        long rounds = (long)Math.Ceiling(defender.HitPoints / (float)damage);
        return rounds;
    }

    private Player ParseBoss()
    {
        long hitPoints = long.Parse(Regex.Match(Input[0], @"\d+").Value, CultureInfo.InvariantCulture);
        long damage = long.Parse(Regex.Match(Input[1], @"\d+").Value, CultureInfo.InvariantCulture);
        long armor = long.Parse(Regex.Match(Input[2], @"\d+").Value, CultureInfo.InvariantCulture);
        return new Player("Boss", hitPoints, damage, armor);
    }

    public override long SolvePart2()
    {
        Player boss = ParseBoss();

        long maximumGold = 0;
        foreach (Item weapon in _weapons)
        {
            long weaponCost = weapon.Cost;
            foreach (Item? armor in _armors.Prepend(null))
            {
                long armorCost = weaponCost + (armor?.Cost ?? 0);
                foreach (Item? ring1 in _rings.Prepend(null))
                {
                    long ring1Cost = armorCost + (ring1?.Cost ?? 0);
                    foreach (Item? ring2 in _rings.Prepend(null))
                    {
                        if (ring2 is not null && ring2 == ring1)
                        {
                            continue;
                        }
                        long ring2Cost = ring1Cost + (ring2?.Cost ?? 0);
                        if (ring2Cost <= maximumGold)
                        {
                            continue;
                        }

                        long totalDamage = weapon.Damage + (ring1?.Damage ?? 0) + (ring2?.Damage ?? 0);
                        long toalArmor = weapon.Armor + (armor?.Armor ?? 0) + (ring1?.Armor ?? 0) + (ring2?.Armor ?? 0);
                        Player player = new("You", 100, totalDamage, toalArmor);
                        if (!CanDefeat(boss, player))
                        {
                            maximumGold = ring2Cost;
                        }
                    }
                }
            }
        }

        return maximumGold;
    }
}

internal sealed record Player(string Name, long HitPoints, long Damage, long Armor);

internal sealed record Item(string Name, long Cost, long Damage, long Armor);
