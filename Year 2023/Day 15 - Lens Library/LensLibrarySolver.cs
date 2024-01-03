using System.Text.RegularExpressions;
using Application;

namespace Year2023.Day15;

public class LensLibrarySolver : ISolver
{
	private readonly List<string> _initializationSequence;

	public LensLibrarySolver(string[] args)
	{
		_initializationSequence = args.SelectMany(s =>
			                              s.Split(','))
		                              .ToList();
	}

	public long PartOne()
	{
		return _initializationSequence.Sum(Hash);
	}

	public long PartTwo()
	{
		List<(string label, int focalLength)>[] boxes = Enumerable.Range(0, 256)
		                                                          .Select(_ => new List<(string label, int focalLength)>())
		                                                          .ToArray();
		PerformInitializationSteps(boxes);
		return CalculateFocusingPower(boxes);
	}

	private static long CalculateFocusingPower(List<(string label, int focalLength)>[] boxes)
	{
		return boxes.Select((box, boxNumber) => (box, boxNumber))
		            .Sum(boxTuple =>
			            boxTuple.box.Select((lens, slotNumber) => (lens, slotNumber))
			                    .Sum(lensTuple => (boxTuple.boxNumber + 1) * (lensTuple.slotNumber + 1) * lensTuple.lens.focalLength));
	}

	private void PerformInitializationSteps(List<(string label, int focalLength)>[] boxes)
	{
		foreach (string initializationStep in _initializationSequence)
		{
			Match match = Regex.Match(initializationStep, @"(?<label>\w+)(-|(=(?<focalLength>\d+)))");
			string label = match.Groups["label"].Value;
			long hash = Hash(label);
			List<(string label, int focalLength)> box = boxes[hash];
			int index = box
				.FindIndex(lens => lens.label == label);

			if (!int.TryParse(match.Groups["focalLength"].Value, out int focalLength))
			{
				if (index != -1)
					box.RemoveAt(index);
			}
			else if (index == -1)
			{
				box.Add((label, focalLength));
			}
			else
			{
				box[index] = (label, focalLength);
			}
		}
	}

	private long Hash(string initializationStep)
	{
		long hash = 0L;

		foreach (char c in initializationStep)
		{
			hash += c;
			hash *= 17;
			hash %= 256;
		}

		return hash;
	}
}