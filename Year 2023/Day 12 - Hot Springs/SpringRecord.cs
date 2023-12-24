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

	public int CountPossibleArrangements()
	{
		var generatedRecords = new List<string> { DamagedRecord };
		var indices = DamagedRecord.Select((c, i) => (c, i)).Where(t => t.c is '?').Select(t => t.i).ToArray();
		foreach(int i in indices)
		{
			int count = generatedRecords.Count;
			for (int j = 0; j < count; j++)
			{
				var record = generatedRecords[j];
				if (record[i] is '?')
				{
					var chars = record.ToCharArray();
					chars[i] = '#';
					generatedRecords[j] = new string(chars);
					chars[i] = '.';
					generatedRecords.Add(new string(chars));
				}
			}
		}

		var pattern = string.Join("[.]+",SpringGroups.Select(i => $"[#]{{{i}}}"));
		var regex = new Regex($"^[^#]*{pattern}[^#]*$");
		var matches =  generatedRecords.Select(cc => new string(cc))
		                .Where(s => regex.IsMatch(s))
		                .ToArray();
		return matches.Length;
	}
}