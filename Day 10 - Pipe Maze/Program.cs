string[] text = """
                ..F7.
                .FJ|.
                SJ.L7
                |F--J
                LJ...
                """.Split('\n');
text = File.ReadAllLines("input.txt");
var map = new Map(text);
var solver = new Solver(map);
long answerPartOne = solver.GertFurthestDistance();
Console.WriteLine(answerPartOne);