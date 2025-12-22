using System.Collections.Specialized;

namespace AdvenOfCode.Solvers.Year2025.Day10;

internal sealed class Button
{
    private BitVector32 _wiring;

    public Button(BitVector32 wiring)
    {
        _wiring = wiring;
    }

    public BitVector32 Press(BitVector32 state)
    {
        return new(state.Data ^ _wiring.Data);
    }

    public void Press(Joltage joltage)
    {
        int i = 0;
        int wiring = _wiring.Data;
        while (wiring > 0)
        {
            if ((wiring & 1) == 1)
            {
                joltage.Values[i]--;
            }
            i++;
            wiring >>= 1;
        }
    }

    public override string ToString()
    {
        return string.Join(',',
        Enumerable.Range(0, 32)
            .Where(i => _wiring[1 << i]));
    }
}
