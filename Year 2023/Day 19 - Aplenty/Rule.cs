using System.Text.RegularExpressions;

namespace Year2023.Day19;

internal class Rule
{
	public Predicate<PartRating> Condition { get; }
	public string WorkflowName { get; }

	private Rule(string workflowName, Predicate<PartRating> condition)
	{
		WorkflowName = workflowName;
		Condition = condition;
	}

	public static Rule Parse(string s)
	{
		var match = Regex.Match(s, @"((?<property>\w)(?<comparer>[<>])(?<value>\d+):)?(?<workflowName>\w+)");
		var workflowName = match.Groups["workflowName"].Value;
		if (int.TryParse(match.Groups["value"]?.Value, out var value))
		{
			Func<PartRating, int> getRatingValue = match.Groups["property"].Value switch
			{
				"x" => partRating => partRating.X,
				"m" => partRating => partRating.M,
				"a" => partRating => partRating.A,
				"s" => partRating => partRating.S,
				_ => throw new ArgumentOutOfRangeException()
			};
			Predicate<PartRating> condition = match.Groups["comparer"].Value switch
			{
				"<" => partRating => getRatingValue(partRating) < value,
				">" => partRating => getRatingValue(partRating) > value,
				_ => throw new ArgumentOutOfRangeException()
			};
			return new Rule(workflowName, condition);
		}

		return new Rule(workflowName, TrueCondition);
	}

	private static bool TrueCondition(PartRating partRating)
	{
		return true;
	}
}