namespace AdvenOfCode.Solvers.Year2015.Day06;

internal sealed class BrightnessLightGrid : BinaryLightGridBase
{
    private readonly uint[] _brightness = new uint[1000 * 1000];
    internal long GetTotalBrightness()
    {
        return _brightness.Sum(b => b);
    }

    internal override void Toggle(IntLocation start, IntLocation end)
    {
        PerformInstruction(start, end, b => b + 2);
    }

    internal override void TurnOff(IntLocation start, IntLocation end)
    {
        PerformInstruction(start, end, b => b == 0 ? b : b - 1);
    }

    internal override void TurnOn(IntLocation start, IntLocation end)
    {
        PerformInstruction(start, end, b => b + 1);
    }

    internal void PerformInstruction(IntLocation start, IntLocation end, Func<uint, uint> instruction)
    {
        for (int x = start.X; x <= end.X; x++)
        {
            for (int y = start.Y; y <= end.Y; y++)
            {
                uint currentValue = _brightness[x + (1000 * y)];
                uint newValue = instruction(currentValue);
                _brightness[x + (1000 * y)] = newValue;
            }
        }
    }
}
