using System.Globalization;

namespace AdvenOfCode.Solvers.Year2015.Day07;

internal sealed class Circuit
{
    private readonly Dictionary<string, Gate> _gates = [];

    internal void AddGate(Gate gate)
    {
        _gates.Add(gate.Out, gate);
    }

    internal short GetWireValue(string wire, Dictionary<string, short> cache)
    {
        if (cache.TryGetValue(wire, out short result))
        {
            return result;
        }
        if (wire.All(char.IsDigit))
        {
            result = short.Parse(wire, CultureInfo.InvariantCulture);
            cache.Add(wire, result);
            return result;
        }
        if (!_gates.TryGetValue(wire, out Gate? gate))
        {
            throw new InvalidOperationException();
        }

        switch (gate)
        {
            case UnaryGate unaryGate:
                short inValue = GetWireValue(unaryGate.In, cache);
                result = unaryGate.Operation(inValue);
                break;
            case BinaryGate binaryGate:
                short leftValue = GetWireValue(binaryGate.Left, cache);
                short rightValue = GetWireValue(binaryGate.Right, cache);
                result = binaryGate.Operation(leftValue, rightValue);
                break;
            default: throw new InvalidOperationException();
        }
        cache.Add(wire, result);
        return result;
    }
}
