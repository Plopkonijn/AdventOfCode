﻿string[] text = """
                ..F7.
                .FJ|.
                SJ.L7
                |F--J
                LJ...
                """.Split('\n');

text = """
       .F----7F7F7F7F-7....
       .|F--7||||||||FJ....
       .||.FJ||||||||L7....
       FJL7L7LJLJ||LJ.L-7..
       L--J.L7...LJS7F-7L7.
       ....F-J..F7FJ|L7L7L7
       ....L7.F7||L7|.L7L7|
       .....|FJLJ|FJ|F7|.LJ
       ....FJL-7.||.||||...
       ....L---J.LJ.LJLJ...
       """.Split('\n');

text = """
       ...........
       .S-------7.
       .|F-----7|.
       .||.....||.
       .||.....||.
       .|L-7.F-J|.
       .|..|.|..|.
       .L--J.L--J.
       ...........
       """.Split('\n');

text = """
       ..........
       .S------7.
       .|F----7|.
       .||....||.
       .||....||.
       .|L-7F-J|.
       .|II||II|.
       .L--JL--J.
       ..........
       """.Split('\n');

text = """
       .F----7F7F7F7F-7....
       .|F--7||||||||FJ....
       .||.FJ||||||||L7....
       FJL7L7LJLJ||LJ.L-7..
       L--J.L7...LJS7F-7L7.
       ....F-J..F7FJ|L7L7L7
       ....L7.F7||L7|.L7L7|
       .....|FJLJ|FJ|F7|.LJ
       ....FJL-7.||.||||...
       ....L---J.LJ.LJLJ...
       """.Split('\n');

text = """
       FF7FSF7F7F7F7F7F---7
       L|LJ||||||||||||F--J
       FL-7LJLJ||||||LJL-77
       F--JF--7||LJLJ7F7FJ-
       L---JF-JLJ.||-FJLJJ7
       |F|F-JF---7F7-L7L|7|
       |FFJF7L7F-JF7|JL---7
       7-L-JL7||F7|L7F-7F7|
       L.L7LFJ|||||FJL7||LJ
       L7JLJL-JLJLJL--JLJ.L
       """.Split('\n');

text = """
       .......
       ...F-7.
       ..FJ.|.
       .FJ.FJ.
       .|.FJ..
       .S-J...
       .......
       """.Split('\n');

text = File.ReadAllLines("input.txt");
var map = new Map(text);
var solver = new Solver(map);

long answerPartOne = solver.GertFurthestDistance();
Console.WriteLine(answerPartOne);

var numberOfEnclosedTiles = solver.GetNumberOfEnclosedTiles();

long answerPartTwo = numberOfEnclosedTiles.Count;
Console.WriteLine(answerPartTwo);

var outputText = string.Join('\n', text.Select((s, y) => new string(
	s.Select((c, x) =>
       {
              if (numberOfEnclosedTiles.Contains((x, y)))
                     return 'I';
              if(!solver.MainLoop.Contains((x,y)))
                     return 'O';
              return c;
       }).ToArray())));
Console.WriteLine(outputText);