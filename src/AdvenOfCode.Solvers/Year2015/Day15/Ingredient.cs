
using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day15;

internal sealed record Ingredient(string Name, long Capacity, long Durability, long Flavor, long Texture, long Calories)
{
    internal static Ingredient Parse(string line)
    {
        Match match = Regex.Match(line, @"(\w+): capacity (-?\d+), durability (-?\d+), flavor (-?\d+), texture (-?\d+), calories (-?\d+)");
        var name = match.Groups[1].Value;
        var capacity = long.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
        var durability = long.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
        var flavor = long.Parse(match.Groups[4].Value, CultureInfo.InvariantCulture);
        var texture = long.Parse(match.Groups[5].Value, CultureInfo.InvariantCulture);
        var calories = long.Parse(match.Groups[6].Value, CultureInfo.InvariantCulture);
        return new Ingredient(name, capacity, durability, flavor, texture, calories);
    }
}