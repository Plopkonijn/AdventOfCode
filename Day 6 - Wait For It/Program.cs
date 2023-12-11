var text = """
           Time:      7  15   30
           Distance:  9  40  200
           """;
text = File.ReadAllText("input.txt");


var records = ParserOne.ParseRecords(text);



var results =  records.Select(record => record.GetNumberOfWaysToBeat())
           .ToList();

var multiple = results.Aggregate((x, y) => x * y);
Console.WriteLine(multiple);

var record = ParserTwo.ParseRecord(text);
var result = record.GetNumberOfWaysToBeat();

Console.WriteLine(result);
