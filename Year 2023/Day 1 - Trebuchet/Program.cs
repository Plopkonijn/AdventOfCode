using Year2023.Trebuchet;

List<CalibrationLine> calibrationLines = File.ReadLines("input.txt")
                                             .Select(line => new CalibrationLine(line))
                                             .ToList();

int answerPartOne = calibrationLines.Sum(line => line.GetCalibrationValue());
Console.WriteLine(answerPartOne);

int answerPartTwo = calibrationLines.Sum(line => line.GetSpelledCalibrationValue());
Console.WriteLine(answerPartTwo);