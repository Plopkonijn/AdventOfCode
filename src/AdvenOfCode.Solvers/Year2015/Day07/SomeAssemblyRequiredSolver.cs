using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day07;

public sealed class SomeAssemblyRequiredSolver(string[] input) : Solver(input)
{
    public override long SolvePart1()
    {
        Circuit circuit = ParseCircuit();
        return circuit.GetWireValue("a", []);
    }

    private Circuit ParseCircuit()
    {
        Circuit circuit = new();
        foreach ((int index, string line) in Input.Index())
        {
            if (line.Split(" -> ") is not [string leftSplit, string targetWire])
            {
                throw new InvalidOperationException();
            }
            Gate gate;
            if (Regex.Match(leftSplit, @"^(\w+) (AND|OR|LSHIFT|RSHIFT) (\w+)$") is { Success: true, Groups: { } binaryGroups })
            {
                string left = binaryGroups[1].Value;
                string right = binaryGroups[3].Value;
                Func<short, short, short> operation = binaryGroups[2].Value switch
                {
                    "AND" => (a, b) => (short)(a & b),
                    "OR" => (a, b) => (short)(a | b),
                    "LSHIFT" => (a, b) => (short)(a << b),
                    "RSHIFT" => (a, b) => (short)(a >> b),
                    _ => throw new InvalidOperationException()
                };
                gate = new BinaryGate(left, right, targetWire, operation);
            }
            else if (Regex.Match(leftSplit, @"^NOT (\w+)$") is { Success: true, Groups: { } notGroups })
            {
                static short operation(short s)
                {
                    return (short)~s;
                }

                gate = new UnaryGate(notGroups[1].Value, targetWire, operation);
            }
            else
            {
                static short operation(short s)
                {
                    return s;
                }
                gate = new UnaryGate(leftSplit, targetWire, operation);
            }
            circuit.AddGate(gate);
        }
        return circuit;
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}
