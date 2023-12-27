using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Application;

namespace AdventOfCode;

internal class Program
{
	private static void Main(string[] args)
	{
		if (!TrySelectProblem(out ProblemSelection? problemSelection))
			return;
		Console.WriteLine($"You've selected : {problemSelection}");

		long answer = SolveProblem(problemSelection);
		Console.WriteLine(answer);
	}

	private static long SolveProblem(ProblemSelection problemSelection)
	{
		string[] inputArgs = GetInputArguments(problemSelection);
		ISolver solver = GetSolver(problemSelection, inputArgs);
		return problemSelection.Part switch
		{
			1 => solver.PartOne(),
			2 => solver.PartTwo(),
			_ => throw new InvalidOperationException()
		};
	}

	private static ISolver GetSolver(ProblemSelection problemSelection, string[] inputArgs)
	{
		Type solverInterface = typeof(ISolver);
		Assembly assembly = Assembly.Load($"Year{problemSelection.Year}.Day{problemSelection.Day}");
		Type solverType = assembly.GetTypes()
		                          .Single(type => type.IsAssignableTo(solverInterface));
		return (ISolver)solverType.GetConstructors()
		                          .First()
		                          .Invoke(new[] { inputArgs });
	}

	private static string[] GetInputArguments(ProblemSelection problemSelection)
	{
		string[] inputArgs = File.ReadAllLines($"Year{problemSelection.Year}.Day{problemSelection.Day}\\input.txt");
		return inputArgs;
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