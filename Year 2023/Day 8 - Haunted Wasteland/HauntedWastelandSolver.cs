using Application;

public sealed class HauntedWastelandSolver : ISolver
{
	private readonly List<Instruction> _instructions;
	private readonly Dictionary<string, Node> _nodes;

	public HauntedWastelandSolver(string[] args)
	{
		_instructions = Parser.ParseInstructions(args[0])
		                      .ToList();
		_nodes = Parser.ParseNodes(args[2..]);
	}

	public long PartOne()
	{
		Node currentNode = _nodes["AAA"];
		int steps = 0;
		while (currentNode.Name != "ZZZ")
		{
			steps += _instructions.Count;
			currentNode = _instructions.Aggregate(currentNode, (current, instruction) => instruction switch
			{
				Instruction.Left => _nodes[current.Left],
				Instruction.Right => _nodes[current.Right],
				_ => throw new ArgumentOutOfRangeException()
			});
		}

		return steps;
	}

	public long PartTwo()
	{
		var cachedNodes = new Dictionary<Node, Node>();
		List<Node> startNodes = _nodes.Values
		                              .Where(n => n.Name.EndsWith('A'))
		                              .ToList();
		List<(List<Node> line, List<Node> cycle)> cycles = startNodes.Select(n => FindCycle(n, cachedNodes))
		                                                             .ToList();

		long combinedCycleLength = LeastCommonMultiple(cycles.Select(t => (long)t.cycle.Count)
		                                                     .ToArray());
		return combinedCycleLength * _instructions.Count;
	}

	public long LeastCommonMultiple(long[] values)
	{
		var divisors = new List<long>();
		long[] dividents = values.ToArray();
		long divisor = 2;
		while (dividents.Any(i => i != 1))
		{
			bool updated = false;
			for (int i = 0; i < dividents.Length; i++)
			{
				(long quotient, long remainder) = long.DivRem(dividents[i], divisor);
				if (remainder == 0)
				{
					dividents[i] = quotient;
					updated = true;
				}
			}

			if (!updated)
				divisor++;
			else
				divisors.Add(divisor);
		}

		return divisors.Aggregate((a, b) => a * b);
	}

	public (List<Node> line, List<Node> cycle) FindCycle(Node node, Dictionary<Node, Node> nodeCahce)
	{
		Node currentNode = node;
		int steps = 0;
		Dictionary<Node, int> nodesByStep = new();
		while (nodesByStep.TryAdd(currentNode, steps++))
		{
			if (!nodeCahce.TryGetValue(currentNode, out Node? nextNode))
			{
				nextNode = _instructions.Aggregate(currentNode, (current, instruction) => instruction switch
				{
					Instruction.Left => _nodes[current.Left],
					Instruction.Right => _nodes[current.Right],
					_ => throw new ArgumentOutOfRangeException()
				});
				nodeCahce.Add(currentNode, nextNode);
			}

			currentNode = nextNode;
		}

		List<Node> line = nodesByStep.OrderBy(kvp => kvp.Value)
		                             .Select(kvp => kvp.Key)
		                             .TakeWhile(n => n != currentNode)
		                             .ToList();
		List<Node> cycle = nodesByStep.OrderBy(kvp => kvp.Value)
		                              .Select(kvp => kvp.Key)
		                              .SkipWhile(n => n != currentNode)
		                              .ToList();
		return (line, cycle);
	}
}