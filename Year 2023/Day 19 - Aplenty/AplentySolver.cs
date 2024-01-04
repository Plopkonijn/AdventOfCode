using Application;
using Common;

namespace Year2023.Day19;

public class AplentySolver : ISolver
{
	private readonly List<PartRating> _partRatings;
	private readonly Dictionary<string, Workflow> _workflows;

	public AplentySolver(string[] args)
	{
		var splitArguments = args.Split(string.IsNullOrEmpty);
		_workflows = new Dictionary<string, Workflow>();
		foreach (var workflowArgument in splitArguments.First())
		{
			var workflow = Workflow.Parse(workflowArgument);
			_workflows.Add(workflow.Name, workflow);
		}

		_partRatings = new List<PartRating>();
		foreach (var partRatingArgument in splitArguments.Last())
		{
			var partRating = PartRating.Parse(partRatingArgument);
			if (partRating is null)
			{
				continue;
			}

			_partRatings.Add(partRating);
		}
	}

	public long PartOne()
	{
		var totalRating = 0L;
		foreach (var partRating in _partRatings)
		{
			var workflowName = "in";
			while (_workflows.TryGetValue(workflowName, out var workflow))
			{
				workflowName = workflow.Process(partRating);
			}

			if (workflowName == "A")
			{
				totalRating += partRating.Total;
			}
		}

		return totalRating;
	}

	public long PartTwo()
	{
		var totalCombinations = 0L;
		var valueRange = new ValueRange(1, 4000);
		var queue = new Queue<(PartRatingRange, string)>();
		queue.Enqueue((new PartRatingRange(valueRange, valueRange, valueRange, valueRange), "in"));
		while (queue.TryDequeue(out var currentTuple))
		{
			var (partRatingRange, workflowName) = currentTuple;
			if (!_workflows.TryGetValue(workflowName, out var workflow))
			{
				if (workflowName == "A")
				{
					totalCombinations += partRatingRange.Total;
				}

				continue;
			}

			foreach (var nextTuple in workflow.Process(partRatingRange))
			{
				queue.Enqueue(nextTuple);
			}
		}

		return totalCombinations;
	}
}