string text = """
              LLR

              AAA = (BBB, BBB)
              BBB = (AAA, ZZZ)
              ZZZ = (ZZZ, ZZZ)
              """;
//text = File.ReadAllText("input.txt");

List<Instruction> instructions = Parser.ParseInstructions(text).ToList();

Console.WriteLine();