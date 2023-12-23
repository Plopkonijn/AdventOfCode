using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode;

internal class Program
{
	private static void Main(string[] args)
	{
		if (!TrySelectProblem(out ProblemSelection? problemSelection))
			return;
		Console.WriteLine($"You've selected : {problemSelection}");
	}

	private static bool TrySelectProblem([NotNullWhen(true)] out ProblemSelection? problemSelection)
	{
		problemSelection = null;
		Console.Write("Year: ");
		if (!int.TryParse(Console.ReadLine(), out int year))
			return false;

		Console.Write("Day: ");
		if (!int.TryParse(Console.ReadLine(), out int day))
			return false;

		Console.Write("Part: ");
		if (!int.TryParse(Console.ReadLine(), out int part))
			return false;

		problemSelection = new ProblemSelection(year, day, part);
		return true;
	}
}