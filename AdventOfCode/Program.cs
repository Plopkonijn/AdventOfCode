using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Application;

namespace AdventOfCode;

internal class Program
{
	private static void Main(string[] args)
	{
		if (!TryParseArguments(args, out var problemSelection))
		{
			if (!TrySelectProblem(args, out problemSelection))
			{
				return;
			}
		}

		Console.WriteLine($"You've selected : {problemSelection}");

		var answer = SolveProblem(problemSelection);
		Console.WriteLine(answer);
	}

	private static bool TryParseArguments(string[] arguments, [NotNullWhen(true)] out ProblemSelection? problemSelection)
	{
		problemSelection = null;
		try
		{
			int? year = default, day = default, part = default;
			string? fileName = default;
			for (var i = 0; i < arguments.Length; i += 2)
			{
				switch (arguments[i])
				{
					case "-y":
						year = int.Parse(arguments[i + 1]);
						break;
					case "-d":
						day = int.Parse(arguments[i + 1]);
						break;
					case "-p":
						part = int.Parse(arguments[i + 1]);
						break;
					case "-f":
						fileName = arguments[i + 1];
						break;
				}
			}

			if (year is not { } y || day is not { } d || part is not { } p || fileName is not { } f)
			{
				return false;
			}

			problemSelection = new ProblemSelection(y, d, p, f);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static long SolveProblem(ProblemSelection problemSelection)
	{
		var inputArgs = GetInputArguments(problemSelection);
		var solver = GetSolver(problemSelection, inputArgs);
		return problemSelection.Part switch
		{
			1 => solver.PartOne(),
			2 => solver.PartTwo(),
			_ => throw new InvalidOperationException()
		};
	}

	private static ISolver GetSolver(ProblemSelection problemSelection, string[] inputArgs)
	{
		var solverInterface = typeof(ISolver);
		var assembly = Assembly.Load($"Year{problemSelection.Year}.Day{problemSelection.Day}");
		var solverType = assembly.GetTypes()
		                         .Single(type => type.IsAssignableTo(solverInterface));
		return (ISolver)solverType.GetConstructors()
		                          .First()
		                          .Invoke([inputArgs]);
	}

	private static string[] GetInputArguments(ProblemSelection problemSelection)
	{
		var inputArgs = File.ReadAllLines($"Year{problemSelection.Year}.Day{problemSelection.Day}\\{problemSelection.FileName}");
		return inputArgs;
	}

	private static bool TrySelectProblem(string[] args, [NotNullWhen(true)] out ProblemSelection? problemSelection)
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

		Console.WriteLine("File: ");
		var directory = Path.Combine(Directory.GetCurrentDirectory(), $"Year{year}.Day{day}");
		var files = Directory.GetFiles(directory);
		for (var i = 0; i < files.Length; i++)
		{
			Console.WriteLine($"{i}\t:{files[i]}");
		}

		var selectedFile = Console.ReadLine();
		if (!files.Contains(selectedFile))
		{
			return false;
		}

		problemSelection = new ProblemSelection(year, day, part, selectedFile);
		return true;
	}
}