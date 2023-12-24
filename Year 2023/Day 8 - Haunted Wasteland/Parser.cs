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

	public static Dictionary<string, Node> ParseNodes(string text)
	{
		return Regex.Matches(text, @"(?<name>\w+) = \((?<left>\w+), (?<right>\w+)\)")
		            .Select(match => new Node(
			            match.Groups["name"].Value,
			            match.Groups["left"].Value,
			            match.Groups["right"].Value
		            ))
		            .ToDictionary(node => node.Name, node => node);
	}
}