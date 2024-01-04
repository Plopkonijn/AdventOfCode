using System.Text.RegularExpressions;

namespace Year2023.Day19;

internal class Workflow
{
	private readonly List<Rule> _rules;

	private Workflow(string name, List<Rule> rules)
	{
		Name = name;
		_rules = rules;
	}

	public string Name { get; }

	public static Workflow Parse(string s)
	{
		var match = Regex.Match(s, @"(?<name>\w+)\{((?<rule>[^,]+),?)+\}");
		var name = match.Groups["name"].Value;

		var rules = match.Groups["rule"]
		                 .Captures.Select(capture => capture.Value)
		                 .Select(Rule.Parse)
		                 .ToList();
		return new Workflow(name, rules);
	}

	public string Process(PartRating partRating)
	{
		foreach (var rule in _rules)
		{
			if (rule.Condition(partRating))
			{
				return rule.WorkflowName;
			}
		}

		throw new InvalidOperationException();
	}

	public IEnumerable<(PartRatingRange partRatingRange, string workflowName)> Process(PartRatingRange partRatingRange)
	{
		foreach (var rule in _rules)
		{
			(var splitOffRange, partRatingRange) = rule.Split(partRatingRange);
			if (splitOffRange.Total > 0)
			{
				yield return (splitOffRange, rule.WorkflowName);
			}
		}
	}
}