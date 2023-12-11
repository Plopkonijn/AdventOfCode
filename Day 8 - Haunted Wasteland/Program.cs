string text = """
              LLR

              AAA = (BBB, BBB)
              BBB = (AAA, ZZZ)
              ZZZ = (ZZZ, ZZZ)
              """;
text = File.ReadAllText("input.txt");

List<Instruction> instructions = Parser.ParseInstructions(text).ToList();
Dictionary<string, Node> nodes = Parser.ParseNodes(text);

var stepsToFinish = GetStepsToFinish(instructions, nodes);

int GetStepsToFinish(List<Instruction> list, Dictionary<string, Node> dictionary)
{
	var currentNode = dictionary["AAA"];
	int steps = 0;
	while (currentNode.Name != "ZZZ")
	{
		steps += list.Count;
		foreach (Instruction instruction in instructions)
		{
			currentNode = instruction switch
			{
				Instruction.Left => dictionary[currentNode.Left],
				Instruction.Right => dictionary[currentNode.Right],
				_ => throw new ArgumentOutOfRangeException(),
			};
		}
	}

	return steps;
}

Console.WriteLine(stepsToFinish);