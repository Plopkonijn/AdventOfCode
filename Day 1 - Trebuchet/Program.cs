using System.Text.RegularExpressions;

int sumOfCalibrationValues =
	File.ReadLines("input.txt")
	    .Select(GetCalibrationValue)
	    .Sum();

Console.WriteLine($"The sum of all of the calibration values is {sumOfCalibrationValues}");

int GetCalibrationValue(string line)
{
	string calibrationString = GetCalibrationString(line);
	return int.Parse(calibrationString);
}

string GetCalibrationString(string line)
{
	Match firstMatch = Regex.Match(line, @"(\d|one|two|three|four|five|six|seven|eight|nine)");
	Match lastMatch = Regex.Match(line, @"(\d|one|two|three|four|five|six|seven|eight|nine)", RegexOptions.RightToLeft);

	char firstDigit = ConvertDigit(firstMatch.Value);
	char lastDigit = ConvertDigit(lastMatch.Value);
	return string.Concat(firstDigit, lastDigit);
}

char ConvertDigit(string digit)
{
	return digit switch
	{
		"one" => '1',
		"two" => '2',
		"three" => '3',
		"four" => '4',
		"five" => '5',
		"six" => '6',
		"seven" => '7',
		"eight" => '8',
		"nine" => '9',
		_ => digit.Single()
	};
}