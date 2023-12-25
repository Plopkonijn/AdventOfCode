using System.Text.RegularExpressions;

namespace Year2023.Day2;

internal partial class CubeSet
{
	public CubeSet(string arg)
	{
		CubeGroups = SetRegex()
		             .Split(arg)
		             .Select(group => new CubeGroup(group))
		             .ToList();
	}

	public CubeSet()
	{
		CubeGroups = new List<CubeGroup>();
	}

	public List<CubeGroup> CubeGroups { get; }

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

	[GeneratedRegex(",")]
	private static partial Regex SetRegex();
}