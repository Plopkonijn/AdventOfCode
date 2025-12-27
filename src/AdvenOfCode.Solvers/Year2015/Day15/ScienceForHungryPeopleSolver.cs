namespace AdvenOfCode.Solvers.Year2015.Day15;

public sealed class ScienceForHungryPeopleSolver(string[] Input) : Solver(Input)
{
    public override long SolvePart1()
    {
        List<Ingredient> ingredients = Input.Select(Ingredient.Parse).ToList();
        int[] recipe = ingredients.Select(_ => 0).ToArray();
        Dictionary<Recipe, long> cache = [];
        return Calculate(100, ingredients, new(recipe), cache, GetScore);
    }

    private static long Calculate(int remainingIngredients, List<Ingredient> ingredients, Recipe recipe, Dictionary<Recipe, long> cache, Func<List<Ingredient>, Recipe, long> getScore)
    {
        if (cache.TryGetValue(recipe, out long result))
        {
            return result;
        }

        if (remainingIngredients == 0)
        {
            result = getScore(ingredients, recipe);
            cache.Add(recipe, result);
            return result;
        }

        foreach ((int index, Ingredient ingredient) in ingredients.Index())
        {
            Recipe newRecipe = new(recipe.Amounts.ToArray());
            newRecipe.Amounts[index]++;
            long score = Calculate(remainingIngredients - 1, ingredients, newRecipe, cache, getScore);
            if (score > result)
            {
                result = score;
            }
        }

        cache.Add(recipe, result);
        return result;
    }

    private static long GetScore(List<Ingredient> ingredients, Recipe recipe)
    {
        long capacity = 0;
        long durability = 0;
        long flavor = 0;
        long texture = 0;

        foreach ((Ingredient? ingredient, int amount) in ingredients.Zip(recipe.Amounts))
        {
            capacity += ingredient.Capacity * amount;
            durability += ingredient.Durability * amount;
            flavor += ingredient.Flavor * amount;
            texture += ingredient.Texture * amount;
        }

        return (capacity < 0 ? 0 : capacity) *
            (durability < 0 ? 0 : durability) *
            (flavor < 0 ? 0 : flavor) *
            (texture < 0 ? 0 : texture);
    }

    private static long GetCalories(List<Ingredient> ingredients, Recipe recipe)
    {
        return ingredients.Select(i => i.Calories).Zip(recipe.Amounts)
            .Sum(t => t.First * t.Second);
    }

    public override long SolvePart2()
    {
        List<Ingredient> ingredients = Input.Select(Ingredient.Parse).ToList();
        int[] recipe = ingredients.Select(_ => 0).ToArray();
        Dictionary<Recipe, long> cache = [];
        return Calculate(100, ingredients, new(recipe), cache, (i, r) => GetCalories(i, r) != 500 ? 0 : GetScore(i, r));
    }
}
