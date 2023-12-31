using System.Text.RegularExpressions;

namespace Year2023.Day1;

internal partial record CalibrationLine(string Value)
{
	private const string DIGIT_PATTERN = @"(\d|one|two|three|four|five|six|seven|eight|nine)";

	public int GetCalibrationValue()
	{
		var firstDigit = int.Parse(Value.First(char.IsNumber)
		                                .ToString());
		var lastDigit = int.Parse(Value.Last(char.IsNumber)
		                               .ToString());
		return CombineDigits(firstDigit, lastDigit);
	}

	public int GetSpelledCalibrationValue()
	{
		var firstDigit = ParseDigit(MatchFirstDigit()
		                            .Match(Value)
		                            .Value);
		var lastDigit = ParseDigit(MatchLastDigit()
		                           .Match(Value)
		                           .Value);
		return CombineDigits(firstDigit, lastDigit);
	}

	private static int CombineDigits(int firstDigit, int lastDigit)
	{
		return 10 * firstDigit + lastDigit;
	}

	private static int ParseDigit(string digit)
	{
		return digit switch
		{
			"one" => 1,
			"two" => 2,
			"three" => 3,
			"four" => 4,
			"five" => 5,
			"six" => 6,
			"seven" => 7,
			"eight" => 8,
			"nine" => 9,
			_ => int.Parse(digit)
		};
	}

	[GeneratedRegex(DIGIT_PATTERN)]
	private static partial Regex MatchFirstDigit();

	[GeneratedRegex(DIGIT_PATTERN, RegexOptions.RightToLeft)]
	private static partial Regex MatchLastDigit();
}