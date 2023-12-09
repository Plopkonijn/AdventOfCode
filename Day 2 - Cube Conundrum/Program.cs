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

var sum = File.ReadLines("input.txt")
                .Select(ParseGame)
                .Where(game => IsGamePossible(game, bag))
                .Sum(game => game.Id);
                
Console.WriteLine(sum);

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