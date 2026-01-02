using System.Collections;

namespace AdvenOfCode.Solvers.Year2015.Day06;

internal sealed class BinaryLightGrid : BinaryLightGridBase
{
    private readonly BitArray _lights = new(1000 * 1000);
    internal long LitLightCount()
    {
        return _lights.OfType<bool>().Count(b => b);
    }

    internal void PerformInstruction(IntLocation start, IntLocation end, Func<bool, bool> instruction)
    {
        for (int x = start.X; x <= end.X; x++)
        {
            for (int y = start.Y; y <= end.Y; y++)
            {
                _lights[x + (1000 * y)] = instruction(_lights[x + (1000 * y)]);
            }
        }
    }

    internal override void Toggle(IntLocation start, IntLocation end)
    {
        PerformInstruction(start, end, b => !b);
    }

    internal override void TurnOff(IntLocation start, IntLocation end)
    {
        PerformInstruction(start, end, b => false);
    }

    internal override void TurnOn(IntLocation start, IntLocation end)
    {
        PerformInstruction(start, end, b => true);
    }
}