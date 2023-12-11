var text = """
           Time:      7  15   30
           Distance:  9  40  200
           """;
// text = File.ReadAllText("input.txt");


var records = Parser.ParseRecords(text);
Console.WriteLine();