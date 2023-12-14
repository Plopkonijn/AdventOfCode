var fileName =
	"example.txt";
	//"input.txt";

var text = File.ReadAllLines(fileName);

var galaxy = new Galaxy(text);