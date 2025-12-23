using System.Collections;

namespace AdvenOfCode.Solvers.Year2015.Day06;

internal sealed class LightGrid
{
    private readonly BitArray _lights = new(1000 * 1000);

    internal long LitLightCount()
    {
        return _lights.OfType<bool>().Count(b => b);
    }

    internal void Toggle(IntLocation start, IntLocation end)
    {
        PerformInstruction(start, end, b => !b);
    }

    internal void TurnOff(IntLocation start, IntLocation end)
    {
        PerformInstruction(start, end, b => false);
    }

    internal void TurnOn(IntLocation start, IntLocation end)
    {
        PerformInstruction(start, end, b => true);
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
}