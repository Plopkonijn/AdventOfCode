string fileName =
	"example.txt";
//"input.txt";

string[] text = File.ReadAllLines(fileName);

var galaxy = new Galaxy(text);

Galaxy expandedGalaxy = galaxy.Expand();