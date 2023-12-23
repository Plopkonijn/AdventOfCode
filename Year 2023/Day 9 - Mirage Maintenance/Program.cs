using Year2023.MirageMaintenance;

string text = """
              0 3 6 9 12 15
              1 3 6 10 15 21
              10 13 16 21 30 45
              """;
text = File.ReadAllText("input.txt");

List<Sequence> parsedSequences = Sequence.ParseSequences(text).ToList();

List<long> extrapolatedLastValues = parsedSequences.Select(Solver.ExtrapolateLastValue)
                                                   .ToList();

long answerPartOne = extrapolatedLastValues.Sum();
Console.WriteLine(answerPartOne);

List<long> extrapolatedFirstValues = parsedSequences.Select(Solver.ExtrapolateFirstValue)
                                                    .ToList();

long answerPartTwo = extrapolatedFirstValues.Sum();
Console.WriteLine(answerPartTwo);