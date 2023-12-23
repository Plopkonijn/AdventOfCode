using System.Text.RegularExpressions;

namespace Year2023.Day2;

internal class CubeSet
{
	public CubeSet(string arg)
	{
		CubeGroups = Regex.Split(arg, ",")
		                  .Select(group => new CubeGroup(group))
		                  .ToList();
	}

	public CubeSet()
	{
	}

	public List<CubeGroup> CubeGroups { get; } = new();

	public bool ContainsSubSet(CubeSet set)
	{
		return CubeGroups.All(setGroup => set.CubeGroups.Any(bagGroup => bagGroup.Color == setGroup.Color && bagGroup.Size >= setGroup.Size));
	}

	public int GetSizeForColor(CubeColor cubeColor)
	{
		return CubeGroups
		       .Where(cubeGroup => cubeGroup.Color == cubeColor)
		       .Select(cubeGroup => cubeGroup.Size)
		       .SingleOrDefault(0);
	}
}