string text = """
              LLR

              AAA = (BBB, BBB)
              BBB = (AAA, ZZZ)
              ZZZ = (ZZZ, ZZZ)
              """;
text = File.ReadAllText("input.txt");

List<Instruction> instructions = Parser.ParseInstructions(text).ToList();
Dictionary<string, Node> nodeMap = Parser.ParseNodes(text);

int stepsToFinishPartOne = Solver.GetStepsToFinish(instructions, nodeMap, "AAA", s => s == "ZZZ");

Console.WriteLine(stepsToFinishPartOne);

List<Node> startNodes = nodeMap
                        .Values
                        .Where(node => node.Name.EndsWith('A'))
                        .ToList();

var stepsToFinishPartTwo = Solver.GetStepsToFinish(instructions, nodeMap, startNodes);
Console.WriteLine(stepsToFinishPartTwo);
Console.WriteLine();