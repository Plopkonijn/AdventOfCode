var sumOfCalibrationValues = File.ReadLines("input.txt")
                     .Select(GetCalibrationValue)
                     .Sum();

Console.WriteLine($"The sum of all of the calibration values is {sumOfCalibrationValues}");

int GetCalibrationValue(string line)
{
	var calibrationString = GetCalibrationString(line);
	return int.Parse(calibrationString);
}

string GetCalibrationString(string line)
{
	var firstDigit = line.First(char.IsNumber);
	var secondDigit = line.Last(char.IsNumber);
	return string.Concat(firstDigit, secondDigit);
}