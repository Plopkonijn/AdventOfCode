using System.Text.RegularExpressions;

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

var cubeGames = File.ReadLines("input.txt")
                                      .Select(ParseGame)
                                      .ToArray();
var sumOfIds = cubeGames
               .Where(game => IsGamePossible(game, bag))
               .Sum(game => game.Id);
var sumOfPowers = cubeGames
                  .Select(GetGamePower)
                  .Sum();
	
                
Console.WriteLine($"Part one: {sumOfIds}");
Console.WriteLine($"Part two: {sumOfPowers}");


CubeGame ParseGame(string line)
{
	var split = Regex.Split(line, ":");
	var id = int.Parse(Regex.Match(split[0], @"\d+").Value);
	var cubeSets = Regex.Split(split[1], ";")
	                    .Select(ParseSets);
	return new CubeGame
	{
		Id = id,
		CubeSets = cubeSets.ToList()
	};
}

CubeSet ParseSets(string line)
{
	var cubeGroups = Regex.Split(line, ",")
	                      .Select(ParseGroup);

	return new CubeSet
	{
		CubeGroups = cubeGroups.ToList()
	};
}

CubeGroup ParseGroup(string line)
{
	int size = int.Parse(Regex.Match(line, @"\d+").Value);
	var color = Regex.Match(line, @"\w+$").Value switch
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
	var minimumRed = GetMinimumForColor(cubeGame, CubeColor.Red);
	var minimumGreen = GetMinimumForColor(cubeGame,CubeColor.Green);
	var minimumBlue = GetMinimumForColor(cubeGame,CubeColor.Blue);
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