using System.Text.RegularExpressions;
using Year2023.CubeConundrum;

var bag = new CubeSet
{
	CubeGroups =
	{
		new CubeGroup
		{
			Color = CubeColor.Red,
			Size = 12
		},
		new CubeGroup
		{
			Color = CubeColor.Green,
			Size = 13
		},
		new CubeGroup
		{
			Color = CubeColor.Blue,
			Size = 14
		}
	}
};

CubeGame[] cubeGames = File.ReadLines("input.txt")
                           .Select(ParseGame)
                           .ToArray();
int sumOfIds = cubeGames
               .Where(game => IsGamePossible(game, bag))
               .Sum(game => game.Id);
int sumOfPowers = cubeGames
                  .Select(GetGamePower)
                  .Sum();

Console.WriteLine($"Part one: {sumOfIds}");
Console.WriteLine($"Part two: {sumOfPowers}");

CubeGame ParseGame(string line)
{
	string[] split = Regex.Split(line, ":");
	int id = int.Parse(Regex.Match(split[0], @"\d+").Value);
	IEnumerable<CubeSet> cubeSets = Regex.Split(split[1], ";")
	                                     .Select(ParseSets);
	return new CubeGame
	{
		Id = id,
		CubeSets = cubeSets.ToList()
	};
}

CubeSet ParseSets(string line)
{
	IEnumerable<CubeGroup> cubeGroups = Regex.Split(line, ",")
	                                         .Select(ParseGroup);

	return new CubeSet
	{
		CubeGroups = cubeGroups.ToList()
	};
}

CubeGroup ParseGroup(string line)
{
	int size = int.Parse(Regex.Match(line, @"\d+").Value);
	CubeColor color = Regex.Match(line, @"\w+$").Value switch
	{
		"red" => CubeColor.Red,
		"green" => CubeColor.Green,
		"blue" => CubeColor.Blue,
		_ => throw new InvalidOperationException()
	};

	return new CubeGroup
	{
		Size = size,
		Color = color
	};
}

bool IsGamePossible(CubeGame game, CubeSet bag)
{
	return game.CubeSets.All(set => BagContainsSubSet(bag, set));
}

bool BagContainsSubSet(CubeSet bag, CubeSet subset)
{
	return subset.CubeGroups.All(setGroup => bag.CubeGroups.Any(bagGroup => bagGroup.Color == setGroup.Color && bagGroup.Size >= setGroup.Size));
}

int GetGamePower(CubeGame cubeGame)
{
	int minimumRed = GetMinimumForColor(cubeGame, CubeColor.Red);
	int minimumGreen = GetMinimumForColor(cubeGame, CubeColor.Green);
	int minimumBlue = GetMinimumForColor(cubeGame, CubeColor.Blue);
	return minimumRed * minimumGreen * minimumBlue;
}

int GetMinimumForColor(CubeGame cubeGame, CubeColor cubeColor)
{
	return cubeGame.CubeSets.Max(set => GetSizeForColor(set, cubeColor));
}

int GetSizeForColor(CubeSet cubeSet, CubeColor cubeColor)
{
	return cubeSet.CubeGroups
	              .Where(cubeGroup => cubeGroup.Color == cubeColor)
	              .Select(cubeGroup => cubeGroup.Size)
	              .SingleOrDefault(0);
}