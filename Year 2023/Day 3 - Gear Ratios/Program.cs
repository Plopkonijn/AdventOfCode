// string example = """
//                  467..114..
//                  ...*......
//                  ..35..633.
//                  ......#...
//                  617*......
//                  .....+.58.
//                  ..592.....
//                  ......755.
//                  ...$.*....
//                  .664.598..
//                  """;
// string[] lines = example.Split('\n');

using Year2023.GearRatios;

string[] lines = File.ReadAllLines("input.txt");

var engineSchematic = new EngineSchematic(lines);

int[] partNumbers = engineSchematic.GetPartNumbers().ToArray();
int sumOfPartNumbers = partNumbers.Sum();
Console.WriteLine($"Part One: {sumOfPartNumbers}");

int[] gearRatios = engineSchematic.GetGearRatios().ToArray();
int sumOfGearRatios = gearRatios.Sum();
Console.WriteLine($"Part Two: {sumOfGearRatios}");