using Application;

namespace Year2023.Day1;

public sealed class TrebuchetSolver : ISolver
{
	private readonly List<CalibrationLine> _calibrationLines;

	public TrebuchetSolver(string[] args)
	{
		_calibrationLines = args.Select(arg => new CalibrationLine(arg))
		                        .ToList();
	}

	public long PartOne()
	{
		return _calibrationLines.Sum(line => line.GetCalibrationValue());
	}

	public long PartTwo()
	{
		return _calibrationLines.Sum(line => line.GetSpelledCalibrationValue());
	}
}