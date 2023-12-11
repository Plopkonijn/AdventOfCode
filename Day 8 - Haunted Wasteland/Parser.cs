using System.Text.RegularExpressions;

internal static class Parser
{
	internal static IEnumerable<Instruction> ParseInstructions(string text)
	{
		return Regex.Match(text, @"(L|R)+")
		            .Value
		            .Select(ParseInstruction);
	}

	private static Instruction ParseInstruction(char c)
	{
		return c switch
		{
			'L' => Instruction.Left,
			'R' => Instruction.Right,
			_ => throw new ArgumentOutOfRangeException()
		};
	}
}