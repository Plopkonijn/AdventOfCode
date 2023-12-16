using System.Text.RegularExpressions;

public record SpringRecord(string DamagedRecord, int[] SpringGroups)
{
	public static SpringRecord Parse(string text)
	{
		string damagedRecord = Regex.Match(text, "[.#?]+").Value;
		int[] springGroups = Regex.Matches(text, @"\d+")
		                          .Select(match => int.Parse(match.Value))
		                          .ToArray();
		return new SpringRecord(damagedRecord, springGroups);
	}
}