using System.Text.RegularExpressions;
using Common;

namespace Year2023.Day19;

internal class Rule
{
	private Rule(string workflowName, string? property = null, string? comparer = null, int value = 0)
	{
		WorkflowName = workflowName;
		Property = property;
		Comparer = comparer;
		Value = value;
	}

	public string WorkflowName { get; }

	public string? Property { get; }
	public string? Comparer { get; }
	public int Value { get; }

	public static Rule Parse(string s)
	{
		var match = Regex.Match(s, @"((?<property>\w)(?<comparer>[<>])(?<value>\d+):)?(?<workflowName>\w+)");
		var workflowName = match.Groups["workflowName"].Value;
		var property = match.Groups["property"].Value;
		var comparer = match.Groups["comparer"].Value;
		var value = int.TryParse(match.Groups["value"].Value, out var v) ? v : 0;
		return new Rule(workflowName, property, comparer, value);
	}

	public bool Condition(PartRating partRating)
	{
		if (string.IsNullOrEmpty(Property))
		{
			return true;
		}

		var value = Property switch
		{
			"x" => partRating.X,
			"m" => partRating.M,
			"a" => partRating.A,
			"s" => partRating.S,
			_ => throw new ArgumentOutOfRangeException()
		};
		return Comparer switch
		{
			"<" => value < Value,
			">" => value > Value,
			_ => throw new ArgumentOutOfRangeException()
		};
	}

	public (PartRatingRange succes, PartRatingRange failed) Split(PartRatingRange partRatingRange)
	{
		if (string.IsNullOrEmpty(Property))
		{
			return (partRatingRange, new PartRatingRange(default, default, default, default));
		}

		ValueRange valueRange, success, failed;
		switch (Property)
		{
			case "x":
				valueRange = partRatingRange.X;
				(success, failed) = Split(valueRange);
				return (partRatingRange with { X = success }, partRatingRange with { X = failed });
			case "m":
				valueRange = partRatingRange.M;
				(success, failed) = Split(valueRange);
				return (partRatingRange with { M = success }, partRatingRange with { M = failed });
			case "a":
				valueRange = partRatingRange.A;
				(success, failed) = Split(valueRange);
				return (partRatingRange with { A = success }, partRatingRange with { A = failed });
			case "s":
				valueRange = partRatingRange.S;
				(success, failed) = Split(valueRange);
				return (partRatingRange with { S = success }, partRatingRange with { S = failed });
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private (ValueRange success, ValueRange failed) Split(ValueRange valueRange)
	{
		ValueRange success, failed;
		switch (Comparer)
		{
			case "<":
				if (valueRange.End <= Value)
				{
					return (valueRange, default);
				}

				if (Value <= valueRange.Start)
				{
					return (default, valueRange);
				}

				success = new ValueRange(valueRange.Start, Value - valueRange.Start);
				failed = new ValueRange(Value, valueRange.End - Value);
				return (success, failed);
			case ">":
				if (Value < valueRange.Start)
				{
					return (valueRange, default);
				}

				if (valueRange.End <= Value)
				{
					return (default, valueRange);
				}

				success = new ValueRange(Value + 1, valueRange.End - Value - 1);
				failed = new ValueRange(valueRange.Start, Value+1-valueRange.Start);
				return (success, failed);
			default:
				throw new ArgumentOutOfRangeException(nameof(Comparer));
		}
	}
}