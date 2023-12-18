namespace LavaductLagoon;

internal record DigPlan(List<DigInstruction> DigInstructions)
{
	public static DigPlan Parse(IEnumerable<string> text)
	{
		List<DigInstruction> digInstructions = text.Select(DigInstruction.Parse)
		                                           .ToList();
		return new DigPlan(digInstructions);
	}
}