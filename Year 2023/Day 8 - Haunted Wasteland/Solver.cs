internal static class Solver
{
	public static int GetStepsToFinish(List<Instruction> instructions, Dictionary<string, Node> nodeMap, string startNodeName,
		Predicate<string> endCondition)
	{
		Node currentNode = nodeMap[startNodeName];
		int steps = 0;
		while (!endCondition(currentNode.Name))
		{
			steps += instructions.Count;
			foreach (Instruction instruction in instructions)
				currentNode = instruction switch
				{
					Instruction.Left => nodeMap[currentNode.Left],
					Instruction.Right => nodeMap[currentNode.Right],
					_ => throw new ArgumentOutOfRangeException()
				};
		}

		return steps;
	}

	public static long GetStepsToFinish(List<Instruction> instructions, Dictionary<string, Node> nodeMap, IEnumerable<Node> startNodes)
	{
		var cachedNodes = new Dictionary<Node, Node>();
		var sets = startNodes.Select(_ => new HashSet<Node>()).ToList();
		List<Node> nodes = startNodes.ToList();
		long steps = 0;
		while (!nodes.All(n => n.Name.EndsWith('Z')))
		{
			steps += instructions.Count;
			for (int i = 0; i < nodes.Count; i++)
			{
				Node startPosition = nodes[i];
				sets[i].Add(startPosition);
				if (cachedNodes.TryGetValue(startPosition, out var endPosition))
				{
					var numbers = sets.Select(set => set.Count(n => n.Name.EndsWith('Z'))).ToList();
					nodes[i] = endPosition;
					continue;
				}

				endPosition = startPosition;
				foreach (Instruction instruction in instructions)
				{
					endPosition = instruction switch
					{
						Instruction.Left => nodeMap[startPosition.Left],
						Instruction.Right => nodeMap[startPosition.Right],
						_ => throw new ArgumentOutOfRangeException()
					};
				}

				cachedNodes.TryAdd(startPosition, endPosition);
				nodes[i] = endPosition;
			}
		}

		return steps;
	}
}