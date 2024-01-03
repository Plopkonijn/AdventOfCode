namespace Year2023.Day25;

internal class Graph
{
	private readonly Dictionary<string, List<Link>> _links;

	public Graph()
	{
		_links = new Dictionary<string, List<Link>>();
	}

	public Graph(Graph graph)
	{
		_links = graph._links.ToDictionary(pair => pair.Key, pair => pair.Value.ToList());
	}

	public int Size => _links.Count;
	public IReadOnlyCollection<string> Nodes => _links.Keys;

	public IReadOnlyCollection<Link> GetLinks(string node)
	{
		return _links[node]
			.AsReadOnly();
	}

	public bool AddNode(string node)
	{
		return _links.TryAdd(node, new List<Link>());
	}

	public bool AddLink(Link link)
	{
		if (!_links.TryGetValue(link.Source, out List<Link>? sourceLinks)
		 || sourceLinks.Contains(link)
		 || !_links.TryGetValue(link.Target, out List<Link>? targetLinks)
		 || targetLinks.Contains(link))
			return false;

		sourceLinks.Add(link);
		targetLinks.Add(link);
		return true;
	}

	public void JoinNodes(string sNode, string tNode)
	{
		string joinedNode = $"{sNode};{tNode}";
		List<Link> joinedLinks = GetJoinedLinks(sNode, tNode, joinedNode);
		RemoveNode(sNode);
		RemoveNode(tNode);

		AddNode(joinedNode);
		joinedLinks.ForEach(link => AddLink(link));
	}

	private void RemoveNode(string node)
	{
		foreach (Link link in _links[node])
		{
			string opposite = link.Opposite(node);
			_links[opposite]
				.Remove(link);
		}

		_links.Remove(node);
	}

	private List<Link> GetJoinedLinks(string sNode, string tNode, string joinedNode)
	{
		IEnumerable<(string node, Link link)> sTuples = GetLinks(sNode)
			.Select(link => (node: link.Opposite(sNode), link));
		IEnumerable<(string node, Link link)> tTuples = GetLinks(tNode)
			.Select(link => (node: link.Opposite(tNode), link));
		IEnumerable<(string node, Link link)> tuples = sTuples.Concat(tTuples);
		return tuples
		       .Where(t => t.node != sNode && t.node != tNode)
		       .GroupBy(t => t.node, t => t.link)
		       .Select(g => new Link
		       {
			       Source = joinedNode,
			       Target = g.Key,
			       Weight = g.Sum(link => link.Weight)
		       })
		       .ToList();
	}
}