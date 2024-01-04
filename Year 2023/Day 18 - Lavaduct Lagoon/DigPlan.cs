using Common;

namespace Year2023.Day18;

internal record DigPlan(List<DigInstruction> DigInstructions)
{
	public static DigPlan Parse(IEnumerable<string> text)
	{
		var digInstructions = text.Select(DigInstruction.Parse)
		                          .ToList();
		return new DigPlan(digInstructions);
	}

	public List<Trench> DigTrenches()
	{
		var trenches = new List<Trench>();
		var position = new Position(0, 0);
		foreach (var digInstruction in DigInstructions)
		{
			var trench = digInstruction.DigTrenches(position);
			position = trench.End;
			trenches.Add(trench);
		}

		return trenches;
	}
}