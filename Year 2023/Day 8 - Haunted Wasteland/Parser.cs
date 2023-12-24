using System.Text.RegularExpressions;

internal static partial class Parser
{
	internal static IEnumerable<Instruction> ParseInstructions(string args)
	{
		return InstructionsRegex()
		       .Match(args)
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

	public static Dictionary<string, Node> ParseNodes(string[] text)
	{
		return text.Select(line => NodeRegex()
			           .Match(line))
		           .Select(match => new Node(
			           match.Groups["name"].Value,
			           match.Groups["left"].Value,
			           match.Groups["right"].Value))
		           .ToDictionary(node => node.Name, node => node);
	}

	[GeneratedRegex(@"(L|R)+")]
	private static partial Regex InstructionsRegex();

	[GeneratedRegex(@"(?<name>\w+) = \((?<left>\w+), (?<right>\w+)\)")]
	private static partial Regex NodeRegex();
}