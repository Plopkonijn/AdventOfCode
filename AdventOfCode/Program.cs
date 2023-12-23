using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Year2023.Day2;

namespace AdventOfCode;

class Program
{
	static void Main(string[] args)
	{
		if (!TrySelectProblem(out var problemSelection))
			return;
		Console.WriteLine($"You've selected : {problemSelection}");
	}

	private static bool TrySelectProblem([NotNullWhen(true)] out ProblemSelection? problemSelection)
	{
		problemSelection = null;
		Console.Write("Year: ");
		if (!int.TryParse(Console.ReadLine(), out var year))
		{
			return false;
		}

		Console.Write("Day: ");
		if (!int.TryParse(Console.ReadLine(), out var day))
		{
			return false;
		}

		Console.Write("Part: ");
		if (!int.TryParse(Console.ReadLine(), out var part))
		{
			return false;
		}

		problemSelection = new ProblemSelection(year, day, part);
		return true;
	}
}