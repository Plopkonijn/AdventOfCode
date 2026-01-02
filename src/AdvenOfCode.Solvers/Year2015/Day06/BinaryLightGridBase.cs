namespace AdvenOfCode.Solvers.Year2015.Day06;

internal abstract class BinaryLightGridBase
{
    internal abstract void Toggle(IntLocation start, IntLocation end);
    internal abstract void TurnOff(IntLocation start, IntLocation end);
    internal abstract void TurnOn(IntLocation start, IntLocation end);
}