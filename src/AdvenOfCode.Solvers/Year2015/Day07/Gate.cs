namespace AdvenOfCode.Solvers.Year2015.Day07;

internal abstract record Gate(string Out);

internal sealed record UnaryGate(string In, string Out, Func<short, short> Operation) : Gate(Out);

internal sealed record BinaryGate(string Left, string Right, string Out, Func<short, short, short> Operation) : Gate(Out);