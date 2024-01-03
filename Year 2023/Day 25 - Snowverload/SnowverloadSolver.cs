using System.Text.RegularExpressions;
using Application;

namespace Year2023.Day25;

public sealed class SnowverloadSolver : ISolver
{
	private readonly Graph _graph = new();

	public SnowverloadSolver(string[] args)
	{
		foreach (string line in args)
		{
			Match match = Regex.Match(line, @"(?<node>\w+):( (?<neighbour>\w+))+");
			string node = match.Groups["node"].Value;
			_graph.AddNode(node);
			foreach (Capture capture in match.Groups["neighbour"].Captures)
			{
				string neighbour = capture.Value;
				_graph.AddNode(neighbour);
				var link = new Link
				{
					Source = node,
					Target = neighbour,
					Weight = 1
				};
				_graph.AddLink(link);
			}
		}
	}

	public long PartOne()
	{
		List<Link> minimumCut = MinimumCut(_graph);
		HashSet<string> sGroup = GetSTGroups(minimumCut, out HashSet<string> tGroup);
		GrowGroup(sGroup, tGroup);
		GrowGroup(tGroup,sGroup);
		return sGroup.Count * tGroup.Count;
	}

	private static HashSet<string> GetSTGroups(List<Link> minimumCut, out HashSet<string> tGroup)
	{
		var sGroup = minimumCut[0]
		             .Source.Split(';')
		             .ToHashSet();
		tGroup = minimumCut[0]
		         .Target.Split(';')
		         .ToHashSet();
		foreach (var link in minimumCut.Skip(1))
		{
			var sNodes = link.Source.Split(';');
			var tNodes = link.Target.Split(';');
			if (sGroup.SetEquals(sNodes))
			{
				tGroup.UnionWith(tNodes);
			}
			else if (sGroup.SetEquals(tNodes))
			{
				tGroup.UnionWith(sNodes);
			}
			else if (tGroup.SetEquals(tNodes))
			{
				sGroup.UnionWith(sNodes);
			}
			else if (tGroup.SetEquals(sNodes))
			{
				sGroup.UnionWith(tNodes);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		return sGroup;
	}

	private void GrowGroup(HashSet<string> sGroup, HashSet<string> tGroup)
	{
		var queue = new Queue<string>(sGroup);
		while (queue.TryDequeue(out var node))
		{
			foreach (Link link in _graph.GetLinks(node))
			{
				var opposite = link.Opposite(node);
				if(sGroup.Contains(opposite) || tGroup.Contains(opposite))
					continue;
				sGroup.Add(opposite);
				queue.Enqueue(opposite);
			}
		}
	}

	public long PartTwo()
	{
		throw new NotImplementedException();
	}

	private static List<Link> MinimumCut(Graph graph)
	{
		var residualGraph = new Graph(graph);
		var minimumCut = new List<Link>();
		int minimumCutValue = int.MaxValue;

		while (residualGraph.Size > 1)
		{
			List<Link> cut = MinimumCutPhase(residualGraph);
			int cutValue = cut.Sum(link => link.Weight);
			if (cutValue < minimumCutValue)
			{
				minimumCut = cut;
				minimumCutValue = cutValue;
			}
		}

		return minimumCut;
	}

	private static List<Link> MinimumCutPhase(Graph graph)
	{
		string? sNode = null;
		string tNode  = graph.Nodes.First();
		var visited = new HashSet<string> { tNode };
		while (visited.Count < graph.Size)
		{
			sNode = tNode;
			tNode = GetMostConnectedToVisitedNode(graph, visited);
			visited.Add(tNode);
		}
		
		if (sNode is null || tNode is null)
		{
			throw new InvalidOperationException();
		}

		var cut = graph.GetLinks(tNode)
		               .ToList();
		graph.JoinNodes(sNode, tNode);
		return cut;
	}

	private static string GetMostConnectedToVisitedNode(Graph graph, HashSet<string> visited)
	{
		string? nextNode = graph.Nodes
		                        .Except(visited)
		                        .MaxBy(node => GetConnectednessToVisited(graph,node, visited));
		return nextNode ?? throw new InvalidOperationException();
	}

	private static int GetConnectednessToVisited(Graph graph, string node, HashSet<string> visited)
	{
		return graph.GetLinks(node)
		             .Where(link => visited.Contains(link.Opposite(node)))
		             .Sum(link => link.Weight);
	}
}